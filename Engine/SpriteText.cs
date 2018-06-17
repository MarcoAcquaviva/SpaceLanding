using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLanding
{
    class SpriteText
    {
        SpriteObj[] sprites = new SpriteObj[10];
        string text;

        public Vector2 Position;

        //public string Text
        //{
        //    get { return text; }
        //    set { SetText(text); }
        //}

        public SpriteText(Vector2 position, string text)
        {
            Position = position;
            if (text != "")
            {
                SetText(text);
            }
        }

        public void SetText(string text)
        {
            this.text = text;
            int numberChars = text.Length;
            int charX = (int)Position.X;
            int charY = (int)Position.Y;
            if (numberChars > sprites.Length)
            {
                numberChars = sprites.Length;
            }

            for (int i = 0; i < numberChars; i++)
            {
                char number = text[i];
                sprites[i] = new SpriteObj("Assets/numbers/numbers_" + number + ".png", charX, charY);
                charX += sprites[i].Sprite.width;
            }
        }

        public void Draw()
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                if (sprites[i] == null)
                {
                    return;
                }
                sprites[i].Draw();
            }
        }

        public void Translate(float deltaX, float deltaY)
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                if (sprites[i] != null)
                    sprites[i].Translate(deltaX, deltaY);
            }
        }
    }
}
