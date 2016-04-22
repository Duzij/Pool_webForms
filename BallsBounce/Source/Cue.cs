using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
     public class Cue
    {
        private Point P1, P2;

        public Cue()
        {
            this.P1 = new Point(0, 0);
            this.P2 = new Point(0, 0);
        }

        public Cue(Point p1, Point p2)
        {
            this.P1 = p1;
            this.P2 = p2;
        }

        public virtual void Render(Graphics g)
        {
            using (var p = new Pen(Color.RosyBrown, 8))
            {
                g.DrawLine(p, P1, P2);
            }
        }



    }
}
