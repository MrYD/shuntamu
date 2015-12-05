using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;
using shuntamu.Util;

namespace shuntamu.View.AutumnGround
{
    class InvisibleBlock:MotionlessObject,IKiller
    {
        private int invisBlockHandle;

        bool hit = false;
        public InvisibleBlock(Point top) : base(top, new Size(32,32))
        {
            invisBlockHandle = DX.LoadGraph(@"../../IWBT素材/ブロック/sprWWBlock.png");
        }

        public override void Draw(Point top, Size size)
        {
            if (hit)
            {
                DX.DrawGraph(top.X, top.Y, invisBlockHandle, DX.TRUE);
                
            }
        }

        public void Kill(MapElementBase target)
        {
            if (!hit)
            {
                SoundManager.Play("invisBlock", DX.DX_PLAYTYPE_BACK);
            }
            hit = true;
        }
    }
}
