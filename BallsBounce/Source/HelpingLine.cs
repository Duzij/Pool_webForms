using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class HelpingLine : Cue
    {
        private Point P1, P2;

        public HelpingLine()
        {
            this.P1 = new Point(0, 0);
            this.P2 = new Point(0, 0);
        }

        public HelpingLine(Point p1, Point p2)
        {
            this.P1 = p1;
            this.P2 = p2;
        }

        public override void Render(Graphics g)
        {
            using (var p = new Pen(Color.Yellow, 3))
            {
                g.DrawLine(p, P1, P2);
            }
        }



    }
}
