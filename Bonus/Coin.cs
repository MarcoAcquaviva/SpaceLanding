using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLanding
{
    sealed class Coin : BasicObj
    {
        float counterMovement;
        float counterSpawn = 0;
        Audio audio;
        public Coin(Vector2 position, int numSprite, float fps, float verticalMaxSpeed, float horizontalMaxSpeed)
        {
            this.position = position;
            verticalSpeed = horizontalSpeed = 0;
            this.verticalMaxSpeed = verticalMaxSpeed;
            this.horizontalMaxSpeed = horizontalMaxSpeed;
            IsAlive = false;
            this.numSprite = numSprite;
            cdSprite = fps;
            sprites = new string[numSprite];

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = "Assets/coin/" + i + ".png";
            }

            sprite = new SpriteObj(sprites[3], position);
            animation = new Animation(sprites, sprite, cdSprite);

            width = sprite.Width;
            height = sprite.Height;
            ray = width / 2;
            sprite.Translate(-ray, -height / 2);
            

            //AUDIO
            string[] audioPath = { @"Assets\media\coin\coin_1_a.wav" };
            audio = new Audio(audioPath, false);
        }

        public void Update()
        {
            if (IsAlive)
            {
                animation.Start();
                animation.Update();
                counterMovement += GfxTools.Win.deltaTime;
                float deltaX = (RandomGenerator.GetRandom((int)0, (int)+horizontalMaxSpeed)) * GfxTools.Win.deltaTime;
                float deltaY = (RandomGenerator.GetRandom((int)-verticalMaxSpeed, (int)+verticalMaxSpeed)) * GfxTools.Win.deltaTime;
                if (counterMovement >= 1.25f)
                {
                    position.X += deltaX;
                    position.Y += deltaY;

                    sprite.Translate(deltaX, deltaY);
                    counterMovement = 0;
                }

                Player player = Game.GetPlayer();

                if (player.IsAlive)
                {
                    if (OnCollisionEnter(player.Position, player.Radius))
                    {
                        Game.AddScore(10);
                        //audio.Play();
                        IsAlive = false;
                        //Index.audio.Play();
                    }

                }

            }
            else if (!IsAlive)
            {
                counterSpawn += GfxTools.Win.deltaTime;
                if (counterSpawn >= 10)
                {
                    Respawn();
                }

                animation.Stop();
            }
        }

        public void Respawn()
        {
            position.GetRandom(sprite.Width + 10, sprite.Width + 50, sprite.Height + 10, GfxTools.Win.height - 10);
            sprite.SetPosition(position);
            IsAlive = true;
            counterSpawn = 0;
        }


        public bool OnCollisionEnter(Vector2 centerPosition, float ray)
        {
            Vector2 dist = Position.Sub(centerPosition);
            return (dist.GetLength() <= width / 2 + ray);
        }
    }
}
