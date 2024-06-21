using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Media;

namespace Space_Invader
{
    public partial class SpaceInvaders : Form
    {
        //Global variable
        //Rectangle variables, player, bunkers, bullets, etc
        Rectangle player = new Rectangle(375, 550, 50, 20);
        Rectangle mothership = new Rectangle(-40, -50, 40, 20);
        Rectangle playerCannon = new Rectangle(392, 540, 15, 10);
        Rectangle bullet = new Rectangle(-10, -10, 5, 15);
        Rectangle alienBullet = new Rectangle(1000, 1000, 5, 15);

        Rectangle bunker1 = new Rectangle(50, 430, 80, 20);
        Rectangle bunker2 = new Rectangle(250, 430, 80, 20);
        Rectangle bunker3 = new Rectangle(450, 430, 80, 20);
        Rectangle bunker4 = new Rectangle(650, 430, 80, 20);

        Rectangle bunker1Leg1 = new Rectangle(50, 430, 20, 40);
        Rectangle bunker2Leg1 = new Rectangle(250, 430, 20, 40);
        Rectangle bunker3Leg1 = new Rectangle(450, 430, 20, 40);
        Rectangle bunker4Leg1 = new Rectangle(650, 430, 20, 40);

        Rectangle bunker1Leg2 = new Rectangle(110, 430, 20, 40);
        Rectangle bunker2Leg2 = new Rectangle(310, 430, 20, 40);
        Rectangle bunker3Leg2 = new Rectangle(510, 430, 20, 40);
        Rectangle bunker4Leg2 = new Rectangle(710, 430, 20, 40);

        //Gameplay variable
        int playerSpeed = 5;
        int playerScore = 0;
        int playerLives = 3;
        int alienSpeed = 1;
        int mothershipSpeed = 2;
        int bulletSpeed = 12;
        int alienBulletSpeed = 6;
        

        //Values for keeping track of various things
        int a = 0;
        int b = 0;
        int c = 0;
        int d = 0;
        int f = 0;
        int g = 0;
        int h = 0;
        int t = 0;

        //Bunker health
        int bunker1Health = 16;
        int bunker1Leg1Health = 12;
        int bunker1Leg2Health = 12;

        int bunker2Health = 16;
        int bunker2Leg1Health = 12;
        int bunker2Leg2Health = 12;

        int bunker3Health = 16;
        int bunker3Leg1Health = 12;
        int bunker3Leg2Health = 12;

        int bunker4Health = 16;
        int bunker4Leg1Health = 12;
        int bunker4Leg2Health = 12;

        //Key press variables
        bool leftPressed = false;
        bool rightPressed = false;
        bool spacePressed = false;

        //Alien rows
        List<Rectangle> alienRow1 = new List<Rectangle>();
        List<Rectangle> alienRow2 = new List<Rectangle>();
        List<Rectangle> alienRow3 = new List<Rectangle>();
        List<Rectangle> alienRow4 = new List<Rectangle>();

        //Random generators and their variables
        Random mothershipGenerate = new Random();
        Random mothershipValue = new Random();
        Random alienBullets = new Random();
        Random alienRow = new Random();

        int randomFire = 0;
        int randColumn = 0;
        int mothershipGenerated = 0;
        int mothershipPoints = 0;

        //Brushes
        SolidBrush greenBrush = new SolidBrush(Color.LawnGreen);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush whiteBrush = new SolidBrush(Color.White);

        SolidBrush bunker1Brush = new SolidBrush(Color.LawnGreen);
        SolidBrush bunker1Leg1Brush = new SolidBrush(Color.LawnGreen);
        SolidBrush bunker1Leg2Brush = new SolidBrush(Color.LawnGreen);

        SolidBrush bunker2Brush = new SolidBrush(Color.LawnGreen);
        SolidBrush bunker2Leg1Brush = new SolidBrush(Color.LawnGreen);
        SolidBrush bunker2Leg2Brush = new SolidBrush(Color.LawnGreen);

