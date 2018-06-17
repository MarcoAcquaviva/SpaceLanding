using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Draw;

namespace SpaceLanding
{
    static class Background
    {
        static Planet sprites;
        static private Vector2 position;
        static private int[] stars;

        static Background()
        {
            position = new Vector2(1, GfxTools.Win.height);

            sprites = new Planet(position, 8, 0, 50, 50);

            stars = new int[10];
        }

        public static void Update()
        {
            for (int i = 0; i < stars.Length; i++)
            {
            GfxTools.PutPixel(RandomGenerator.GetRandom(0, GfxTools.Win.width), RandomGenerator.GetRandom(0, GfxTools.Win.height),255, 255, 255);

            }
            sprites.Update();
        }

        public static void Draw()
        {            
            sprites.Draw();
        }
    }
}
