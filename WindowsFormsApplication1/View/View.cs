using shuntamu.View.AutumnGround;

namespace shuntamu.View
{
    /// <summary>
    /// Mode の切り替えをするクラス
    /// </summary>
    class View
    {
        private readonly ModeBase[] _modes;
        public int ModeNumber { get; set; }

        public View()
        {
            _modes = new ModeBase[1];
            ModeNumber = 0;
            _modes[0] = new GameMode1();
        }

        public ModeBase CurrentMode
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
    }
}
