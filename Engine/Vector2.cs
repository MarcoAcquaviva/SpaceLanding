using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLanding
{
    struct Vector2
    {
        public float X;
        public float Y;

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Vector2 Sub(Vector2 vec)
        {
            return new Vector2(X - vec.X, Y - vec.Y);
        }

        public float GetLength()
        {
            return (float)Math.Sqrt(X * X + Y * Y);
        }

        public void UpdateValue(int valueX,int valueY)
        {
            X += valueX;
            Y += valueY;
        }

        public void GetRandom(float minX, float maxX, float minY, float maxY)
        {
            X = RandomGenerator.GetRandom((int)minX, (int)maxX);
            Y = RandomGenerator.GetRandom((int)minY, (int)maxY);
        }

        public void AddRandom(float minX, float maxX, float minY, float maxY)
        {
            X += RandomGenerator.GetRandom((int)minX, (int)maxX);
            Y += RandomGenerator.GetRandom((int)minY, (int)maxY);
        }

        public void SetPosition(Vector2 position)
        {
            X = position.X;
            Y = position.Y;
        }
    }
}
