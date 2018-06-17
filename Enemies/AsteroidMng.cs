using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLanding
{
    static class AsteroidMng
    {
        static Asteroid[] asteroids;

        public static void Init(int numOfAsteroid, int numSpriteAsteroid, float fpsAsteroid, float verticalMaxSpeedAsteroid, float horizontalMaxSpeedAsteroid)
        {
            asteroids = new Asteroid[numOfAsteroid];
            for (int i = 0; i < asteroids.Length; i++)
            {
                asteroids[i] = new Asteroid(numSpriteAsteroid, fpsAsteroid, verticalMaxSpeedAsteroid, horizontalMaxSpeedAsteroid);
            }
        }


        public static void Update()
        {
            for (int i = 0; i < asteroids.Length; i++)
            {
                asteroids[i].Update();
            }
        }

        public static void Draw()
        {
            for (int i = 0; i < asteroids.Length; i++)
            {
                if (asteroids[i].IsAlive)
                {
                    asteroids[i].Draw();
                }
            }
        }

    }
}
