using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits 
{
    /// <summary>
    /// Each Pin represents an input or an output of a gate.
    /// Every Pin knows which gate it belongs to
    /// (and the Gate property returns this).
    /// 
    /// Input pins can be connected to at most one wire
    /// (see the InputWire property).
    /// 
    /// Output pins may have lots of wires pointing to them,
    /// but they don't know anything about this.
    /// </summary>
    public class Pin
    {
        // vars
        
        private Elements parent; // the gate this pin belongs to
        private bool isInput; // is it an input pin
        private int offsetX, offsetY; // position relative to the gate

        // If this pin is an input, it may have one wire feeding into it
        public Wire InputWire { get; set; }

        // Constructor
        public Pin(Elements parent, int offsetX, int offsetY, bool isInput)
        {
            this.parent = parent;
            this.offsetX = offsetX;
            this.offsetY = offsetY;
            this.isInput = isInput;
        }


        private Elements owner;  // The gate this pin belongs to

        public int X { get; set; }
        public int Y { get; set; }
        public bool IsInput { get; } // A read-only property that returns true for input pins and false for output pins.

        public bool Input { get; set; } // explicit pin type bools
        public bool Output { get; set; }


        // initialises the object to the values passed in.
        public Pin(Elements owner, bool isInput, int spacing)
        {
            this.owner = owner;
            this.IsInput = isInput;
            // position will be set later in MoveTo of the gate
            X = owner.Left;
            Y = owner.Top;
        }


        // draws the pin using paper Graphics display
        public void Draw(Graphics paper)
        {
            // Simple example: draw a small circle for pin
            int radius = 4;
            paper.FillEllipse(Brushes.Black, X - radius, Y - radius, radius * 2, radius * 2);
        }


        // gets the x and y position of the Pin and returns as strings
        public override string ToString()
        {
            return $"Pin({(IsInput ? "In" : "Out")}) at ({X},{Y})";
        }


        /*
        // For input pins, this gets or sets the wire that is coming into the pin.  (Input pins can only be connected to one wire)
        // For output pins, sets are ignored and get always returns null.
        public Wire InputWire
        {
            get
            {
                return connection;
            }
            set
            {
                if (IsInput)
                {
                    connection = value;
                }
            }
        }

        // get/set X,Y positions
        // For input pins, this is at the left position of the pin
        // For output pins, this is at the right position of the pin
        public int X { get; set; }
        public int Y { get; set; }

        // True if (mouseX, mouseY) is within 3 pixels of end position of the pin.
        public bool isMouseOn(int mouseX, int mouseY)
        {
            int diffX = mouseX - x;
            int diffY = mouseY - y;
            return diffX * diffX + diffY * diffY <= 5 * 5; // return true if valid position
        }

        // draws the pin using paper Graphics display
        public override void Draw(Graphics paper)
        {
            Brush brush = Brushes.CornflowerBlue;

            if (IsInput)
            {
                paper.FillRectangle(brush, x - 1, y - 1, length, 3);
            }
            else
            {
                paper.FillRectangle(brush, x - length + 1, y - 1, length, 3);
            }
        }
        */
        
    }
}