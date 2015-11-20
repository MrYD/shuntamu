using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace shuntamu.View.AutumnGround
{
    class ClearObject:MotionlessObject,IKiller
    {
        public void Kill()
        {
            View.ModeNumber = 2;
            SaveObject.RestartPoint = new Point(32, 128);
        }

        public ClearObject(Point top) : base(top, new Size(32,32))
        {

        }

        private int clearHandle = DX.LoadGraph(@"../../IWBT素材/スプライト/ゴールボール.png");
        public override void Draw(Point top, Size size)
        {
            DX.DrawGraph(top.X, top.Y, clearHandle, DX.TRUE);
        }
    }
}
