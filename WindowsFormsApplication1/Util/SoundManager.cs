using System.Collections.Generic;
using DxLibDLL;

namespace shuntamu.Util
{
    class SoundManager
    {
        private static SoundManager _instance;
        private Dictionary<string, int> _soundHandleDictionary = new Dictionary<string, int>();

        public static SoundManager Instance
        {
            get { return _instance ?? (_instance = new SoundManager()); }
            set { _instance = value; }
        }

        private SoundManager()
        {
            Load();
        }

        public Dictionary<string, int> SoundHandleDictionary
        {
            get { return _soundHandleDictionary; }
            set { _soundHandleDictionary = value; }
        }

        private void AddSound(string name, string path)
        {
            int handle = DX.LoadSoundMem(path);
            SoundHandleDictionary.Add(name,handle);
        }
        private void AddSound(string name, string path,int volume)
        {
            int handle = DX.LoadSoundMem(path);
            DX.ChangeVolumeSoundMem(volume, handle);
            SoundHandleDictionary.Add(name, handle);
        }

        private void Load()
        {
            AddSound("BGM", @"../../IWBT素材/音源/bgm_loop_103.wav",80);
            AddSound("onDeath", @"../../IWBT素材/音源/sndOnDeath.mp3",80);
            AddSound("jump", @"../../IWBT素材/音源/sndJump.wav");
            AddSound("invisBlock", @"../../IWBT素材/音源/sndBlockChange.wav",80);
        }

        public static void Play(string name,int playType)
        {
            if (DX.CheckSoundMem(Instance.SoundHandleDictionary[name]) == 0)
            {
                DX.PlaySoundMem(Instance.SoundHandleDictionary[name], playType);
            }
        }

        public static void Stop(string name)
        {
            DX.StopSoundMem(Instance.SoundHandleDictionary[name]);
        }

        public static void Stop()
        {
            foreach (var VARIABLE in Instance.SoundHandleDictionary)
            {
                DX.StopSoundMem(VARIABLE.Value);
            }
        }
    }
}
