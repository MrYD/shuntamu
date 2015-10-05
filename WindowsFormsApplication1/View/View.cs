using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shuntamu.View
{
    class View
    {
        private Mode[] modes;
        public int ModeNumber { get; set; }

        public View()
        {
            modes=new Mode[1];
            ModeNumber = 0;
            modes[0]=new GameMode1();
        }

        public Mode CurrentMode
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
