using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLanding
{
    static class LifeMng
    {
        static Heart[] hearts;
        static Vector2 startPosition;
        
        public static void Init(Vector2 startPosition, int numOfLifes, int offSetX)
        {
            hearts = new Heart[numOfLifes];
            for (int i = 0; i < hearts.Length; i++)
            {
               
                hearts[i] = new Heart(startPosition, 1, 2, 10,4);

                startPosition = new Vector2((startPosition.X - hearts[i].GetSprite().Width - offSetX), startPosition.Y);
            }
        }

        public static Heart GetAliveHeart()
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                if (hearts[i].IsAlive && !hearts[i].IsCursed)
                    return hearts[i];
            }
            return null;
        }

        public static void Update()
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                hearts[i].Update();
            }
        }

        public static void Draw()
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                if (hearts[i].IsAlive)
                {
                    hearts[i].Draw();
                }
            }
        }
    }
}
