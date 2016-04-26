using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class BallsBounceWin : Form
    {
        private World _world;
        public WhiteBall _whiteball = new WhiteBall();

        public float Xaxis { get; private set; }
        public float Yaxis { get; private set; }

        public BallsBounceWin()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this._world = new World(this.pictureBox1.Width, this.pictureBox1.Height);

            this._world.AddBall(this._whiteball);
            this._whiteball.ResetPosition();

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            this._world.Render(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this._world.Next();
            this.pictureBox1.Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (_whiteball.Vx <= 0.01 && _whiteball.Vy <= 0.01)
            {
                var newX = Convert.ToSingle((e.X - this._whiteball.X) * -0.1);
                var newY = Convert.ToSingle((e.Y - this._whiteball.Y) * -0.1);
                this._whiteball.Vx = newX;
                this._whiteball.Vy = newY;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            this.label1.Text = $"X: {e.X}, Y: {e.Y}";

            if (
                _whiteball.Vx <= 0.01 && _whiteball.Vy <= 0.01 &&
                _whiteball.Vx >= -0.01 && _whiteball.Vy >= -0.01
                )
            {
                _world.cue = new Cue(new Point(e.X, e.Y), new Point((int)this._whiteball.X, (int)this._whiteball.Y));
                _world.hLine = new HelpingLine(e, new PointF(this._whiteball.X , this._whiteball.Y));

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this._world = new World(this.pictureBox1.Width, this.pictureBox1.Height);
            this._whiteball = new WhiteBall();
            this._whiteball.ResetPosition();
            this._world.AddBall(this._whiteball);
        }
    }
}
