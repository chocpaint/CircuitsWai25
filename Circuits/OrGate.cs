using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    /// <summary>
    /// github.com/chocpaint/CircuitsWai25 
    /// This class implements an OR gate with two inputs and one output.
    /// </summary>
    public class OrGate : Elements
    {
        // set images
        protected static Image ResImg = Properties.Resources.OrGate;
        protected static Image ResImgSelect = Properties.Resources.OrGateSelected;

        // image dependant sizing/spacing
        protected static int WIDTH = ResImg.Width;
        protected static int HEIGHT = ResImg.Height;
        protected const int GAP = 10; // spacing for pins
        protected bool isOn = false; // active state

        // var overrides
        protected override int Width => WIDTH;
        protected override int Height => HEIGHT;


        // initialises the Gate
        public OrGate(int x, int y) : base(x, y)
        {
            // add 2 input pins
            pins.Add(new Pin(this, true, 20));
            pins.Add(new Pin(this, true, 20));
            // add 1 output pin
            pins.Add(new Pin(this, false, 20));
            // move the gate and the pins to the position passed in (mouse pos)
            MoveTo(x, y);
        }


        // elements override method. draw all parts on display.
        public override void Draw(Graphics paper)
        {
            Image imgToDraw = Selected // ternary determining image from selected state
                ? ResImgSelect  // selected alternate image
                : ResImg;       // normal image (unselected)

            // draw every pin
            foreach (Pin p in pins)
                p.Draw(paper);

            // draw gate image with resource W/H to draw correct size, to correlate to mouse boundary box and position pins correctly
            paper.DrawImage(imgToDraw, Left, Top, Width, Height);
        }


        // moveto overide method. move the gate to the position specified (mouse pos) and pins.
        public override void MoveTo(int x, int y)
        {
            // call inheritted method with override
            base.MoveTo(x, y);

            // debugging message
            Console.WriteLine("pins = " + pins.Count);

            // pins placement
            pins[0].X = x - GAP; // one/2 in pin on upper center left 
            pins[0].Y = y + HEIGHT / 2 - GAP;
            pins[1].X = x - GAP; // one in pin on lower center left 
            pins[1].Y = y + HEIGHT / 2 + GAP;
            pins[2].X = x + WIDTH + GAP; // one out pin on center right
            pins[2].Y = y + HEIGHT / 2;
        }

        // evaluate override method with or gate logic
        public override bool Evaluate()
        {
            bool a = pins[0].InputWire?.FromPin.Owner.Evaluate() ?? false;
            bool b = pins[1].InputWire?.FromPin.Owner.Evaluate() ?? false;
            return a || b;
        }

        // clone override method
        public override Elements Clone()
        {
            return new OrGate(Left, Top);
        }
    }
}