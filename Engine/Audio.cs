using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace SpaceLanding
{
    class Audio
    {
        SoundPlayer player;
        string[] audio;
        bool isLoop;

        public bool IsLoop
        {
            get
            {
                return IsLoop;
            }

            set
            {
                isLoop = value;
            }
        }

        public Audio(string[] audios, bool isLooping)
        {
            SetAudio(audios);
            player = SetPlayer();
            isLoop = isLooping;
        }

        void SetAudio(string[] audios)
        {
            this.audio = new string[audios.Length];
            for (int i = 0; i < audios.Length; i++)
            {
                this.audio[i] = audios[i];
            }            
        }

        SoundPlayer SetPlayer()
        {
            int random = RandomGenerator.GetRandom(0, audio.Length);
            player = new SoundPlayer(audio[random]);
            return player;
        }

        public void Play()
        {
            if (!isLoop)
                player.Play();
            else
                player.PlayLooping();
        }

        public void Stop()
        {
            player.Stop();
        }

    }
}
