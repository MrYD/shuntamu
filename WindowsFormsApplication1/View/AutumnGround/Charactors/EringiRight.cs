using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace shuntamu.View.AutumnGround.Charactors
{
    class EringiRight:MotionlessObject,IKiller
    {
        private int eringiRHandle;
        public EringiRight(Point top) : base(top, new Size(32,32))
        {
            eringiRHandle = DX.LoadGraph(@"../../IWBT素材/ブロック/eringiRightS.png");
        }

        public override void Draw(Point top, Size size)
        {
            DX.DrawGraph(top.X, top.Y, eringiRHandle, DX.TRUE);
            //base.Draw(top, size);
        }
        public void Kill(MapElementBase target)
        {
            View.ModeNumber = 1;
        }
    }
}
