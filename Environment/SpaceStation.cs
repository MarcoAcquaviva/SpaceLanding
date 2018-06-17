using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLanding
{
    class SpaceStation : BasicObj
    {
        float cdSpawn;
        public SpaceStation(Vector2 position, int numSprite, float fps)
        {
            this.position = position;
            verticalSpeed = horizontalSpeed = cdSpawn = 0;
            cdSpawn = 30;
            IsAlive = false;

            this.numSprite = numSprite;
            cdSprite = fps;
            sprites = new string[numSprite];

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = "Assets/platform/" + i + ".png";
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
            cdSpawn -= GfxTools.Win.deltaTime;
            if (cdSpawn <= 0)
                IsAlive = true;
        }

        public bool CheckAlive()
        {
            return IsAlive;
        }
        //public override void Draw()
        //{
        //    if(cdSpawn<= 0)
        //    base.Draw();
        //}
    }
}
