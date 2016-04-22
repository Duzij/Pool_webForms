using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class WhiteBall : Ball
    {
        public WhiteBall()
        {
            base.Color = System.Drawing.Color.White;
            base.BorderColor = System.Drawing.Color.White;
            base.DefX = 340;
            base.DefY = 325;
        }
    }
}
