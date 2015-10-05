using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shuntamu.View
{
    internal class MotionObject : MapObject
    {
        public MotionObject(Size top, Size size)
            : base(top, size)
        {
        }

        public Size Distance { get; set; }

        public virtual void Update(Map map)
        {
            bool hitflag = false;
            foreach (var Obj in map)
            {
                if (CheckHit(new Square(new Size(Top.Width + Distance.Width, Top.Height), Size), Obj))
                {
                    hitflag = true;
                    break;
                }
                if (!hitflag) Top += new Size(Distance.Width, 0);
                hitflag = false;
            }
            foreach (var Obj in map)
            {
                if (CheckHit(new Square(new Size(Top.Width, Top.Height + Distance.Height), Size), Obj))
                {
                    hitflag = true;
                    break;
                }
                if (!hitflag) Top += new Size(0, Distance.Height);
            }
        }
        public static bool CheckHit(Square a, Square b)
        {
            if (CheckHit(a.Top, b) || CheckHit(a.Bottom, b) || CheckHit(b.Top, a) || CheckHit(b.Bottom, a)) return true;
            return false;
        }

        public static bool CheckHit(Size p, Square b)
        {
            if ((b.Top.Width <= p.Width) && (p.Width <= b.Bottom.Width) && (b.Top.Height <= p.Height) && (p.Height <= b.Bottom.Height)) return true;
            return false;
        }
    }
}