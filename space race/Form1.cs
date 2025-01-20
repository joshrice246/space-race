using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace space_race
{
    public partial class Form1 : Form
    {
        //ints 
        Rectangle player1 = new Rectangle(190, 399, 20, 20);
        Rectangle player2 = new Rectangle(485, 399, 20, 20);
        Rectangle point = new Rectangle(0, 13, 689,10);
        Rectangle sep = new Rectangle(330, 0, 10, 689);
       

        Random randgen = new Random();

        int player1Score = 0;
        int player2Score = 0;
        int random;
        int player1Speed = 3;
        int player2Speed = 3;
        int rectSize = 5;
        int rectSpeed = 6;
        int rektSize = 5;
        int rektSpeed = 6;
        int timer= 1000;
        bool wPressed = false;
        bool sPressed = false;
        bool upPressed = false;
        bool downPressed = false;
        bool spacePressed = false;

        List<Rectangle> rect = new List<Rectangle>();
        List<Rectangle> rekt = new List<Rectangle>();
        SolidBrush blueBrush = new SolidBrush(Color.Purple);
        SolidBrush whiteBrush = new SolidBrush(Color.Transparent);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        SolidBrush greenbrush = new SolidBrush(Color.Green);
        SolidBrush hurt = new SolidBrush(Color.White);
        Pen playerbrush = new Pen(Color.White, 1);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //intitalization
           
           
            p1Label.Text = $"{player1Score}";
            p2Label.Text = $"{player2Score}";
            time.Text = $"Time Left: {timer}";
            e.Graphics.FillRectangle(blueBrush, player1);
            e.Graphics.FillRectangle(greenbrush, player2);
            e.Graphics.FillRectangle(whiteBrush, point);
            e.Graphics.FillRectangle(hurt, sep);
           
            for (int i = 0; i < rect.Count; i++)
            {
                e.Graphics.FillRectangle(hurt, rect[i]);
            }
            for (int i = 0; i < rekt.Count; i++)
            {
                e.Graphics.FillRectangle(hurt, rekt[i]);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.W:
                    wPressed = true;
                    break;
                case Keys.S:
                    sPressed = true;
                    break;
                case Keys.Up:
                    upPressed = true;
                    break;
                case Keys.Down:
                    downPressed = true;
                    break;
                case Keys.Space:
                    spacePressed = true;
                    break;
            }
            }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
               
                case Keys.W:
                    wPressed = false;
                    break;
                case Keys.S:
                    sPressed = false;
                    break;
                case Keys.Up:
                    upPressed = false;
                    break;
                case Keys.Down:
                    downPressed = false;
                    break;
                case Keys.Space:
                    spacePressed = false;
                    break;
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            
        }





        private void timer1_Tick(object sender, EventArgs e)
        {
          
            //checks if button pressed

            if (wPressed == true && player1.Y > 0)
            {
                player1.Y -= player1Speed;
            }

            if (sPressed == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += player1Speed;
            }



            if (upPressed == true && player2.Y > 0)
            {
                player2.Y -= player2Speed;
            }

            if (downPressed == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += player2Speed;
            }

            //if interacts with reset positon

            if (player1.IntersectsWith(point))
            {
                player1Score += 1;
                player1.Y = (399);
                player1.X = (190);
                timer += 300;
            }
            else if (player2.IntersectsWith(point))
            {
                player2Score += 1;
                player2.Y = (399);
                player2.X = (485);
                timer += 200;
            }

            for (int i = 0; i < rect.Count; i++)
            {
                if (player1.IntersectsWith(rect[i]))
                {
                    player1.Y = (399);
                    player1.X = (190);

                }
                    }


            for (int i = 0; i < rekt.Count; i++)
            {
                if (player1.IntersectsWith(rekt[i]))
                {
                    player2.Y = (399);
                    player2.X = (485);

                }
            }

           


            //game over
            if (player1Score == 5)
            {
                gameover.Text = $"GAME OVER\n player1 wins";
            }
            if (player2Score == 5) 
            {
                gameover.Text = $"GAME OVER\n player2 wins";

            }

            //spawn astroids and move
            if (randgen.Next(0,100) <20)
            {
                int y = randgen.Next(0, this.Height -100);

                Rectangle newball = new Rectangle(0, y, rectSize, rectSize);
                rect.Add(newball);

            }


            for (int i = 0; i < rect.Count; i++)
            {
                int sp = randgen.Next(0, 5);
                sp += rectSpeed;
                int x = rect[i].X + rectSpeed;
                rect[i] = new Rectangle(x, rect[i].Y, rectSize, rectSize);

            }



            if (randgen.Next(0, 100) < 20)
            {
                int y = randgen.Next(0, this.Height - 100);

                Rectangle newball = new Rectangle(this.Width, y, rektSize, rektSize);
                rekt.Add(newball);

            }

            for (int i = 0; i < rekt.Count; i++)
            {
                int sp = randgen.Next(0, 5);
                sp += rektSpeed;
                int x = rekt[i].X - rektSpeed;
                rekt[i] = new Rectangle(x, rekt[i].Y, rektSize, rektSize);

            }


            //win conditions
            if (player1Score == 3)
            {
                gameover.Text = $"GAME OVER\n player1 wins";
                label5.Text = $"GAME OVER\n player1 wins";
                gameTimer.Stop();
            }

            if (player2Score == 3)
            {
                gameover.Text = $"GAME OVER\n player2 wins";
                label5.Text = $"GAME OVER\n player2 wins";
                gameTimer.Stop();
            }

            timer--;

            if (timer == 0 && player1Score > player2Score)
            {

                gameover.Text = $"GAME OVER\n player1 wins";
                label5.Text = $"GAME OVER\n player1 wins";
                gameTimer.Stop();
            }

            if (timer == 0 && player2Score > player1Score)
            {

                gameover.Text = $"GAME OVER\n player2 wins";
                label5.Text = $"GAME OVER\n player2 wins";
                gameTimer.Stop();
            }


            if (timer == 0 && player2Score == player1Score)
            {

                gameover.Text = $"GAME OVER\n NO ONE WINS";
                label5.Text = $"GAME OVER\n NO ONE WINS";
                gameTimer.Stop();
            }

            Refresh();

        }

        private void p2Label_Click(object sender, EventArgs e)
        {
            //idd
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