        SolidBrush bunker3Brush = new SolidBrush(Color.LawnGreen);
        SolidBrush bunker3Leg1Brush = new SolidBrush(Color.LawnGreen);
        SolidBrush bunker3Leg2Brush = new SolidBrush(Color.LawnGreen);

        SolidBrush bunker4Brush = new SolidBrush(Color.LawnGreen);
        SolidBrush bunker4Leg1Brush = new SolidBrush(Color.LawnGreen);
        SolidBrush bunker4Leg2Brush = new SolidBrush(Color.LawnGreen);

        public SpaceInvaders()
        {
            InitializeComponent();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            scoreNumber.Text = $"{playerScore}";
            livesNumber.Text = $"{playerLives}";

            playerControls();

            alienMovement();

            alienAttacks();

            alienInterception();

            magicBus();

            bunker1Method();

            bunker2Method();

            bunker3Method();

            bunker4Method();

            Refresh();
        }

        public void playerControls()
        {
            //Key press code
            if (leftPressed == true && player.X > 0)
            {
                player.X = player.X - playerSpeed;
                playerCannon.X = playerCannon.X - playerSpeed;
            }

            if (rightPressed == true && player.X < 800 - player.Width)
            {
                player.X = player.X + playerSpeed;
                playerCannon.X = playerCannon.X + playerSpeed;
            }

            if (spacePressed == true && bullet.Y < 0)
            {
                bullet = new Rectangle(playerCannon.X + 5, 530, 5, 15);
            }

            //Setting bullet movement
            bullet.Y = bullet.Y - bulletSpeed;
        }

        public void alienMovement()
        {
            //Variable for tracking how many times the aliens have gone back and forth
            int endLine = 0;

            //Making aliens bounce back and forth
            for (int i = 0; i < alienRow1.Count; i++)
            {
                if (alienRow1[i].X == 780)
                {
                    alienSpeed = -1;
                    endLine++;
                }

                if (alienRow1[i].X == 0)
                {
                    alienSpeed = 1;
                    endLine++;
                }
            }

            for (int i = 0; i < alienRow2.Count; i++)
            {
                if (alienRow2[i].X == 780)
                {
                    alienSpeed = -1;
                    endLine++;
                }

                if (alienRow2[i].X == 0)
                {
                    alienSpeed = 1;
                    endLine++;
                }
            }

            for (int i = 0; i < alienRow3.Count; i++)
            {
                if (alienRow3[i].X == 780)
                {
                    alienSpeed = -1;
                    endLine++;
                }

                if (alienRow3[i].X == 0)
                {
                    alienSpeed = 1;
                    endLine++;
                }
            }

            for (int i = 0; i < alienRow4.Count; i++)
            {
                if (alienRow4[i].X == 780)
                {
                    alienSpeed = -1;
                    endLine++;
                }

                if (alienRow4[i].X == 0)
                {
                    alienSpeed = 1;
                    endLine++;
                }
            }

            //Making aliens move
            for (int i = 0; i < alienRow1.Count(); i++)
            {
                int x = alienRow1[i].X + alienSpeed;
                alienRow1[i] = new Rectangle(x, alienRow1[i].Y + endLine * 10, 25, 25);
            }

            for (int i = 0; i < alienRow2.Count(); i++)
            {
                int x = alienRow2[i].X + alienSpeed;
                alienRow2[i] = new Rectangle(x, alienRow2[i].Y + endLine * 10, 25, 25);
            }

            for (int i = 0; i < alienRow3.Count(); i++)
            {
                int x = alienRow3[i].X + alienSpeed;
                alienRow3[i] = new Rectangle(x, alienRow3[i].Y + endLine * 10, 25, 25);
            }

            for (int i = 0; i < alienRow4.Count(); i++)
            {
                int x = alienRow4[i].X + alienSpeed;
                alienRow4[i] = new Rectangle(x, alienRow4[i].Y + endLine * 10, 25, 25);
            }

            //Respawning aliens slightly lower than last time
            if (alienRow1.Count == 0 && alienRow2.Count == 0 && alienRow3.Count == 0 && alienRow4.Count == 0)
            {
                t++;
                playerLives++;

                for (int i = 0; i < 12; i++)
                {
                    Rectangle alien = new Rectangle(10 + i * 40, 50 + t * 20, 20, 20);
                    alienRow1.Add(alien);
                }

                for (int i = 0; i < 12; i++)
                {
                    Rectangle alien = new Rectangle(10 + i * 40, 90 + t * 20, 20, 20);
                    alienRow2.Add(alien);
                }

                for (int i = 0; i < 12; i++)
                {
                    Rectangle alien = new Rectangle(10 + i * 40, 130 + t * 20, 20, 20);
                    alienRow3.Add(alien);
                }

                for (int i = 0; i < 12; i++)
                {
                    Rectangle alien = new Rectangle(10 + i * 40, 170 + t * 20, 20, 20);
                    alienRow4.Add(alien);
                }
            }

            //Killing you if the aliens cross the baracades
            for (int i = 0; i < alienRow1.Count(); i++)
            {
                if (alienRow1[i].Y > 450)
                {
                    Death();
                }
            }

            for (int i = 0; i < alienRow2.Count(); i++)
            {
                if (alienRow2[i].Y > 450)
                {
                    Death();
                }
            }

            for (int i = 0; i < alienRow3.Count(); i++)
            {
                if (alienRow3[i].Y > 450)
                {
                    Death();
                }
            }

            for (int i = 0; i < alienRow4.Count(); i++)
            {
                if (alienRow4[i].Y > 450)
                {
                    Death();
                }
            }
        }

