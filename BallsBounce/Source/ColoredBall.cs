using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class ColoredBall : Ball
    {
        public ColoredBall( Color mainColor , bool pruh)
        {
            if (pruh)
            {
                base.BorderColor = mainColor;
                base.Color = System.Drawing.Color.LightGray;
            }
            else
            {
                base.Color = mainColor;
                base.BorderColor = System.Drawing.Color.LightGray;
            }
        }
    }
}
