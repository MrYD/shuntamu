using System.Drawing;
using shuntamu.View.AutumnGround.Charactors;

namespace shuntamu.View.AutumnGround
{
    class GameMode1 : ModeBase
    {
        private readonly Map1 _map1;
        private readonly MainCharactor _mario;
        public GameMode1()
        {
            _mario = new MainCharactor();
            _map1 = new Map1();
        }

        public override void Draw()
        {

            int y;
            if (_mario.Top.Y > 500)
            {
                y = 0;
            }
            else
            {
                y = 300 - _mario.Top.Y;
            }


             var p = new Point(400-_mario.Top.X,y);
            _map1.Draw(p);
            _mario.Draw(p);
        }

        public override void Update()
        {
            _mario.Update(_map1);
            _map1.Update(_mario.Point);
        }
    }
}
