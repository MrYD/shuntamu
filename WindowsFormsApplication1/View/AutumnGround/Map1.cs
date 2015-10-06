using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shuntamu.View.AutumnGround
{
    class Map1 : MapBase
    {
        public Map1()
            : base(new Size(1000, 1000))
        {
            var floor = new MotionlessObject(new Point(0, 500), new Size(1000, 100));
            AddElement(floor);
        }
    }
}
