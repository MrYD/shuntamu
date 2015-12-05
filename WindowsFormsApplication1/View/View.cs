using shuntamu.View.AutumnGround;
using shuntamu.View.Clear;
using shuntamu.View.GameOver;

namespace shuntamu.View
{
    /// <summary>
    /// Mode の切り替えをするクラス
    /// </summary>
    class View
    {
        private static ModeBase[] _modes;
        private static int _modeNumber;

        public static int ModeNumber
        {
            get { return _modeNumber; }
            set
            {
                if (CurrentMode != null)
                {
                    CurrentMode.End();
                    _modeNumber = value;
                    CurrentMode.Init();
                }
                _modeNumber = value;
            }
        }

        public View()
        {
            _modes = new ModeBase[3];
            ModeNumber = 0;
            _modes[0] = new GameMode1();
            _modes[1] = new GameOverMode();
            _modes[2] = new ClearMode();
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
            ModeNumber = 0;
        }
    }
}
