using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Draw;

namespace SpaceLanding
{
    class BasicObj
    {
        protected Vector2 position;
        protected Animation animation;
        protected SpriteObj sprite;
        protected int width, height, ray,numSprite;
        protected float verticalSpeed, verticalMaxSpeed, horizontalSpeed, horizontalMaxSpeed;
        protected string[] sprites;
        protected float cdSprite = 5f;
        bool isAlive;

        public Vector2 Position { get { return position; } set { position = value; } }
        public bool IsAlive { get { return isAlive; } set { isAlive = value; } }
        public int Radius { get { return ray; } }

        public bool StillAlive()
        {
            if (position.X + width/2 > GfxTools.Win.width || position.X -width/2 < 0 || position.Y + height/2 > GfxTools.Win.height || position.Y+height/2  < 0)
            {
                isAlive = false;
                return false;
            }
            return true;
        }

        public virtual void Draw()
        {
            if(StillAlive()&& isAlive)
            sprite.Draw();
        }
    }
}
