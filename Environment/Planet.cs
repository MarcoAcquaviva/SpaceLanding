using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLanding
{
    class Planet : BasicObj
    {
        int indexPlanet;
        public Planet(Vector2 position, int numSprite, float fps, float verticalMaxSpeed, float horizontalMaxSpeed)
        {
            this.position = position;
            position.AddRandom(0, GfxTools.Win.width / 2, -GfxTools.Win.height / 2, 0);
            this.verticalMaxSpeed = verticalMaxSpeed;
            this.horizontalMaxSpeed = horizontalMaxSpeed;
            do
            {
                horizontalSpeed = RandomGenerator.GetRandom(-(int)this.horizontalMaxSpeed, (int)this.horizontalMaxSpeed);
                verticalSpeed = RandomGenerator.GetRandom(-(int)this.verticalMaxSpeed, (int)this.verticalMaxSpeed);

            } while (verticalSpeed == 0 || horizontalSpeed == 0);
            IsAlive = true;
            this.numSprite = numSprite;
            cdSprite = fps;
            indexPlanet = 0;
            sprites = new string[numSprite];

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = "Assets/background/" + i + ".png";
            }


            sprite = new SpriteObj(sprites[indexPlanet], position);
            animation = new Animation(sprites, sprite, cdSprite);

            width = sprite.Width;
            height = sprite.Height;
            ray = width / 2;
            sprite.Translate(-ray, -height / 2);
        }

        public void Update()
        {
            float Xdelta = ((horizontalSpeed * GfxTools.Win.deltaTime));
            float Ydelta = ((verticalSpeed * GfxTools.Win.deltaTime));
            position.X += Xdelta;
            position.Y -= Ydelta;


            sprite.Translate(Xdelta, -Ydelta);

            if (position.X + width <= 0 || position.X >= GfxTools.Win.width)
            {
                if (position.Y + height <= 0)
                {
                    Respawn(sprite.Width / 2 + 1, GfxTools.Win.width - sprite.Width, GfxTools.Win.height - sprite.Height, GfxTools.Win.height - sprite.Height / 2);
                }
                else if (position.Y - height / 2 > GfxTools.Win.height)
                {
                    Respawn(sprite.Width / 2 + 1, GfxTools.Win.width - sprite.Width, sprite.Height, GfxTools.Win.height / 2 + sprite.Height);
                }

            }
        }

        public void Respawn(float minX, float maxX, float minY, float maxY)
        {
            //change planet
            int tempIndex = indexPlanet;
            do
            {
                indexPlanet = RandomGenerator.GetRandom(0, numSprite);
            } while (tempIndex == indexPlanet);
            sprite.SetSprite(sprites[indexPlanet]);

            //change angle
            verticalSpeed = RandomGenerator.GetRandom(-(int)this.verticalMaxSpeed, (int)this.verticalMaxSpeed);
            if (position.X < GfxTools.Win.width / 2)
                horizontalSpeed = RandomGenerator.GetRandom((int)this.horizontalMaxSpeed / 3, (int)this.horizontalMaxSpeed);
            else if (position.X > GfxTools.Win.width / 2)
                horizontalSpeed = RandomGenerator.GetRandom(-(int)this.horizontalMaxSpeed , -(int)this.horizontalMaxSpeed/3);

            //reset position
            position.GetRandom(minX, minX, minY, maxY);
            sprite.SetPosition(position);
            sprite.Translate(-ray, -height / 2);
            IsAlive = true;
        }

        public override void Draw()
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                sprite.Draw();
            }
        }
    }
}
