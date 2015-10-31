using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace shuntamu.View.AutumnGround
{
    class Rock1:MotionlessObject
    {
        public Rock1(Point top, Size size) : base(top, size)
        {
            handle = DX.MakeScreen(size.Width, size.Height);
            DX.SetDrawScreen(handle);
            int rockHandle = DX.LoadGraph(@"IWBT素材\ブロック\rockNormal.png");
            int rockWidth = size.Width / 32;
            int rockHight = size.Height / 32;
            for (int i = 0; i < rockWidth; i++)
            {
                for (int j = 0; j < rockHight; j++)
                {
                    DX.DrawGraph(i * 32,j * 32, rockHandle, DX.TRUE);
                }
            }
            DX.SetDrawScreen(DX.DX_SCREEN_FRONT);
        }


        public override void Draw(Point top, Size size)
        {
         
            DX.DrawGraph(top.X,top.Y,handle,DX.TRUE);
            //  base.Draw(top, size);
        }

        public int handle;
    }
}
