using System;
using System.Windows.Forms;

namespace Game_WinForm
{
    public partial class Form1 : Form
    {
        bool UpPressed;
        bool DownPressed;
        bool LeftPressed;
        bool RightPressed;
        int Score = 0;
        int Lives = 5;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                UpPressed = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                DownPressed = true;
            }

            if (e.KeyCode == Keys.Left)
            {
                LeftPressed = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                RightPressed = true;
            }
        }

        private void Form1_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                UpPressed = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                DownPressed = false;
            }

            if (e.KeyCode == Keys.Left)
            {
                LeftPressed = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                RightPressed = false;
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (UpPressed)
            {
                pictureBox1.Top -= 5;

                if (pictureBox1.Top < 0)
                {
                    pictureBox1.Top = 0;
                }
            }

            if (DownPressed)
            {
                pictureBox1.Top += 5;

                if (pictureBox1.Top + pictureBox1.Height > ClientSize.Height)
                {
                    pictureBox1.Top = ClientSize.Height - pictureBox1.Height;
                }
            }

            if (LeftPressed)
            {
                pictureBox1.Left -= 5;

                if (pictureBox1.Left < 0)
                {
                    pictureBox1.Left = 0;
                }
            }

            if (RightPressed)
            {
                pictureBox1.Left += 5;

                if (pictureBox1.Left + pictureBox1.Width > ClientSize.Width)
                {
                    pictureBox1.Left = ClientSize.Width - pictureBox1.Width;
                }
            }

            if (Collision(pictureBox1, pictureBox2))
            {
                Random random = new Random();
                pictureBox2.Top = random.Next(0, ClientSize.Height - pictureBox2.Height);
                pictureBox2.Left = random.Next(0, ClientSize.Width - pictureBox2.Width);

                Score = Score + 1;
                label1.Text = "Score: " + Score.ToString();
            }
            Chase(ref pictureBox3, ref pictureBox1);

            label2.Text = "Lives: " + Lives.ToString();

            if (Collision(pictureBox1, pictureBox3) == true)
            {
                if (Lives > 1)
                {
                    Lives = Lives - 1;

                    pictureBox1.Top = 0;
                    pictureBox1.Left = 0;

                    pictureBox3.Top=this.Height-pictureBox3.Height;
                    pictureBox3.Left=this.Width-pictureBox3.Width;
                }
                else
                {
                    Lives = 5;
                    label2.Text = "Lives: 0";
                    timer1.Stop();
                    HighScore highscore = new HighScore(label1.Text);
                    highscore.ShowDialog();
                }
            }
        }

        private bool Collision(PictureBox object1, PictureBox object2)
        {
            return object1.Bounds.IntersectsWith(object2.Bounds);
        }

        void Chase(ref PictureBox object1, ref PictureBox object2)
        {
            if (object1.Left > object2.Left)
            {
                object1.Left -= 2;
            }
            if (object1.Left < object2.Left)
            {
                object1.Left += 2;
            }
            if (object1.Top > object2.Top)
            {
                object1.Top -= 2;
            }
            if (object1.Top< object2.Top)
            {
                object1.Top += 2;
            }
        }
    }
}