        public void alienAttacks()
        {
            //Random variable to make aliens occasionly fire
            randomFire = alienBullets.Next(1, 151);

            //If random fire variable is between 1 and 5 and no alien bullet is on screen 
            if (randomFire < 5 && alienBullet.Y > 800)
            {
                if (randomFire == 1 && alienRow1.Count() > 0)
                {
                    randColumn = alienRow.Next(0, alienRow1.Count());
                    alienBullet.X = alienRow1[randColumn].X;
                    alienBullet.Y = alienRow1[randColumn].Y;
                }
                else if (randomFire == 2 && alienRow2.Count() > 0)
                {
                    randColumn = alienRow.Next(0, alienRow2.Count());
                    alienBullet.X = alienRow2[randColumn].X;
                    alienBullet.Y = alienRow2[randColumn].Y;
                }
                else if (randomFire == 3 && alienRow3.Count() > 0)
                {
                    randColumn = alienRow.Next(0, alienRow3.Count());
                    alienBullet.X = alienRow3[randColumn].X;
                    alienBullet.Y = alienRow3[randColumn].Y;
                }
                else if (randomFire == 4 && alienRow4.Count() > 0)
                {
                    randColumn = alienRow.Next(0, alienRow4.Count());
                    alienBullet.X = alienRow4[randColumn].X;
                    alienBullet.Y = alienRow4[randColumn].Y;
                }
            }

            //Moving the alien bullet
            alienBullet.Y = alienBullet.Y + alienBulletSpeed;

            //If alien bullets hit the player reduce players #of lifes
            if (alienBullet.IntersectsWith(player) || alienBullet.IntersectsWith(playerCannon))
            {
                SoundPlayer hitPlayer = new SoundPlayer(Properties.Resources.hit);
                hitPlayer.Play();

                playerLives--;
                alienBullet.X = 1000;
                alienBullet.Y = 1000;

                if (playerLives == 0)
                {
                    livesNumber.Text = "0";
                    Death();
                }
            }
        }

