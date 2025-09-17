using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    public abstract class Elements
    {

        // left is the left-hand edge of the main part of the gate.
        // So the input pins are further left than left.
        protected int left;

        // top is the top of the whole gate
        protected int top;

        /// <summary>
        /// This is the list of all the pins of this gate.
        /// An AND gate always has two input pins (0 and 1)
        /// and one output pin (number 2).
        /// </summary>
        protected List<Pin> pins = new List<Pin>();
        //Has the gate been selected
        protected bool selected = false;


        /// <summary>
        /// this will initialize a gate object
        /// </summary>
        /// <param name="x">represents the _x position of the gates</param>
        /// <param name="y">this represents the y position of the gates</param>
        public Elements(int x, int y)
        {
            
        }


        /// <summary>
        /// Gets the left hand edge of the gate
        /// </summary>
        public int Left
        {
            get { return left;  }
        }

        /// <summary>
        /// gets the top edge of the gates
        /// </summary>
        public int Top
        { 
            get { return top; }
        }

        /// <summary>
        /// gets the list of pins for the gates
        /// </summary>
        public List<Pin> Pins
        {
            get { return pins; }
        }

        public virtual bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }


        /// <summary>
        /// Checks if the gate has been clicked on.
        /// </summary>
        /// <param name="x">The x position of the mouse click</param>
        /// <param name="y">The y position of the mouse click</param>
        /// <returns>True if the mouse click position is inside the gate</returns>
        public virtual bool IsMouseOn(int x, int y)
        {
            if (left <= x && x < left + WIDTH
                && top <= y && y < top + HEIGHT)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Moves the gate to the position specified.
        /// </summary>
        /// <param name="x">The x position to move the gate to</param>
        /// <param name="y">The y position to move the gate to</param>
        public virtual void MoveTo(int x, int y)
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

        /// <summary>
        /// abstract method used for drawing other gates
        /// </summary>
        /// <param name="paper"></param>
        public abstract void Draw(Graphics paper);

        /// <summary>
        /// an abstract method used for evaluating circuit each gate will call on this method
        /// with slight variations to represent the functions of difrent gates
        /// </summary>
        /// <returns></returns>
        public abstract bool Evaluate();

        /// <summary>
        /// abstract method used to clone seperate gates
        /// </summary>
        /// <returns></returns>
        public abstract Elements Clone();




    }
}
