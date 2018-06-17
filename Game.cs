using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Draw;
using System.Threading;

namespace SpaceLanding
{
    static class Game
    {
        static Player player;
        static Coin coin;
        static Asteroid asteroid;
        static SpaceStation platform;
        static SpriteText scoreText;
        static GUI gui;
        static Audio audio;
        static int score;
        static private float cd_exit = 1.5f;
        static public bool isAlive = false;
        static public bool isPlayble = true;
        static public bool isSavable = false;

        static Game()
        {
            Reset();
        }

        public static void Play()
        {
            while (isAlive && isPlayble)
            {
                GfxTools.Clean();
                //Input
                if (GfxTools.Win.GetKey(KeyCode.P))
                {
                    Exit();
                }


                player.Input();

                //Update
                Update();
                Background.Update();
                coin.Update();
                AsteroidMng.Update();
                platform.Update();
                player.Update();
                LifeMng.Update();


                //Draw
                Background.Draw();
                coin.Draw();
                AsteroidMng.Draw();
                platform.Draw();
                player.Draw();
                Explosion.Draw();
                scoreText.Draw();
                LifeMng.Draw();
                gui.Draw();


                GfxTools.Win.Blit();
            }
            if (!isAlive && !isPlayble && isSavable)
                SaveData();

        }

        public static Player GetPlayer()
        {
            return player;
        }

        public static SpaceStation GetPlatform()
        {
            return platform;
        }

        public static GUI GetGUI()
        {
            return gui;
        }

        public static void AddScore(int amount)
        {
            if (score + amount >= 0)
            {
                score += amount;
                scoreText.SetText(score.ToString("D6"));
            }
            else
            {
                score = 0;
                scoreText.SetText(score.ToString("D6"));
            }
        }

        public static void Update()
        {
            if (player.GameOver())
            {
                cd_exit -= GfxTools.Win.deltaTime;
                gui.GameOver();
                if (cd_exit <= 0)
                {
                    //audio.Play();
                    Exit();
                    isPlayble = false;
                    isSavable = true;
                }
            }
        }

        static void SaveData()
        {
            string scoreText = CheckScore(score);

            using (System.IO.StreamWriter file =
    new System.IO.StreamWriter(@"score\score.txt", true))
            {
                file.WriteLine(scoreText);
            }

            string[] tempLines = System.IO.File.ReadAllLines(@"score\score.txt");

            Array.Sort(tempLines);

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"score\score.txt"))
            {
                foreach (string line in tempLines)
                {
                    {
                        file.WriteLine(line);
                    }
                }
            }

            isSavable = false;
        }

        static string CheckScore(int score)
        {
            if (score < 10)
            {
                return "00000" + score;
            }
            else if (score >= 10 && score < 100)
            {
                return "0000" + score;
            }
            else if (score >= 100 && score < 1000)
            {
                return "000" + score;
            }
            else if (score >= 1000 && score < 10000)
            {
                return "00" + score;
            }
            else if (score >= 10000 && score < 100000)
            {
                return "0" + score;
            }
            else if (score >= 999999)
            {
                return "999999";
            }
            else
            {
                return score.ToString("D6");
            }
        }

        public static void Exit()
        {
            isAlive = false;
            Index.Wrap(false);
        }

        public static void Reset()
        {
            //PLAYER
            Vector2 playerPos;
            playerPos.X = GfxTools.Win.width / 2;
            playerPos.Y = GfxTools.Win.height - 100;
            float fpsPalyer = 20;
            int numSpritePlayer = 8;
            int verticalMaxSpeedPlayer = Gravity.gravity * 3;
            int horizontalMaxSpeedPlayer = Gravity.gravity * 3;
            int numOfLifes = 3;
            player = new Player(playerPos, numSpritePlayer, fpsPalyer, verticalMaxSpeedPlayer, horizontalMaxSpeedPlayer, numOfLifes);

            //COIN
            Vector2 coinPosition = new Vector2(50, RandomGenerator.GetRandom(50, GfxTools.Win.height - 50));
            float fpsCoin = 8;
            int numSpriteCoin = 6;
            float verticalMaxSpeedCoin = Gravity.gravity * 150f;
            float horizontalMaxSpeedCoin = Gravity.gravity * 100f;
            coin = new Coin(coinPosition, numSpriteCoin, fpsCoin, verticalMaxSpeedCoin, horizontalMaxSpeedCoin);

            //ASTEROID
            Vector2 asteroidPosition = new Vector2(80, RandomGenerator.GetRandom(50, GfxTools.Win.height - 50));
            float fpsAsteroid = 24;
            int numSpriteAsteroid = 64;
            float verticalMaxSpeedAsteroid = Gravity.gravity * 7.52f;
            float horizontalMaxSpeedAsteroid = Gravity.gravity * 2.5f;
            int numOfAsteroid = 4;
            asteroid = new Asteroid(numSpriteAsteroid, fpsAsteroid, verticalMaxSpeedAsteroid, horizontalMaxSpeedAsteroid);
            AsteroidMng.Init(numOfAsteroid, numSpriteAsteroid, fpsAsteroid, verticalMaxSpeedAsteroid, horizontalMaxSpeedAsteroid);

            //LIFE
            Vector2 lifePosition = new Vector2(GfxTools.Win.width - 50, 20);
            int offSetX = 30;
            LifeMng.Init(lifePosition, numOfLifes, offSetX);

            //PLATFORM
            Vector2 platformPosition = new Vector2(GfxTools.Win.width / 2, GfxTools.Win.height - 30);
            float fpsPlatform = 0;
            int numSpritePlatform = 1;
            //int verticalMaxSpeedPlatform = 0;
            //int horizontalMaxSpeedPlatform = 0;
            platform = new SpaceStation(platformPosition, numSpritePlatform, fpsPlatform);

            //SCORE
            score = 0;
            scoreText = new SpriteText(new Vector2(GfxTools.Win.width / 4, 20), "000000");

            //GUI
            Vector2 guiPosition = new Vector2(GfxTools.Win.width / 2, GfxTools.Win.height / 2);
            int numSpriteGui = 2;
            gui = new GUI(guiPosition, numSpriteGui);

            //AUDIOGAMEOVER
            string[] audioPath = { @"Assets\media\gameover\decrease_bell_3.wav" };
            audio = new Audio(audioPath, false);
        }
    }
}
