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
            IsActive = true;
        }

        public Point Distance { get; set; }
        public event Action<MapElementBase> HitYEvent;
        public event Action<MapElementBase> HitXEvent;
        public event Action<MapElementBase> HitEvent;

        public virtual void Update(MapBase map)
        {
            if (!IsActive) return;
            var hitflag = false;
            for (int index = 0; index < map.Elements.Count; index++)
            {
                var obj = map.Elements[index];
                if (obj.Equals(this)) continue;
                if (CheckHit(new Square(new Point(Top.X + Distance.X, Top.Y), Size), obj))
                {
                    OnHitEvent(obj);
                    OnHitXEvent(obj);
                    if (obj.IsSolid)
                    {
                        hitflag = true;
                        break;
                    }
                                  
                }
            }
            if (!hitflag) Top += new Size(Distance.X, 0);

            hitflag = false;
            foreach (var obj in map.Elements)
            {
                if (obj.Equals(this)) continue;
                if (CheckHit(new Square(new Point(Top.X, Top.Y + Distance.Y), Size), obj))
                {
                    OnHitEvent(obj);
                    OnHitYEvent(obj);
                    if (obj.IsSolid)
                    {
                        hitflag = true;
                        break;
                    }
                }
            }
            if (!hitflag) Top += new Size(0, Distance.Y);

        }

        public override void Draw(Point top, Size size)
        {
            if (!IsActive) return;
            base.Draw(top, size);
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


        protected virtual void OnHitYEvent(MapElementBase obj)
        {
            var handler = HitYEvent;
            if (handler != null) handler(obj);
        }

        protected virtual void OnHitXEvent(MapElementBase obj)
        {
            var handler = HitXEvent;
            if (handler != null) handler(obj);
        }

        protected virtual void OnHitEvent(MapElementBase obj)
        {
            var handler = HitEvent;
            if (handler != null) handler(obj);
        }
    }
}