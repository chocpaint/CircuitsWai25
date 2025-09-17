using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Circuits
{
    /// <summary>
    /// The main GUI for the COMPX102 digital circuits editor.
    /// This has a toolbar, containing buttons called buttonAnd, buttonOr, etc.
    /// The contents of the circuit are drawn directly onto the form.
    /// 
    /// </summary>
    public partial class Form1 : Form
    {

        //====================================================================================================================================================================================
        //                  Lists
        //====================================================================================================================================================================================
        /// <summary>
        /// The set of gates in the circuit
        /// </summary>
        protected List<Elements> listElements = new List<Elements>();
        /// <summary>
        /// The gates to remove from gateslist for a compound gate
        /// </summary>
        protected List<Elements> removeList = new List<Elements>();
        /// <summary>
        /// The set of connector wires in the circuit
        /// </summary>
        protected List<Wire> wiresList = new List<Wire>();
        /// <summary>
        /// A list of selected gates
        /// </summary>
        protected List<Elements> currentGate = new List<Elements>();

        //====================================================================================================================================================================================
        //                  Variables
        //====================================================================================================================================================================================

        // The (x,y) mouse position of the last MouseDown event.
        protected int startX, startY;
        // If this is non-null, we are inserting a wire by
        // dragging the mouse from startPin to some output Pin.
        protected Pin startPin = null;
        // The (x,y) position of the current gate, just before we started dragging it.
        protected int currentX, currentY;
        // The currently selected gate, or null if no gate is selected.
        protected Elements current = null;
        // The new gate that is about to be inserted into the circuit
        protected Elements newElement = null;
        // a temporary variable used to hold compund gates on initiation
        protected Compound newCompound = null;



//====================================================================================================================================================================================
//                  METHODS
//====================================================================================================================================================================================
        // Finds the pin that is close to (x,y), or returns
        // null if there are no pins close to the position.
        // <returns>The pin that has been selected</returns>
        public Pin findPin(int x, int y)
        {
            foreach (Elements g in listElements)
            {
                foreach (Pin p in g.Pins)
                {
                    if (p.isMouseOn(x, y))
                        return p;
                }
            }
            return null;
        }

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        // Redraws all the graphics for the current circuit.
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Draw all of the gates
            foreach (Elements g in listElements)
            {
                g.Draw(e.Graphics);
            }
            //Draw all of the wires
            foreach (Wire w in wiresList)
            {
                w.Draw(e.Graphics);
            }

            if (startPin != null)
            {
                e.Graphics.DrawLine(Pens.White,
                    startPin.X, startPin.Y,
                    currentX, currentY);
            }
            if (newElement != null)
            {
                // show the gate that we are dragging into the circuit
                newElement.MoveTo(currentX, currentY);
                newElement.Draw(e.Graphics);
            }
        }


//====================================================================================================================================================================================
//                  MOUSE EVENTS
//====================================================================================================================================================================================
        // Handles all events when the mouse is moving.
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (startPin != null)
            {
                Console.WriteLine("wire from " + startPin + " to " + e.X + "," + e.Y);
                currentX = e.X;
                currentY = e.Y;
                this.Invalidate();  // this will draw the line
            }
            else if (startX >= 0 && startY >= 0 && current != null)
            {
                Console.WriteLine("mouse move to " + e.X + "," + e.Y);
                current.MoveTo(currentX + (e.X - startX), currentY + (e.Y - startY));
                this.Invalidate();
            }
            else if (newElement != null)
            {
                currentX = e.X;
                currentY = e.Y;
                this.Invalidate();
            }
        }

        // Handles all events when the mouse button is released.
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (startPin != null)
            {
                // see if we can insert a wire
                Pin endPin = findPin(e.X, e.Y);
                if (endPin != null)
                {
                    Console.WriteLine("Trying to connect " + startPin + " to " + endPin);
                    Pin input, output;
                    if (startPin.IsOutput)
                    {
                        input = endPin;
                        output = startPin;
                    }
                    else
                    {
                        input = startPin;
                        output = endPin;
                    }
                    if (input.IsInput && output.IsOutput)
                    {
                        if (input.InputWire == null)
                        {
                            Wire newWire = new Wire(output, input);
                            input.InputWire = newWire;
                            wiresList.Add(newWire);
                        }
                        else
                        {
                            MessageBox.Show("That input is already used.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: you must connect an output pin to an input pin.");
                    }
                }
                startPin = null;
                this.Invalidate();
            }
            // We have finished moving/dragging
            startX = -1;
            startY = -1;
            currentX = 0;
            currentY = 0;
        }

        // Handles events while the mouse button is pressed down.
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (current == null)
            {
                // try to start adding a wire
                startPin = findPin(e.X, e.Y);
            }
            else if (current.IsMouseOn(e.X, e.Y))
            {
                // start dragging the current object around
                startX = e.X;
                startY = e.Y;
                currentX = current.Left;
                currentY = current.Top;
            }
        }

        // Handles all events when a mouse is clicked in the form.
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            // check if a gate is currently selected
            if (current != null)
            {
                //allow compound start button to select multiple gates
                if (newCompound == null)
                {
                    current.Selected = false;
                }
                //current = null;
                //this.Invalidate();
                // unselect the selected gate
                //current.Selected = false;
                current = null;
                this.Invalidate();
            }
            // if we are inserting a new gate
            if (newElement != null)
            {
                newElement.MoveTo(e.X, e.Y);
                listElements.Add(newElement);
                newElement = null;
                this.Invalidate();
            }
            else
            {
                // search for the first gate under the mouse position
                foreach (Elements g in listElements)
                {
                    if (g.IsMouseOn(e.X, e.Y))
                    {
                        g.Selected = true;
                        current = g;

                        if (g is Input inputGate)
                        {
                            inputGate.Toggle();
                        }

                        if (newCompound != null)
                        {
                            newCompound.AddGate(g);
                            removeList.Add(g);
                        }

                        this.Invalidate();
                        break;
                    }
                }
            }
        }


