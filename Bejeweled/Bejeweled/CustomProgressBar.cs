using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled
{
    public class CustomProgressBar
    {
        Rectangle rec { get; set; }
        Point point = new Point(100, 500);
        int value;
        string text;
        public CustomProgressBar(int current, string txt)
        {
            value = current;
            text = txt;
        }

        public void Draw(Graphics g)
        {
            Brush b;
            Pen p;
            int skalar = 360 - (value * 3);
            p = new Pen(Color.Black, 1);
            rec = new Rectangle(80, 500, 360, 30);
            g.DrawRectangle(p, rec);

            if (value < 80)
            {
                b = new SolidBrush(Color.FromArgb(51, 0, 51));
            }
            else if (value >= 80 && value < 100)
            {
                b = new SolidBrush(Color.FromArgb(134, 45, 134));
            }
            else
            {
                b = new SolidBrush(Color.FromArgb(255, 230, 255));
            }
            rec = new Rectangle(81, 501, skalar, 29);
            g.FillRectangle(b, rec);
            Font f = new Font("Ariel", 14);
            b = new SolidBrush(Color.White);
            g.DrawString(text, f, b, 200, 505);
        }


    }
}
