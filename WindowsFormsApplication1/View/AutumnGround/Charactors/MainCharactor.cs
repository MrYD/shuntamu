using System.Collections.Generic;
using System.Drawing;
using shuntamu.Util;

namespace shuntamu.View
{
    class MainCharactor : MotionObject
    {
        public MainCharactor()
            : base(new Point(100, 0), new Size(50, 100))
        {
         
        }

        private int distancex;
        private int distancey;
        
        public override void Update(MapBase map)
        {
            distancey = 5;
            if (Input.Instance.Right)
            {
                distancex = 5;
            }
            else if (Input.Instance.Left)
            {
                distancex = -5;
            }
            else
            {
                distancex = 0;
            }

            Distance = new Point(distancex, distancey);
            base.Update(map);
        }
    }
}
