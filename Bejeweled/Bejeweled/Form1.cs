using Bejeweled.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;


namespace Bejeweled
{
    public partial class Form1 : Form
    {
        public static int MATRIX_WIDTH = 8;
        public static int MATRIX_HEIGHT = 8;
        public static int IMAGE_SIZE = 50;
        private static readonly int TIME = 4;

        private SoundPlayer soundPlayer;
        Img[][] Images;
        Random random;
        Timer TimerForFive;
        //Point FirstPoint;
        //Point SecondPoint;
        Point PreviousPoint;
        int I, J, CurrentI, CurrentJ;
        bool Break;
        bool IsSwapped;
      
      //  bool Delete;
        int timeElapsed;
        int time = 0;
        CustomProgressBar progress;
        int NoOfUsedHints;

        public Form1()
        {
            InitializeComponent();
            random = new Random();
            I = -1;
            J = -1;
            CurrentI = -1;
            CurrentJ = -1;
            Break = false;
            IsSwapped = false;
            lblVremeForFive.Text = "";
            time = 0;
            NoOfUsedHints = 0;  
            progress = new CustomProgressBar(0, "");
            timer1.Start();
            lblNumOfHits.Text = String.Format("3 hits left.");
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
                        int x = j * IMAGE_SIZE + 5 * j + 80;
                        int y = i * IMAGE_SIZE + 5 * i + 50;

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
            for (int i = 0; i < MATRIX_HEIGHT; i++)
            {
                for (int j = 0; j < MATRIX_WIDTH - 2; j++)
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
            progress.Draw(e.Graphics);
            GenerateRandomDeletedImages();
            CheckState();
            Shuffle();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < Images.Length; i++)
            {
                for (int j = 0; j < Images[i].Length; j++)
                {
                    if (Images[i][j].IsHit(e.X, e.Y))
                    {
                        Images[i][j].IsSelected = true;
                        I = i;
                        J = j;
                        Break = true;
                        break;
                    }
                }
                if (Break)
                {
                    Break = false;
                    break;
                }
            }
            Invalidate(true);
            PreviousPoint = e.Location;
        }

        public void SwapSquare(int a, int b)
        {
            Img temp = Images[I][J];
            Images[I][J] = Images[a][b];
            Images[a][b] = temp;
        }



        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (I != -1 && J != -1 && CurrentI != -1 && CurrentJ != -1)
            {
                Images[I][J].X = Images[I][J].StartingPosition.X;
                Images[I][J].Y = Images[I][J].StartingPosition.Y;
                Images[CurrentI][CurrentJ].X = Images[CurrentI][CurrentJ].StartingPosition.X;
                Images[CurrentI][CurrentJ].Y = Images[CurrentI][CurrentJ].StartingPosition.Y;
                Images[CurrentI][CurrentJ].IsSelected = false;

            }
            if (I != -1 && J != -1)
            {
                Images[I][J].IsSelected = false;
                I = -1;
                J = -1;
            }
            RefreshSelected();
            Invalidate(true);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (I != -1 && J != -1)
            {
                int dX = e.X - PreviousPoint.X;
                int dY = e.Y - PreviousPoint.Y;
                int newX = Images[I][J].X + dX;
                int newY = Images[I][J].Y + dY;

                // move right one square
                //Current Square for putting back in place if no swap happens
                if (J < (Images[I].Length - 1) && newX <= (Images[I][J].StartingPosition.X + 5 + IMAGE_SIZE) &&
                    newX >= Images[I][J].StartingPosition.X
                    && newY == Images[I][J].StartingPosition.Y)
                {

                    Images[I][J].X = Images[I][J].X + dX;
                    Images[I][J].Y = Images[I][J].Y;
                    Images[I][J + 1].X = Images[I][J + 1].X - dX;
                    Images[I][J + 1].Y = Images[I][J + 1].Y;
                    Images[I][J + 1].IsSelected = true;
                    CurrentI = I;
                    CurrentJ = J + 1;
                    //check if square moved to end, then swap
                    if (Images[I][J].X == Images[I][J + 1].StartingPosition.X
                        && Images[I][J].Y == Images[I][J + 1].StartingPosition.Y)
                    {
                        //Proveri dali se dve bombi
                        if(Images[I][J].Type == Img.ImageType.Bomba4 && Images[CurrentI][CurrentJ].Type == Img.ImageType.Bomba4)
                        {
                            IsSwapped = true;
                            Images[I][J].IsForDeleting = true;
                            Images[CurrentI][CurrentJ].IsForDeleting = true;
                            Images[I][J].IsSelected = false;
                            Images[CurrentI][CurrentJ].IsSelected = false;
                            I = -1;
                            J = -1;
                            CallSnake();
                        }
                        //proveri bomba da ne e kliknata
                        else if (Images[I][J].Type == Img.ImageType.Bomba5 || Images[I][J].Type == Img.ImageType.Bomba4 || Images[CurrentI][CurrentJ].Type == Img.ImageType.Bomba4 || Images[CurrentI][CurrentJ].Type == Img.ImageType.Bomba5)
                        {
                            SwapSquare(I, J + 1);
                            Point t = Images[I][J].StartingPosition;
                            Images[I][J].StartingPosition = Images[I][J + 1].StartingPosition;
                            Images[I][J + 1].StartingPosition = t;
                            Images[I][J].IsSelected = false;
                            Images[I][J + 1].IsSelected = false;
                            if (Images[CurrentI][CurrentJ].Type == Img.ImageType.Bomba5 || Images[I][J].Type == Img.ImageType.Bomba5)
                            {
                                DeleteForFive();
                            }
                            else if (Images[CurrentI][CurrentJ].Type == Img.ImageType.Bomba4)
                            {
                                DeleteForFour(CurrentI, CurrentJ);
                            }
                            else
                            {
                                DeleteForFour(I, J);
                            }
                            I = -1;
                            J = -1;
                        }
                       else if(IsSwapPossible(I, J, CurrentI, CurrentJ))
                        {
                            SwapSquare(I, J + 1);
                            Point t = Images[I][J].StartingPosition;
                            Images[I][J].StartingPosition = Images[I][J + 1].StartingPosition;
                            Images[I][J + 1].StartingPosition = t;
                            Images[I][J].IsSelected = false;
                            Images[I][J + 1].IsSelected = false;
                            IsSwapped = true;
                            CheckAndAddBomb(I, J);
                            CheckAndAddBomb(CurrentI, CurrentJ);
                            I = -1;
                            J = -1;
                        }
                    }
                }

                // move left one square
                else if (J > 0 && newX <= Images[I][J].StartingPosition.X
                    && newX >= (Images[I][J].StartingPosition.X - 5 - IMAGE_SIZE)
                    && newY == Images[I][J].StartingPosition.Y)
                {
                    Images[I][J].X = Images[I][J].X + dX;
                    Images[I][J].Y = Images[I][J].Y;
                    Images[I][J - 1].X = Images[I][J - 1].X - dX;
                    Images[I][J - 1].Y = Images[I][J - 1].Y;
                    Images[I][J - 1].IsSelected = true;
                    CurrentI = I;
                    CurrentJ = J - 1;
                    if (Images[I][J].X == Images[I][J - 1].StartingPosition.X
                         && Images[I][J].Y == Images[I][J - 1].StartingPosition.Y)
                    {
                        //Proveri dali se dve bombi
                        if (Images[I][J].Type == Img.ImageType.Bomba4 && Images[CurrentI][CurrentJ].Type == Img.ImageType.Bomba4)
                        {
                            IsSwapped = true;
                            Images[I][J].IsForDeleting = true;
                            Images[CurrentI][CurrentJ].IsForDeleting = true;
                            Images[I][J].IsSelected = false;
                            Images[CurrentI][CurrentJ].IsSelected = false;
                            I = -1;
                            J = -1;
                            CallSnake();
                        }
                        //proveri bomba da ne e kliknata
                        else if (Images[I][J].Type == Img.ImageType.Bomba4 || Images[I][J].Type == Img.ImageType.Bomba5 || Images[CurrentI][CurrentJ].Type == Img.ImageType.Bomba4 || Images[CurrentI][CurrentJ].Type == Img.ImageType.Bomba5)
                        {
                            SwapSquare(I, J - 1);
                            Point t = Images[I][J].StartingPosition;
                            Images[I][J].StartingPosition = Images[I][J - 1].StartingPosition;
                            Images[I][J - 1].StartingPosition = t;
                            Images[I][J].IsSelected = false;
                            Images[I][J - 1].IsSelected = false;
                            if (Images[CurrentI][CurrentJ].Type == Img.ImageType.Bomba5 || Images[I][J].Type == Img.ImageType.Bomba5)
                            {
                                DeleteForFive();
                            }
                            else if (Images[CurrentI][CurrentJ].Type == Img.ImageType.Bomba4)
                            {
                                DeleteForFour(CurrentI, CurrentJ);
                            }
                            else
                            {
                                DeleteForFour(I, J);
                            }
                            I = -1;
                            J = -1;
                        }
                        else if (IsSwapPossible(I, J, CurrentI, CurrentJ))
                        {
                            SwapSquare(I, J - 1);
                            Point t = Images[I][J].StartingPosition;
                            Images[I][J].StartingPosition = Images[I][J - 1].StartingPosition;
                            Images[I][J - 1].StartingPosition = t;
                            Images[I][J].IsSelected = false;
                            Images[I][J - 1].IsSelected = false;
                            IsSwapped = true;
                            CheckAndAddBomb(I, J);
                            CheckAndAddBomb(CurrentI, CurrentJ);
                            I = -1;
                            J = -1;
                        }


                    }
                }

                // move bottom one square
                else if (I < (Images.Length - 1) && newY <= (Images[I][J].StartingPosition.Y + 5 + IMAGE_SIZE)
                    && newY >= Images[I][J].StartingPosition.Y
                    && newX == Images[I][J].StartingPosition.X)
                {
                    Images[I][J].X = Images[I][J].X;
                    Images[I][J].Y = Images[I][J].Y + dY;
                    Images[I + 1][J].X = Images[I + 1][J].X;
                    Images[I + 1][J].Y = Images[I + 1][J].Y - dY;
                    Images[I + 1][J].IsSelected = true;
                    CurrentI = I + 1;
                    CurrentJ = J;
                    if (Images[I][J].X == Images[I + 1][J].StartingPosition.X
                        && Images[I][J].Y == Images[I + 1][J].StartingPosition.Y)
                    {
                        //Proveri dali se dve bombi
                        if (Images[I][J].Type == Img.ImageType.Bomba4 && Images[CurrentI][CurrentJ].Type == Img.ImageType.Bomba4)
                        {
                            IsSwapped = true;
                            Images[I][J].IsForDeleting = true;
                            Images[CurrentI][CurrentJ].IsForDeleting = true;
                            Images[I][J].IsSelected = false;
                            Images[CurrentI][CurrentJ].IsSelected = false;
                            I = -1;
                            J = -1;
                            CallSnake();
                        }
                        //proveri bomba da ne e kliknata
                        else if(Images[I][J].Type == Img.ImageType.Bomba4 || Images[I][J].Type == Img.ImageType.Bomba5 || Images[CurrentI][CurrentJ].Type == Img.ImageType.Bomba4 || Images[CurrentI][CurrentJ].Type == Img.ImageType.Bomba5)
                        {
                            SwapSquare(I + 1, J);
                            Point t = Images[I][J].StartingPosition;
                            Images[I][J].StartingPosition = Images[I + 1][J].StartingPosition;
                            Images[I + 1][J].StartingPosition = t;
                            Images[I][J].IsSelected = false;
                            Images[I + 1][J].IsSelected = false;
                            if (Images[CurrentI][CurrentJ].Type == Img.ImageType.Bomba5 || Images[I][J].Type == Img.ImageType.Bomba5)
                            {
                                DeleteForFive();
                            }
                            else if (Images[CurrentI][CurrentJ].Type == Img.ImageType.Bomba4)
                            {
                                DeleteForFour(CurrentI, CurrentJ);
                            }
                            else
                            {
                                DeleteForFour(I, J);
                            }
                            I = -1;
                            J = -1;
                        }
                        else if (IsSwapPossible(I,J,CurrentI,CurrentJ))
                        {
                            SwapSquare(I + 1, J);
                            Point t = Images[I][J].StartingPosition;
                            Images[I][J].StartingPosition = Images[I + 1][J].StartingPosition;
                            Images[I + 1][J].StartingPosition = t;
                            Images[I][J].IsSelected = false;
                            Images[I + 1][J].IsSelected = false;
                            IsSwapped = true;
                            CheckAndAddBomb(I, J);
                            CheckAndAddBomb(CurrentI, CurrentJ);
                            I = -1;
                            J = -1;
                        }
                    }
                }

                // move top one square
                else if (I > 0 && newY >= (Images[I][J].StartingPosition.Y - 5 - IMAGE_SIZE)
                     && newY <= Images[I][J].StartingPosition.Y
                     && newX == Images[I][J].StartingPosition.X)
                {
                    Images[I][J].X = Images[I][J].X;
                    Images[I][J].Y = Images[I][J].Y + dY;
                    Images[I - 1][J].X = Images[I - 1][J].X;
                    Images[I - 1][J].Y = Images[I - 1][J].Y - dY;
                    Images[I - 1][J].IsSelected = true;
                    CurrentI = I - 1;
                    CurrentJ = J;
                    if (Images[I][J].X == Images[I - 1][J].StartingPosition.X
                        && Images[I][J].Y == Images[I - 1][J].StartingPosition.Y)
                    {
                        //Proveri dali se dve bombi
                        if (Images[I][J].Type == Img.ImageType.Bomba4 && Images[CurrentI][CurrentJ].Type == Img.ImageType.Bomba4)
                        {
                            IsSwapped = true;
                            Images[I][J].IsForDeleting = true;
                            Images[CurrentI][CurrentJ].IsForDeleting = true;
                            Images[I][J].IsSelected = false;
                            Images[CurrentI][CurrentJ].IsSelected = false;
                            I = -1;
                            J = -1;
                            CallSnake();
                        }
                        //proveri bomba da ne e kliknata
                        else if(Images[I][J].Type == Img.ImageType.Bomba4 || Images[I][J].Type == Img.ImageType.Bomba5 || Images[CurrentI][CurrentJ].Type == Img.ImageType.Bomba4 || Images[CurrentI][CurrentJ].Type == Img.ImageType.Bomba5)
                        {
                            SwapSquare(I - 1, J);
                            Point t = Images[I][J].StartingPosition;
                            Images[I][J].StartingPosition = Images[I - 1][J].StartingPosition;
                            Images[I - 1][J].StartingPosition = t;
                            Images[I][J].IsSelected = false;
                            Images[I - 1][J].IsSelected = false;
                            if (Images[CurrentI][CurrentJ].Type == Img.ImageType.Bomba5 || Images[I][J].Type == Img.ImageType.Bomba5)
                            {
                                DeleteForFive();
                            }
                            else if(Images[CurrentI][CurrentJ].Type == Img.ImageType.Bomba4)
                            {
                                DeleteForFour(CurrentI, CurrentJ);
                            }
                            else
                            {
                                DeleteForFour(I, J);
                            }
                            I = -1;
                            J = -1;
                        }
                        else if (IsSwapPossible(I, J, CurrentI, CurrentJ))
                        {
                            SwapSquare(I - 1, J);
                            Point t = Images[I][J].StartingPosition;
                            Images[I][J].StartingPosition = Images[I - 1][J].StartingPosition;
                            Images[I - 1][J].StartingPosition = t;
                            Images[I][J].IsSelected = false;
                            Images[I - 1][J].IsSelected = false;
                            IsSwapped = true;
                            CheckAndAddBomb(I, J);
                            CheckAndAddBomb(CurrentI, CurrentJ);
                            I = -1;
                            J = -1;
                        }
                       
                    }
                }
                if (IsSwapped)
                {
                    DeleteSquares();
                }
                PreviousPoint = e.Location;
                Invalidate(true);
            }
        }

