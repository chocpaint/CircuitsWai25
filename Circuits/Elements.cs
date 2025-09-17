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
        // vars
        protected int left; // left side of the gate
        protected int top; // top side of the gate
        protected List<Pin> pins = new List<Pin>(); // pins list
        protected bool selected = false; // selected state


        // initialise an element object (public)
        public Elements(int x, int y)
        {
            
        }


        // localised vars
        public int Left => left;
        public int Top => top;
        public List<Pin> Pins => pins;


        // selected bool
        public virtual bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }


        // W/H declaration, used in subclasses
        protected abstract int Width { get; }
        protected abstract int Height { get; }


        // mouse hovering bool
        public virtual bool IsMouseOn(int x, int y)
        {
            return left <= x && x < left + Width
                && top <= y && y < top + Height;
        }


        // moving element event
        public virtual void MoveTo(int x, int y)
        {
            left = x;
            top = y;
        }


        // abstract method used for drawing elements
        public abstract void Draw(Graphics paper);

        // an abstract method used for evaluating circuit each gate will call on this method
        // with slight variations to represent the functions of differrent gates
        public abstract bool Evaluate();

        // abstract method used to clone seperate gates
        public abstract Elements Clone();
    }
}
