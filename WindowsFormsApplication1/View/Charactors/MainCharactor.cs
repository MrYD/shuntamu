using System.Collections.Generic;
using System.Drawing;

namespace shuntamu.View
{
    class MainCharactor : Square
    {
        public MainCharactor()
            : base(new Size(100, 0), new Size(50, 100))
        {
        }

        public void Updata(List<Square> world)
        {
            Size distance = new Size(10,10);
            bool hitflag = false;
            foreach (var Obj in world)
            {
                if (CheckHit(new Square(new Size(Top.Width + distance.Width, Top.Height), Size), Obj))
                {
                    hitflag = true;
                    break;
                }
                if (!hitflag) Top += new Size(distance.Width,0);
                hitflag = false;
            }
            foreach (var Obj in world)
            {
                if (CheckHit(new Square(new Size(Top.Width, Top.Height+distance.Height), Size), Obj))
                {
                    hitflag = true;
                    break;
                }
                if (!hitflag) Top += new Size(0,distance.Height);
            }
        }

        public static bool CheckHit(Square a, Square b)
        {
            if (CheckHit(a.Top, b) ||( CheckHit(a.Top+a.Size, b)))
                return true;
            else return false;
        }

        public static bool CheckHit(Size p, Square b)
        {
            if ((b.Top.Width < p.Height) && (p.Width < b.Bottom.Width) && (b.Top.Height < p.Height) &&
                (p.Height < b.Bottom.Height)) return true;
            else
            {
                return false;
            }
        }
    }
}
