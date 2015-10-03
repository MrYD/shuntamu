using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace shuntamu
{
    class square:DrawableObject
    {
        public Size Top { get; set; }
        public Size Size { get; set; }
        public Size Bottom { get { return Top + Size; } }
        
        public square(Size top, Size size)
        {
            Top = top;
            Size = size;
        }

        public  void Draw()
        {
            DX.DrawBox(Top.Width, Top.Height, (Top+Size).Width,(Top+Size).Height , DX.GetColor(0, 0, 255), DX.TRUE);
        }
    }
}
