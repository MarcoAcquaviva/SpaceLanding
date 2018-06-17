using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Aiv.Draw;

namespace SpaceLanding
{
    sealed class Player : BasicObj
    {
        int nrg;
        float mass, force;

        //score
        float counterScore = 0;

        //danger variable
        SpriteObj danger;
        Vector2 dangerPosition = new Vector2(20, 15);

        //platform checker
        bool checkPlatform;
        float scoreWinner;


        public Player(Vector2 position, int numSprite, float fps, float verticalMaxSpeed, float horizontalMaxSpeed, int numOfLifes)
        {
            this.position = position;
            verticalSpeed = horizontalSpeed = 0;
            this.verticalMaxSpeed = verticalMaxSpeed;
            this.horizontalMaxSpeed = horizontalMaxSpeed;
            IsAlive = true;
            nrg = numOfLifes;
            mass = 50f;
            force = mass * verticalSpeed;



            this.numSprite = numSprite;
            cdSprite = fps;
            sprites = new string[numSprite];

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = "Assets/rocket/" + i + ".png";
            }

            sprite = new SpriteObj(sprites[0], position);
            animation = new Animation(sprites, sprite, cdSprite);

            width = sprite.Width;
            height = sprite.Height;
            ray = width / 2;
            sprite.Translate(-ray, -height / 2);

            //danger Sprite
            danger = new SpriteObj("Assets/danger/0.png", dangerPosition);

            //platform
            scoreWinner = 100;
        }

        public void Input()
        {
            if (GfxTools.Win.GetKey(KeyCode.W))
            {
                verticalSpeed += verticalMaxSpeed * GfxTools.Win.deltaTime;
                sprite.SetSprite("Assets/rocket/5.png");
            }
            else if (GfxTools.Win.GetKey(KeyCode.S))
            {
                verticalSpeed += (Gravity.gravity * GfxTools.Win.deltaTime - verticalMaxSpeed * GfxTools.Win.deltaTime);
                sprite.SetSprite("Assets/rocket/5.png");
            }
            else
            {
                verticalSpeed -= Gravity.gravity * GfxTools.Win.deltaTime;
                sprite.SetSprite("Assets/rocket/2.png");
            }

            if (GfxTools.Win.GetKey(KeyCode.D))
            {
                horizontalSpeed += horizontalMaxSpeed * GfxTools.Win.deltaTime;
                sprite.SetSprite("Assets/rocket/7.png");
            }
            else if (GfxTools.Win.GetKey(KeyCode.A))
            {
                horizontalSpeed -= horizontalMaxSpeed * GfxTools.Win.deltaTime;
                sprite.SetSprite("Assets/rocket/4.png");
            }
        }

        public void Update()
        {

            //player move
            float deltaY = verticalSpeed * GfxTools.Win.deltaTime;
            float deltaX = horizontalSpeed * GfxTools.Win.deltaTime;
            position.X += deltaX;
            position.Y -= deltaY;

            force = (mass * verticalSpeed) / 100;

            sprite.Translate(deltaX, -deltaY);

            //force checker
            if (force < -80f)
            {
                danger.Draw();
            }
            //heart checker
            int lifePoint = nrg * 50;
            //platform checker
            SpaceStation platform = Game.GetPlatform();
            checkPlatform = platform.CheckAlive();
            if (checkPlatform)
                scoreWinner += GfxTools.Win.deltaTime;

            //platform collision
            if (OnPlatformEnter())
            {
                verticalSpeed = 0;
                horizontalSpeed = 0;
                Game.AddScore((int)scoreWinner + lifePoint);
                GUI gui = Game.GetGUI();
                gui.YouWin();
                Game.isPlayble = false;
                Game.isSavable = true;
                Game.Exit();
            }

            //player score

            if (IsAlive && !OnPlatformEnter())
            {
                counterScore += 0.9f * GfxTools.Win.deltaTime;
                if (counterScore >= 1)
                {
                    Game.AddScore(1);
                    counterScore = 0;
                }
            }

        }

        public override void Draw()
        {
            base.Draw();

            //if (IsAlive)
            //    GfxTools.DrawRect((int)position.X, (int)position.Y, sprite.Width, sprite.Height, 255, 255, 255);
        }

        public bool OnPlatformEnter()
        {
            SpaceStation platform = Game.GetPlatform();

            if (platform.IsAlive)
            {
                if (position.Y + height / 2 >= platform.Position.Y)
                {
                    if (position.X - ray >= platform.Position.X - platform.Radius && position.X + ray <= platform.Position.X + platform.Radius)
                    {
                        if (force >= -100f)
                        {

                            return true;
                        }
                        else
                        {
                            IsAlive = false;
                        }
                    }

                }

            }

            return false;
        }

        public bool OnHit()
        {
            nrg--;
            Heart heart = LifeMng.GetAliveHeart();
            heart.IsCursed = true;
            if (nrg <= 0)
            {
                IsAlive = false;
            }
            return true;
        }

        public bool GameOver()
        {
            if (!StillAlive() || nrg <= 0)
            {
                for (int i = 0; i < nrg; i++)
                {
                    Heart heart = LifeMng.GetAliveHeart();
                    heart.IsCursed = true;
                    nrg--;
                }
                return true;
            }
            return false;
        }
    }
}
