using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace last_task
{
    public class PolarCircle
    {
        public int XC;
        public int YC;
        public int R;
        public PolarCircle(int xcent, int ycent, int rad)
        {
            XC = 700;
            YC = 350;
            R = 150;
        }
        public void Drawcirc(Graphics g, int gap, int sangle)
        {
            float angle = sangle;
            while (angle < 360)
            {
                float thRadian = (float)(angle * Math.PI / 180);
                float x = (float)(R * Math.Cos(thRadian)) + XC;
                float y = (float)(R * Math.Sin(thRadian)) + YC;
                g.FillEllipse(Brushes.DarkRed, x, y, 5, 5);
                angle += gap;
            }
              
        }
        public PointF getnextpoint(float angle)
        {
            float thRadian = (float)(angle * Math.PI / 180);
            float x = (float)(R * Math.Cos(thRadian)) + XC;
            float y = (float)(R * Math.Sin(thRadian)) + YC;

            PointF pnn = new PointF(x, y);
            return pnn;
        }
    }

}

    
