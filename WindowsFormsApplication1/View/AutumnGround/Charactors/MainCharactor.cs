using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DxLibDLL;
using shuntamu.Util;

namespace shuntamu.View.AutumnGround.Charactors
{
    internal enum MainCharactorStatus
    {
        Idle,
        Run,
        Jump,
        Fall,
        Death
    }

    internal class MainCharactor : MotionObject
    {
        public static MainCharactor Instance
        {
            get
            {
                return _instance ?? (_instance = new MainCharactor());
            }
            set { _instance = value; }
        }

        private MainCharactor()
            : base(SaveObject.RestartPoint, new Size(10, 20))
        {
            MainCharactorStatus = MainCharactorStatus.Idle;
            Direction = Direction.Right;
            HitYEvent += obj =>
            {
                if (obj.IsSolid)
                {
                    _vy = 0;
                    if (obj.Top.Y >= Bottom.Y)
                    {

                        if (Vx != 0)
                            MainCharactorStatus = MainCharactorStatus.Run;
                        else
                        {
                            MainCharactorStatus = MainCharactorStatus.Idle;
                        }
                        if (obj is MovingFloor)
                        {
                            movingFloor = (MovingFloor)obj;
                        }
                        if (Input.Instance.LeftShift)
                        {
                            _vy = -3;
                            jumpflame = 1;
                        }
                    }
                }
            };
            HitXEvent += obj =>
            {
                if (obj.IsSolid)
                {
                    _vx = 0;
                }

            };
            HitEvent += obj =>
            {
                obj.OnBeHitEvent();
                if (obj is SaveObject)
                {
                    ((SaveObject)obj).Save();
                }
                if (obj is IKiller)
                {
                    ((IKiller)obj).Kill(this);
                    // DX.DrawString(400, 200, "Game Over", DX.GetColor(200, 200, 200));
                }
            };

        }

        public void Init()
        {
            Top = SaveObject.RestartPoint;
            MainCharactorStatus = MainCharactorStatus.Idle;
            Direction = Direction.Right;
        }
        private MovingFloor movingFloor;
        private float _vx = 0;
        private float _vy = 0;
        public MainCharactorStatus MainCharactorStatus { get; set; }

