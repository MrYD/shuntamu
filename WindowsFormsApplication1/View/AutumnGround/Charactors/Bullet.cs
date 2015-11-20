using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace shuntamu.View.AutumnGround.Charactors
{
    enum Direction
    {
        Right,
        Left
    }
    internal class Bullet : MotionObject
    {
        private int bulletHandle;
        public Bullet(Point top, Direction direction)
            : base(top, new Size(5, 5))
        {

            bulletHandle = DX.LoadGraph(@"../../IWBT素材/スプライト/fireBullet.png");
            _direction = direction;
            HitEvent += obj =>
            {
                IsActive = false;
                if(obj is IEnemy)
                    ((IEnemy) obj).Damage();
            };
        }

        public override void Update(MapBase map)
        {
            if(!IsActive)return;
            _bulletLife++;
            if (_bulletLife > 50)
            {
                IsActive = false;
            }
            if (_direction == Direction.Right)
               Distance = new Point(10, 0);
            else
            {
                Distance = new Point(- 10, 0);
            }
            base.Update(map);
        }

        private Direction _direction;
        private int _bulletLife;

        public override void Draw(Point top, Size size)
        {
            DX.DrawGraph(top.X, top.Y, bulletHandle, DX.TRUE);
        }

    }
}
