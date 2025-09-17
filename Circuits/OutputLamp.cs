using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    internal class OutputLamp : Elements
    {




        public OutputLamp(int x, int y)
            : base(x, y)
        {
            //add pins to gate
            pins.Add(new Pin(this, true, 30));
            //move the gate and the pins to the position passed in
            MoveTo(x, y);
        }
    }
}
