using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public abstract class Ball
    {
        public int Id { get; set; }

        public float DefX { get; set; }
        public float DefY { get; set; }
        public Color Color { get; set; }
        public Color BorderColor { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public int Radius { get; set; } = 12;
        public float Vx { get; set; }
        public float Vy { get; set; }
        public float Mass { get; set; }
        public Ball()
        {
            this.Mass = Radius * (float)1.3;
        }

        public Ball(Color color, Color borderColor)
        {
            this.Color = color;
            this.BorderColor = borderColor;
            this.Mass = Radius * (float)1.3;
        }

        public virtual void Move()
        {
            this.X = Convert.ToSingle(this.Vx + this.X);
            this.Y = Convert.ToSingle(this.Vy + this.Y);

            this.Vx *= (float)0.99;
            this.Vy *= (float)0.99;
        }

        public void Collide(int worldWidth, int worldHeight)
        {
            if (this.X + this.Radius + 5 >= worldWidth - 60 || this.X - this.Radius - 5 <= 60)
                this.Vx *= -1;

            if (this.Y + this.Radius + 5 >= worldHeight - 60 || this.Y - this.Radius - 5 <= 60)
                this.Vy *= -1;
        }

        public void ResetPosition()
        {
            this.X = this.DefX;
            this.Y = this.DefY;
        }

        public void Render(Graphics g)
        {
            using (SolidBrush brush = new SolidBrush(this.Color))
            {
                g.FillEllipse(brush, Convert.ToSingle(this.X - this.Radius), Convert.ToSingle(this.Y - this.Radius), (this.Radius * 2), (this.Radius * 2));
            }
            using (Pen border = new Pen(this.BorderColor, 12))
            {
                g.DrawEllipse(border, Convert.ToSingle(this.X - this.Radius), Convert.ToSingle(this.Y - this.Radius), this.Radius * 2, this.Radius * 2);
            }
        }
    }
}
