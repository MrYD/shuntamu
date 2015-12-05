using System;
using System.Collections.Generic;
using System.Drawing;

namespace shuntamu.View
{
    /// <summary>
    /// Map に追加可能な要素
    /// </summary>
    abstract class MapElementBase : Square
    {
        protected MapElementBase(Point top, Size size)
            : base(top, size)
        {
            IsActive = true;
            IsSolid = true;
        }
        public event Action BeHitEvent;

        public MapBase Map { get; set; }

        public MapElementBase AddTo(MapBase map)
        {
            Map = map;
            map.AddElement(this);
            return this;
        }

        public bool IsActive { get; set; }

        public bool IsSolid { get; set; }

        public void OnBeHitEvent()
        {
            var handler = BeHitEvent;
            if (handler != null) handler();
        }

        virtual internal void Death()
        {
            
        }
    }
}