        internal override void Death()
        {
            MainCharactorStatus = MainCharactorStatus.Death;
            SoundManager.Play("onDeath", DX.DX_PLAYTYPE_BACK);
            View.ModeNumber = 1;
        }

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
                    _vx += ax / m;
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
                    _vy += ay / m;
                }
                return (int)_vy;
            }
        }

        private int jumpflame = 0;
        private float ax;
        private float ay;
        private float m = 10f;
        private int _bulletIntervalCount = BULLETINTERVAL;
        private const int BULLETINTERVAL = 20;

        public override void Update(MapBase map)
        {
            // 銃
            if (Input.Instance.Z)
            {
                if (_bulletIntervalCount <= 0)
                {
                    Bullet bullet;
                    if (Direction == Direction.Right)
                    {
                        bullet = new Bullet(new Point(Point.X + 11, Point.Y + 7), Direction);
                    }
                    else
                    {
                        bullet = new Bullet(new Point(Point.X - 11, Point.Y + 7), Direction);
                    }
                    map.AddElement(bullet);
                    map.UpdateElement();
                    _bulletIntervalCount = BULLETINTERVAL;
                }
            }
            if (_bulletIntervalCount > 0)
            {
                _bulletIntervalCount--;
            }
            // ジャンプ
            if (Input.Instance.LeftShift)
            {
                if (jumpflame != 0)
                {
                    if (jumpflame < 20)
                    {
                        if (jumpflame == 1)
                        {
                            SoundManager.Play("jump", DX.DX_PLAYTYPE_BACK);
                        }
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
            // 移動
            ay = 5;
            ax = 0;          
            if (Input.Instance.Right)
            {
                Direction = Direction.Right;
                ax += 5;
            }
            if (Input.Instance.Left)
            {
                Direction = Direction.Left;
                ax -= 5;
            }
            if (!Input.Instance.Right && !Input.Instance.Left)
            {
                _vx = 0;
            }
            if (movingFloor != null)
            {
                Top = new Point(Top.X + movingFloor.Distance.X * 2, Top.Y + movingFloor.Distance.Y * 2);
                movingFloor = null;
            }
            // 状態
            if (Top.Y > 600)
            {
                Death();
            }
            if (Vy < 0)
            {
                MainCharactorStatus = MainCharactorStatus.Jump;
            }
            else if (Vy > 5)
            {
                MainCharactorStatus = MainCharactorStatus.Fall;
            }
            // 更新
            base.Update(map);
            Distance = new Point(Vx, Vy);          
        }

        public Direction Direction { get; set; }
        private int playerIdleHandleR1 = DX.LoadGraph(@"../../IWBT素材/スプライト/sprPlayerIdleR1.png");
        private int playerIdleHandleR2 = DX.LoadGraph(@"../../IWBT素材/スプライト/sprPlayerIdleR2.png");
        private int playerIdleHandleR3 = DX.LoadGraph(@"../../IWBT素材/スプライト/sprPlayerIdleR3.png");
        private int playerIdleHandleR4 = DX.LoadGraph(@"../../IWBT素材/スプライト/sprPlayerIdleR4.png");
        private int playerIdleHandleL1 = DX.LoadGraph(@"../../IWBT素材/スプライト/sprPlayerIdleL1.png");
        private int playerIdleHandleL2 = DX.LoadGraph(@"../../IWBT素材/スプライト/sprPlayerIdleL2.png");
        private int playerIdleHandleL3 = DX.LoadGraph(@"../../IWBT素材/スプライト/sprPlayerIdleL3.png");
        private int playerIdleHandleL4 = DX.LoadGraph(@"../../IWBT素材/スプライト/sprPlayerIdleL4.png");
        private int playerRunHandleR1 = DX.LoadGraph(@"../../IWBT素材/スプライト/sprPlayerRunningR1.png");
        private int playerRunHandleR2 = DX.LoadGraph(@"../../IWBT素材/スプライト/sprPlayerRunningR2.png");
        private int playerRunHandleR3 = DX.LoadGraph(@"../../IWBT素材/スプライト/sprPlayerRunningR3.png");
        private int playerRunHandleR4 = DX.LoadGraph(@"../../IWBT素材/スプライト/sprPlayerRunningR4.png");
        private int playerRunHandleL1 = DX.LoadGraph(@"../../IWBT素材/スプライト/sprPlayerRunningL1.png");
        private int playerRunHandleL2 = DX.LoadGraph(@"../../IWBT素材/スプライト/sprPlayerRunningL2.png");
        private int playerRunHandleL3 = DX.LoadGraph(@"../../IWBT素材/スプライト/sprPlayerRunningL3.png");
        private int playerRunHandleL4 = DX.LoadGraph(@"../../IWBT素材/スプライト/sprPlayerRunningL4.png");
        private int playerJumpHandleR = DX.LoadGraph(@"../../IWBT素材/スプライト/sprPlayerJumpR.png");
        private int playerJumpHandleL = DX.LoadGraph(@"../../IWBT素材/スプライト/sprPlayerJumpL.png");
        private int playerFallHandleR = DX.LoadGraph(@"../../IWBT素材/スプライト/sprPlayerFallR.png");
        private int playerFallHandleL = DX.LoadGraph(@"../../IWBT素材/スプライト/sprPlayerFallL.png");
        private static MainCharactor _instance;

        public override void Draw(Point top, Size size)
        {
            double flame = GameTimer.Loop(20);
            switch (MainCharactorStatus)
            {
                case MainCharactorStatus.Idle:
                    if (Direction == Direction.Right)
                    {
                        if (flame <= 1 / 4.0)
                        {
                            DX.DrawGraph(top.X - 11, top.Y - 12, playerIdleHandleR1, DX.TRUE);
                            return;
                        }
                        if (flame > 1 / 4.0 && flame <= 1 / 2.0)
                        {
                            DX.DrawGraph(top.X - 11, top.Y - 12, playerIdleHandleR2, DX.TRUE);
                            return;
                        }
                        if (flame > 1 / 2.0 && flame <= 3 / 4.0)
                        {
                            DX.DrawGraph(top.X - 11, top.Y - 12, playerIdleHandleR3, DX.TRUE);
                            return;
                        }
                        if (flame > 3 / 4.0)
                        {
                            DX.DrawGraph(top.X - 11, top.Y - 12, playerIdleHandleR4, DX.TRUE);
                            return;
                        }
                    }
                    else
                    {
                        if (flame <= 1 / 4.0)
                        {
                            DX.DrawGraph(top.X - 11, top.Y - 12, playerIdleHandleL1, DX.TRUE);
                            return;
                        }
                        if (flame > 1 / 4.0 && flame <= 1 / 2.0)
                        {
                            DX.DrawGraph(top.X - 11, top.Y - 12, playerIdleHandleL2, DX.TRUE);
                            return;
                        }
                        if (flame > 1 / 2.0 && flame <= 3 / 4.0)
                        {
                            DX.DrawGraph(top.X - 11, top.Y - 12, playerIdleHandleL3, DX.TRUE);
                            return;
                        }
                        if (flame > 3 / 4.0)
                        {
                            DX.DrawGraph(top.X - 11, top.Y - 12, playerIdleHandleL4, DX.TRUE);
                            return;
                        }
                    }
                    break;
                case MainCharactorStatus.Run:
                    if (Direction == Direction.Right)
                    {
                        if (flame <= 1 / 4.0)
                        {
                            DX.DrawGraph(top.X - 11, top.Y - 12, playerRunHandleR1, DX.TRUE);
                            return;
                        }
                        if (flame > 1 / 4.0 && flame <= 1 / 2.0)
                        {
                            DX.DrawGraph(top.X - 11, top.Y - 12, playerRunHandleR2, DX.TRUE);
                            return;
                        }
                        if (flame > 1 / 2.0 && flame <= 3 / 4.0)
                        {
                            DX.DrawGraph(top.X - 11, top.Y - 12, playerRunHandleR3, DX.TRUE);
                            return;
                        }
                        if (flame > 3 / 4.0)
                        {
                            DX.DrawGraph(top.X - 11, top.Y - 12, playerRunHandleR4, DX.TRUE);
                            return;
                        }
                    }
                    else
                    {
                        if (flame <= 1 / 4.0)
                        {
                            DX.DrawGraph(top.X - 11, top.Y - 12, playerRunHandleL1, DX.TRUE);
                            return;
                        }
                        if (flame > 1 / 4.0 && flame <= 1 / 2.0)
                        {
                            DX.DrawGraph(top.X - 11, top.Y - 12, playerRunHandleL2, DX.TRUE);
                            return;
                        }
                        if (flame > 1 / 2.0 && flame <= 3 / 4.0)
                        {
                            DX.DrawGraph(top.X - 11, top.Y - 12, playerRunHandleL3, DX.TRUE);
                            return;
                        }
                        if (flame > 3 / 4.0)
                        {
                            DX.DrawGraph(top.X - 11, top.Y - 12, playerRunHandleL4, DX.TRUE);
                            return;
                        }
                    }
                    break;
                case MainCharactorStatus.Jump:
                    if (Direction == Direction.Right)
                    {
                        DX.DrawGraph(top.X - 11, top.Y - 12, playerJumpHandleR, DX.TRUE);
                    }
                    else
                    {
                        DX.DrawGraph(top.X - 11, top.Y - 12, playerJumpHandleL, DX.TRUE);
                    }
                    break;
                case MainCharactorStatus.Fall:
                    if (Direction == Direction.Right)
                    {
                        DX.DrawGraph(top.X - 11, top.Y - 12, playerFallHandleR, DX.TRUE);
                    }
                    else
                    {
                        DX.DrawGraph(top.X - 11, top.Y - 12, playerFallHandleL, DX.TRUE);
                    }
                    break;
                case MainCharactorStatus.Death:
                    DX.DrawGraph(top.X - 11, top.Y - 12, playerFallHandleL, DX.TRUE);
                    break;
            }
        }
    }
}
