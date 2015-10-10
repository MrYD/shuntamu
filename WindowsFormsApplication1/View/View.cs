using shuntamu.View.AutumnGround;
using shuntamu.View.GameOver;

namespace shuntamu.View
{
    /// <summary>
    /// Mode の切り替えをするクラス
    /// </summary>
    class View
    {
        private static ModeBase[] _modes;
        public static int ModeNumber { get; set; }

        public View()
        {
            _modes = new ModeBase[2];
            ModeNumber = 0;
            _modes[0] = new GameMode1();
            _modes[1]=new GameOverMode();
        }

        public static ModeBase CurrentMode
        {
            get { return _modes[ModeNumber]; }
        }

        internal void Update()
        {
            CurrentMode.Update();
        }

        internal void Draw()
        {
            CurrentMode.Draw();
        }

        public static void Reset()
        {
           _modes[0]=new GameMode1();
            ModeNumber = 0;
        }
    }
}
