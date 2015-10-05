using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shuntamu.View.AutumnGround;

namespace shuntamu.View
{
    class GameMode1 : Mode
    {

        private Map1 map1;
        private MainCharactor mario;
        public GameMode1()
        {
            mario = new MainCharactor();
            map1 = new Map1();
        }

        public override void Draw()
        {
            map1.Draw();
            mario.Draw();
        }

        public override void Update()
        {
            mario.Update(map1);
            //TODO map内のアップデート
        }
    }
}
