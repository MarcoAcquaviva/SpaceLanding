using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SpaceLanding
{
    class Logo:BasicIndex
    {
        bool isOpen;
        public Logo(Vector2 position, int numSprite, float fps)
        {
            //value
            this.position = position;
            verticalSpeed = horizontalSpeed = 0;
            IsAlive = true;
            isOpen = false;


            //sprite
            this.numSprite = numSprite;
            cdSprite = fps;
            sprites = new string[numSprite];

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = "Assets/cmd/logo/" + i + ".png";
            }

            sprite = new SpriteObj(sprites[0], position);
            animation = new Animation(sprites, sprite, cdSprite);

            width = sprite.Width;
            height = sprite.Height;
            ray = width / 2;
            sprite.Translate(-ray, -height / 2);
        }

        public void Update()
        {
            if (GfxTools.Win.mouseLeft)
            {
                CheckClick();
            }
        }

        public override void OnCick()
        {
            if(!isOpen)
            Process.Start("https://www.facebook.com/A-Duck-To-Remember-775967455928911/");
        }
    }
}
