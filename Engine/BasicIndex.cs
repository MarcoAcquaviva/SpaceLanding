using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLanding
{
    class BasicIndex
    {
        protected Vector2 position;
        protected Animation animation;
        protected SpriteObj sprite;
        protected int width, height, ray, numSprite;
        protected float verticalSpeed, verticalMaxSpeed, horizontalSpeed, horizontalMaxSpeed;
        protected string[] sprites;
        protected float cdSprite = 5f;
        bool isAlive;

        public Vector2 Position { get { return position; } set { position = value; } }
        public bool IsAlive { get { return isAlive; } set { isAlive = value; } }
        public int Radius { get { return ray; } }

        public void CheckClick()
        {
            if (isAlive)
            {
                if (GfxTools.Win.mouseX >= position.X - ray && GfxTools.Win.mouseX <= position.X + ray)
                {
                    if (GfxTools.Win.mouseY >= position.Y - height / 2 && GfxTools.Win.mouseY <= position.Y + height / 2)
                    {
                        OnCick();
                    }
                }
            }
        }

        public virtual void OnCick()
        {
            return;
        }

        public virtual void Draw()
        {
            if (isAlive)
                sprite.Draw();
        }
    }
}
