using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    /// <summary>
    /// This class implements an AND gate with two inputs
    /// and one output.
    /// </summary>
    public class AndGate
    {
        // left is the left-hand edge of the main part of the gate.
        // So the input pins are further left than left.
        protected int left;

        // top is the top of the whole gate
        protected int top;

        // set image
        protected static Image ResImg = Properties.Resources.AndGate;
        protected static Image ResImgSelect = Properties.Resources.AndGateSelected;

        // width and height of the main part of the gate
        protected static int WIDTH = ResImg.Width;
        protected static int HEIGHT = ResImg.Height;
        // length of the connector legs sticking out left and right
        protected const int GAP = 10;


        /// <summary>
        /// This is the list of all the pins of this gate.
        /// An AND gate always has two input pins (0 and 1)
        /// and one output pin (number 2).
        /// </summary>
        protected List<Pin> pins = new List<Pin>();
        //Has the gate been selected
        protected bool selected = false;

        /// <summary>
        /// Initialises the Gate.
        /// </summary>
        /// <param name="x">The x position of the gate</param>
        /// <param name="y">The y position of the gate</param>
        public AndGate(int x, int y)
        {
            //Add the two input pins to the gate
            pins.Add(new Pin(this, true, 20));
            pins.Add(new Pin(this, true, 20));
            //Add the output pin to the gate
            pins.Add(new Pin(this, false, 20));
            //move the gate and the pins to the position passed in
            MoveTo(x, y);
        }

        /// <summary>
        /// Gets and sets whether the fate is selected or not.
        /// </summary>
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        /// <summary>
        /// Gets the left hand edge of the gate.
        /// </summary>
        public int Left
        {
            get { return left; }
        }

        /// <summary>
        /// Gets the top edge of the gate.
        /// </summary>
        public int Top
        {
            get { return top; }
        }

        /// <summary>
        /// Gets the list of pins for the gate.
        /// </summary>
        public List<Pin> Pins
        {
            get { return pins; }
        }

        /// <summary>
        /// Checks if the gate has been clicked on.
        /// </summary>
        /// <param name="x">The x position of the mouse click</param>
        /// <param name="y">The y position of the mouse click</param>
        /// <returns>True if the mouse click position is inside the gate</returns>
        public bool IsMouseOn(int x, int y)
        {
            if (left <= x && x < left + WIDTH
                && top <= y && y < top + HEIGHT)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Draws the gate in the normal colour or in the selected colour.
        /// </summary>
        /// <param name="paper"></param>
        public void Draw(Graphics paper)
        {
            Image imgToDraw = selected // using ternary for swapping imgs based on clicked on status
                ? ResImgSelect  // selected alternate image
                : ResImg;       // normal image
            
            //Draw each of the pins
            foreach (Pin p in pins)
                p.Draw(paper);

            //Note: You can also use the images that have been imported into the project if you wish,
            //      using the code below.  You will need to space the pins out a bit more in the constructor.
            //      There are provided images for the other gates and selected versions of the gates as well.
            paper.DrawImage(imgToDraw, Left, Top, WIDTH, HEIGHT); // with resource img W/H to draw correct size, to correlate to mouse boundary box and pin positions correctly
        }

        /// <summary>
        /// Moves the gate to the position specified.
        /// </summary>
        /// <param name="x">The x position to move the gate to</param>
        /// <param name="y">The y position to move the gate to</param>
        public void MoveTo(int x, int y)
        {
            //Debugging message
            Console.WriteLine("pins = " + pins.Count);
            //Set the position of the gate to the values passed in
            left = x;
            top = y;

            // more accurate drawing points for pins
            pins[0].X = x - GAP; 
            pins[0].Y = y + HEIGHT / 2 - GAP;
            pins[1].X = x - GAP;
            pins[1].Y = y + HEIGHT / 2 + GAP;
            pins[2].X = x + WIDTH + GAP;
            pins[2].Y = y + HEIGHT / 2;
        }
    }
}
