using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLanding
{
    class Heart:BasicObj
    {
        bool isCursed = false;
        public bool IsCursed { get { return isCursed; } set { isCursed = value; } }

        public Heart(Vector2 position, int numSprite, float fps, float verticalMaxSpeed, float horizontalMaxSpeed)
        {
            this.position = position;
            verticalSpeed = horizontalSpeed = 0;
            this.verticalMaxSpeed = verticalMaxSpeed;
            this.horizontalMaxSpeed = horizontalMaxSpeed;
            IsAlive = true;
            this.numSprite = numSprite;
            cdSprite = fps;
            sprites = new string[numSprite];

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = "Assets/heart/" + i + ".png";
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
            if (isCursed)
            {
                Effect();
            }
        }

        public SpriteObj GetSprite()
        {
            return sprite;
        }

        public void Effect()
        {
            float counter = 0.02f;
            float deltaX = 0;
            float deltaY = 0;
            counter -= GfxTools.Win.deltaTime;
            if (counter > 0)
            {
                deltaX = RandomGenerator.GetRandom((int)-horizontalMaxSpeed, (int)horizontalMaxSpeed) * GfxTools.Win.deltaTime;
                position.X += deltaX;
                sprite.Translate(deltaX, 0);
            }else if(counter <= 0)
            {
                deltaY = (verticalMaxSpeed * GfxTools.Win.deltaTime);
                position.Y += deltaY;
                sprite.Translate(0,deltaY);
                if(position.Y <= GfxTools.Win.height)
                {
                  IsAlive = false;
                }
            }
        }
    }
}
