using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    /// <summary>
    /// NO NEED TO CHANGE ANYTHING HERE
    /// A wire connects between two pins.
    /// That is, it connects the output pin FromPin 
    /// to the input pin ToPin.
    /// </summary>
    public class Wire
    {
        // has the wire been selected
        protected bool selected = false;
        // the pins the wire is connected to
        protected Pin fromPin, toPin;

        // initialises the object to the pins it is connected to.
        public Wire(Pin from, Pin to)
        {
            fromPin = from;
            toPin = to;
        }

        // indicates whether this gate is the current one selected.
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        // the output pin that this wire is connected to.
        public Pin FromPin
        {
            get { return fromPin; }
        }

        // the input pin that this wire is connected to.
        public Pin ToPin
        {
            get { return toPin; }
        }

        // draws the wire.
        public void Draw(Graphics paper)
        {
            // if selected == true, use Color.Red, else use Color.White
            Pen wire = new Pen(selected ? Color.Red : Color.White, 3);
            // draw the wire
            paper.DrawLine(wire, fromPin.X, fromPin.Y, toPin.X, toPin.Y);
        }
    }
}
