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
        Point point = new Point(50, 500);
        int value;
        String text;
        public CustomProgressBar(int current, string txt)
        {

            value = current;
            text = txt;

        }

        public void Draw(Graphics g)
        {
            Brush b;
            Pen p;
            int skalar = value * 3;
            if (value < 80)
            {
                b = new SolidBrush(Color.Green);
                p = new Pen(Color.Black, 1);
                rec = new Rectangle(80, 500, 435, 30);
                g.DrawRectangle(p, rec);
                skalar += 3;
                rec = new Rectangle(80, 500, skalar, 30);
                g.FillRectangle(b, rec);

            }
            else if (value >= 80 && value < 100)
            {
                b = new SolidBrush(Color.Yellow);
                p = new Pen(Color.Black, 1);
                rec = new Rectangle(80, 498, 435, 30);
                g.DrawRectangle(p, rec);
                skalar += 3;
                rec = new Rectangle(80, 500, skalar, 30);
                g.FillRectangle(b, rec);

            }
            else
            {
                b = new SolidBrush(Color.Red);
                p = new Pen(Color.Black, 1);
                rec = new Rectangle(80, 500, 435, 30);
                g.DrawRectangle(p, rec);
                skalar += 3;
                rec = new Rectangle(80, 500, skalar, 30);
                g.FillRectangle(b, rec);

            }
            Font f = new Font("Ariel", 14);
            b = new SolidBrush(Color.Black);
            g.DrawString(text, f, b, 230, 505);
        }


    }
}
