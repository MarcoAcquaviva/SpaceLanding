using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLanding
{
    static class Explosion
    {
        static Vector2 position;
        static SpriteObj sprite;
        static string[] sprites;
        static Animation animation;
        static int fps;
        public static Vector2 Position { get {return position; } }

        static Explosion()
        {
            Player player = Game.GetPlayer();
            position = new Vector2(player.Position.X, player.Position.Y);
            fps = 15;
            sprites = new string[9];
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = "Assets/explosion/regularExplosion0" + i + ".png";
            }

            sprite = new SpriteObj(sprites[0], position);
            animation = new Animation(sprites, sprite, fps)
            {
                Loop = true
            };
            animation.Stop();
        }

        public static void SetPosition(Vector2 newPosition, float deltaX, float deltaY)
        {
            position = newPosition;
            sprite.Translate(deltaX,deltaY);
        }

        public static void SetPosition(float newPositionX, float newPositionY)
        {
            position.X += newPositionX;
            position.Y += newPositionY;
            sprite.Translate(newPositionX, newPositionY);
        }

        public static void Update()
        {
            animation.Start();
            animation.Update();
        }

        public static void Draw()
        {
            if (animation.IsPlaying)
            {
                sprite.Draw();
            }
        }
    }
}
