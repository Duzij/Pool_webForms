using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Hole : Ball
    {
        public Hole()
        {
            base.Color = System.Drawing.Color.Transparent;
            base.BorderColor = System.Drawing.Color.Red;
            base.Radius = 10;
        }
    }
}
