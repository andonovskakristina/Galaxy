using Bejeweled.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled
{
    public class Snake
    {
        public List<Square> squares { get; set; }
        public Image Apple { get; set; }
        public int AppleX { get; set; }
        public int AppleY { get; set; }
        public Random random { get; set; }
        public bool EndGame { get; set; }
        public int StarsEaten { get; set; }
        public Snake(Point p, Rectangle rect)
        {
            squares = new List<Square>();
            squares.Add(new Square(p));
            squares.Add(new Square(new Point(p.X - Square.WIDTH - 2, p.Y)));
            squares.Add(new Square(new Point(squares[1].TopLeft.X - Square.WIDTH - 2, p.Y)));
            random = new Random();
            Apple = Resources.Star3;
            AppleX = random.Next(rect.Left + 15, rect.Width + rect.Left - 15);
            AppleY = random.Next(rect.Top + 15, rect.Height + rect.Top - 15);
            EndGame = false;
            StarsEaten = 0;
        }

        public void Add()
        {
            squares.Add(new Square(new Point(squares[squares.Count - 1].TopLeft.X - Square.WIDTH + 2, squares[squares.Count - 1].TopLeft.Y)));
        }

        public void Draw(Graphics g)
        {
            foreach (var s in squares)
            {
                s.Draw(g);
            }
            g.DrawImageUnscaled(Apple, AppleX, AppleY);
        }

        public void Move(Rectangle r)
        {
            for (int i = squares.Count - 1; i > 0; i--)
            {
                squares[i].position = squares[i - 1].position;
                squares[i].TopLeft = squares[i - 1].TopLeft;
            }
            squares[0].Move(r);
            if (squares[0].Hit(Apple, AppleX, AppleY))
            {
                if (squares[squares.Count - 1].position == Square.Position.Right)
                {
                    squares.Add(new Square(new Point(squares[squares.Count - 1].TopLeft.X - Square.WIDTH - 2, squares[squares.Count - 1].TopLeft.Y)));
                }
                else if (squares[squares.Count - 1].position == Square.Position.Left)
                {
                    squares.Add(new Square(new Point(squares[squares.Count - 1].TopLeft.X + Square.WIDTH + 2, squares[squares.Count - 1].TopLeft.Y)));
                }
                else if (squares[squares.Count - 1].position == Square.Position.Up)
                {
                    squares.Add(new Square(new Point(squares[squares.Count - 1].TopLeft.X, squares[squares.Count - 1].TopLeft.Y + Square.WIDTH + 2)));
                }
                else if (squares[squares.Count - 1].position == Square.Position.Down)
                {
                    squares.Add(new Square(new Point(squares[squares.Count - 1].TopLeft.X, squares[squares.Count - 1].TopLeft.Y - Square.WIDTH - 2)));
                }
                AppleX = random.Next(r.Left + 15, r.Width + r.Left - 15);
                AppleY = random.Next(r.Top + 15, r.Height + r.Top - 15);
                StarsEaten++;
            }
            CheckIfEatSelf();
        }

        public void CheckIfEatSelf()
        {
            for (int i = 1; i < squares.Count; i++)
            {
                if (squares[0].HitS(squares[i].TopLeft))
                {
                    EndGame = true;
                    break;
                }
            }
        }
    }
}
