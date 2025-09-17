using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    public class Compound : Elements
    {
        // set images
        protected static Image ResImg = Properties.Resources.AndGate, OrGate, NotGate, InputOn, OutputOn;
        protected static Image ResImgSelect = Properties.Resources.AndGateSelected, OrGateSelected, NotGateSelected, InputOff, OutputOff;
        // image dependant sizing/spacing
        protected static int WIDTH = ResImg.Width;
        protected static int HEIGHT = ResImg.Height;
        protected const int GAP = 10; // spacing for pins
        protected bool isOn = false; // active state
        // var overrides
        protected override int Width => WIDTH;
        protected override int Height => HEIGHT;

        protected List<Elements> gates;
        /// <summary>
        /// Initializes a compound gate object
        /// </summary>
        /// <param name="x">Mouse position passed in on x axis</param>
        /// <param name="y">mouse position passed in of y axis</param>
        public Compound(int x, int y)
          : base(x, y)
        {
            left = x;
            top = y;
            gates = new List<Elements>();
        }
        /// <summary>
        /// This property returns the internal list of gates in the compound gate.
        /// </summary>
        public List<Elements> Gates
        {
            get { return gates; }
        }
        /// <summary>
        /// This method overrides the moveto method to move each individual gate in the
        /// compound list.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>

        /// <summary>
        /// This method overrides the draw method and draws each gate
        /// </summary>
        /// <param name="paper"></param>
        public override void Draw(Graphics paper)
        {
            foreach (Elements gate in gates)
            {
                gate.Draw(paper);
            }
        }
        /// <summary>
        /// this method adds gates to compound gates list
        /// </summary>
        /// <param name="g"></param>
        public void AddGate(Elements g)
        {
            gates.Add(g);

            if (g.Left < Left)
            {

                left = g.Left;

            }

            if (g.Top < Top)
            {
                top = g.Top;
            }
        }
        public override void MoveTo(int x, int y)
        {
            if (gates.Count == 0) return;

            // Find the current bounds of the compound gate
            int currentLeft = gates.Min(g => g.Left);
            int currentTop = gates.Min(g => g.Top);

            // Calculate the distance to move
            int distx = x - currentLeft;
            int disty = y - currentTop;

            // Move each gate in the compound by the calculated distance
            foreach (Elements gate in gates)
            {
                gate.MoveTo(gate.Left + distx, gate.Top + disty);
            }

            // Update the compound gate's position to match
            left = x;
            top = y;

        }
        /// <summary>
        /// This method ovverides the selected property for each gate in the
        /// compound list.
        /// </summary>
        public override bool Selected
        {
            get => base.Selected;
            set
            {
                foreach (Elements g in gates)
                {
                    g.Selected = value;
                }
            }
        }
        /// <summary>
        /// this method overrides the ismouse n methon to select 
        /// each individual gate in the compound
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override bool IsMouseOn(int x, int y)
        {
            foreach (Elements g in gates)
            {
                //check if mouse is on gate
                if (g.IsMouseOn(x, y) == true)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// This method should clone the compound gate
        /// </summary>
        /// <returns></returns>
        public override Elements Clone()
        {
            return new Compound(0, 0);
        }
        /// <summary>
        /// this method should evaluate the compoud gate by using
        /// the evaluate method of each gate in the list
        /// </summary>
        /// <returns></returns>
        public override bool Evaluate()
        {
            foreach (Elements gate in gates)
            {
                //check if gate should start reaction of evaluate calls
                if (gate is Output)
                {
                    return gate.Evaluate();
                }
                return false;
            }
            return false;
        }

    }
}