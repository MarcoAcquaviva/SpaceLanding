using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Draw;

namespace SpaceLanding
{
    class SpriteObj
    {
        private Sprite sprite;
        private Vector2 position;
        private int height, width;

        public Sprite Sprite { get { return sprite; } }
        public Vector2 Position { get { return position; } set { position = value; } }
        public int Height { get { return height; } }
        public int Width { get { return width; } }

        public SpriteObj(string fileName, float x, float y)
        {
            sprite = new Sprite(fileName);
            position.X = x;
            position.Y = y;
            width = sprite.width;
            height = sprite.height;
        }

        public SpriteObj(string fileName, Vector2 position) :
            this(fileName, position.X, position.Y)
        {

        }

        public SpriteObj(Sprite sprite)
        {
            this.sprite = sprite;
        }

        public void Translate(Vector2 offset)
        {
            position.X += offset.X;
            position.Y += offset.Y;
        }

        public void Translate(float x, float y)
        {
            position.X += x;
            position.Y += y;
        }

        public void UpdatePosition(Vector2 Position)
        {
            this.Position = Position;
        }

        public void SetSprite(Sprite newSprite)
        {
            sprite = newSprite;
        }

        public void SetSprite(string newSpriteString)
        {
            sprite = new Sprite(newSpriteString);
        }

        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }

        public void Draw()
        {
            GfxTools.DrawSprite(sprite, (int)position.X, (int)position.Y);
        }
    }
}