        public void alienInterception()
        {
            //Checking to see if an alien is hit with a bullet
            for (int i = 0; i < alienRow1.Count; i++)
            {
                if (bullet.IntersectsWith(alienRow1[i]))
                {
                    SoundPlayer pointPlayer = new SoundPlayer(Properties.Resources.point);
                    pointPlayer.Play();

                    bullet.X = 0;
                    bullet.Y = -20;
                    alienRow1.RemoveAt(i);
                    playerScore = playerScore + 40;
                }
            }

            for (int i = 0; i < alienRow2.Count; i++)
            {
                if (bullet.IntersectsWith(alienRow2[i]))
                {
                    SoundPlayer pointPlayer = new SoundPlayer(Properties.Resources.point);
                    pointPlayer.Play();

                    bullet.X = 0;
                    bullet.Y = -20;
                    alienRow2.RemoveAt(i);
                    playerScore = playerScore + 20;
                }
            }

            for (int i = 0; i < alienRow3.Count; i++)
            {
                if (bullet.IntersectsWith(alienRow3[i]))
                {
                    SoundPlayer pointPlayer = new SoundPlayer(Properties.Resources.point);
                    pointPlayer.Play();

                    bullet.X = 0;
                    bullet.Y = -20;
                    alienRow3.RemoveAt(i);
                    playerScore = playerScore + 10;
                }
            }

            for (int i = 0; i < alienRow4.Count; i++)
            {
                if (bullet.IntersectsWith(alienRow4[i]))
                {
                    SoundPlayer pointPlayer = new SoundPlayer(Properties.Resources.point);
                    pointPlayer.Play();

                    bullet.X = 0;
                    bullet.Y = -20;
                    alienRow4.RemoveAt(i);
                    playerScore = playerScore + 10;
                }
            }
        }

        public void magicBus()
        {
            //Generating a random value to see if it should spawn a mothership
            mothershipGenerated = mothershipGenerate.Next(1, 2001);

            //Moving the mothership into position
            if (mothershipGenerated == 1 && mothership.Y < 0)
            {
                mothershipPoints = mothershipValue.Next(1, 5);
                mothership = new Rectangle(-40, 50, 40, 20);
            }

            //Assigning points and moving it off screen if you hit it
            if (mothership.IntersectsWith(bullet) && mothershipPoints == 1)
            {
                SoundPlayer pointPlayer = new SoundPlayer(Properties.Resources.point);
                pointPlayer.Play();

                playerScore = playerScore + 200;
                mothership.Y = -50;
            }

            if (mothership.IntersectsWith(bullet) && mothershipPoints == 2)
            {
                SoundPlayer pointPlayer = new SoundPlayer(Properties.Resources.point);
                pointPlayer.Play();

                playerScore = playerScore + 200;
                mothership.Y = -50;
            }

            if (mothership.IntersectsWith(bullet) && mothershipPoints == 3)
            {
                SoundPlayer pointPlayer = new SoundPlayer(Properties.Resources.point);
                pointPlayer.Play();

                playerScore = playerScore + 200;
                mothership.Y = -50;
            }

            if (mothership.IntersectsWith(bullet) && mothershipPoints == 4)
            {
                SoundPlayer pointPlayer = new SoundPlayer(Properties.Resources.point);
                pointPlayer.Play();

                playerScore = playerScore + 200;
                mothership.Y = -50;
            }

            //Moving it off screen after it crosses the boundary
            if (mothership.X > 800)
            {
                mothership.Y = -50;
            }

            //Moving the mothership
            mothership.X = mothership.X + mothershipSpeed;
        }

