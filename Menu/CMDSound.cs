using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLanding
{
    class CMDSound:BasicIndex
    {
        bool isPlaying;
        public CMDSound(Vector2 position, int numSprite, float fps)
        {
            //value
            this.position = position;
            IsAlive = true;
            isPlaying = true;

            //sprite
            this.numSprite = numSprite;
            cdSprite = fps;
            sprites = new string[numSprite];

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = "Assets/cmd/sound/" + i + ".png";
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
            if (isPlaying)
            {
                Index.audio.Stop();
                sprite.SetSprite(sprites[1]);
                isPlaying = false;
            }
            else
            {
                Index.audio.Play();
                sprite.SetSprite(sprites[0]);
                isPlaying = true;
            }
        }
    }
}
