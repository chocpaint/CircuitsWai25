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
    public class AndGate : Elements
    {
        // set images
        protected static Image ResImg = Properties.Resources.AndGate;
        protected static Image ResImgSelect = Properties.Resources.AndGateSelected;

        // image dependant sizing/spacing
        protected static int WIDTH = ResImg.Width;
        protected static int HEIGHT = ResImg.Height;
        protected const int GAP = 10; // spacing for pins

        // var overrides
        protected override int Width => WIDTH;
        protected override int Height => HEIGHT;


        // initialises the Gate
        public AndGate(int x, int y)
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
        public override MoveTo(int x, int y)
        {
            // call inheritted method with override
            base.MoveTo(x, y); 

            // debugging message
            Console.WriteLine("pins = " + pins.Count);

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
