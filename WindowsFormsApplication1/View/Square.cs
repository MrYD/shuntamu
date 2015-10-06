using System.Drawing;
using DxLibDLL;

namespace shuntamu.View
{
    /// <summary>
    /// IDrawable の 最も基本的な実装
    /// </summary>
    class Square : IDrawable
    {
        public Point Top { get; set; }

        public Point Point
        {
            get { return Top; }
            set { Top = value; }
        }

        public Size Size { get; set; }
        public Point Bottom { get { return Top + Size; } }
        public Point RightTop { get { return Top + new Size(Size.Width, 0); } }
        public Point LeftBottom { get { return Top + new Size(0, Size.Height); } }
        public Square(Point top, Size size)
        {
            Top = top;
            Size = size;
        }

        public virtual void Draw(Point zeropoint)
        {
            DX.DrawBox(zeropoint.X + Top.X, zeropoint.Y + Top.Y, zeropoint.X + (Top + Size).X, zeropoint.Y + (Top + Size).Y, DX.GetColor(0, 0, 255), DX.TRUE);
        }
    }
}
