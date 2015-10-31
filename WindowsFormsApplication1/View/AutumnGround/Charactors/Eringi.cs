using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace shuntamu.View.AutumnGround.Charactors
{
    class Eringi:MotionlessObject,IKiller
    {
        private int eringiHandle;
        public Eringi(Point top) : base(top, new Size(32,32))
        {
             eringiHandle = DX.LoadGraph(@"IWBT素材\ブロック\eringi_S.png");
        }

        public override void Draw(Point top, Size size)
        {
            DX.DrawGraph(top.X, top.Y, eringiHandle, DX.TRUE);
            //base.Draw(top, size);
        }
        public void Kill()
        {
            View.ModeNumber = 1;
        }
    }
}
