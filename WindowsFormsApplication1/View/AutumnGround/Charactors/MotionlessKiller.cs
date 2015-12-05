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
    enum Skin
    {
        Eringi,
        EringiDown,
        BambooSpear
    }
    class MotionlessKiller:MotionlessObject,IKiller
    {
        private int eringiHandle;

        public MotionlessKiller(Point top, Skin skin)
            : base(top, new Size(0, 0))
        {
            switch (skin)
            {
                case Skin.Eringi:
                    eringiHandle = DX.LoadGraph(@"../../IWBT素材/ブロック/eringi_S.png");
                    Size = new Size(32, 32);
                    break;
                case Skin.EringiDown:
                    eringiHandle = DX.LoadGraph(@"../../IWBT素材/ブロック/eringiDownS.png");
                    Size = new Size(32, 32);
                    break;
                case Skin.BambooSpear:
                    eringiHandle = DX.LoadGraph(@"../../IWBT素材/ブロック/bambooSpear.png");
                    Size = new Size(32, 32);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("skin", skin, null);
            }
           
        }

        public override void Draw(Point top, Size size)
        {
            DX.DrawGraph(top.X, top.Y, eringiHandle, DX.TRUE);
            //base.Draw(top, size);
        }
        public void Kill(MapElementBase target)
        {
            //View.ModeNumber = 1;

        }
    }
}
