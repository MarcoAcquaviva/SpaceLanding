using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLanding
{
    class GUI:BasicObj
    {
        public GUI(Vector2 position, int numSprite  )
        {
            this.position = position;
            IsAlive = false;
            this.numSprite = numSprite;
            sprites = new string[numSprite];

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = "Assets/GUI/" + i + ".png";
            }

            sprite = new SpriteObj(sprites[0], position);

            width = sprite.Width;
            height = sprite.Height;
            ray = width / 2;
            sprite.Translate(-ray, -height / 2);
        }

        public void YouWin()
        {
            IsAlive = true;
            sprite.SetSprite("Assets/GUI/1.png");
        }

        public void GameOver()
        {
            IsAlive = true;
            sprite.SetSprite("Assets/GUI/0.png");
        }
    }
}
