using System;using System.Collections.Generic;using System.Drawing;using System.IO.Packaging;using System.Linq;using System.Text;using System.Threading.Tasks;using System.Windows;using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApplication1{    public class World    {        private Random r = new Random();        public List<Ball> _balls_on_field;
        public Cue cue;
        public HelpingLine hLine;

        public List<List<int>> positions = new List<List<int>>() { new List<int> {850,325},
            new List<int> {881,325},new List<int> {912,325},new List<int> {943,325},
            new List<int> {881,356},new List<int> {912,356},new List<int> {943,356},
            new List<int> {912,387},new List<int> {943,387},new List<int> {943,418},
            new List<int> {881,294},new List<int> {912,294},new List<int> {943,294},
            new List<int> {912,263},new List<int> {943,263},new List<int> {943,232},
        };



        private List<Ball> ResetGame()
        {
            List<Ball> ballsAholls = new List<Ball>()
            {
                new ColoredBall(Color.Yellow, false),
                new ColoredBall(Color.Blue, false),
                new ColoredBall(Color.Red, false) ,
                new ColoredBall(Color.Purple, false),
                new ColoredBall(Color.Orange, false) ,
                new ColoredBall(Color.Green, false),
                new ColoredBall(Color.DarkRed, false),
                new ColoredBall(Color.Black, false),
                new ColoredBall(Color.Yellow, true) ,
                new ColoredBall(Color.Blue, true),
                new ColoredBall(Color.Red, true) ,
                new ColoredBall(Color.Purple, true) ,
                new ColoredBall(Color.Orange, true),
                new ColoredBall(Color.Green, true),
                new ColoredBall(Color.DarkRed, true) ,
                new ColoredBall(Color.Black, true),


            };

            List<int> used = new List<int>();

            foreach (var ball in ballsAholls)
            {
                int Pindex = r.Next(15);
                if (!used.Contains(Pindex))
                {
                    ball.DefX = (float)positions[Pindex][0];
                    ball.DefY = (float)positions[Pindex][1];
                    used.Add(Pindex);
                }
            }

            List<Hole> holes = new List<Hole>() { new Hole() { DefX = 60, DefY = 58 },
                new Hole() { DefX = 650, DefY = 50 },
                new Hole() { DefX = 1238, DefY = 57 },

                new Hole() { DefX = 60, DefY = 621 },
                new Hole() { DefX = 650, DefY = 625 },
                new Hole() { DefX = 1238, DefY = 621 } };


            ballsAholls.AddRange(holes);

            return ballsAholls;
        }
        private int _width;        private int _height;        public World(int width, int height)        {            _balls_on_field = this.ResetGame();
            cue = new Cue();
            hLine = new HelpingLine();            foreach (var ball in _balls_on_field)
            {
                ball.ResetPosition();
            }            this._width = width;            this._height = height;        }

        public void Regenerate()
        {
            _balls_on_field = this.ResetGame();

            foreach (var ball in _balls_on_field)
            {
                ball.ResetPosition();
            }
        }

        public void AddBall(Ball b)        {            this._balls_on_field.Add(b);        }        public void Next()        {            foreach (Ball ball in _balls_on_field)            {                ball.Move();                ball.Collide(this._width, this._height);            }
        }        public void Render(Graphics g)        {
            this.cue.Render(g);
            this.hLine.Render(g);

            for (int i = 0; i < this._balls_on_field.Count; i++)            {                Ball a = this._balls_on_field[i];                a.Render(g);                for (int j = i + 1; j < this._balls_on_field.Count; j++)                {                    Ball b = this._balls_on_field[j];                    this.Collide(a, b);                }            }        }        private void Collide(Ball b1, Ball b2)        {
            //pythagorus
            float xDifferece = b1.X - b2.X;
            float yDifferece = b1.Y - b2.Y;
            float hypotenuse2 = Convert.ToSingle(Math.Pow(xDifferece, 2) + Math.Pow(yDifferece, 2));


            if (Math.Sqrt(hypotenuse2) <= (b1.Radius + b2.Radius + b2.Radius))
            {

                if (b2 is Hole || b1 is Hole)
                {
                    Debug.WriteLine("ball is in the hole.");
                    b2.Vx = 0;
                    b2.Vy = 0;
                    b1.Vx = 0;
                    b1.Vy = 0;

                    if (b2 is Hole)
                    {
                        if (b1 is WhiteBall)
                            b1.ResetPosition();
                        else
                            _balls_on_field.Remove(b1);
                    }
                    else
                    {
                        if (b2 is WhiteBall)
                            b2.ResetPosition();
                        else
                            _balls_on_field.Remove(b2);
                    }

                }
                else
                {
                    float Vx = b2.Vx - b1.Vx;
                    float Vy = b2.Vy - b1.Vy;
                    float dotProduct = xDifferece * Vx + yDifferece * Vy;

                    if (dotProduct > 0)
                    {
                        float collisionScale = dotProduct / hypotenuse2;

                        float xCollision = (xDifferece * collisionScale);
                        float yCollision = (yDifferece * collisionScale);
                        float combinedMass = b1.Mass + b2.Mass;

                        float collisionWeightA = 2 * b2.Mass / combinedMass;
                        float collisionWeightB = 2 * b1.Mass / combinedMass;

                        b1.Vx += collisionWeightA * xCollision;
                        b1.Vy += collisionWeightA * yCollision;
                        b2.Vx -= collisionWeightB * xCollision;
                        b2.Vy -= collisionWeightB * yCollision;
                    }
                }
            }        }    }}