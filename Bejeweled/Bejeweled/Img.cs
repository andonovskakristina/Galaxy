using Bejeweled.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled
{
    public class Img
    {
        public enum ImageType
        {
            Red,
            Blue,
            Green,
            Yellow,
            Orange,
            Purple,
            Bomba5,
            Bomba4
        }

        public int X { get; set; }
        public int Y { get; set; }
        public ImageType Type { get; set; }
        public Image image { get; set; }
        public Point StartingPosition { get; set; }
        public bool IsSelected { get; set; }
        public bool IsForDeleting { get; set; }

        public Img(int X, int Y, ImageType Type)
        {
            IsForDeleting = false;
            StartingPosition = new Point(X, Y);
            this.X = X;
            this.Y = Y;
            this.Type = Type;

            if (Type == ImageType.Blue)
                image = Resources.Blue;
            else if (Type == ImageType.Green)
                image = Resources.Green;
            else if (Type == ImageType.Red)
                image = Resources.Red;
            else if (Type == ImageType.Yellow)
                image = Resources.Yellow;
            else if (Type == ImageType.Orange)
                image = Resources.Orange;
            else if (Type == ImageType.Purple)
                image = Resources.Purple;

            IsSelected = false;
        }

        public void Draw(Graphics g)
        {
            g.DrawImageUnscaled(image, X, Y);
            if(IsSelected)
            {
                Pen pen = new Pen(Color.Black, 1);
                g.DrawRectangle(pen, X, Y, image.Size.Width, image.Size.Height);
            }
        }

        public void Click(int x, int y)
        {
            if(IsHit(x, y))
            {
                IsSelected = true;
            }
        }

        public bool IsHit(int x, int y)
        {
            if (X <= x && x <= X + image.Size.Width && y >= Y && y <= Y + image.Size.Height)
            {
                return true;
            }

            return false;
        }
    }
}
