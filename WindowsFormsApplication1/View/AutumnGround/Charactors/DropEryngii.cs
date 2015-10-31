using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shuntamu.View.AutumnGround.Charactors
{
    class DropEryngii : MotionObject, IEnemy
    {

        public MotionlessObject Erea { get; set; }

        private bool _isTrigered = false;

        public void Damage()
        {
        }

        public DropEryngii(Point top, Size size, Point ereatop, Size ereasize)
            : base(top, size)
        {
            Erea = new MotionlessObject(ereatop, ereasize);
            Erea.IsSolid = false;
            Erea.BeHitEvent += () =>
            {
                _isTrigered = true;
            };
        }

        public override void Draw(Point top, Size size)
        {
            base.Draw(top, size);
        }

        public override void Update(MapBase map)
        {
            base.Update(map);
        }
    }
}
