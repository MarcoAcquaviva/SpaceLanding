using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLanding
{
    class IndexClose:BasicIndex
    {
        public IndexClose(Vector2 position, int numSprite, float fps, float verticalMaxSpeed, float horizontalMaxSpeed)
        {
            //value
            this.position = position;
            verticalSpeed = horizontalSpeed = 0;
            this.verticalMaxSpeed = verticalMaxSpeed;
            this.horizontalMaxSpeed = horizontalMaxSpeed;
            IsAlive = false;


            //sprite
            this.numSprite = numSprite;
            cdSprite = fps;
            sprites = new string[numSprite];

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = "Assets/cmd/close/" + i + ".png";
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
            Index.Wrap(false);
            Credits credits = Index.GetCredits();
            credits.IsAlive = false;
            Score scores = Index.GetScore();
            scores.IsAlive = false;

        }
    }
}