        public void bunker1Method()
        {
            //Intersecting with bunker1
            if (bullet.IntersectsWith(bunker1) && bunker1Health > 0 || alienBullet.IntersectsWith(bunker1) && bunker1Health > 0)
            {
                bunker1Health--;

                if (bullet.IntersectsWith(bunker1))
                {
                    bullet.X = 0;
                    bullet.Y = -20;
                }

                if (alienBullet.IntersectsWith(bunker1))
                {
                    alienBullet.X = 1000;
                    alienBullet.Y = 1000;
                }

                if (bunker1Health <= 5)
                {
                    bunker1Brush.Color = Color.Red;
                }
            }

            //Intersecting with bunker1's first leg
            if (bullet.IntersectsWith(bunker1Leg1) && bunker1Leg1Health > 0 || alienBullet.IntersectsWith(bunker1Leg1) && bunker1Leg1Health > 0)
            {
                bunker1Leg1Health--;

                if (bullet.IntersectsWith(bunker1Leg1))
                {
                    bullet.X = 0;
                    bullet.Y = -20;
                }

                if (alienBullet.IntersectsWith(bunker1Leg1))
                {
                    alienBullet.X = 1000;
                    alienBullet.Y = 1000;
                }

                if (bunker1Leg1Health <= 5)
                {
                    bunker1Leg1Brush.Color = Color.Red;
                }
            }

            //Intersecting with bunker1's second leg
            if (bullet.IntersectsWith(bunker1Leg2) && bunker1Leg2Health > 0 || alienBullet.IntersectsWith(bunker1Leg2) && bunker1Leg2Health > 0)
            {
                bunker1Leg2Health--;

                if (bullet.IntersectsWith(bunker1Leg2))
                {
                    bullet.X = 0;
                    bullet.Y = -20;
                }

                if (alienBullet.IntersectsWith(bunker1Leg2))
                {
                    alienBullet.X = 1000;
                    alienBullet.Y = 1000;
                }

                if (bunker1Leg2Health <= 5)
                {
                    bunker1Leg2Brush.Color = Color.Red;
                }
            }

            //"Removing" bunker1
            if (bunker1Health == 0)
            {
                bunker1Brush.Color = Color.Black;
            }

            //"Removing" bunker1's first leg
            if (bunker1Leg1Health == 0)
            {
                bunker1Leg1Brush.Color = Color.Black;
            }

            //"Removing" bunker1's second leg
            if (bunker1Leg2Health == 0)
            {
                bunker1Leg2Brush.Color = Color.Black;
            }
        }

        public void bunker2Method()
        {
            //Intersecting with bunker2
            if (bullet.IntersectsWith(bunker2) && bunker2Health > 0 || alienBullet.IntersectsWith(bunker2) && bunker2Health > 0)
            {
                bunker2Health--;

                if (bullet.IntersectsWith(bunker2))
                {
                    bullet.X = 0;
                    bullet.Y = -20;
                }

                if (alienBullet.IntersectsWith(bunker2))
                {
                    alienBullet.X = 1000;
                    alienBullet.Y = 1000;
                }

                if (bunker2Health <= 5)
                {
                    bunker2Brush.Color = Color.Red;
                }
            }

            //Intersecting with bunker2's first leg
            if (bullet.IntersectsWith(bunker2Leg1) && bunker2Leg1Health > 0 || alienBullet.IntersectsWith(bunker2Leg1) && bunker2Leg1Health > 0)
            {
                bunker2Leg1Health--;

                if (bullet.IntersectsWith(bunker2Leg1))
                {
                    bullet.X = 0;
                    bullet.Y = -20;
                }

                if (alienBullet.IntersectsWith(bunker2Leg1))
                {
                    alienBullet.X = 1000;
                    alienBullet.Y = 1000;
                }

                if (bunker2Leg1Health <= 5)
                {
                    bunker2Leg1Brush.Color = Color.Red;
                }
            }

            //Intersecting with bunker2's second leg
            if (bullet.IntersectsWith(bunker2Leg2) && bunker2Leg2Health > 0 || alienBullet.IntersectsWith(bunker2Leg2) && bunker2Leg2Health > 0)
            {
                bunker2Leg2Health--;

                if (bullet.IntersectsWith(bunker2Leg2))
                {
                    bullet.X = 0;
                    bullet.Y = -20;
                }

                if (alienBullet.IntersectsWith(bunker2Leg2))
                {
                    alienBullet.X = 1000;
                    alienBullet.Y = 1000;
                }

                if (bunker2Leg2Health <= 5)
                {
                    bunker2Leg2Brush.Color = Color.Red;
                }
            }

            //"Removing" bunker2
            if (bunker2Health == 0)
            {
                bunker2Brush.Color = Color.Black;
            }

            //"Removing" bunker2's first leg
            if (bunker2Leg1Health == 0)
            {
                bunker2Leg1Brush.Color = Color.Black;
            }

            //"Removing" bunker2's second leg
            if (bunker2Leg2Health == 0)
            {
                bunker2Leg2Brush.Color = Color.Black;
            }
        }

