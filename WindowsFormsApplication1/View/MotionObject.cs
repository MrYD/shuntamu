using System;
using System.Drawing;
using System.Linq;

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
        public event Action HitYEvent;
        public event Action HitXEvent;

        public virtual void Update(MapBase map)
        {
            var hitflag = map.Elements.Any(obj => CheckHit(new Square(new Point(Top.X + Distance.X, Top.Y), Size), obj));
            if (!hitflag) Top += new Size(Distance.X, 0);
            else
            {
                OnHitXEvent();
            }
            hitflag = map.Elements.Any(obj => CheckHit(new Square(new Point(Top.X, Top.Y + Distance.Y), Size), obj));
            if (!hitflag) Top += new Size(0, Distance.Y);
            else
            {
                OnHitYEvent();
            }
        }
        public static bool CheckHit(Square a, Square b)
        {
            return CheckHit(a.Top, b) || CheckHit(a.Bottom, b) || CheckHit(a.LeftBottom, b) || CheckHit(a.RightTop, b) ||
                   CheckHit(b.Top, a) || CheckHit(b.Bottom, a) || CheckHit(b.LeftBottom, a) || CheckHit(b.RightTop, a);
        }

        public static bool CheckHit(Point p, Square b)
        {
            return (b.Top.X <= p.X) && (p.X <= b.Bottom.X) && (b.Top.Y <= p.Y) && (p.Y <= b.Bottom.Y);
        }

        protected virtual void OnHitYEvent()
        {
            var handler = HitYEvent;
            if (handler != null) handler();
        }

        protected virtual void OnHitXEvent()
        {
            var handler = HitXEvent;
            if (handler != null) handler();

        }
    }
}