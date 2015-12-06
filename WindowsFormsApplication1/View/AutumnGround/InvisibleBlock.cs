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
    class InvisibleBlock : MotionlessObject, IKiller,IEnemy
    {
        private int invisBlockHandle;

        public InvisibleBlock(Point top) : base(top, new Size(32, 32))
        {
            invisBlockHandle = DX.LoadGraph(@"../../IWBT素材/ブロック/sprWWBlock.png");
            IsVisible = false;
        }

        public override void Draw(Point top, Size size)
        {
            DX.DrawGraph(top.X, top.Y, invisBlockHandle, DX.TRUE);
        }

        public void Kill(MapElementBase target)
        {
            if (!IsVisible)
            {
                SoundManager.Play("invisBlock", DX.DX_PLAYTYPE_BACK);
                IsVisible = true;
            }              
        }

        public void Damage()
        {
            if (!IsVisible)
            {
                SoundManager.Play("invisBlock", DX.DX_PLAYTYPE_BACK);
                IsVisible = true;
            }
        }
    }
}