        public void bunker3Method()
        {
            //Intersecting with bunker3
            if (bullet.IntersectsWith(bunker3) && bunker3Health > 0 || alienBullet.IntersectsWith(bunker3) && bunker3Health > 0)
            {
                bunker3Health--;

                if (bullet.IntersectsWith(bunker3))
                {
                    bullet.X = 0;
                    bullet.Y = -20;
                }

                if (alienBullet.IntersectsWith(bunker3))
                {
                    alienBullet.X = 1000;
                    alienBullet.Y = 1000;
                }

                if (bunker3Health <= 5)
                {
                    bunker3Brush.Color = Color.Red;
                }
            }

            //Intersecting with bunker3's first leg
            if (bullet.IntersectsWith(bunker3Leg1) && bunker3Leg1Health > 0 || alienBullet.IntersectsWith(bunker3Leg1) && bunker3Leg1Health > 0)
            {
                bunker3Leg1Health--;

                if (bullet.IntersectsWith(bunker3Leg1))
                {
                    bullet.X = 0;
                    bullet.Y = -20;
                }

                if (alienBullet.IntersectsWith(bunker3Leg1))
                {
                    alienBullet.X = 1000;
                    alienBullet.Y = 1000;
                }

                if (bunker3Leg1Health <= 5)
                {
                    bunker3Leg1Brush.Color = Color.Red;
                }
            }

            //Intersecting with bunker3's second leg
            if (bullet.IntersectsWith(bunker3Leg2) && bunker3Leg2Health > 0 || alienBullet.IntersectsWith(bunker3Leg2) && bunker3Leg2Health > 0)
            {
                bunker3Leg2Health--;

                if (bullet.IntersectsWith(bunker3Leg2))
                {
                    bullet.X = 0;
                    bullet.Y = -20;
                }

                if (alienBullet.IntersectsWith(bunker3Leg2))
                {
                    alienBullet.X = 1000;
                    alienBullet.Y = 1000;
                }

                if (bunker3Leg2Health <= 5)
                {
                    bunker3Leg2Brush.Color = Color.Red;
                }
            }

            //"Removing" bunker3
            if (bunker3Health == 0)
            {
                bunker3Brush.Color = Color.Black;
            }

            //"Removing" bunker3's first leg
            if (bunker3Leg1Health == 0)
            {
                bunker3Leg1Brush.Color = Color.Black;
            }

            //"Removing" bunker3's second leg
            if (bunker3Leg2Health == 0)
            {
                bunker3Leg2Brush.Color = Color.Black;
            }
        }

