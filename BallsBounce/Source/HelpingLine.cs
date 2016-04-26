using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class HelpingLine : GameLine
    {

        float newx, newy;

        public HelpingLine()
        {
            base.P1 = new PointF(0, 0);
            base.P2 = new PointF(0, 0);
        }

        public HelpingLine(MouseEventArgs e, PointF _whiteBallCenter)
        {
            base.P1 = _whiteBallCenter;

            var diffX = Convert.ToSingle(e.X - _whiteBallCenter.X);
            var diffY = Convert.ToSingle(e.Y - _whiteBallCenter.Y);

            newx = _whiteBallCenter.X - diffX;
            newy = _whiteBallCenter.Y - diffY;

            base.P2 = new PointF(newx, newy);

            base.lineColor = Color.Red;
            base.lineWidth = 1;
        }
    }
}