        private void GamePause()
        {
            this.MouseDown -= new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove -= new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp -= new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            timer1.Stop();
        }

        private void GameUnPause()
        {
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            timer1.Start();
        }
        private void CallSnake()
        {
            GamePause();
            SnakeForm sf = new SnakeForm();
            if(sf.ShowDialog() == DialogResult.OK)
            {
                sf.Close();
            }
            GameUnPause();

        }
        private void CallAssociation()
        {
            GamePause();
            AsocijacijaForm af = new AsocijacijaForm();
            if(af.ShowDialog() == DialogResult.OK)
            {
                af.Close();
            }
            GameUnPause();
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

        //public bool NotDiagonal()
        //{
        //    int i1, i2, j1, j2;
        //    i1 = i2 = j1 = j2 = -1;

        //    for (int i = 0; i < MATRIX_HEIGHT; i++)
        //    {
        //        for (int j = 0; j < MATRIX_WIDTH; j++)
        //        {
        //            if(Images[i][j].IsHit(FirstPoint.X, FirstPoint.Y))
        //            {
        //                i1 = i;
        //                j1 = j;
        //            }
        //            else if (Images[i][j].IsHit(SecondPoint.X, SecondPoint.Y))
        //            {
        //                i2 = i;
        //                j2 = j;
        //            }
        //        }
        //    }

        //    if(i1 != -1 && i2 != -1 && j1 != -1 && j2 != -1)
        //    {
        //        if(i2 == i1 - 1 && j2 == j1)
        //        {
        //            // nad
        //            return true;
        //        }
        //        else if(i2 == i1 + 1 && j2 == j1)
        //        {
        //            // pod
        //            return true;
        //        }
        //        else if(i2 == i1 && j2 == j1 - 1)
        //        {
        //            // levo
        //            return true;
        //        }
        //        else if(i2 == i1 && j2 == j1 + 1)
        //        {
        //            // desno
        //            return true;
        //        }
        //    }

        //    return false;
        //}

        //public bool SwapNeeded(int a, int b, int a1, int b1)
        //{
        //    // x = j * IMAGE_SIZE + 5 * j
        //    // y = i * IMAGE_SIZE + 5 * i

        //    //int i1 = FirstPoint.Y / (IMAGE_SIZE + 5);
        //    //int j1 = FirstPoint.X / (IMAGE_SIZE + 5);
        //    //int i2 = SecondPoint.Y / (IMAGE_SIZE + 5);
        //    //int j2 = SecondPoint.X / (IMAGE_SIZE + 5);
        //    int i1 = a;
        //    int j1 = b;
        //    int i2 = a1;
        //    int j2 = b1;
        //    Delete = false;

        //    if (j1 == j2 && J != -1)
        //    {
        //        // nad pod - horizontala

        //        // isto isto (first ili second) isto isto
        //        if (j1 > 1 && j1 < MATRIX_WIDTH - 2)
        //        {
        //            // sobira 5
        //            if ((Images[i1][j1 - 2].Type == Images[i1][j1 - 1].Type) && (Images[i1][j1 - 2].Type == Images[i2][j2].Type) && (Images[i1][j1 - 2].Type == Images[i1][j1 + 1].Type) && (Images[i1][j1 - 2].Type == Images[i1][j1 + 2].Type))
        //            {
        //                Images[i1][j1 - 2].IsForDeleting = true;
        //                Images[i1][j1 - 1].IsForDeleting = true;
        //                //Images[i2][j2].IsForDeleting = true;
        //                Images[i1][j1 + 1].IsForDeleting = true;
        //                Images[i1][j1 + 2].IsForDeleting = true;
        //                Images[i2][j2].Bomba5 = true;
        //                Delete = true;
        //                //MessageBox.Show("5");
        //            }
        //            else if ((Images[i2][j2 - 2].Type == Images[i2][j2 - 1].Type) && (Images[i2][j2 - 2].Type == Images[i1][j1].Type) && (Images[i2][j2 - 2].Type == Images[i2][j2 + 1].Type) && (Images[i2][j2 - 2].Type == Images[i2][j2 + 2].Type))
        //            {
        //                Images[i2][j2 - 2].IsForDeleting = true;
        //                Images[i2][j2 - 1].IsForDeleting = true;
        //                //Images[i1][j1].IsForDeleting = true;
        //                Images[i1][j1 + 1].IsForDeleting = true;
        //                Images[i1][j1 + 2].IsForDeleting = true;
        //                Images[i1][j1].Bomba5 = true;
        //                Delete = true;
        //                //  MessageBox.Show("5");
        //            }
        //        }

        //        // isto isto (first ili second) isto
        //        if (j1 > 1 && j1 < MATRIX_WIDTH - 1 && j2 > 1)
        //        {
        //            if ((Images[i1][j1 - 2].Type == Images[i1][j1 - 1].Type) && (Images[i1][j1 - 2].Type == Images[i2][j2].Type) && (Images[i1][j1 - 2].Type == Images[i1][j1 + 1].Type))
        //            {
        //                Images[i1][j1 - 2].IsForDeleting = true;
        //                Images[i1][j1 - 1].IsForDeleting = true;
        //                //Images[i2][j2].IsForDeleting = true;
        //                Images[i1][j1 + 1].IsForDeleting = true;
        //                Images[i2][j2].Bomba4 = true;
        //                Delete = true;
        //                //  MessageBox.Show("4");
        //            }
        //            else if ((Images[i2][j2 - 2].Type == Images[i2][j2 - 1].Type) && (Images[i2][j2 - 2].Type == Images[i1][j1].Type) && (Images[i2][j2 - 2].Type == Images[i2][j2 + 1].Type))
        //            {
        //                Images[i2][j2 - 2].IsForDeleting = true;
        //                Images[i2][j2 - 1].IsForDeleting = true;
        //                //Images[i1][j1].IsForDeleting = true;
        //                Images[i2][j2 + 1].IsForDeleting = true;
        //                Images[i1][j1].Bomba4 = true;
        //                Delete = true;
        //                //  MessageBox.Show("4");
        //            }
        //        }

        //        // isto (first ili second) isto isto
        //        if (j1 > 0 && j1 < MATRIX_WIDTH - 2)
        //        {
        //            if ((Images[i1][j1 - 1].Type == Images[i2][j2].Type) && (Images[i1][j1 - 1].Type == Images[i1][j1 + 1].Type) && (Images[i1][j1 - 1].Type == Images[i1][j1 + 2].Type))
        //            {
        //                Images[i1][j1 - 1].IsForDeleting = true;
        //                //Images[i2][j2].IsForDeleting = true;
        //                Images[i1][j1 + 1].IsForDeleting = true;
        //                Images[i1][j1 + 2].IsForDeleting = true;
        //                Images[i2][j2].Bomba4 = true;
        //                Delete = true;
        //                //    MessageBox.Show("4");
        //            }
        //            else if ((Images[i2][j2 - 1].Type == Images[i1][j1].Type) && (Images[i2][j2 - 1].Type == Images[i2][j2 + 1].Type) && (Images[i2][j2 - 1].Type == Images[i2][j2 + 2].Type))
        //            {
        //                Images[i2][j2 - 1].IsForDeleting = true;
        //                //Images[i1][j1].IsForDeleting = true;
        //                Images[i2][j2 + 1].IsForDeleting = true;
        //                Images[i2][j2 + 2].IsForDeleting = true;
        //                Images[i1][j1].Bomba4 = true;
        //                Delete = true;
        //                //  MessageBox.Show("4");
        //            }
        //        }

        //        // (first ili second) isto isto
        //        if (j1 >= 0 && j1 < MATRIX_WIDTH - 2)
        //        {
        //            if ((Images[i2][j2].Type == Images[i1][j1 + 1].Type) && (Images[i2][j2].Type == Images[i1][j1 + 2].Type))
        //            {
        //                Images[i2][j2].IsForDeleting = true;
        //                Images[i1][j1 + 1].IsForDeleting = true;
        //                Images[i1][j1 + 2].IsForDeleting = true;
        //                Delete = true;
        //                // MessageBox.Show("3");
        //            }
        //            else if ((Images[i1][j1].Type == Images[i2][j2 + 1].Type) && (Images[i1][j1].Type == Images[i2][j2 + 2].Type))
        //            {
        //                Images[i1][j1].IsForDeleting = true;
        //                Images[i2][j2 + 1].IsForDeleting = true;
        //                Images[i2][j2 + 2].IsForDeleting = true;
        //                Delete = true;
        //                //   MessageBox.Show("3");
        //            }
        //        }

        //        // isto (first ili second) isto
        //        if (j1 > 0 && j1 < MATRIX_WIDTH - 1)
        //        {
        //            if ((Images[i1][j1 - 1].Type == Images[i2][j2].Type) && (Images[i1][j1 - 1].Type == Images[i1][j1 + 1].Type))
        //            {
        //                Images[i1][j1 - 1].IsForDeleting = true;
        //                Images[i2][j2].IsForDeleting = true;
        //                Images[i1][j1 + 1].IsForDeleting = true;
        //                Delete = true;
        //                // MessageBox.Show("3");
        //            }
        //            else if ((Images[i2][j2 - 1].Type == Images[i1][j1].Type) && (Images[i2][j2 - 1].Type == Images[i2][j2 + 1].Type))
        //            {
        //                Images[i2][j2 - 1].IsForDeleting = true;
        //                Images[i1][j1].IsForDeleting = true;
        //                Images[i2][j2 + 1].IsForDeleting = true;
        //                Delete = true;
        //                //  MessageBox.Show("3");
        //            }
        //        }

        //        // isto isto (first ili second)
        //        if (j1 > 1 && j1 < MATRIX_WIDTH)
        //        {
        //            if ((Images[i1][j1 - 2].Type == Images[i1][j1 - 1].Type) && (Images[i1][j1 - 2].Type == Images[i2][j2].Type))
        //            {
        //                Images[i1][j1 - 2].IsForDeleting = true;
        //                Images[i1][j1 - 1].IsForDeleting = true;
        //                Images[i2][j2].IsForDeleting = true;
        //                Delete = true;
        //                //  MessageBox.Show("3");
        //            }
        //            else if ((Images[i2][j2 - 2].Type == Images[i2][j2 - 1].Type) && (Images[i2][j2 - 2].Type == Images[i1][j1].Type))
        //            {
        //                Images[i2][j2 - 2].IsForDeleting = true;
        //                Images[i2][j2 - 1].IsForDeleting = true;
        //                Images[i1][j1].IsForDeleting = true;
        //                Delete = true;
        //                //   MessageBox.Show("3");
        //            }
        //        }
        //    }
        //    else if (i1 == i2 && I != -1)
        //    {
        //        // levo desno - vertikala

        //        // isto isto (first ili second) isto isto
        //        if (i1 > 1 && i1 < MATRIX_HEIGHT - 2)
        //        {
        //            if ((Images[i2 - 2][j2].Type == Images[i2 - 1][j2].Type) && (Images[i2 - 2][j2].Type == Images[i1][j1].Type) && (Images[i2 - 2][j2].Type == Images[i2 + 1][j2].Type) && (Images[i2 - 2][j2].Type == Images[i2 + 2][j2].Type))
        //            {
        //                Images[i2 - 2][j2].IsForDeleting = true;
        //                Images[i2 - 1][j2].IsForDeleting = true;
        //                Images[i1][j1].IsForDeleting = true;
        //                Images[i2 + 1][j2].IsForDeleting = true;
        //                //Images[i2 + 2][j2].IsForDeleting = true;
        //                Delete = true;
        //                Images[i2 + 2][j2].Bomba5 = true;
        //                //  MessageBox.Show("5");
        //            }
        //            else if ((Images[i1 - 2][j1].Type == Images[i1 - 1][j1].Type) && (Images[i1 - 2][j1].Type == Images[i2][j2].Type) && (Images[i1 - 2][j1].Type == Images[i1 + 1][j1].Type) && (Images[i1 - 2][j1].Type == Images[i1 + 2][j1].Type))
        //            {
        //                Images[i1 - 2][j1].IsForDeleting = true;
        //                Images[i1 - 1][j1].IsForDeleting = true;
        //                Images[i2][j2].IsForDeleting = true;
        //                Images[i1 + 1][j1].IsForDeleting = true;
        //                //Images[i1 + 2][j1].IsForDeleting = true;
        //                Images[i1 + 2][j1].Bomba5 = true;
        //                Delete = true;
        //                //   MessageBox.Show("5");
        //            }
        //        }

        //        // isto isto (first ili second) isto
        //        if (i1 > 1 && i1 < MATRIX_HEIGHT - 1)
        //        {
        //            if ((Images[i2 - 2][j2].Type == Images[i2 - 1][j2].Type) && (Images[i2 - 2][j2].Type == Images[i1][j1].Type) && (Images[i2 - 2][j2].Type == Images[i2 + 1][j2].Type))
        //            {
        //                Images[i2 - 2][j2].IsForDeleting = true;
        //                Images[i2 - 1][j2].IsForDeleting = true;
        //                Images[i1][j1].IsForDeleting = true;
        //                //Images[i2 + 1][j2].IsForDeleting = true;
        //                Images[i2 + 1][j1 - 1].Bomba4 = true;
        //                Delete = true;
        //                //   MessageBox.Show("4");
        //            }
        //            else if ((Images[i1 - 2][j1].Type == Images[i1 - 1][j1].Type) && (Images[i1 - 2][j1].Type == Images[i2][j2].Type) && (Images[i1 - 2][j1].Type == Images[i1 + 1][j1].Type))
        //            {
        //                Images[i1 - 2][j1].IsForDeleting = true;
        //                Images[i1 - 1][j1].IsForDeleting = true;
        //                Images[i2][j2].IsForDeleting = true;
        //                //Images[i1 + 1][j1].IsForDeleting = true;
        //                Images[i1 + 1][j1].Bomba4 = true;
        //                Delete = true;
        //                //   MessageBox.Show("4");
        //            }
        //        }

        //        // isto (first ili second) isto isto
        //        if (i1 > 0 && i1 < MATRIX_HEIGHT - 2)
        //        {
        //            if ((Images[i2 - 1][j2].Type == Images[i1][j1].Type) && (Images[i2 - 1][j2].Type == Images[i2 + 1][j2].Type) && (Images[i2 - 1][j2].Type == Images[i2 + 2][j2].Type))
        //            {
        //                Images[i2 - 1][j2].IsForDeleting = true;
        //                Images[i1][j1].IsForDeleting = true;
        //                Images[i2 + 1][j2].IsForDeleting = true;
        //                //Images[i2 + 2][j2].IsForDeleting = true;
        //                Images[i2 + 2][j2].Bomba4 = true;
        //                Delete = true;
        //                //  MessageBox.Show("4");
        //            }
        //            else if ((Images[i1 - 1][j1].Type == Images[i2][j2].Type) && (Images[i1 - 1][j1].Type == Images[i1 + 1][j1].Type) && (Images[i1 - 1][j1].Type == Images[i1 + 2][j1].Type))
        //            {
        //                Images[i1 - 1][j1].IsForDeleting = true;
        //                Images[i2][j2].IsForDeleting = true;
        //                Images[i1 + 1][j1].IsForDeleting = true;
        //                //Images[i1 + 2][j1].IsForDeleting = true;
        //                Images[i1 + 2][j1].Bomba4 = true;
        //                Delete = true;
        //                //   MessageBox.Show("4");
        //            }
        //        }

        //        // (first ili second) isto isto
        //        if (i1 >= 0 && i1 < MATRIX_HEIGHT - 2)
        //        {
        //            if ((Images[i1][j1].Type == Images[i2 + 1][j2].Type) && (Images[i2 + 1][j2].Type == Images[i2 + 2][j2].Type))
        //            {
        //                Images[i1][j1].IsForDeleting = true;
        //                Images[i2 + 1][j2].IsForDeleting = true;
        //                Images[i2 + 2][j2].IsForDeleting = true;
        //                Delete = true;
        //                //   MessageBox.Show("3");
        //            }
        //            else if ((Images[i2][j2].Type == Images[i1 + 1][j1].Type) && (Images[i1 + 1][j1].Type == Images[i1 + 2][j1].Type))
        //            {
        //                Images[i2][j2].IsForDeleting = true;
        //                Images[i1 + 1][j1].IsForDeleting = true;
        //                Images[i1 + 2][j1].IsForDeleting = true;
        //                Delete = true;
        //                //    MessageBox.Show("3");
        //            }
        //        }

        //        // isto (first ili second) isto
        //        if (i1 > 0 && i1 < MATRIX_HEIGHT - 1)
        //        {
        //            if ((Images[i2 - 1][j2].Type == Images[i1][j1].Type) && (Images[i2 - 1][j2].Type == Images[i2 + 1][j2].Type))
        //            {
        //                Images[i2 - 1][j2].IsForDeleting = true;
        //                Images[i1][j1].IsForDeleting = true;
        //                Images[i2 + 1][j2].IsForDeleting = true;
        //                Delete = true;
        //                //   MessageBox.Show("3");
        //            }
        //            else if ((Images[i1 - 1][j1].Type == Images[i2][j2].Type) && (Images[i1 - 1][j1].Type == Images[i1 + 1][j1].Type))
        //            {
        //                Images[i1 - 1][j1].IsForDeleting = true;
        //                Images[i2][j2].IsForDeleting = true;
        //                Images[i1 + 1][j1].IsForDeleting = true;
        //                Delete = true;
        //                //  MessageBox.Show("3");
        //            }
        //        }

        //        // isto isto (first ili second)
        //        if (i1 > 1 && i1 < MATRIX_HEIGHT)
        //        {
        //            if ((Images[i2 - 2][j2].Type == Images[i2 - 1][j2].Type) && (Images[i2 - 2][j2].Type == Images[i1][j1].Type))
        //            {
        //                Images[i2 - 2][j2].IsForDeleting = true;
        //                Images[i2 - 1][j2].IsForDeleting = true;
        //                Images[i1][j1].IsForDeleting = true;

        //                Delete = true;
        //                // MessageBox.Show("3");
        //            }
        //            else if ((Images[i1 - 2][j1].Type == Images[i1 - 1][j1].Type) && (Images[i1 - 2][j1].Type == Images[i2][j2].Type))
        //            {
        //                Images[i1 - 2][j1].IsForDeleting = true;
        //                Images[i1 - 1][j1].IsForDeleting = true;
        //                Images[i2][j2].IsForDeleting = true;
        //                Delete = true;
        //                //   MessageBox.Show("3");
        //            }
        //        }
        //    }

        //    // isto razlicno isto isto - horizontalno
        //    if (i1 == i2 && ((j1 == j2 - 1 && j1 >= 0 && j1 < MATRIX_WIDTH - 3) || (j1 == j2 + 1 && j2 >= 0 && j2 < MATRIX_WIDTH - 3)))
        //    {
        //        if ((Images[i1][j1].Type != Images[i2][j2].Type) && (Images[i1][j1].Type == Images[i1][j1 + 2].Type) && (Images[i1][j1].Type == Images[i1][j1 + 3].Type))
        //        {
        //            Images[i1][j1].IsForDeleting = true;
        //            Images[i1][j1 + 2].IsForDeleting = true;
        //            Images[i1][j1 + 3].IsForDeleting = true;
        //            Delete = true;
        //            //  MessageBox.Show("3");
        //        }
        //        else if ((Images[i2][j2].Type != Images[i1][j1].Type) && (Images[i2][j2].Type == Images[i2][j2 + 2].Type) && (Images[i2][j2].Type == Images[i2][j2 + 3].Type))
        //        {
        //            Images[i2][j2].IsForDeleting = true;
        //            Images[i2][j2 + 2].IsForDeleting = true;
        //            Images[i2][j2 + 3].IsForDeleting = true;
        //            Delete = true;
        //            //  MessageBox.Show("3");
        //        }
        //    }

        //    // isto isto razlicno isto - horizontalno
        //    if (i1 == i2 && ((j1 == j2 - 1 && j1 > 1 && j1 < MATRIX_WIDTH - 1) || (j1 == j2 + 1 && j2 > 2 && j2 < MATRIX_WIDTH)))
        //    {
        //        if ((Images[i1][j1 - 2].Type == Images[i1][j1 - 1].Type) && (Images[i1][j1 - 2].Type != Images[i1][j1].Type) && (Images[i1][j1 - 2].Type == Images[i2][j2].Type))
        //        {
        //            Images[i1][j1 - 2].IsForDeleting = true;
        //            Images[i1][j1 - 1].IsForDeleting = true;
        //            Images[i2][j2].IsForDeleting = true;
        //            Delete = true;
        //            //  MessageBox.Show("3");
        //        }
        //        else if ((Images[i2][j2 - 2].Type == Images[i2][j2 - 1].Type) && (Images[i2][j2 - 2].Type != Images[i2][j2].Type) && (Images[i2][j2 - 2].Type == Images[i1][j1].Type))
        //        {
        //            Images[i2][j2 - 2].IsForDeleting = true;
        //            Images[i2][j2 - 1].IsForDeleting = true;
        //            Images[i1][j1].IsForDeleting = true;
        //            Delete = true;
        //            //  MessageBox.Show("3");
        //        }
        //    }

        //    // isto razlicno isto isto - vertikalno
        //    if (j1 == j2 && ((i1 == i2 - 1 && i1 >= 0 && i1 < MATRIX_HEIGHT - 3) || (i1 == i2 + 1 && i2 >= 0 && i2 < MATRIX_HEIGHT - 3)))
        //    {
        //        if ((Images[i1][j1].Type != Images[i2][j2].Type) && (Images[i1][j1].Type == Images[i1 + 2][j1].Type) && (Images[i1][j1].Type == Images[i1 + 3][j1].Type))
        //        {
        //            Images[i1][j1].IsForDeleting = true;
        //            Images[i1 + 2][j1].IsForDeleting = true;
        //            Images[i1 + 3][j1].IsForDeleting = true;
        //            Delete = true;
        //            //  MessageBox.Show("3");
        //        }
        //        else if ((Images[i2][j2].Type != Images[i1][j1].Type) && (Images[i2][j2].Type == Images[i2 + 2][j2].Type) && (Images[i2][j2].Type == Images[i2 + 3][j2].Type))
        //        {

        //            Images[i2][j2].IsForDeleting = true;
        //            Images[i2 + 2][j2].IsForDeleting = true;
        //            Images[i2 + 3][j2].IsForDeleting = true;
        //            Delete = true;
        //            //  MessageBox.Show("3");
        //        }
        //    }

        //    // isto isto razlicno isto - vertikalno
        //    if (j1 == j2 && ((i1 == i2 - 1 && i1 > 1 && i1 < MATRIX_HEIGHT - 1) || (i1 == i2 + 1 && i2 > 2 && i2 < MATRIX_HEIGHT)))
        //    {
        //        if ((Images[i1 - 2][j1].Type == Images[i1 - 1][j1].Type) && (Images[i1 - 2][j1].Type != Images[i1][j1].Type) && (Images[i1 - 2][j1].Type == Images[i2][j2].Type))
        //        {
        //            Images[i1 - 2][j1].IsForDeleting = true;
        //            Images[i1 - 1][j1].IsForDeleting = true;
        //            Images[i2][j2].IsForDeleting = true;
        //            Delete = true;
        //            //  MessageBox.Show("3");
        //        }
        //        else if ((Images[i2 - 2][j2].Type == Images[i2 - 1][j2].Type) && (Images[i2 - 2][j2].Type != Images[i2][j2].Type) && (Images[i2 - 2][j2].Type == Images[i1][j1].Type))
        //        {
        //            Images[i2 - 2][j2].IsForDeleting = true;
        //            Images[i2 - 1][j2].IsForDeleting = true;
        //            Images[i1][j1].IsForDeleting = true;
        //            Delete = true;
        //            //   MessageBox.Show("3");
        //        }
        //    }

        //    return Delete;
        //}

        public void DeleteSquares()
        {
            for (int i = 0; i < Images.Length; i++)
            {
                for (int j = 0; j < Images[i].Length; j++)
                {
                    if (Images[i][j].Bomba4)
                    {
                        Images[i][j].image = Resources.Black;
                        Images[i][j].Type = Img.ImageType.Bomba4;
                        Images[i][j].Bomba4 = false;
                    }
                    else if (Images[i][j].Bomba5)
                    {
                        Images[i][j].image = Resources.Gray;
                        Images[i][j].Type = Img.ImageType.Bomba5;
                        Images[i][j].Bomba5 = false;
                    }
                    else if (Images[i][j].IsForDeleting)
                    {
                        Images[i][j].IsForDeleting = false;
                        FallDown(i, j);

                        Invalidate();
                    }
                }
            }
        }


        public void DeleteForFive()
        {
            this.MouseDown -= new MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove -= new MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp -= new MouseEventHandler(this.Form1_MouseUp);
            this.MouseClick += new MouseEventHandler(this.Form1_MouseClick);
            TimerForFive = new Timer();
            TimerForFive.Tick += new EventHandler(TimerForFive_Tick);
            TimerForFive.Interval = 1000;
            timeElapsed = 0;
            updateTimer();
            TimerForFive.Start();
            lblVremeForFive.Visible = true;
            Images[CurrentI][CurrentJ].IsForDeleting = true;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //10 sec
            for (int i = 0; i < Images.Length; i++)
            {
                for (int j = 0; j < Images[i].Length; j++)
                {
                    if (Images[i][j].IsHit(e.X, e.Y))
                    {
                        Images[i][j].IsSelected = true;
                        Images[i][j].IsForDeleting = true;
                    }
                }
            }
            Invalidate(true);


        }

        private void TimerForFive_Tick(object sender, EventArgs e)
        {
            timeElapsed++;
            if (timeElapsed == TIME)
            {
                updateTimer();
                TimerForFive.Stop();
                //povikaj funkcija za vrakanje nazad vo igra
                GoBackToGame();
            }
            updateTimer();
        }

        private void GoBackToGame()
        {
            this.MouseClick -= new MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new MouseEventHandler(this.Form1_MouseUp);
            lblVremeForFive.Text = "";
            for (int i = 0; i < Images.Length; i++)
            {
                for (int j = 0; j < Images[i].Length; j++)
                {
                    if (Images[i][j].IsSelected)
                    {
                        Images[i][j].IsSelected = false;

                    }
                }
            }
            lblVremeForFive.Visible = false;
            DeleteSquares();
            Invalidate(true);
        }

        public void updateTimer()
        {
            int left = TIME - timeElapsed;
            int min = left / 60;
            int sec = left % 60;
            lblVremeForFive.Text = string.Format("{0:00}:{1:00}", min, sec);
        }

        public void DeleteForFour(int X, int Y) // ka kje se mrdne bombata
        {
            if (X < MATRIX_HEIGHT-1) Images[X + 1][Y].IsForDeleting = true;
            if (X > 0) Images[X - 1][Y].IsForDeleting = true;
            if (Y < MATRIX_WIDTH - 1) Images[X][Y + 1].IsForDeleting = true;
            if (Y > 0) Images[X][Y - 1].IsForDeleting = true;
            Images[X][Y].IsForDeleting = true;
            if (X < MATRIX_HEIGHT - 1 && Y < MATRIX_WIDTH-1) Images[X + 1][Y + 1].IsForDeleting = true;
            if (X > 0 && Y > 0) Images[X - 1][Y - 1].IsForDeleting = true;
            if (X > 0 && Y < MATRIX_HEIGHT - 1) Images[X - 1][Y + 1].IsForDeleting = true;
            if (Y > 0 && X < MATRIX_WIDTH - 1) Images[X + 1][Y - 1].IsForDeleting = true;
            DeleteSquares();
        }

        public void FallDown(int I, int J)
        {
            if (I == 0)
            {
                Images[I][J].image = Resources.White;
                Images[I][J].Type = Img.ImageType.White;
            }
            //else if (!Images[I - 1][J].IsForDeleting)
            // {
            for (int i = I; i > 0; i--)
            {
                Images[i][J].image = Images[i - 1][J].image;
                Images[i][J].Type = Images[i - 1][J].Type;
                Images[i - 1][J].image = Resources.White;
                Images[i - 1][J].Type = Img.ImageType.White;
            }
            //}
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            if (time == 120)
            {
                timer1.Stop();
                MessageBox.Show("GAME OVER!!");
            }
            int left = 120 - time;
            int min = left / 60;
            int sec = left % 60;
            string s = String.Format("Time left: {0:00}:{1:00} ", min, sec);

            progress = new CustomProgressBar(time, s);
            Invalidate();
        }

        public void GenerateRandomDeletedImages()
        {
            for (int i = 0; i < MATRIX_HEIGHT; i++)
            {
                for (int j = 0; j < MATRIX_WIDTH; j++)
                {
                    if (Images[i][j].Type == Img.ImageType.White)
                    {
                        int type = random.Next(0, 6); // 6 tipovi na sliki (0 - red, 1 - blue, 2 - green, 3 - yellow, 4 - orange, 5 - purple)
                        int x = j * IMAGE_SIZE + 5 * j + 80;
                        int y = i * IMAGE_SIZE + 5 * i + 50;

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
            }
        }

        public bool Check(int i, int j)
        {
            // 5 vertikalno
            if (i > 1 && i < MATRIX_HEIGHT - 2 && Images[i][j].Type == Images[i + 1][j].Type &&
                Images[i][j].Type == Images[i - 1][j].Type && Images[i][j].Type == Images[i + 2][j].Type &&
                Images[i][j].Type == Images[i - 2][j].Type)
            {
                Images[i][j].IsForDeleting = true;
                Images[i - 1][j].IsForDeleting = true;
                Images[i + 1][j].IsForDeleting = true;
                Images[i + 2][j].IsForDeleting = true;
                Images[i - 2][j].IsForDeleting = true;
                return true;
            }

            // 4 vertikalno
            if (i > 1 && i < MATRIX_HEIGHT - 1 && Images[i][j].Type == Images[i + 1][j].Type &&
                Images[i][j].Type == Images[i - 1][j].Type && Images[i][j].Type == Images[i - 2][j].Type)
            {
                Images[i][j].IsForDeleting = true;
                Images[i - 1][j].IsForDeleting = true;
                Images[i + 1][j].IsForDeleting = true;
                Images[i - 2][j].IsForDeleting = true;
                return true;
            }

            // 3 vertikalno
            if (i > 0 && i < MATRIX_HEIGHT - 1 && Images[i][j].Type == Images[i + 1][j].Type
                && Images[i][j].Type == Images[i - 1][j].Type)
            {
                Images[i][j].IsForDeleting = true;
                Images[i - 1][j].IsForDeleting = true;
                Images[i + 1][j].IsForDeleting = true;
                return true;
            }

            // 5 horizontalno
            if (j > 1 && j < MATRIX_WIDTH - 2 && Images[i][j].Type == Images[i][j + 1].Type &&
                Images[i][j].Type == Images[i][j - 1].Type && Images[i][j].Type == Images[i][j + 2].Type &&
                Images[i][j].Type == Images[i][j - 2].Type)
            {
                Images[i][j].IsForDeleting = true;
                Images[i][j - 1].IsForDeleting = true;
                Images[i][j + 1].IsForDeleting = true;
                Images[i][j + 2].IsForDeleting = true;
                Images[i][j - 2].IsForDeleting = true;
                return true;
            }

            // 4 horizontalno
            if (j > 1 && j < MATRIX_WIDTH - 1 && Images[i][j].Type == Images[i][j + 1].Type &&
                Images[i][j].Type == Images[i][j - 1].Type && Images[i][j].Type == Images[i][j - 2].Type)
            {
                Images[i][j].IsForDeleting = true;
                Images[i][j - 1].IsForDeleting = true;
                Images[i][j + 1].IsForDeleting = true;
                Images[i][j - 2].IsForDeleting = true;
                return true;
            }

            // 3 horizontalno
            if (j > 0 && j < MATRIX_WIDTH - 1 && Images[i][j].Type == Images[i][j + 1].Type
                && Images[i][j].Type == Images[i][j - 1].Type)
            {
                Images[i][j].IsForDeleting = true;
                Images[i][j - 1].IsForDeleting = true;
                Images[i][j + 1].IsForDeleting = true;
                return true;
            }

            return false;
        }

        public void CheckAndAddBomb(int i, int j)
        {
            // 5 vertikalno
            if (i > 1 && i < MATRIX_HEIGHT - 2 && Images[i][j].Type == Images[i + 1][j].Type &&
                Images[i][j].Type == Images[i - 1][j].Type && Images[i][j].Type == Images[i + 2][j].Type &&
                Images[i][j].Type == Images[i - 2][j].Type)
            {
                Images[i][j].image = Resources.Gray;
                Images[i][j].Type = Img.ImageType.Bomba5;
                Images[i - 1][j].IsForDeleting = true;
                Images[i + 1][j].IsForDeleting = true;
                Images[i + 2][j].IsForDeleting = true;
                Images[i - 2][j].IsForDeleting = true;
            }

            // 4 vertikalno isto isto razl isto
            if (i > 1 && i < MATRIX_HEIGHT - 1 && Images[i][j].Type == Images[i + 1][j].Type &&
                Images[i][j].Type == Images[i - 1][j].Type && Images[i][j].Type == Images[i - 2][j].Type)
            {
                Images[i][j].image = Resources.Black;
                Images[i][j].Type = Img.ImageType.Bomba4;
                Images[i - 1][j].IsForDeleting = true;
                Images[i + 1][j].IsForDeleting = true;
                Images[i - 2][j].IsForDeleting = true;
            }

            // 4 vertikalno isto razl isto isto
            if (i > 0 && i < MATRIX_HEIGHT - 2 && Images[i][j].Type == Images[i + 1][j].Type &&
                Images[i][j].Type == Images[i - 1][j].Type && Images[i][j].Type == Images[i + 2][j].Type)
            {
                Images[i][j].image = Resources.Black;
                Images[i][j].Type = Img.ImageType.Bomba4;
                Images[i - 1][j].IsForDeleting = true;
                Images[i + 1][j].IsForDeleting = true;
                Images[i + 2][j].IsForDeleting = true;
            }

            // 3 vertikalno
            if (i > 0 && i < MATRIX_HEIGHT - 1 && Images[i][j].Type == Images[i + 1][j].Type
                && Images[i][j].Type == Images[i - 1][j].Type)
            {
                Images[i][j].IsForDeleting = true;
                Images[i - 1][j].IsForDeleting = true;
                Images[i + 1][j].IsForDeleting = true;
            }

            // 5 horizontalno
            if (j > 1 && j < MATRIX_WIDTH - 2 && Images[i][j].Type == Images[i][j + 1].Type &&
                Images[i][j].Type == Images[i][j - 1].Type && Images[i][j].Type == Images[i][j + 2].Type &&
                Images[i][j].Type == Images[i][j - 2].Type)
            {
                Images[i][j].image = Resources.Gray;
                Images[i][j].Type = Img.ImageType.Bomba5;
                Images[i][j - 1].IsForDeleting = true;
                Images[i][j + 1].IsForDeleting = true;
                Images[i][j + 2].IsForDeleting = true;
                Images[i][j - 2].IsForDeleting = true;
            }

            // 4 horizontalno isto isto razl isto
            if (j > 1 && j < MATRIX_WIDTH - 1 && Images[i][j].Type == Images[i][j + 1].Type &&
                Images[i][j].Type == Images[i][j - 1].Type && Images[i][j].Type == Images[i][j - 2].Type)
            {
                Images[i][j].image = Resources.Black;
                Images[i][j].Type = Img.ImageType.Bomba4;
                Images[i][j - 1].IsForDeleting = true;
                Images[i][j + 1].IsForDeleting = true;
                Images[i][j - 2].IsForDeleting = true;
            }
            // 4 horizontalno isto razl isto isto
            if (j > 0 && j < MATRIX_WIDTH - 2 && Images[i][j].Type == Images[i][j + 1].Type &&
                Images[i][j].Type == Images[i][j - 1].Type && Images[i][j].Type == Images[i][j + 2].Type)
            {
                Images[i][j].image = Resources.Black;
                Images[i][j].Type = Img.ImageType.Bomba4;
                Images[i][j - 1].IsForDeleting = true;
                Images[i][j + 1].IsForDeleting = true;
                Images[i][j + 2].IsForDeleting = true;
            }

            // 3 horizontalno
            if (j > 0 && j < MATRIX_WIDTH - 1 && Images[i][j].Type == Images[i][j + 1].Type
                && Images[i][j].Type == Images[i][j - 1].Type)
            {
                Images[i][j].IsForDeleting = true;
                Images[i][j - 1].IsForDeleting = true;
                Images[i][j + 1].IsForDeleting = true;
            }
            //3 horizontalno - na rab desno
            if (j == MATRIX_WIDTH - 1 && Images[i][j].Type == Images[i][j - 1].Type
                && Images[i][j].Type == Images[i][j - 2].Type)
            {
                Images[i][j].IsForDeleting = true;
                Images[i][j - 1].IsForDeleting = true;
                Images[i][j - 2].IsForDeleting = true;
            }
            //3 horizontalno - na rab levo
            if (j == 0 && Images[i][j].Type == Images[i][j + 1].Type
                && Images[i][j].Type == Images[i][j + 2].Type)
            {
                Images[i][j].IsForDeleting = true;
                Images[i][j + 1].IsForDeleting = true;
                Images[i][j + 2].IsForDeleting = true;
            }
        }

        private void btnHint_Click(object sender, EventArgs e)
        {
           Hint();
            NoOfUsedHints++;
            int x = 3 - NoOfUsedHints;
            lblNumOfHits.Text = String.Format("{0} hits left.", x);
            if (NoOfUsedHints == 3)
            {
                btnHint.Enabled = false;
            }
        }

        public void Hint()
        {
            bool flag = false;
            for (int i = 0; i < MATRIX_HEIGHT; i++)
            {
                for (int j = 0; j < MATRIX_WIDTH; j++)
                {
                    //bomba 5
                    if(Images[i][j].Type == Img.ImageType.Bomba5)
                    {
                        Images[i][j].IsSelected = true;
                        if(j > 0)
                        {
                            Images[i][j - 1].IsSelected = true;
                        }
                        else
                        Images[i][j + 1].IsSelected = true;
                        flag = true;
                        break;
                    }
                    //bomba 4
                    if (Images[i][j].Type == Img.ImageType.Bomba4)
                    {
                        Images[i][j].IsSelected = true;
                        if (j > 0)
                        {
                            Images[i][j - 1].IsSelected = true;
                        }
                        else
                            Images[i][j + 1].IsSelected = true;
                        flag = true;
                        break;
                    }
                    // levo isto razl isto isto
                    if (j > 0 && j < MATRIX_WIDTH - 2 && Images[i][j - 1].Type == Images[i][j + 1].Type && Images[i][j - 1].Type == Images[i][j + 2].Type)
                    {
                        Images[i][j - 1].IsSelected = true;
                        Images[i][j + 1].IsSelected = true;
                        Images[i][j + 2].IsSelected = true;
                        flag = true;
                        break;
                       
                    }
                    // desno isto isto razl isto
                    if(j > 1 && j < MATRIX_WIDTH - 1 && Images[i][j - 1].Type == Images[i][j + 1].Type && Images[i][j - 1].Type == Images[i][j - 2].Type)
                    {
                        Images[i][j - 1].IsSelected = true;
                        Images[i][j + 1].IsSelected = true;
                        Images[i][j - 2].IsSelected = true;
                        flag = true;
                        break;
                    }
                    // isto isto gore
                    if(i > 0 && j>0 && j<MATRIX_WIDTH - 1 &&  Images[i][j].Type == Images[i][j - 1].Type && Images[i][j - 1].Type == Images[i - 1][j + 1].Type)
                    {
                        Images[i][j].IsSelected = true;
                        Images[i][j - 1].IsSelected = true;
                        Images[i-1][j + 1].IsSelected = true;
                        flag = true;
                        break;
                    }
                    // isto isto dole
                    if (i < MATRIX_HEIGHT - 1 && j > 0 && j < MATRIX_WIDTH - 1 && Images[i][j].Type == Images[i][j - 1].Type && Images[i][j - 1].Type == Images[i + 1][j + 1].Type)
                    {
                        Images[i][j].IsSelected = true;
                        Images[i][j - 1].IsSelected = true;
                        Images[i + 1][j + 1].IsSelected = true;
                        flag = true;
                        break;
                    }
                    // gore isto isto 
                    if (i > 0 && j > 0 && j < MATRIX_WIDTH - 1 && Images[i][j].Type == Images[i][j + 1].Type && Images[i][j + 1].Type == Images[i - 1][j - 1].Type)
                    {
                        Images[i][j].IsSelected = true;
                        Images[i][j + 1].IsSelected = true;
                        Images[i - 1][j - 1].IsSelected = true;
                        flag = true;
                        break;
                    }
                    // dole isto isto 
                    if (i < MATRIX_HEIGHT - 1 && j > 0 && j < MATRIX_WIDTH - 1 && Images[i][j].Type == Images[i][j + 1].Type && Images[i][j + 1].Type == Images[i + 1][j - 1].Type)
                    {
                        Images[i][j].IsSelected = true;
                        Images[i][j + 1].IsSelected = true;
                        Images[i + 1][j - 1].IsSelected = true;
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    break;
                }
            }
            Invalidate();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (btnPause.Text == "Pause")
            {
                btnPause.Text = "Start";
                GamePause();
            }
            else
            {
                btnPause.Text = "Pause";
                GameUnPause();
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show( "Guest the term behind the photo and add 5 sec to your time!", "Earn extra time", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                CallAssociation();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GamePause();
            SoundForm af = new SoundForm();
            if (af.ShowDialog() == DialogResult.OK)
            {
                af.Close();
            }
            GameUnPause();

        }

        public void CheckState()
        {
            for (int i = 0; i < MATRIX_HEIGHT; i++)
            {
                for (int j = 0; j < MATRIX_WIDTH; j++)
                {
                    if (Check(i, j))
                    {
                        DeleteSquares();
                        Invalidate();
                    }
                }
            }
        }

        public bool IsSwapPossible(int a, int b, int a1, int b1)
        {
            int i1 = a;
            int j1 = b;
            int i2 = a1;
            int j2 = b1;

            if (j1 == j2 && J != -1)
            {
                // nad pod - horizontala

                // isto isto (first ili second) isto isto
                if (j1 > 1 && j1 < MATRIX_WIDTH - 2 && j2>1 && j2 < MATRIX_WIDTH - 2)
                {
                    // sobira 5
                    if ((Images[i1][j1 - 2].Type == Images[i1][j1 - 1].Type) && (Images[i1][j1 - 2].Type == Images[i2][j2].Type) && (Images[i1][j1 - 2].Type == Images[i1][j1 + 1].Type) && (Images[i1][j1 - 2].Type == Images[i1][j1 + 2].Type))
                    {
                        return true;
                    }
                    else if ((Images[i2][j2 - 2].Type == Images[i2][j2 - 1].Type) && (Images[i2][j2 - 2].Type == Images[i1][j1].Type) && (Images[i2][j2 - 2].Type == Images[i2][j2 + 1].Type) && (Images[i2][j2 - 2].Type == Images[i2][j2 + 2].Type))
                    {
                        return true;
                    }
                }

                // isto isto (first ili second) isto
                if (j1 > 1 && j1 < MATRIX_WIDTH - 1 && j2 > 1)
                {
                    if ((Images[i1][j1 - 2].Type == Images[i1][j1 - 1].Type) && (Images[i1][j1 - 2].Type == Images[i2][j2].Type) && (Images[i1][j1 - 2].Type == Images[i1][j1 + 1].Type))
                    {
                        return true;
                    }
                    else if ((Images[i2][j2 - 2].Type == Images[i2][j2 - 1].Type) && (Images[i2][j2 - 2].Type == Images[i1][j1].Type) && (Images[i2][j2 - 2].Type == Images[i2][j2 + 1].Type))
                    {
                        return true;
                    }
                }

                // isto (first ili second) isto isto
                if (j1 > 0 && j1 < MATRIX_WIDTH - 2 && j2 > 0 && j2 < MATRIX_WIDTH - 2)
                {
                    if ((Images[i1][j1 - 1].Type == Images[i2][j2].Type) && (Images[i1][j1 - 1].Type == Images[i1][j1 + 1].Type) && (Images[i1][j1 - 1].Type == Images[i1][j1 + 2].Type))
                    {
                        return true;
                    }
                    else if ((Images[i2][j2 - 1].Type == Images[i1][j1].Type) && (Images[i2][j2 - 1].Type == Images[i2][j2 + 1].Type) && (Images[i2][j2 - 1].Type == Images[i2][j2 + 2].Type))
                    {
                        return true;
                    }
                }

                // (first ili second) isto isto
                if (j1 >= 0 && j1 < MATRIX_WIDTH - 2 && j2 >= 0 && j2 < MATRIX_WIDTH - 2)
                {
                    if ((Images[i2][j2].Type == Images[i1][j1 + 1].Type) && (Images[i2][j2].Type == Images[i1][j1 + 2].Type))
                    {
                        return true;
                    }
                    else if ((Images[i1][j1].Type == Images[i2][j2 + 1].Type) && (Images[i1][j1].Type == Images[i2][j2 + 2].Type))
                    {
                        return true;
                    }
                }

                // isto (first ili second) isto
                if (j1 > 0 && j1 < MATRIX_WIDTH - 1 && j2 > 0 && j2 < MATRIX_WIDTH - 1)
                {
                    if ((Images[i1][j1 - 1].Type == Images[i2][j2].Type) && (Images[i1][j1 - 1].Type == Images[i1][j1 + 1].Type))
                    {
                        return true;
                    }
                    else if ((Images[i2][j2 - 1].Type == Images[i1][j1].Type) && (Images[i2][j2 - 1].Type == Images[i2][j2 + 1].Type))
                    {
                        return true;
                    }
                }

                // isto isto (first ili second)
                if (j1 > 1 && j1 < MATRIX_WIDTH )
                {
                    if ((Images[i1][j1 - 2].Type == Images[i1][j1 - 1].Type) && (Images[i1][j1 - 2].Type == Images[i2][j2].Type))
                    {
                        return true;
                    }
                    else if ((Images[i2][j2 - 2].Type == Images[i2][j2 - 1].Type) && (Images[i2][j2 - 2].Type == Images[i1][j1].Type))
                    {
                        return true;
                    }
                }
            }
            else if (i1 == i2 && I != -1)
            {
                // levo desno - vertikala

                // isto isto (first ili second) isto isto
                if (i1 > 1 && i1 < MATRIX_HEIGHT - 2 && i2 > 1)
                {
                    if ((Images[i2 - 2][j2].Type == Images[i2 - 1][j2].Type) && (Images[i2 - 2][j2].Type == Images[i1][j1].Type) && (Images[i2 - 2][j2].Type == Images[i2 + 1][j2].Type) && (Images[i2 - 2][j2].Type == Images[i2 + 2][j2].Type))
                    {
                        return true;
                    }
                    else if ((Images[i1 - 2][j1].Type == Images[i1 - 1][j1].Type) && (Images[i1 - 2][j1].Type == Images[i2][j2].Type) && (Images[i1 - 2][j1].Type == Images[i1 + 1][j1].Type) && (Images[i1 - 2][j1].Type == Images[i1 + 2][j1].Type))
                    {
                        return true;
                    }
                }

                // isto isto (first ili second) isto
                if (i1 > 1 && i1 < MATRIX_HEIGHT - 1 && i2 > 1)
                {
                    if ((Images[i2 - 2][j2].Type == Images[i2 - 1][j2].Type) && (Images[i2 - 2][j2].Type == Images[i1][j1].Type) && (Images[i2 - 2][j2].Type == Images[i2 + 1][j2].Type))
                    {
                        return true;
                    }
                    else if ((Images[i1 - 2][j1].Type == Images[i1 - 1][j1].Type) && (Images[i1 - 2][j1].Type == Images[i2][j2].Type) && (Images[i1 - 2][j1].Type == Images[i1 + 1][j1].Type))
                    {
                        return true;
                    }
                }

                // isto (first ili second) isto isto
                if (i1 > 0 && i1 < MATRIX_HEIGHT - 2 && i2 > 0 && i2 < MATRIX_WIDTH - 2  )
                {
                    if ((Images[i2 - 1][j2].Type == Images[i1][j1].Type) && (Images[i2 - 1][j2].Type == Images[i2 + 1][j2].Type) && (Images[i2 - 1][j2].Type == Images[i2 + 2][j2].Type))
                    {
                        return true;
                    }
                    else if ((Images[i1 - 1][j1].Type == Images[i2][j2].Type) && (Images[i1 - 1][j1].Type == Images[i1 + 1][j1].Type) && (Images[i1 - 1][j1].Type == Images[i1 + 2][j1].Type))
                    {
                        return true;
                    }
                }

                // (first ili second) isto isto
                if (i1 >= 0 && i1 < MATRIX_HEIGHT - 2  && i2 < MATRIX_WIDTH - 2)
                {
                    if ((Images[i1][j1].Type == Images[i2 + 1][j2].Type) && (Images[i2 + 1][j2].Type == Images[i2 + 2][j2].Type))
                    {
                        return true;
                    }
                    else if ((Images[i2][j2].Type == Images[i1 + 1][j1].Type) && (Images[i1 + 1][j1].Type == Images[i1 + 2][j1].Type))
                    {
                        return true;
                    }
                }

                // isto (first ili second) isto
                if (i1 > 0 && i1 < MATRIX_HEIGHT - 1 && i2 > 0 && i2 < MATRIX_WIDTH -1)
                {
                    if ((Images[i2 - 1][j2].Type == Images[i1][j1].Type) && (Images[i2 - 1][j2].Type == Images[i2 + 1][j2].Type))
                    {
                        return true;
                    }
                    else if ((Images[i1 - 1][j1].Type == Images[i2][j2].Type) && (Images[i1 - 1][j1].Type == Images[i1 + 1][j1].Type))
                    {
                        return true;
                    }
                }

                // isto isto (first ili second)
                if (i1 > 1 && i1 < MATRIX_HEIGHT && i2 > 1)
                {
                    if ((Images[i2 - 2][j2].Type == Images[i2 - 1][j2].Type) && (Images[i2 - 2][j2].Type == Images[i1][j1].Type))
                    {
                        return true;
                    }
                    else if ((Images[i1 - 2][j1].Type == Images[i1 - 1][j1].Type) && (Images[i1 - 2][j1].Type == Images[i2][j2].Type))
                    {
                        return true;
                    }
                }
            }

            // isto razlicno isto isto - horizontalno
            if (i1 == i2 && ((j1 == j2 - 1 && j1 >= 0 && j1 < MATRIX_WIDTH - 3) || (j1 == j2 + 1 && j2 >= 0 && j2 < MATRIX_WIDTH - 3)))
            {
                if (j1 == j2 - 1 && j1 >= 0 && j1 < MATRIX_WIDTH - 3 && (Images[i1][j1].Type != Images[i2][j2].Type) && (Images[i1][j1].Type == Images[i1][j1 + 2].Type) && (Images[i1][j1].Type == Images[i1][j1 + 3].Type))
                {
                    return true;
                }
                else if (j1 == j2 + 1 && j2 >= 0 && j2 < MATRIX_WIDTH - 3 && (Images[i2][j2].Type != Images[i1][j1].Type) && (Images[i2][j2].Type == Images[i2][j2 + 2].Type) && (Images[i2][j2].Type == Images[i2][j2 + 3].Type))
                {
                    return true;
                }
            }

            // isto isto razlicno isto - horizontalno
            if (i1 == i2 && ((j1 == j2 - 1 && j1 > 1 && j1 < MATRIX_WIDTH - 1) || (j1 == j2 + 1 && j2 > 2 && j2 < MATRIX_WIDTH)))
            {
                if (j1 == j2 - 1 && j1 > 1 && j1 < MATRIX_WIDTH - 1 && (Images[i1][j1 - 2].Type == Images[i1][j1 - 1].Type) && (Images[i1][j1 - 2].Type != Images[i1][j1].Type) && (Images[i1][j1 - 2].Type == Images[i2][j2].Type))
                {
                    return true;
                }
                else if (j1 == j2 + 1 && j2 > 2 && j2 < MATRIX_WIDTH && (Images[i2][j2 - 2].Type == Images[i2][j2 - 1].Type) && (Images[i2][j2 - 2].Type != Images[i2][j2].Type) && (Images[i2][j2 - 2].Type == Images[i1][j1].Type))
                {
                    return true;
                }
            }

            // isto razlicno isto isto - vertikalno
            if (j1 == j2 && ((i1 == i2 - 1 && i1 >= 0 && i1 < MATRIX_HEIGHT - 3) || (i1 == i2 + 1 && i2 >= 0 && i2 < MATRIX_HEIGHT - 3)))
            {
                if (i1 == i2 - 1 && i1 >= 0 && i1 < MATRIX_HEIGHT - 3 && (Images[i1][j1].Type != Images[i2][j2].Type) && (Images[i1][j1].Type == Images[i1 + 2][j1].Type) && (Images[i1][j1].Type == Images[i1 + 3][j1].Type))
                {
                    return true;
                }
                else if (i1 == i2 + 1 && i2 >= 0 && i2 < MATRIX_HEIGHT - 3 && (Images[i2][j2].Type != Images[i1][j1].Type) && (Images[i2][j2].Type == Images[i2 + 2][j2].Type) && (Images[i2][j2].Type == Images[i2 + 3][j2].Type))
                {

                    return true;
                    //  MessageBox.Show("3");
                }
            }

            // isto isto razlicno isto - vertikalno
            if (j1 == j2 && ((i1 == i2 - 1 && i1 > 1 && i1 < MATRIX_HEIGHT - 1) || (i1 == i2 + 1 && i2 > 2 && i2 < MATRIX_HEIGHT)))
            {
                if (i1 == i2 - 1 && i1 > 1 && i1 < MATRIX_HEIGHT - 1 && (Images[i1 - 2][j1].Type == Images[i1 - 1][j1].Type) && (Images[i1 - 2][j1].Type != Images[i1][j1].Type) && (Images[i1 - 2][j1].Type == Images[i2][j2].Type))
                {
                    return true;
                }
                else if (i1 == i2 + 1 && i2 > 2 && i2 < MATRIX_HEIGHT && (Images[i2 - 2][j2].Type == Images[i2 - 1][j2].Type) && (Images[i2 - 2][j2].Type != Images[i2][j2].Type) && (Images[i2 - 2][j2].Type == Images[i1][j1].Type))
                {
                    return true;
                }
            }

            return false;
        }

        public void Shuffle()
        {
            bool ShuffleNeeded = true;
            for (int i = 0; i < MATRIX_HEIGHT; i++)
            {
                for (int j = 0; j < MATRIX_WIDTH; j++)
                {
                    // ako ima bomba, postoi sleden poteg
                    if(Images[i][j].Type == Img.ImageType.Bomba4 || Images[i][j].Type == Img.ImageType.Bomba5)
                    {
                        ShuffleNeeded = false;
                    }

                    // gore
                    if(i > 0 && IsSwapPossible(i, j, i - 1, j))
                    {
                        ShuffleNeeded = false;
                    }

                    // levo
                    if(j > 0 && IsSwapPossible(i, j, i, j - 1))
                    {
                        ShuffleNeeded = false;
                    }

                    // dole
                    if(i < MATRIX_HEIGHT - 1 && IsSwapPossible(i, j, i + 1, j))
                    {
                        ShuffleNeeded = false;
                    }

                    // desno
                    if(j < MATRIX_WIDTH - 1 && IsSwapPossible(i, j, i, j + 1))
                    {
                        ShuffleNeeded = false;
                    }
                }

                if (!ShuffleNeeded)
                    break;
            }

            if (ShuffleNeeded)
            {
              //  MessageBox.Show("No more possible moves.. Shuffle");
                GenerateRandomImages();
            }
        }
    }
}
