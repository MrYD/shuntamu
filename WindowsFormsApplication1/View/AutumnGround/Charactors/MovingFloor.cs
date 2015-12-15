using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;
using shuntamu.Util;

namespace shuntamu.View.AutumnGround
{
    class MovingFloor:MotionObject,IKiller
    {
        private int movingFloorHandle = DX.LoadGraph(@"../../IWBT素材/スプライト/movingObject.png");

        private long time =1;
      //  private float ax;
        private bool vanish;

        private long Time
        {
            get
            {
                long span = time%32;
                return span;
            }
        }

        public MovingFloor(Point top) : base(top,new Size(96,16) )
        {           
        }

        public MovingFloor(Point top,bool van)
            : base(top, new Size(96, 16))
        {
            vanish = van;
            if (vanish)
            {
                IsSolid = false;
            }
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

        public void Kill(MapElementBase target)
        {
            if (vanish)
            {
                IsActive = false;
                SoundManager.Play("blockChange", DX.DX_PLAYTYPE_BACK);
                Map.UpdateElement();
            }
        }
    }
}
