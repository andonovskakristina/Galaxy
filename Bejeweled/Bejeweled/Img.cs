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
            Mars,
            Earth,
            Saturn,
            Jupiter,
            Comet,
            Mercury,
            Bomba5,
            Bomba4,
            White
        }

        public int X { get; set; }
        public int Y { get; set; }
        public ImageType Type { get; set; }
        public Image image { get; set; }
        public Point StartingPosition { get; set; }
        public bool IsSelected { get; set; }
        public bool IsForDeleting { get; set; }
        public bool Bomba4 { get; set; }
        public bool Bomba5 { get; set; }
        public Img(int X, int Y, ImageType Type)
        {
            Bomba4 = false;
            Bomba5 = false;
            IsForDeleting = false;
            StartingPosition = new Point(X, Y);
            this.X = X;
            this.Y = Y;
            this.Type = Type;

            if (Type == ImageType.Earth)
                image = Resources.Earth;
            else if (Type == ImageType.Saturn)
                image = Resources.Saturn;
            else if (Type == ImageType.Mars)
                image = Resources.Mars;
            else if (Type == ImageType.Jupiter)
                image = Resources.Jupiter;
            else if (Type == ImageType.Mercury)
                image = Resources.Mercury;
            else if (Type == ImageType.Comet)
                image = Resources.Comet;

            IsSelected = false;
        }

        public void Draw(Graphics g)
        {
            g.DrawImageUnscaled(image, X, Y);
            if (IsSelected)
            {
                Pen pen = new Pen(Color.White, 2);
                if (Type == Img.ImageType.Bomba4 || Type == ImageType.Bomba5)
                {
                    g.DrawRectangle(pen, X, Y, 50, 50);
                }
                else
                {
                    g.DrawRectangle(pen, X, Y, image.Size.Width, image.Size.Height);
                }
               
               
            }
        }

        public void Click(int x, int y)
        {
            if (IsHit(x, y))
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
