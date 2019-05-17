using Bejeweled.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bejeweled
{
    public partial class Form1 : Form
    {
        public static int MATRIX_WIDTH = 8;
        public static int MATRIX_HEIGHT = 8;
        public static int IMAGE_SIZE = 50;

        Img[][] Images;
        Random random;
        Point FirstPoint;
        Point SecondPoint;

        public Form1()
        {
            InitializeComponent();
            random = new Random();
            FirstPoint = new Point(-1, -1);
            SecondPoint = new Point(-1, -1);

            GenerateRandomImages();
            DoubleBuffered = true;
        }

        public void GenerateRandomImages()
        {
            // inicijalizacija na matricata od sliki i polnenje so random vrednosti
            Images = new Img[MATRIX_HEIGHT][];
            for (int i = 0; i < MATRIX_HEIGHT; i++)
            {
                Images[i] = new Img[MATRIX_WIDTH];
            }

            while (true)
            {
                for (int i = 0; i < MATRIX_HEIGHT; i++)
                {
                    for (int j = 0; j < MATRIX_WIDTH; j++)
                    {
                        int type = random.Next(0, 6); // 6 tipovi na sliki (0 - red, 1 - blue, 2 - green, 3 - yellow, 4 - orange, 5 - purple)
                        int x = j * IMAGE_SIZE + 5 * j;
                        int y = i * IMAGE_SIZE + 5 * i;

                        if (type == 0)
                            Images[i][j] = new Img(x, y, Img.ImageType.Red);
                        else if (type == 1)
                            Images[i][j] = new Img(x, y, Img.ImageType.Blue);
                        else if (type == 2)
                            Images[i][j] = new Img(x, y, Img.ImageType.Green);
                        else if (type == 3)
                            Images[i][j] = new Img(x, y, Img.ImageType.Yellow);
                        else if (type == 4)
                            Images[i][j] = new Img(x, y, Img.ImageType.Orange);
                        else if (type == 5)
                            Images[i][j] = new Img(x, y, Img.ImageType.Purple);
                    }
                }

                if (!ThreeFromTheSameType())
                    break;
            }
        }

        public bool ThreeFromTheSameType()
        {
            // dali vo horizontala nekade ima barem 3 isti po red
            for(int i = 0; i < MATRIX_HEIGHT; i++)
            {
                for(int j = 0; j < MATRIX_WIDTH - 2; j++)
                {
                    if ((Images[i][j].Type == Images[i][j + 1].Type) && (Images[i][j + 1].Type == Images[i][j + 2].Type))
                        return true;
                }
            }

            // dali vo vertikala nekade ima barem 3 isti po red
            for (int j = 0; j < MATRIX_WIDTH; j++)
            {
                for (int i = 0; i < MATRIX_HEIGHT - 2; i++)
                {
                    if ((Images[i][j].Type == Images[i + 1][j].Type) && (Images[i + 1][j].Type == Images[i + 2][j].Type))
                        return true;
                }
            }

            return false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < Images.Length; i++)
            {
                for (int j = 0; j < Images[i].Length; j++)
                {
                    Images[i][j].Draw(e.Graphics);
                }
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            // ako sme kliknale vo ramkata
            if (e.X >= Images[0][0].X && e.X <= Images[MATRIX_HEIGHT - 1][MATRIX_WIDTH - 1].X + IMAGE_SIZE && e.Y >= Images[0][0].Y && e.Y <= Images[MATRIX_HEIGHT - 1][MATRIX_WIDTH - 1].Y + IMAGE_SIZE)
            {
                // ako klikame po prv pat
                if (FirstPoint.X == -1 && FirstPoint.Y == -1)
                {
                    FirstPoint = e.Location;
                }
                else
                {
                    SecondPoint = e.Location;

                    double distance = Math.Sqrt((FirstPoint.X - SecondPoint.X) * (FirstPoint.X - SecondPoint.X) + (FirstPoint.Y - SecondPoint.Y) * (FirstPoint.Y - SecondPoint.Y));
                    if (distance < 2 * IMAGE_SIZE)
                    {
                        // kliknato e nekoe sosedno

                        // ako ne e po dijagonala, zameni gi
                        if (NotDiagonal() && SwapNeeded())
                        {
                            Swap();
                            FirstPoint = new Point(-1, -1);
                            SecondPoint = new Point(-1, -1);
                            RefreshSelected();
                        }
                        else
                        {
                            // izbrisi gi selektiranite
                            FirstPoint = new Point(-1, -1);
                            SecondPoint = new Point(-1, -1);
                            RefreshSelected();
                        }
                    }
                    else
                    {
                        // kliknato e nekoe na strana, izbrisi go prethodnoto, zacuvaj go novoto
                        FirstPoint = SecondPoint;
                        SecondPoint = new Point(-1, -1);
                        RefreshSelected();
                    }
                }

                for (int i = 0; i < MATRIX_HEIGHT; i++)
                {
                    for (int j = 0; j < MATRIX_WIDTH; j++)
                    {
                        Images[i][j].Click(FirstPoint.X, FirstPoint.Y);
                        Images[i][j].Click(SecondPoint.X, SecondPoint.Y);
                    }
                }

                Invalidate();
            }
        }

        public void RefreshSelected()
        {
            for (int i = 0; i < Images.Length; i++)
            {
                for (int j = 0; j < Images[i].Length; j++)
                {
                    Images[i][j].IsSelected = false;
                }
            }
        }

        public bool NotDiagonal()
        {
            int i1, i2, j1, j2;
            i1 = i2 = j1 = j2 = -1;

            for (int i = 0; i < MATRIX_HEIGHT; i++)
            {
                for (int j = 0; j < MATRIX_WIDTH; j++)
                {
                    if(Images[i][j].IsHit(FirstPoint.X, FirstPoint.Y))
                    {
                        i1 = i;
                        j1 = j;
                    }
                    else if (Images[i][j].IsHit(SecondPoint.X, SecondPoint.Y))
                    {
                        i2 = i;
                        j2 = j;
                    }
                }
            }

            if(i1 != -1 && i2 != -1 && j1 != -1 && j2 != -1)
            {
                if(i2 == i1 - 1 && j2 == j1)
                {
                    // nad
                    return true;
                }
                else if(i2 == i1 + 1 && j2 == j1)
                {
                    // pod
                    return true;
                }
                else if(i2 == i1 && j2 == j1 - 1)
                {
                    // levo
                    return true;
                }
                else if(i2 == i1 && j2 == j1 + 1)
                {
                    // desno
                    return true;
                }
            }

            return false;
        }

        public bool SwapNeeded()
        {
            // x = j * IMAGE_SIZE + 5 * j
            // y = i * IMAGE_SIZE + 5 * i

            int i1 = FirstPoint.Y / (IMAGE_SIZE + 5);
            int j1 = FirstPoint.X / (IMAGE_SIZE + 5);
            int i2 = SecondPoint.Y / (IMAGE_SIZE + 5);
            int j2 = SecondPoint.X / (IMAGE_SIZE + 5);

            if (j1 == j2)
            {
                // nad pod - horizontala

                // isto isto (first ili second) isto isto
                if(j1 > 1 && j1 < MATRIX_WIDTH - 2)
                {
                    // sobira 5
                    if((Images[i1][j1 - 2].Type == Images[i1][j1 - 1].Type) && (Images[i1][j1 - 2].Type == Images[i2][j2].Type) && (Images[i1][j1 - 2].Type == Images[i1][j1 + 1].Type) && (Images[i1][j1 - 2].Type == Images[i1][j1 + 2].Type))
                    {
                        MessageBox.Show("5");
                    }
                    else if((Images[i2][j2 - 2].Type == Images[i2][j2 - 1].Type) && (Images[i2][j2 - 2].Type == Images[i1][j1].Type) && (Images[i2][j2 - 2].Type == Images[i2][j2 + 1].Type) && (Images[i2][j2 - 2].Type == Images[i2][j2 + 2].Type))
                    {
                        MessageBox.Show("5");
                    }
                }

                // isto isto (first ili second) isto
                if(j1 > 1 && j1 < MATRIX_WIDTH - 1)
                {
                    if ((Images[i1][j1 - 2].Type == Images[i1][j1 - 1].Type) && (Images[i1][j1 - 2].Type == Images[i2][j2].Type) && (Images[i1][j1 - 2].Type == Images[i1][j1 + 1].Type))
                    {
                        MessageBox.Show("4");
                    }
                    else if ((Images[i2][j2 - 2].Type == Images[i2][j2 - 1].Type) && (Images[i2][j2 - 2].Type == Images[i1][j1].Type) && (Images[i2][j2 - 2].Type == Images[i2][j2 + 1].Type))
                    {
                        MessageBox.Show("4");
                    }
                }

                // isto (first ili second) isto isto
                if (j1 > 0 && j1 < MATRIX_WIDTH - 2)
                {
                    if ((Images[i1][j1 - 1].Type == Images[i2][j2].Type) && (Images[i1][j1 - 1].Type == Images[i1][j1 + 1].Type) && (Images[i1][j1 - 1].Type == Images[i1][j1 + 2].Type))
                    {
                        MessageBox.Show("4");
                    }
                    else if ((Images[i2][j2 - 1].Type == Images[i1][j1].Type) && (Images[i2][j2 - 1].Type == Images[i2][j2 + 1].Type) && (Images[i2][j2 - 1].Type == Images[i2][j2 + 2].Type))
                    {
                        MessageBox.Show("4");
                    }
                }

                // (first ili second) isto isto
                if (j1 >= 0 && j1 < MATRIX_WIDTH - 2)
                {
                    if ((Images[i1][j2].Type == Images[i1][j1 + 1].Type) && (Images[i2][j2].Type == Images[i1][j1 + 2].Type))
                    {
                        MessageBox.Show("3");
                    }
                    else if ((Images[i2][j1].Type == Images[i2][j2 + 1].Type) && (Images[i1][j1].Type == Images[i2][j2 + 2].Type))
                    {
                        MessageBox.Show("3");
                    }
                }

                // isto (first ili second) isto
                if (j1 > 0 && j1 < MATRIX_WIDTH - 1)
                {
                    if ((Images[i1][j1 - 1].Type == Images[i2][j2].Type) && (Images[i1][j1 - 1].Type == Images[i1][j1 + 1].Type))
                    {
                        MessageBox.Show("3");
                    }
                    else if ((Images[i2][j2 - 1].Type == Images[i1][j1].Type) && (Images[i2][j2 - 1].Type == Images[i2][j2 + 1].Type))
                    {
                        MessageBox.Show("3");
                    }
                }

                // isto isto (first ili second)
                if (j1 > 1 && j1 < MATRIX_WIDTH)
                {
                    if ((Images[i1][j1 - 2].Type == Images[i1][j1 - 1].Type) && (Images[i1][j1 - 2].Type == Images[i2][j2].Type))
                    {
                        MessageBox.Show("3");
                    }
                    else if ((Images[i2][j2 - 2].Type == Images[i2][j2 - 1].Type) && (Images[i2][j2 - 2].Type == Images[i1][j1].Type))
                    {
                        MessageBox.Show("3");
                    }
                }
            }
            else if(i1 == i2)
            {
                // levo desno - vertikala

                // isto isto (first ili second) isto isto
                if(i1 > 1 && i1 < MATRIX_HEIGHT - 2)
                {
                    if((Images[i2 - 2][j2].Type == Images[i2 - 1][j2].Type) && (Images[i2 - 2][j2].Type == Images[i1][j1].Type) && (Images[i2 - 2][j2].Type == Images[i2 + 1][j2].Type) && (Images[i2 - 2][j2].Type == Images[i2 + 2][j2].Type))
                    {
                        MessageBox.Show("5");
                    }
                    else if((Images[i1 - 2][j1].Type == Images[i1 - 1][j1].Type) && (Images[i1 - 2][j1].Type == Images[i2][j2].Type) && (Images[i1 - 2][j1].Type == Images[i1 + 1][j1].Type) && (Images[i1 - 2][j1].Type == Images[i1 + 2][j1].Type))
                    {
                        MessageBox.Show("5");
                    }
                }

                // isto isto (first ili second) isto
                if(i1 > 1 && i1 < MATRIX_HEIGHT - 1)
                {
                    if ((Images[i2 - 2][j2].Type == Images[i2 - 1][j2].Type) && (Images[i2 - 2][j2].Type == Images[i1][j1].Type) && (Images[i2 - 2][j2].Type == Images[i2 + 1][j2].Type))
                    {
                        MessageBox.Show("4");
                    }
                    else if ((Images[i1 - 2][j1].Type == Images[i1 - 1][j1].Type) && (Images[i1 - 2][j1].Type == Images[i2][j2].Type) && (Images[i1 - 2][j1].Type == Images[i1 + 1][j1].Type))
                    {
                        MessageBox.Show("4");
                    }
                }

                // isto (first ili second) isto isto
                if(i1 > 0 && i1 < MATRIX_HEIGHT - 2)
                {
                    if ((Images[i2 - 1][j2].Type == Images[i1][j1].Type) && (Images[i2 - 1][j2].Type == Images[i2 + 1][j2].Type) && (Images[i2 - 1][j2].Type == Images[i2 + 2][j2].Type))
                    {
                        MessageBox.Show("4");
                    }
                    else if ((Images[i1 - 1][j1].Type == Images[i2][j2].Type) && (Images[i1 - 1][j1].Type == Images[i1 + 1][j1].Type) && (Images[i1 - 1][j1].Type == Images[i1 + 2][j1].Type))
                    {
                        MessageBox.Show("4");
                    }
                }

                // (first ili second) isto isto
                if (i1 >= 0 && i1 < MATRIX_HEIGHT - 2)
                {
                    if ((Images[i1][j1].Type == Images[i2 + 1][j2].Type) && (Images[i2 + 1][j2].Type == Images[i2 + 2][j2].Type))
                    {
                        MessageBox.Show("3");
                    }
                    else if ((Images[i2][j2].Type == Images[i1 + 1][j1].Type) && (Images[i1 + 1][j1].Type == Images[i1 + 2][j1].Type))
                    {
                        MessageBox.Show("3");
                    }
                }

                // isto (first ili second) isto
                if (i1 > 0 && i1 < MATRIX_HEIGHT - 1)
                {
                    if ((Images[i2 - 1][j2].Type == Images[i1][j1].Type) && (Images[i2 - 1][j2].Type == Images[i2 + 1][j2].Type))
                    {
                        MessageBox.Show("3");
                    }
                    else if ((Images[i1 - 1][j1].Type == Images[i2][j2].Type) && (Images[i1 - 1][j1].Type == Images[i1 + 1][j1].Type))
                    {
                        MessageBox.Show("3");
                    }
                }

                // isto isto (first ili second)
                if (i1 > 1 && i1 < MATRIX_HEIGHT)
                {
                    if ((Images[i2 - 2][j2].Type == Images[i2 - 1][j2].Type) && (Images[i2 - 2][j2].Type == Images[i1][j1].Type))
                    {
                        MessageBox.Show("3");
                    }
                    else if ((Images[i1 - 2][j1].Type == Images[i1 - 1][j1].Type) && (Images[i1 - 2][j1].Type == Images[i2][j2].Type))
                    {
                        MessageBox.Show("3");
                    }
                }
            }

            // isto razlicno isto isto - horizontalno
            if(i1 == i2 && ((j1 == j2 - 1 && j1 >= 0 && j1 < MATRIX_WIDTH - 3) || (j1 == j2 + 1 && j2 >= 0 && j2 < MATRIX_WIDTH - 3)))
            {
                if((Images[i1][j1].Type != Images[i2][j2].Type) && (Images[i1][j1].Type == Images[i1][j1 + 2].Type) && (Images[i1][j1].Type == Images[i1][j1 + 3].Type))
                {
                    MessageBox.Show("3");
                }
                else if((Images[i2][j2].Type != Images[i1][j1].Type) && (Images[i2][j2].Type == Images[i2][j2 + 2].Type) && (Images[i2][j2].Type == Images[i2][j2 + 3].Type))
                {
                    MessageBox.Show("3");
                }
            }

            // isto isto razlicno isto - horizontalno
            if (i1 == i2 && ((j1 == j2 - 1 && j1 > 1 && j1 < MATRIX_WIDTH - 1) || (j1 == j2 + 1 && j2 > 2 && j2 < MATRIX_WIDTH)))
            {
                if ((Images[i1][j1 - 2].Type == Images[i1][j1 - 1].Type) && (Images[i1][j1 - 2].Type != Images[i1][j1].Type) && (Images[i1][j1 - 2].Type == Images[i2][j2].Type))
                {
                    MessageBox.Show("3");
                }
                else if ((Images[i2][j2 - 2].Type == Images[i2][j2 - 1].Type) && (Images[i2][j2 - 2].Type != Images[i2][j2].Type) && (Images[i2][j2 - 2].Type == Images[i1][j1].Type))
                {
                    MessageBox.Show("3");
                }
            }

            // isto razlicno isto isto - vertikalno
            if (j1 == j2 && ((i1 == i2 - 1 && i1 >= 0 && i1 < MATRIX_HEIGHT - 3) || (i1 == i2 + 1 && i2 >= 0 && i2 < MATRIX_HEIGHT - 3)))
            {
                if ((Images[i1][j1].Type != Images[i2][j2].Type) && (Images[i1][j1].Type == Images[i1 + 2][j1].Type) && (Images[i1][j1].Type == Images[i1 + 3][j1].Type))
                {
                    MessageBox.Show("3");
                }
                else if ((Images[i2][j2].Type != Images[i1][j1].Type) && (Images[i2][j2].Type == Images[i2 + 2][j2].Type) && (Images[i2][j2].Type == Images[i2 + 3][j2].Type))
                {
                    MessageBox.Show("3");
                }
            }

            // isto isto razlicno isto - vertikalno
            if (j1 == j2 && ((i1 == i2 - 1 && i1 > 1 && i1 < MATRIX_HEIGHT - 1) || (i1 == i2 + 1 && i2 > 2 && i2 < MATRIX_HEIGHT)))
            {
                if ((Images[i1 - 2][j1].Type == Images[i1 - 1][j1].Type) && (Images[i1 - 2][j1].Type != Images[i1][j1].Type) && (Images[i1 - 2][j1].Type == Images[i2][j2].Type))
                {
                    MessageBox.Show("3");
                }
                else if ((Images[i2 - 2][j2].Type == Images[i2 - 1][j2].Type) && (Images[i2 - 2][j2].Type != Images[i2][j2].Type) && (Images[i2 - 2][j2].Type == Images[i1][j1].Type))
                {
                    MessageBox.Show("3");
                }
            }

            return true;
        }

        public void Swap()
        {
            MessageBox.Show("Swap");
        }
    }
}
