using System.Drawing;
using DxLibDLL;

namespace shuntamu.View
{
    class Square:IDrawable
    {
        public Size Top { get; set; }
        public Size Size { get; set; }
        public Size Bottom { get { return Top + Size; } }
        
        public Square(Size top, Size size)
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
