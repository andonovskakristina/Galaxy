using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled
{
    public class Square
    {
        public enum Position
        {
            Up,
            Down,
            Left,
            Right
        }
        public Point TopLeft { get; set; }
        public static Color color = Color.Purple;
        public static int WIDTH = 15;
        public Position position { get; set; }
        public Square(Point tl)
        {
            TopLeft = tl;
            position = Position.Right;
        }

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(color);
            g.FillRectangle(b, TopLeft.X, TopLeft.Y, WIDTH, WIDTH);
        }

        public void Move(Rectangle r)
        {
            int RightX = TopLeft.X + WIDTH + 2;
            int LeftX = TopLeft.X - WIDTH - 2;
            int UpY = TopLeft.Y - WIDTH - 2;
            int DownY = TopLeft.Y + WIDTH + 2;
            //move right
            if (position == Position.Right)
            {
                if (RightX + WIDTH - 5 > r.Right)
                {
                    TopLeft = new Point(r.X, TopLeft.Y);
                }
                else
                {
                    TopLeft = new Point(RightX, TopLeft.Y);
                }
            }
            //move left
            if (position == Position.Left)
            {
                if (LeftX < r.Left)
                {
                    TopLeft = new Point(r.Right - r.Left - 5, TopLeft.Y);
                }
                else
                {
                    TopLeft = new Point(LeftX, TopLeft.Y);
                }
            }
            //move up
            if (position == Position.Up)
            {
                if (UpY + 5 < r.Top)
                {
                    TopLeft = new Point(TopLeft.X, r.Bottom - r.Top - 5);
                }
                else
                {
                    TopLeft = new Point(TopLeft.X, UpY);
                }
            }
            //move down
            if (position == Position.Down)
            {
                if (DownY + WIDTH - 5 > r.Bottom)
                {
                    TopLeft = new Point(TopLeft.X, r.Top);
                }
                else
                {
                    TopLeft = new Point(TopLeft.X, DownY);
                }
            }
        }

        public bool Hit(Image a, int AX, int AY)
        {
            int CenterSX = TopLeft.X + WIDTH / 2;
            int CenterSY = TopLeft.Y + WIDTH / 2;
            int CenterAX = AX + a.Width / 2;
            int CenterAY = AY + a.Width / 2;
            double distance = Math.Sqrt((CenterSX - CenterAX) * (CenterSX - CenterAX) + (CenterSY - CenterAY) * (CenterSY - CenterAY));
            return distance < 15;
        }

        public bool HitS(Point p)
        {
            int CenterSX = TopLeft.X + WIDTH / 2;
            int CenterSY = TopLeft.Y + WIDTH / 2;
            int CenterAX = p.X + WIDTH / 2;
            int CenterAY = p.Y + WIDTH / 2;
            double distance = Math.Sqrt((CenterSX - CenterAX) * (CenterSX - CenterAX) + (CenterSY - CenterAY) * (CenterSY - CenterAY));
            return distance < 15;
        }

    }
}