        public void bunker4Method()
        {
            //Intersecting with bunker4
            if (bullet.IntersectsWith(bunker4) && bunker4Health > 0 || alienBullet.IntersectsWith(bunker4) && bunker4Health > 0)
            {
                bunker4Health--;

                if (bullet.IntersectsWith(bunker4))
                {
                    bullet.X = 0;
                    bullet.Y = -20;
                }

                if (alienBullet.IntersectsWith(bunker4))
                {
                    alienBullet.X = 1000;
                    alienBullet.Y = 1000;
                }

                if (bunker4Health <= 5)
                {
                    bunker4Brush.Color = Color.Red;
                }
            }

            //Intersecting with bunker4's first leg
            if (bullet.IntersectsWith(bunker4Leg1) && bunker4Leg1Health > 0 || alienBullet.IntersectsWith(bunker4Leg1) && bunker4Leg1Health > 0)
            {
                bunker4Leg1Health--;

                if (bullet.IntersectsWith(bunker4Leg1))
                {
                    bullet.X = 0;
                    bullet.Y = -20;
                }

                if (alienBullet.IntersectsWith(bunker4Leg1))
                {
                    alienBullet.X = 1000;
                    alienBullet.Y = 1000;
                }

                if (bunker4Leg1Health <= 5)
                {
                    bunker4Leg1Brush.Color = Color.Red;
                }
            }

            //Intersecting with bunker4's second leg
            if (bullet.IntersectsWith(bunker4Leg2) && bunker4Leg2Health > 0 || alienBullet.IntersectsWith(bunker4Leg2) && bunker4Leg2Health > 0)
            {
                bunker4Leg2Health--;

                if (bullet.IntersectsWith(bunker4Leg2))
                {
                    bullet.X = 0;
                    bullet.Y = -20;
                }

                if (alienBullet.IntersectsWith(bunker4Leg2))
                {
                    alienBullet.X = 1000;
                    alienBullet.Y = 1000;
                }

                if (bunker4Leg2Health <= 5)
                {
                    bunker4Leg2Brush.Color = Color.Red;
                }
            }

            //"Removing" bunker4
            if (bunker4Health == 0)
            {
                bunker4Brush.Color = Color.Black;
            }

            //"Removing" bunker4's first leg
            if (bunker4Leg1Health == 0)
            {
                bunker4Leg1Brush.Color = Color.Black;
            }

            //"Removing" bunker4's second leg
            if (bunker4Leg2Health == 0)
            {
                bunker4Leg2Brush.Color = Color.Black;
            }
        }

        public void InitializeGame()
        {
            //Setting variables to original
            playerScore = 0;
            playerLives = 3;
             
            
            bunker1Health = 16;
            bunker1Leg1Health = 12;
            bunker1Leg2Health = 12;

            bunker2Health = 16;
            bunker2Leg1Health = 12;
            bunker2Leg2Health = 12;

            bunker3Health = 16;
            bunker3Leg1Health = 12;
            bunker3Leg2Health = 12;

            bunker4Health = 16;
            bunker4Leg1Health = 12;
            bunker4Leg2Health = 12;

            bunker1Brush.Color = Color.LawnGreen;
            bunker1Leg1Brush.Color = Color.LawnGreen;
            bunker1Leg2Brush.Color = Color.LawnGreen;

            bunker2Brush.Color = Color.LawnGreen;
            bunker2Leg1Brush.Color = Color.LawnGreen;
            bunker2Leg2Brush.Color = Color.LawnGreen;

            bunker3Brush.Color = Color.LawnGreen;
            bunker3Leg1Brush.Color = Color.LawnGreen;
            bunker3Leg2Brush.Color = Color.LawnGreen;

            bunker4Brush.Color = Color.LawnGreen;
            bunker4Leg1Brush.Color = Color.LawnGreen;
            bunker4Leg2Brush.Color = Color.LawnGreen;

            //Clearing the screen
            spaceLabel.Visible = false;
            invadersLabel.Visible = false;
            instructionLabel.Visible = false;

            alienRow1.Clear();
            alienRow2.Clear();
            alienRow3.Clear();
            alienRow4.Clear();

            //Adding aliens to the screen
            for (int i = 0; i < 12; i++)
            {
                Rectangle alien = new Rectangle(10 + i * 40, 50, 20, 20);
                alienRow1.Add(alien);
            }

            for (int i = 0; i < 12; i++)
            {
                Rectangle alien = new Rectangle(10 + i * 40, 90, 20, 20);
                alienRow2.Add(alien);
            }

            for (int i = 0; i < 12; i++)
            {
                Rectangle alien = new Rectangle(10 + i * 40, 130, 20, 20);
                alienRow3.Add(alien);
            }

            for (int i = 0; i < 12; i++)
            {
                Rectangle alien = new Rectangle(10 + i * 40, 170, 20, 20);
                alienRow4.Add(alien);
            }

        }

