using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace shuntamu.View.AutumnGround.Charactors
{
    class EringiLeft:MotionlessObject,IKiller
    {
        private int eringiLHandle;
        public EringiLeft(Point top) : base(top, new Size(32,32))
        {
            eringiLHandle = DX.LoadGraph(@"../../IWBT素材/ブロック/eringiLeftS.png");
        }

        public override void Draw(Point top, Size size)
        {
            DX.DrawGraph(top.X, top.Y, eringiLHandle, DX.TRUE);
            //base.Draw(top, size);
        }
        public void Kill(MapElementBase target)
        {
            target.Death();
        }

    }
}