//====================================================================================================================================================================================
//                  BUTTONS
//====================================================================================================================================================================================
        // add input button onclick. adds input item to cursor for user to place.
        private void toolStripButtonINPUT_Click(object sender, EventArgs e)
        {
            newElement = new Input(0, 0);
        }

        // add output button onclick. adds output item to cursor for user to place.
        private void toolStripButtonOUTPUT_Click(object sender, EventArgs e)
        {
            newElement = new Output(0, 0);
        }


        // add AND gate button onclick. adds AND gate to cursor for user to place.
        private void toolStripButtonAnd_Click(object sender, EventArgs e)
        {
            newElement = new AndGate(0, 0);
        }


        // add OR gate button onclick. adds OR gate to cursor for user to place.
        private void toolStripButtonOr_Click(object sender, EventArgs e)
        {
            newElement = new OrGate(0, 0);
        }


        // add NOT gate button onclick. adds NOT gate to cursor for user to place.
        private void toolStripButtonNot_Click(object sender, EventArgs e)
        {
            newElement = new NotGate(0, 0);
        }


        // copy button onclick. _
        private void toolStripButtonCOPY_Click(object sender, EventArgs e)
        {
            foreach (Elements g in listElements)
            {
                if (g.Selected == true)
                {
                    newElement = g.Clone();
                }
            }
        }


        // evaluate (?) button onclick. _
        private void toolStripButtonEVALUATE_Click(object sender, EventArgs e)
        {
            foreach (Elements g in listElements)
            {
                if (g is Output)
                {
                    bool result = g.Evaluate();
                    Console.WriteLine("Output evaluated to: " + result);
                }
            }
            this.Invalidate(); // redraw form with updated on/off images
        }


        // start compound button onclick. _
        private void toolStripButtonSTARTC_Click(object sender, EventArgs e)
        {
            newCompound = new Compound(this.Width, this.Height);
        }


        // end compound button onclick. _
        private void toolStripButtonENDC_Click(object sender, EventArgs e)
        {

            current = null;
            //Track gates to remove from gateslist and currentlist
            foreach (Elements g in removeList)
            {
                if (listElements.Contains(g))
                {
                    listElements.Remove(g);
                }

                if (currentGate.Contains(g))
                {
                    currentGate.Remove(g);
                }
            }
            removeList.Clear();
            //deselect all gates when clicked
            foreach (Elements g in newCompound.Gates)
            {
                if (g.Selected)
                {
                    g.Selected = false;
                }
            }
            //make newgate the compound gate
            newElement = newCompound;
            newCompound = null;
        }

        /// exit button onclick. ends the program.
        private void toolStripButtonEXIT_Click(object sender, EventArgs e)
        {
            Application.Exit(); // kill app
        }


    }
}
// TREY WUZ'ERE
// key wordis was as Himothy has taken over. they call me Himothy for i am the HIM - regards Tama



//1. Is it a better idea to fully document the Gate class or the AndGate
//subclass? Can you inherit comments?

//it is better to comment the gate class as it can apply to many different instances of objects
//You cannot inherit comments

//Q2)   What is the advantage of making a method abstract in the superclass
//rather than just writing a virtual method with no code in the body of
//the method? Is there any disadvantage to an abstract method?


//abstract methods force a sub class to inherit that method from the superclass the 
//specific design of the superclass can be enforced as appossed to a virtual method
//which the sub class can choose to use fbLip side this can be a disadvantage aswell as it
//decreases the flexibility of the sub classes

//Q3) If a class has an abstract method in it, does the class have to be
//abstract?


//yes if the class has abstract methods it itself must also be abstract


//Q4) What would happen in your program if one of the gates added to your
//Compound Gate is another Compound Gate? Is your design robust    
//enough to cope with this situation?


