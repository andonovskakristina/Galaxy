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
    public partial class AsocijacijaForm : Form
    {
        public string[] solutions = { "planet", "comet", "star" };
        public int i;
        int t;
        int points;
        bool flag = true;
        bool flag1 = false;
       
        public AsocijacijaForm()
        {
            InitializeComponent();
            timer1.Start();
            i = 0;
            lblVreme.Text = "Time left: 20";
            points = 0;
            t = 0;
        }
        private void StartDialog()
        {
           
           if(MessageBox.Show("Earn extra time","Guest the term behind the photo and and 5 sec to your time!",MessageBoxButtons.YesNo) == DialogResult.OK)
            {
                timer1.Start();
            }

        }

        private void btnGuess_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            txtSolution.Visible = true;
            btnCheck.Visible = true;
            txtSolution.Focus();
        }

        private void btnCheck_Click(object sender, EventArgs e)   //dava 5 poeni ili ti zema 10 sekundi
        { 
            {
                if (txtSolution.Text != "")
                {
                    if (txtSolution.Text.Equals(solutions[i]))
                    {
                        MessageBox.Show("QUESS!!!  Well done!");
                        points += 5;
                        i++;
                        lblPoints.Text = "Current points: " + points.ToString();
                        txtSolution.Text = "";
                        if (i == 3)
                        {
                            picture.Image = Resources.gameOver;
                            btnCheck.Visible = false;
                            btnNext.Visible = false;
                            txtSolution.Visible = false;
                            lblVreme.Text = string.Format("Time left:  0:00");
                            MessageBox.Show("You won " + points + "points!!");
                            timer1.Stop();
                            this.Close();
                        }
                        else
                        {

                            if (flag)
                            {
                                picture.Image = Resources.two;
                                flag = false;

                            }
                            else
                            {
                                picture.Image = Resources.three;
                            }
                        }
                        timer1.Start();
                    }
                    else
                    {
                        MessageBox.Show("MISS!!! Think smarter!");
                        if (t > 6)
                        {
                            t -= 5;
                            UpdateTimer();
                        }
                        txtSolution.Text = "";
                        timer1.Start();
                    }
                }
                else
                {
                    MessageBox.Show("Внесете го Вашето решение па кликнете на копчето Guess");
                    timer1.Start();
                }
            }

        }

        public void UpdateTimer()
        {
            t++;
            int left = 20 - t;
            lblVreme.Text = string.Format("Time left:  {0:00}", left);
            if (left == 0)
            {
                picture.Image = Resources.gameOver;
                btnCheck.Visible = false;
                btnNext.Visible = false;
                txtSolution.Visible = false;
                timer1.Stop();
              //  MessageBox.Show("You won " + points + "points!!");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateTimer();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (i == 2)
            {
                btnNext.Enabled = false;
            }
            else
            {
                txtSolution.Text = "";
                i++;
                GenerateImages();
                btnCheck.Visible = !false;
                btnNext.Visible = !false;
                txtSolution.Visible = !false;
                if (t > 11)
                {
                    t -= 5;
                }
                UpdateTimer();
            }
        }
        public void GenerateImages()
        {
            btnCheck.Visible = false;
            txtSolution.Visible = false;
            if (flag1)
            {
                picture.Image = Resources.three;
            }
            else if (flag)
            {
                picture.Image = Resources.two;
                flag = false;
                flag1 = true;
            }

        }
    }
}
