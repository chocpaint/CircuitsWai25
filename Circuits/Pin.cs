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
        public Elements Owner { get; private set; } // the gate this pin belongs to
        private bool isInput; // is it an input pin
        public int X { get; set; } // coordinates
        public int Y { get; set; }


        // if this pin is an input, it may have one wire feeding into it
        public Wire InputWire { get; set; }


        // constructor
        public Pin(Elements owner, bool isInput, int offset)
        {
            this.Owner = owner;
            this.isInput = isInput;

            // default position until gate MoveTo sets them properly
            this.X = owner.Left + offset;
            this.Y = owner.Top + offset;
        }


        // is input pin bool
        public bool IsInput => isInput;

        // is output pin bool
        public bool IsOutput => !isInput;


        // True if (mouseX, mouseY) is within 3 pixels of end position of the pin.
        public bool isMouseOn(int mouseX, int mouseY)
        {
            int diffX = mouseX - X;
            int diffY = mouseY - Y;
            return diffX * diffX + diffY * diffY <= 5 * 5; // return true if valid position
        }


        // draws the pin using paper Graphics display
        public void Draw(Graphics paper)
        {
            // Simple example: draw a small circle for pin
            int radius = 4;
            Brush brush = isInput ? Brushes.Blue : Brushes.Green;
            paper.FillEllipse(brush, X - radius, Y - radius, radius * 2, radius * 2);
        }


        // gets the x and y position of the Pin and returns as strings
        public override string ToString()
        {
            return $"Pin({(IsInput ? "In" : "Out")}) at ({X},{Y})";
        }

    }
}