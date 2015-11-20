using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace shuntamu.View.AutumnGround
{
    class MovingFloor:MotionObject
    {
        private int movingFloorHandle = DX.LoadGraph(@"../../IWBT素材/スプライト/movingObject.png");

        private long time =1;
      //  private float ax;

        private long Time
        {
            get
            {
                long span = time%32;
                return span;
            }
        }

        public MovingFloor(Point top, Size size) : base(top,new Size(96,16) )
        {
           
        }

        public override void Update(MapBase map)
        {
            time++;
            if (Time<16)
            {
                Distance = new Point(2, 0);
            }
            else
            {
                Distance = new Point(-2,0);
            }
            base.Update(map);
        }

        public override void Draw(Point top, Size size)
        {
            DX.DrawGraph(top.X, top.Y, movingFloorHandle, DX.TRUE);
        }
    }
}
