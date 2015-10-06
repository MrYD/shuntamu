using System.Drawing;

namespace shuntamu.View
{
    /// <summary>
    /// Update が必要な Map要素
    /// </summary>
    class MotionObject : MapElementBase
    {
        public MotionObject(Point top, Size size)
            : base(top, size)
        {
        }

        public Point Distance { get; set; }

        public virtual void Update(MapBase map)
        {
            bool hitflag = false;
            foreach (var obj in map.Elements)
            {
                if (CheckHit(new Square(new Point(Top.X + Distance.X, Top.Y), Size), obj))
                {
                    hitflag = true;
                    break;
                }
                if (!hitflag) Top += new Size(Distance.X, 0);
                hitflag = false;
            }
            foreach (var obj in map.Elements)
            {
                if (CheckHit(new Square(new Point(Top.X, Top.Y + Distance.Y), Size), obj))
                {
                    hitflag = true;
                    break;
                }
                if (!hitflag) Top += new Size(0, Distance.Y);
            }
        }
        public static bool CheckHit(Square a, Square b)
        {
            if (CheckHit(a.Top, b) || CheckHit(a.Bottom, b) || CheckHit(b.Top, a) || CheckHit(b.Bottom, a)) return true;
            return false;
        }

        public static bool CheckHit(Point p, Square b)
        {
            if ((b.Top.X <= p.X) && (p.X <= b.Bottom.X) && (b.Top.Y <= p.Y) && (p.Y <= b.Bottom.Y)) return true;
            return false;
        }
    }
}