using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace shuntamu.View.AutumnGround
{
    class InvisibleBlock:MotionlessObject,IKiller
    {
        private int invisBlockHandle;
        private int invisBlockSHandle;

        bool hit = false;
        public InvisibleBlock(Point top) : base(top, new Size(32,32))
        {
            invisBlockHandle = DX.LoadGraph(@"../../IWBT素材/ブロック/sprWWBlock.png");
            invisBlockSHandle = DX.LoadSoundMem(@"../../IWBT素材/音源/sndBlockChange.wav");
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
            hit = true;
            DX.PlaySoundMem(invisBlockSHandle, DX.DX_PLAYTYPE_BACK, DX.TRUE);
        }
    }
}
