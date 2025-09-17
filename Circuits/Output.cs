using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    internal class Output : Elements
    {
        // set images
        protected static Image ResImgOff = Properties.Resources.OutputOff;
        protected static Image ResImgOn = Properties.Resources.OutputOn;
        protected static Image ResImgSelect = Properties.Resources.OutputSelect;

        // image dependant sizing/spacing
        protected static int WIDTH = ResImgOff.Width;
        protected static int HEIGHT = ResImgOff.Height;
        protected const int GAP = 10; // spacing for pins
        protected bool isOn = false; // active state

        // var overrides
        protected override int Width => WIDTH;
        protected override int Height => HEIGHT;


        // constructor
        public Output(int x, int y)
            : base(x, y)
        {
            //add pins to output
            pins.Add(new Pin(this, true, 30));
            //move the output and the pins to the position passed in
            MoveTo(x, y);
        }

        // toggle active state
        public void Toggle()
        {
            isOn = !isOn;
        }

        // move the gate based on users input
        public override void MoveTo(int x, int y)
        {
            base.MoveTo(x, y);
            pins[0].X = x;
            pins[0].Y = y + HEIGHT/2;
        }

        // overrides the draw method in Elements class, uses images to display active state, and selected state
        public override void Draw(Graphics paper)
        {
            // base image = on/off visual state
            Image baseImg = isOn // using ternary for swapping imgs based on clicked on status
                ? ResImgOn
                : ResImgOff;

            // draw each of the pins
            foreach (Pin p in pins)
                p.Draw(paper);

            paper.DrawImage(baseImg, Left, Top, Width, Height); // with resource img W/H to draw correct size, to correlate to mouse boundary box and pin positions correctly

            // if selected, overlay the select image (transparent red highlight)
            if (Selected)
            {
                paper.DrawImage(ResImgSelect, Left, Top, Width, Height);
            }
        }

        // clone the element
        public override Elements Clone()
        {
            return new Input(0, 0);
        }

        // begins checking the status of circuits and change ison based on the input of the other gates
        public override bool Evaluate()
        {
            //check if pin has connection
            if (pins[0].InputWire == null)
            {
                isOn = false;
            }
            else
            {
                Elements Output = pins[0].InputWire.FromPin.Owner;
                isOn = Output.Evaluate();
            }
            return isOn;
        }

    }
}

