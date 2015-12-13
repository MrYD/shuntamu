using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace shuntamu.View.AutumnGround.Charactors
{
    class LongEringi:MotionlessObject,IKiller
    {
        private int longEringiHandle;
        public LongEringi(Point top) : base(top, new Size(32,64))
        {
            longEringiHandle = DX.LoadGraph(@"../../IWBT素材\ブロック\longEringiUp.png");
        }

        public override void Draw(Point top, Size size)
        {
            DX.DrawGraph(top.X, top.Y, longEringiHandle, DX.TRUE);
            //base.Draw(top, size);
        }

        public void Kill(MapElementBase target)
        {
            target.Death();
        }
    }
}
