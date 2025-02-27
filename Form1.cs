using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Ballon_pop_arcade_game_MOO_ICT.Form1;


namespace Ballon_pop_arcade_game_MOO_ICT
{
    public partial class Form1 : Form
    {
        int speed;
        int score;
        Random rand = new Random();
        bool gameOver;


        public class Bomb
        {
            public Image Image { get; set; }

        }




        public Form1()
        {
            InitializeComponent();
            RestartGame();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score;
            {
                txtScore.Text = "Score: " + score + " Game over , press enter to restart!";
            }

            foreach(Control x in this .Controls)
            {
                x.Top -= speed;

                if(x.Top < -100)
                {
                    x.Top = rand.Next(700, 1000);
                    x.Left = rand.Next(5, 500);
                }
                
                if((string)x.Tag == "balloon")
                {
                    if(x.Top < -50)
                    {
                        gameOver = true;
                    }
                }
            }
        }

        




        private void PopBalloon(object sender, EventArgs e)
        {
            if (gameOver == false)
            {
                var balloon = (PictureBox)sender;

                balloon.Top = rand.Next(700, 1000);
                balloon.Left = rand.Next(5, 500);

                score += 1;
            }
        }

        private void PopBallon(object sender, EventArgs e)
        {
            if (gameOver == false)
            {
                var balloon = (PictureBox)sender;

                balloon.Top = rand.Next(700, 1000);
                balloon.Left = rand.Next(5, 500);

                score += 1;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && gameOver == true)
            {
                RestartGame();
            }

        }

        private void RestartGame()
        {
            speed = 5;
            score = 0;
            gameOver = false;



            var bomb = new Bomb();
            bomb.Image = Properties.Resources.bomb;  // Assuming bomb is a valid image in your resources



            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    x.Top = rand.Next(750, 1000);
                    x.Left = rand.Next(5, 500);


                }


            }

            gameTimer.Start();

        }

        private void GoBoom(object sender, EventArgs e)
        {
            if (gameOver == false)
            {
                var bomb = new Bomb();
                bomb.Image = Properties.Resources.boom;
                gameOver = true;
            }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
