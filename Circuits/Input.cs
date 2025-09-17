using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    internal class Input : Elements
    {

        // image dependant sizing/spacing
        protected static int WIDTH = ResImg.Width;
        protected static int HEIGHT = ResImg.Height;
        // length of the connector legs sticking out left and right
        protected const int GAP = 10;
        protected static Image ResImg = Properties.Resources.InputOn;
        protected static Image ResImgSelect = Properties.Resources.InputOff;

        // var overrides
        protected override int Width => WIDTH;
        protected override int Height => HEIGHT;


        protected bool isOn = false;

        public Input(int x, int y)
            : base(x, y)
        {
            //add pins to input
            pins.Add(new Pin(this, true, 30));
            //move the input and the pins to the position passed in
            MoveTo(x, y);

        }
        /// <summary>
        /// overides the draw method in Elements class
        /// uses images for selected input
        /// switches the input on when selected
        /// </summary>
        /// <param name="paper"></param>
        public override void Draw(Graphics paper)
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
            paper.DrawImage(imgToDraw, Left, Top, Width, Height); // with resource img W/H to draw correct size, to correlate to mouse boundary box and pin positions correctly
        }

        /// <summary>
        /// clone the gate.
        /// </summary>
        /// <returns></returns>
        public override Elements Clone()
        {
            return new Input(0, 0);
        }

        /// <summary>
        /// begins checking the status of circuits and change ison based on the input of the other gates
        /// </summary>
        /// <returns></returns>
        public override bool Evaluate()
        {
            //check if pin has connection
            if (pins[0].InputWire == null)
            {
                return false;
            }
            else
            {

                Elements Input = pins[0].InputWire.FromPin.Owner;
                isOn = Input.Evaluate();
                return isOn;
            }
        }

    }
}
