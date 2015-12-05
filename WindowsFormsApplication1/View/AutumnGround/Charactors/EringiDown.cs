using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace shuntamu.View.AutumnGround.Charactors
{
    class EringiDown:MotionlessObject,IKiller
    {
        private int eringiDHandle;
        public EringiDown(Point top) : base(top, new Size(32,32))
        {
            eringiDHandle = DX.LoadGraph(@"../../IWBT素材/ブロック/eringiDownS.png");
        }

        public override void Draw(Point top, Size size)
        {
            DX.DrawGraph(top.X, top.Y, eringiDHandle, DX.TRUE);
            //base.Draw(top, size);
        }
        public void Kill(MapElementBase target)
        {
            View.ModeNumber = 1;
        }
    }
}
