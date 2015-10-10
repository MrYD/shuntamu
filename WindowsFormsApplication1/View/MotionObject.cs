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
        public event Action<object> HitYEvent;
        public event Action<object> HitXEvent;
        public event Action<object> HitEvent;

        public virtual void Update(MapBase map)
        {
            var hitflag = false;
            foreach (var obj in map.Elements)
            {
                if(obj.Equals(this))continue;
                if (CheckHit(new Square(new Point(Top.X + Distance.X, Top.Y), Size), obj))
                {
                    hitflag = true;
                    OnHitEvent(obj);
                    OnHitXEvent(obj);
                    break;
                }
            }
            if (!hitflag) Top += new Size(Distance.X, 0);
           
            hitflag = false;
            foreach (var obj in map.Elements)
            {
                if (obj.Equals(this)) continue;
                if (CheckHit(new Square(new Point(Top.X, Top.Y + Distance.Y), Size), obj))
                {
                    hitflag = true;
                    OnHitEvent(obj);
                    OnHitYEvent(obj);  
                    break;
                }
            }
            if (!hitflag) Top += new Size(0, Distance.Y);
          
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


        protected virtual void OnHitYEvent(object obj)
        {
            var handler = HitYEvent;
            if (handler != null) handler(obj);
        }

        protected virtual void OnHitXEvent(object obj)
        {
            var handler = HitXEvent;
            if (handler != null) handler(obj);
        }

        protected virtual void OnHitEvent(object obj)
        {
            var handler = HitEvent;
            if (handler != null) handler(obj);
        }
    }
}