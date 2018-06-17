using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Draw;

namespace SpaceLanding
{
    static class Index
    {
        static Window window;
        static Logo logo;
        static IndexPlay cmdPlay;
        static IndexScore cmdScore;
        static IndexCredits cmdCredits;
        static IndexClose cmdClose;
        static CMDSound  cmdSound;
        static Credits credits;
        static Score scores;
        static public Audio audio;

        static Index()
        {
            window = new Window(800, 600, "Home Page", PixelFormat.RGB);

            GfxTools.Init(window);

            //CMDLOGO
            Vector2 logoPosition;
            logoPosition.X = GfxTools.Win.width / 2;
            logoPosition.Y = 150;
            int numSpriteLogo = 1;
            float fpsLogo = 0;
            logo = new Logo(logoPosition, numSpriteLogo, fpsLogo);

            //CMDPLAY
            Vector2 playPosition;
            playPosition.X = GfxTools.Win.width / 2;
            playPosition.Y = 300;
            float fpsPalyer = 0;
            int numSpritePlayer = 1;
            int verticalMaxSpeedPlayer = Gravity.gravity * 3;
            int horizontalMaxSpeedPlayer = Gravity.gravity * 3;
            cmdPlay = new IndexPlay(playPosition, numSpritePlayer, fpsPalyer, verticalMaxSpeedPlayer, horizontalMaxSpeedPlayer);

            //CMDSCORE
            Vector2 scorePosition;
            scorePosition.X = GfxTools.Win.width / 2;
            scorePosition.Y = playPosition.Y + 100;
            float fpsScore = 0;
            int numSpriteScore = 1;
            int verticalMaxSpeedScore = Gravity.gravity * 3;
            int horizontalMaxSpeedScore = Gravity.gravity * 3;
            cmdScore = new IndexScore(scorePosition, numSpriteScore, fpsScore, verticalMaxSpeedScore, horizontalMaxSpeedScore);

            //CMDCREDITS
            Vector2 creditsPosition;
            creditsPosition.X = GfxTools.Win.width / 2;
            creditsPosition.Y = scorePosition.Y + 100;
            float fpsCredits = 0;
            int numSpriteCredits = 1;
            int verticalMaxSpeedCredits = Gravity.gravity * 3;
            int horizontalMaxSpeedCredits = Gravity.gravity * 3;
            cmdCredits = new IndexCredits(creditsPosition, numSpriteCredits, fpsCredits, verticalMaxSpeedCredits, horizontalMaxSpeedCredits);

            //CMDCLOSE
            Vector2 closePosition;
            closePosition.X = GfxTools.Win.width - 50;
            closePosition.Y = 100;
            float fpsClose = 0;
            int numSpriteClose = 1;
            int verticalMaxSpeedClose = Gravity.gravity * 3;
            int horizontalMaxSpeedClose = Gravity.gravity * 3;
            cmdClose = new IndexClose(closePosition, numSpriteClose, fpsClose, verticalMaxSpeedClose, horizontalMaxSpeedClose);

            //CMDSOUND
            Vector2 soundPosition;
            soundPosition.X = 100;
            soundPosition.Y = GfxTools.Win.height - 100;
            float fpsSound = 0;
            int numSpriteSound = 2;
            cmdSound = new CMDSound(soundPosition, numSpriteSound, fpsSound);
            

            //CREDITSTEXT
            Vector2 creditsTextPosition;
            creditsTextPosition.X = GfxTools.Win.width / 2;
            creditsTextPosition.Y = 300;
            float fpsCreditsText = 0;
            int numSpriteCreditsText = 1;
            int verticalMaxSpeedCreditsText = Gravity.gravity * 3;
            int horizontalMaxSpeedCreditsText = Gravity.gravity * 3;
            credits = new Credits(playPosition, numSpriteCreditsText, fpsCreditsText, verticalMaxSpeedCreditsText, horizontalMaxSpeedCreditsText);

            //SCORES
            scores = new Score();

            //AUDIO
            string[] audioPath = { @"Assets\media\index\Deep_In_Space.wav" };
            audio = new Audio(audioPath, true);
            audio.Play();
        }

        public static void Play()
        {
            while (window.opened)
            {
                GfxTools.Clean();

                //Input
                if (window.GetKey(KeyCode.Esc))
                    window.opened = false;
                scores.Input();

                //Update
                Background.Update();
                logo.Update();
                cmdPlay.Update();
                cmdCredits.Update();
                cmdScore.Update();
                cmdClose.Update();
                cmdSound.Update();
                Game.Play();
                scores.Update();


                //Draw
                Background.Draw();
                logo.Draw();
                cmdPlay.Draw();
                cmdCredits.Draw();
                cmdScore.Draw();
                cmdSound.Draw();
                scores.Draw();
                credits.Draw();
                cmdClose.Draw();


                window.Blit();
            }
        }

        public static Credits GetCredits()
        {
            return credits;
        }

        public static Score GetScore()
        {
            return scores;
        }

        public static IndexClose GetCmdClose()
        {
            return cmdClose;
        }

        public static void Wrap(bool wrapping)
        {
            if (wrapping)
            {
                //wrap
                cmdPlay.IsAlive = false;
                cmdScore.IsAlive = false;
                cmdCredits.IsAlive = false;
                logo.IsAlive = false;

                //unwrap
                cmdClose.IsAlive = true;
            }
            else
            {
                //wrap
                cmdClose.IsAlive = false;

                //unwrap
                cmdPlay.IsAlive = true;
                cmdScore.IsAlive = true;
                cmdCredits.IsAlive = true;
                logo.IsAlive = true;

            }
        }
    }
}
