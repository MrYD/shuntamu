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
            _map1.Draw(new Point(0,0));
            _mario.Draw(new Point(0,0));
        }

        public override void Update()
        {
            _mario.Update(_map1);
            //TODO map内のアップデート
        }
    }
}
