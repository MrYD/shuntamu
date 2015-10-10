using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace shuntamu.Util
{
    internal class Input
    {
        private static Input _Instance;
        private byte[] Buf=new byte[256];

        public static Input Instance
        {
            get
            {
                if (_Instance == null)
                {
                    return _Instance = new Input();
                }
                else
                {
                    return _Instance;
                }
            }
        }
      


        public bool Right
        {
            get
            {
                if (Buf[DX.KEY_INPUT_RIGHT] == 1) return true;
                else
                {
                    return false;
                }
            }

        }

        public bool Left
        {
            get
            {
                if (Buf[DX.KEY_INPUT_LEFT] == 1) return true;
                else
                {
                    return false;
                }
            }
        }

        public bool Up
        {
            get
            {
                if (Buf[DX.KEY_INPUT_UP] == 1) return true;
                else
                {
                    return false;
                }
            }
        }

        public bool Down
        {
            get
            {
                if (Buf[DX.KEY_INPUT_DOWN] == 1) return true;
                else
                {
                    return false;
                }
            }
        }

        public bool Space
        {
            get
            {
                if (Buf[DX.KEY_INPUT_SPACE] == 1) return true;
                else
                {
                    return false;
                }
            }
        }

        public bool LeftShift
        {
            get
            {
                if (Buf[DX.KEY_INPUT_LSHIFT] == 1) return true;
                else
                {
                    return false;
                }
            }
        }

        public void Update()
        {
            DX.GetHitKeyStateAll(out Buf[0]);
        }
    }
}
