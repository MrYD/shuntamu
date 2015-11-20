using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shuntamu.View.AutumnGround
{
    class MovingFloor:MotionObject
    {
        private long time =1;
      //  private float ax;

        private long Time
        {
            get
            {
                long span = time%40;
                return span;
            }
        }

        public MovingFloor(Point top, Size size) : base(top,new Size(32,16) )
        {
           
        }

        public override void Update(MapBase map)
        {
            time++;
            if (Time<20)
            {
                Distance = new Point(5, 0);
            }
            else
            {
                Distance = new Point(-5,0);
            }
            base.Update(map);
        }
    }
}
