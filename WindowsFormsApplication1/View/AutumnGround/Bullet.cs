using System.Drawing;
using DxLibDLL;

namespace shuntamu.View.AutumnGround
{
    enum Direction
    {
        Right,
        Left
    }
    internal class Bullet : BulletBase
    {
        public Bullet(Point top, Direction direction)
            : base(top, new Size(5, 5), @"../../IWBT素材/スプライト/fireBullet.png")
        {
            HitEvent += obj =>
            {
                if (obj is IEnemy)
                    ((IEnemy)obj).Damage();
            };
            if (direction == Direction.Left)
            {
                Distance = new Point(-10,0);
            }
            else
            {
                Distance = new Point(10, 0);
            }
        }
    }
}
