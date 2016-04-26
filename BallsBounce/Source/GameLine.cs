using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public abstract class GameLine
    {
        protected PointF P1, P2;
        protected Color lineColor;
        protected int lineWidth;

        public GameLine()
        {

        }

        public GameLine(PointF p1, PointF p2)
        {
            this.P1 = p1;
            this.P2 = p2;
        }

        public virtual void Render(Graphics g)
        {
            using (var p = new Pen(this.lineColor, this.lineWidth))
            {
                g.DrawLine(p, P1, P2);
            }
        }
    }
}
