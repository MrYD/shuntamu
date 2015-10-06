using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shuntamu.View.AutumnGround;

namespace shuntamu.View
{
    /// <summary>
    /// Mode の切り替えをするクラス
    /// </summary>
    class View
    {
        private readonly ModeBase[] modes;
        public int ModeNumber { get; set; }

        public View()
        {
            modes = new ModeBase[1];
            ModeNumber = 0;
            modes[0] = new GameMode1();
        }

        public ModeBase CurrentMode
        {
            get { return modes[ModeNumber]; }
        }

        internal void Update()
        {
            CurrentMode.Update();
        }

        internal void Draw()
        {
            CurrentMode.Draw();
        }
    }
}
