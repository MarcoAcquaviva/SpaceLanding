using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLanding
{
    class Asteroid:BasicObj
    {
        float counterMovement;
        float counterRespawn = RandomGenerator.GetRandom(2, 10);

        public Asteroid( int numSprite, float fps, float verticalMaxSpeed, float horizontalMaxSpeed)
        {
            verticalSpeed = (RandomGenerator.GetRandom((int)1,(int)+verticalMaxSpeed)) ;
            horizontalSpeed = (RandomGenerator.GetRandom((int)1, (int)+horizontalMaxSpeed))  ;
            this.verticalMaxSpeed = verticalMaxSpeed;
            this.horizontalMaxSpeed = horizontalMaxSpeed;
            IsAlive = false;
            this.numSprite = numSprite;
            cdSprite = fps;
            sprites = new string[numSprite];

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = "Assets/asteroid/" + i + ".png";
            }

            sprite = new SpriteObj(sprites[0], position);
            animation = new Animation(sprites, sprite, cdSprite);

            position.GetRandom(sprite.Width, GfxTools.Win.width / 2 + sprite.Width + 10, 1, 10);
            sprite.SetPosition(position);
            width = sprite.Width;
            height = sprite.Height;
            ray = width / 2;
            sprite.Translate(-ray, -height / 2);
        }
        public void Update()
        {            
            if (IsAlive)
            {
                animation.Update();
                width = sprite.Width;
                height = sprite.Height;
                counterMovement += GfxTools.Win.deltaTime;
                float deltaX = horizontalSpeed*GfxTools.Win.deltaTime;
                float deltaY = verticalSpeed*GfxTools.Win.deltaTime;
                if (counterMovement >= 0.01)
                {
                    position.X += deltaX;
                    position.Y += deltaY;

                    sprite.Translate(deltaX, deltaY);
                    counterMovement = 0;
                }

                Player player = Game.GetPlayer();
                if (player.IsAlive && IsAlive)
                {
                if (OnCollisionEnter(player.Position, player.Radius))
                {
                    Game.AddScore(-10);
                    player.OnHit();
                    IsAlive = false;
                }

                }
            }
            else if (!IsAlive)
            {
                counterRespawn -= GfxTools.Win.deltaTime;
                if (counterRespawn <= 0)
                {
                    Respawn();
                }
            }
        }
        public void Respawn()
        {
            position.GetRandom(sprite.Width, GfxTools.Win.width / 2 + sprite.Width + 10, 1, 10);
            sprite.SetPosition(position);
            horizontalSpeed = (RandomGenerator.GetRandom((int)0, (int)+horizontalMaxSpeed)) ;
            verticalSpeed = (RandomGenerator.GetRandom((int)0, (int)+verticalMaxSpeed));
            IsAlive = true;
            counterRespawn = RandomGenerator.GetRandom(2, 5); 
        }



        public bool OnCollisionEnter(Vector2 centerPosition, float ray)
        {
            Vector2 dist = Position.Sub(centerPosition);
            return (dist.GetLength() <= width / 2 + ray);
        }
    }
}
