using System;
using System.Drawing;
using System.Windows.Forms;
using DxLibDLL;
using shuntamu.Util;

namespace shuntamu.View.AutumnGround.Charactors
{
    class MainCharactor : MotionObject
    {
        public MainCharactor()
            : base(SaveObject.RestartPoint, new Size(10, 20))
        {
            Direction = Direction.Right;
            HitYEvent += obj =>
            {
                _vy = 0;
                if (Input.Instance.LeftShift)
                {
                    _vy = -3;
                    jumpflame = 1;
                }
            };
            HitXEvent += obj =>
            {
                _vx = 0;
            };
            HitEvent += obj =>
            {
                if (obj is SaveObject)
                {
                    ((SaveObject)obj).Save();
                }
                if (obj is Siratama)
                {
                    View.ModeNumber = 1;
                    // DX.DrawString(400, 200, "Game Over", DX.GetColor(200, 200, 200));
                }
            };

        }

        private float _vx = 0;
        private float _vy = 0;

        private int Vx
        {
            get
            {
                if (_vx > 5)
                {
                    _vx = 5;
                }
                else if (_vx < -5)
                {
                    _vx = -5;
                }
                else
                {
                    _vx += +ax / m;
                }
                return (int)_vx;
            }
        }

        private int Vy
        {
            get
            {
                if (_vy > 15)
                {
                    _vy = 15;
                }
                else if (_vy < -20)
                {
                    _vy = -20;
                }
                else
                {
                    _vy += +ay / m;
                }
                return (int)_vy;
            }
        }

        private int jumpflame = 0;
        private float ax;
        private float ay;
        private float m = 10f;
        private int _bulletInterval = 30;

        public override void Update(MapBase map)
        {
            if (_bulletInterval > 0)
            {
                _bulletInterval--;
            }

            if (Input.Instance.Z)
            {
                if (_bulletInterval <= 0)
                {
                    Bullet bullet;
                    if (Direction == Direction.Right)
                    {
                        bullet = new Bullet(new Point(Point.X + 11, Point.Y), Direction);
                    }
                    else
                    {
                        bullet = new Bullet(new Point(Point.X - 11, Point.Y), Direction);
                    }
                    map.AddElement(bullet);
                    map.UpdateElement();
                    _bulletInterval = 30;
                }
            }

            if (Input.Instance.LeftShift)
            {
                if (jumpflame != 0)
                {
                    if (jumpflame < 20)
                    {
                        jumpflame++;
                        _vy = -10;
                    }
                    else
                    {
                        jumpflame = 0;
                    }
                }
            }
            else
            {
                jumpflame = 0;
            }
            if (Top.Y > 600)
            {
                View.ModeNumber = 1;
            }
            ay = 5;
            if (Input.Instance.Right)
            {
                Direction = Direction.Right;
                ax = 5;
            }
            else if (Input.Instance.Left)
            {
                Direction = Direction.Left;
                ax = -5;
            }
            else
            {
                ax = 0;
                _vx = 0;
            }
            base.Update(map);
            Distance = new Point(Vx, Vy);
        }

        public Direction Direction { get; set; }


        public override void Draw(Point top, Size size)
        {
            // DX.DrawCircle(top.X, top.Y, 10, DX.GetColor(200, 200, 200));
            base.Draw(top, size);
        }
    }
}
