using Bejeweled.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bejeweled
{
    public partial class AsocijacijaForm : Form
    {
       
        public int i;
        int t;
        public int Guesses;
        public string image;
        public string solution;
        public  SoundPlayer soundPlayerAsos;

        List<int> indeksi;
        int index;
        Random r;
        int brojac;
       
        public AsocijacijaForm()
        {
            InitializeComponent();
            timer1.Start();
            i = 0;
            lblTime.Text = "Time left: 20"; 
            Guesses = 0;
            t = 0;
            r = new Random();
            index = 0;
            indeksi = new List<int>();
            soundPlayerAsos = new SoundPlayer();
            refresh();
            generateImage(index);
            brojac = 0;
        }

        

        private void btnGuess_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            txtSolution.Visible = true;
            btnCheck.Visible = true;
            txtSolution.Focus();
        }
        private void btnCheck_Click(object sender, EventArgs e) 
        {
            if (txtSolution.Text != "")
            {
                string x = txtSolution.Text.Trim().ToLower();
                string y = solution.Trim().ToLower();
                int cmp = x.CompareTo(y);

                if (cmp == 0)
                {
                    soundPlayerAsos = new SoundPlayer(Resources.Correct_Answer);
                    soundPlayerAsos.Play();
                    Guesses++;
                    lblPoints.Text = "Current guesses: " + Guesses;
                    refresh();
                    brojac++;
                    if (brojac == 7)
                    {
                        timer1.Stop();
                        soundPlayerAsos.Stop();
                        this.Close();
                    }
                    else
                    {
                        generateImage(index);
                    }
                }
                else
                {
                    soundPlayerAsos = new SoundPlayer(Resources.Wrong_answer);
                    soundPlayerAsos.Play();
            
                    refresh();
                    brojac++;
                    if (brojac == 7)
                    {
                        timer1.Stop();
                        soundPlayerAsos.Stop();

                        this.Close();
                    }
                    else
                    {
                        generateImage(index);
                    }
                    //generateImage(index);

                }
            }
                else
                {
                    MessageBox.Show("Внесете го Вашето решение па кликнете на копчето Guess");
                   // timer1.Start();
                }
          
            txtSolution.Text = "";
        }

     

        private void timer1_Tick(object sender, EventArgs e)
        {
            t++;
            int left = 20 - t;
            lblTime.Text = string.Format("Time left:  {0:00}", left);
            if (left == 0)
            {
               //picture.Image = Resources.gameOver;
                btnCheck.Visible = false;
                btnNext.Visible = false;
                txtSolution.Visible = false;
                soundPlayerAsos.Stop();

                timer1.Stop();
                this.Close();
            }
            if (!Form1.flagSoundIcon)
            {
                soundPlayerAsos.Stop();
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            refresh();
            if (brojac == 6)
            {
                btnNext.Enabled = false;
              //  this.Close();
            }
            else
            {
                generateImage(index);
            }
        }
       
        private void refresh()
        {
            index = r.Next(0, 8);
            if (indeksi.Contains(index))
            {
                while (indeksi.Contains(index))
                {
                    index = r.Next(0, 8);
                }
            }
            indeksi.Add(index);
            txtSolution.Text = "";
        }
        private void generateImage(int index)
        {
           
            if (index == 0)
            {
                picture.BackgroundImage = Resources.comet1;
                lblText.Text = "An icy blue trail:";
                solution = "comet";
            }
            if (index == 1)
            {
                picture.BackgroundImage = Resources.sun1;
                lblText.Text = "The brightest star:";
                solution = "sun";
            }
            if (index == 2)
            {
                picture.BackgroundImage = Resources.star1;
                lblText.Text = "A sky full of:";
                solution = "stars";
            }
            if (index == 3)
            {
                picture.BackgroundImage = Resources.moon;
                lblText.Text = "Our satallite: ";
                solution = "moon";
            }
            if (index == 4)
            {
                picture.BackgroundImage = Resources.jupiter1;
                lblText.Text = "The biggest planet: ";
                solution = "jupiter";
            }
            if (index == 5)
            {
                picture.BackgroundImage = Resources.earth1;
                lblText.Text = "Our planet: ";
                solution = "earth";
            }
            if (index == 6)
            {
                picture.BackgroundImage = Resources.mars1;
                lblText.Text = "The red planet: ";
                solution = "mars";
            }
            if (index == 7)
            {
                picture.BackgroundImage = Resources.blackHole;
                lblText.Text = "Has the strongest \n gravitational pull:";
                solution = "black hole";
            }

        }

        private void txtSolution_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
              
                if (txtSolution.Text != "")
                {
                    string x = txtSolution.Text.Trim().ToLower();
                    string y = solution.Trim().ToLower();
                    int cmp = x.CompareTo(y);

                    if (cmp == 0)
                    {
                        soundPlayerAsos = new SoundPlayer(Resources.Correct_Answer);
                        soundPlayerAsos.Play();
                        Guesses++;
                        lblPoints.Text = "Current guesses: " + Guesses;
                        refresh();
                        generateImage(index);

                    }
                    else
                    {
                        soundPlayerAsos = new SoundPlayer(Resources.Wrong_answer);
                        soundPlayerAsos.Play();
                        refresh();
                        generateImage(index);

                    }
                    brojac++;
                    if (brojac == 7)
                    {
                        timer1.Stop();
                        soundPlayerAsos.Stop();

                        this.Close();
                    }
                    else
                    {
                        generateImage(index);
                    }
                }
                else
                {
                    MessageBox.Show("Внесете го Вашето решение па кликнете на копчето Guess");
                    timer1.Start();
                }

                txtSolution.Text = "";
               
            }
                    
        }

        private void AsocijacijaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void AsocijacijaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
            timer1.Stop();
            soundPlayerAsos.Stop();
        }
    }
}