        public void Death()
        {
            gameTimer.Stop();

            spaceLabel.Text = "PLAY";
            invadersLabel.Text = "AGAIN?";
            invadersLabel.Visible = true;
            spaceLabel.Visible = true;
            instructionLabel.Visible = true;
        }

        private void SpaceInvaders_KeyDown(object sender, KeyEventArgs e)
        {
            //Key code
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftPressed = true;
                    break;
                case Keys.Right:
                    rightPressed = true;
                    break;
                case Keys.Space:
                    spacePressed = true;
                    break;
                case Keys.Enter:
                    if (gameTimer.Enabled == false)
                    {
                        gameTimer.Enabled = true;
                        InitializeGame();
                    }
                    break;
                case Keys.Escape:
                    if (gameTimer.Enabled == false)
                    {
                        Application.Exit();
                    }
                    break;
            }
        }

        private void SpaceInvaders_KeyUp(object sender, KeyEventArgs e)
        {
            //Key code
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftPressed = false;
                    break;
                case Keys.Right:
                    rightPressed = false;
                    break;
                case Keys.Space:
                    spacePressed = false;
                    break;
            }
        }

        private void SpaceInvaders_Paint(object sender, PaintEventArgs e)
        {
            if (gameTimer.Enabled == true)
            {
                //Making all of the bunkers
                e.Graphics.FillRectangle(greenBrush, player);
                e.Graphics.FillRectangle(greenBrush, playerCannon);
                e.Graphics.FillRectangle(redBrush, mothership);

                e.Graphics.FillRectangle(bunker1Brush, bunker1);
                e.Graphics.FillRectangle(bunker2Brush, bunker2);
                e.Graphics.FillRectangle(bunker3Brush, bunker3);
                e.Graphics.FillRectangle(bunker4Brush, bunker4);

                e.Graphics.FillRectangle(bunker1Leg1Brush, bunker1Leg1);
                e.Graphics.FillRectangle(bunker2Leg1Brush, bunker2Leg1);
                e.Graphics.FillRectangle(bunker3Leg1Brush, bunker3Leg1);
                e.Graphics.FillRectangle(bunker4Leg1Brush, bunker4Leg1);

                e.Graphics.FillRectangle(bunker1Leg2Brush, bunker1Leg2);
                e.Graphics.FillRectangle(bunker2Leg2Brush, bunker2Leg2);
                e.Graphics.FillRectangle(bunker3Leg2Brush, bunker3Leg2);
                e.Graphics.FillRectangle(bunker4Leg2Brush, bunker4Leg2);

                e.Graphics.FillRectangle(whiteBrush, bullet);
                e.Graphics.FillRectangle(whiteBrush, alienBullet);

                //Drawing alien row 1
                for (int i = 0; i < alienRow1.Count(); i++)
                {
                    e.Graphics.FillEllipse(whiteBrush, alienRow1[i]);
                }

                //Drawing alien row 2
                for (int i = 0; i < alienRow2.Count(); i++)
                {
                    e.Graphics.FillEllipse(whiteBrush, alienRow2[i]);
                }

                //Drawing alien row 3
                for (int i = 0; i < alienRow3.Count(); i++)
                {
                    e.Graphics.FillEllipse(whiteBrush, alienRow3[i]);
                }

                //Drawing alien row 4
                for (int i = 0; i < alienRow4.Count(); i++)
                {
                    e.Graphics.FillEllipse(whiteBrush, alienRow4[i]);
                }
            }
        }
    }
}
