using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Draw;

namespace SpaceLanding
{
    class Score
    {
        Vector2 position;
        SpriteText[] scores;
        float speed, maxSpeed;
        bool isAlive;

        public Vector2 Position { get { return position; } set { position = value; } }
        public bool IsAlive { get { return isAlive; } set { isAlive = value; } }

        string[] tempLines = System.IO.File.ReadAllLines(@"score\score.txt");

        public Score()
        {
            position = new Vector2(GfxTools.Win.width / 3 * 2, GfxTools.Win.height / 2);
            speed = 0;
            maxSpeed = 40;
            scores = new SpriteText[tempLines.Length];
            for (int i = 0; i < tempLines.Length; i++)
            {
                scores[i] = new SpriteText(position, tempLines[i]);
                position.Y += 20;
            }
        }

        public void Input()
        {
            if (GfxTools.Win.GetKey(KeyCode.Down))
            {
                speed = maxSpeed;
            }
            else if (GfxTools.Win.GetKey(KeyCode.Up))
            {
                speed = -maxSpeed;
            }
            else
            {
                speed = 0;
            }
        }


        public void Update()
        {
            if (isAlive)
            {
                float deltaY = speed * GfxTools.Win.deltaTime;
                for (int i = 0; i < scores.Length; i++)
                {
                    scores[i].Position.Y += deltaY;
                    scores[i].Translate(0, deltaY);
                }
            }


        }

        public void Draw()
        {
            if (isAlive)
            {
                IndexClose close = Index.GetCmdClose();
                for (int i = 0; i < scores.Length; i++)
                {
                    if (scores[i].Position.Y >= close.Position.Y + close.Radius)
                        scores[i].Draw();
                }
            }
        }

        public void LoadData()
        {
            string[] tempLines = System.IO.File.ReadAllLines(@"score\score.txt");
            position = new Vector2(GfxTools.Win.width / 3 * 2, GfxTools.Win.height / 2);

            scores = new SpriteText[tempLines.Length];
            for (int i = 0; i < tempLines.Length; i++)
            {
                scores[i] = new SpriteText(position, tempLines[i]);
                position.Y += 20;
            }
        }
    }
}
