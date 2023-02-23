using System.Windows.Forms;
using System;
using System.Threading.Tasks;
using Joc.Properties;
using System.Xml.Linq;

namespace Joc
{
    public partial class Form1 : Form
    {
        //Orientare: 0 -> .|..   1-> verticala   2 -> ..|.   3 verticala invers
        int index_directie = 1;
        int index_faza = 0;

        int secondchance = 0;
        int dice1, dice2;
        int countplanes1 = 0;
        int countplanes2 = 0;
        int current_player, first_player;

        Button[,] buttons1 = new Button[10, 10];
        Button[,] buttons2 = new Button[10, 10];

        private System.Windows.Forms.Timer timer;

        public class Butoane
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        public class Plane
        {
            public Butoane[] Buttons { get; set; }
        }

        public class Player
        {
            public Plane[] Planes { get; set; }
        }

        // Define the players and their planes
        public Player player1 = new Player
        {
            Planes = new Plane[]
            {
                new Plane { Buttons = new Butoane[] { new Butoane {}, new Butoane {}, new Butoane {}, new Butoane {}, new Butoane {} } },
                new Plane { Buttons = new Butoane[] { new Butoane {}, new Butoane {}, new Butoane {}, new Butoane {}, new Butoane {} } },
                new Plane { Buttons = new Butoane[] { new Butoane {}, new Butoane {}, new Butoane {}, new Butoane {}, new Butoane {} } },
            }
        };

        public Player player2 = new Player
        {
            Planes = new Plane[]
            {
                new Plane { Buttons = new Butoane[] { new Butoane {}, new Butoane {}, new Butoane {}, new Butoane {}, new Butoane {} } },
                new Plane { Buttons = new Butoane[] { new Butoane {}, new Butoane {}, new Butoane {}, new Butoane {}, new Butoane {} } },
                new Plane { Buttons = new Butoane[] { new Butoane {}, new Butoane {}, new Butoane {}, new Butoane {}, new Butoane {} } },
            }
        };

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            DiceBox.Location = new Point(650, 300);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    buttons1[i, j] = new Button();
                    buttons1[i, j].Width = 30;
                    buttons1[i, j].Height = 30;
                    buttons1[i, j].Top = 390 + i * 30;
                    buttons1[i, j].Left = 560 + j * 30;
                    buttons1[i, j].BackColor = Color.White;
                    buttons1[i, j].Name = $"button1_{i}_{j}";
                    buttons1[i, j].Click += new EventHandler(Button_Click);
                    this.Controls.Add(buttons1[i, j]);
                    

                    buttons2[i, j] = new Button();
                    buttons2[i, j].Width = 30;
                    buttons2[i, j].Height = 30;
                    buttons2[i, j].Top = 390 + i * 30;
                    buttons2[i, j].Left = 1060 + j * 30;
                    buttons2[i, j].BackColor = Color.White;
                    this.Controls.Add(buttons2[i, j]);
                    buttons2[i, j].Name = $"button2_{i}_{j}";
                    buttons2[i, j].Click += new EventHandler(Button_Click);
                }
            }

            foreach (Control c in Controls)
            {
                if (!c.Equals(DiceBox) && !c.Equals(exitBtn))
                {
                    c.Enabled = false;
                    c.Visible = false;
                }
            }

            DiceBox.Visible = true;
        }

        private void rollBtn_Click(object sender, EventArgs e)
        {
            timer.Start();
            resultTextEqual.Visible = false;
            resultText1.Visible = false;
            resultText2.Visible = false;
            playBtn.Enabled = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            progressBar1.Increment(5);
            if (progressBar1.Value == 100)
            {
                timer.Stop();
                if (dice1 == dice2)
                {
                    resultTextEqual.Visible = true;
                }
                else if (dice1 > dice2)
                {
                    playBtn.Enabled = true;
                    resultText1.Visible = true;
                    current_player = 1;
                    first_player = 1;
                }
                else if (dice1 < dice2)
                {
                    playBtn.Enabled = true;
                    resultText2.Visible = true;
                    current_player = 2;
                    first_player = 2;
                }
                progressBar1.Value = 0;
            }
            else
            {
                dice1 = random.Next(1, 7);
                dice2 = random.Next(1, 7);

                if (dice1 == 1)
                {
                    picDie1.Image = Properties.Resources.Die_1;
                }
                else if (dice1 == 2)
                {
                    picDie1.Image = Properties.Resources.Die_2;
                }
                else if (dice1 == 3)
                {
                    picDie1.Image = Properties.Resources.Die_3;
                }
                else if (dice1 == 4)
                {
                    picDie1.Image = Properties.Resources.Die_4;
                }
                else if (dice1 == 5)
                {
                    picDie1.Image = Properties.Resources.Die_5;
                }
                else if (dice1 == 6)
                {
                    picDie1.Image = Properties.Resources.Die_6;
                }

                if (dice2 == 1)
                {
                    picDie2.Image = Properties.Resources.Die_1;
                }
                else if (dice2 == 2)
                {
                    picDie2.Image = Properties.Resources.Die_2;
                }
                else if (dice2 == 3)
                {
                    picDie2.Image = Properties.Resources.Die_3;
                }
                else if (dice2 == 4)
                {
                    picDie2.Image = Properties.Resources.Die_4;
                }
                else if (dice2 == 5)
                {
                    picDie2.Image = Properties.Resources.Die_5;
                }
                else if (dice2 == 6)
                {
                    picDie2.Image = Properties.Resources.Die_6;
                }
            }
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            DiceBox.Visible = false;
            exitBtn.Enabled = true;

            foreach (Control c in Controls)
                if (!c.Equals(DiceBox))
                {
                    c.Enabled = true;
                    c.Visible = true;
                }

            if (current_player == 1)
                MessageBox.Show("Pozitioneaza cele 3 avioane identice pe tabla ta de joc -> Stanga");
            else
                MessageBox.Show("Pozitioneaza cele 3 avioane identice pe tabla ta de joc -> Dreapta");
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            string[] buttonNameParts = clickedButton.Name.Split('_');

            int current_i = int.Parse(buttonNameParts[1]);
            int current_j = int.Parse(buttonNameParts[2]);

            if (index_faza < 2)
            {//Handle Plane Placement
                if (current_player == 1)
                {//Handle event placing currentplayer's planes
                    if (CheckAndMarkPattern(player1, buttons1, current_i, current_j, index_directie, countplanes1) == true)
                        countplanes1++;
                }
                else
                {
                    if (CheckAndMarkPattern(player2, buttons2, current_i, current_j, index_directie, countplanes2) == true)
                        countplanes2++;
                }
            }
            else
            {// Handle Attack
                if (current_player == 1)
                {
                    //Parcurc avioanele jucatorului. Daca butonul pe care am dat click loveste cabina, tot avionul devine negru.
                    foreach (Plane plane in player2.Planes)
                        if (clickedButton.Location.X == plane.Buttons[0].X && clickedButton.Location.Y == plane.Buttons[0].Y)
                        {
                            countplanes1--;
                            foreach (Butoane buton in plane.Buttons)
                                buttons2[buton.X, buton.Y].BackColor = Color.Black;
                        }
                        //Daca butonul lovit este parte din corpul avionului dar nu e cabina, butonul devine negru.
                        else
                            foreach (Butoane buton in plane.Buttons)
                                if (clickedButton.Location.X == buton.X && clickedButton.Location.Y == buton.Y)
                                    buttons2[buton.X, buton.Y].BackColor = Color.Black;
                                //Daca butonul atins nu face parte dintr-un avion, butonul devine inaccesibil.
                                else
                                    buttons2[buton.X, buton.Y].Enabled = false;
                }
                else
                {
                    foreach (Plane plane in player2.Planes)
                        if (clickedButton.Location.X == plane.Buttons[0].X && clickedButton.Location.Y == plane.Buttons[0].Y)
                        {
                            countplanes2--;
                            foreach (Butoane buton in plane.Buttons)
                                buttons1[buton.X, buton.Y].BackColor = Color.Black;
                        }
                        else
                            foreach (Butoane buton in plane.Buttons)
                                if (clickedButton.Location.X == buton.X && clickedButton.Location.Y == buton.Y)
                                    buttons1[buton.X, buton.Y].BackColor = Color.Black;
                                else
                                    buttons1[buton.X, buton.Y].Enabled = false;
                }
                //Daca playerul 1 a inceput si player 2 a ramas fara avioane, acesta mai voie sa faca o mutare.
                if (first_player == 1 && countplanes2 == 0)
                    if (secondchance == 0)
                        secondchance = 1;
                    else
                        // Rezolv remiza
                        if (countplanes1 == 0)
                        {
                            MessageBox.Show("Remiza!");
                            Application.Restart();
                        }
                        else
                        {
                            MessageBox.Show("Player 1 a castigat!" + "\n Felicitari!");
                            Application.Restart();
                        }
                else if(first_player == 2 && countplanes1 == 0)
                    if(secondchance == 0)
                        secondchance = 1;
                    else
                    {
                        if (countplanes2 == 0)
                        {
                            MessageBox.Show("Remiza!");
                            Application.Restart();
                        }
                        else
                        {
                            MessageBox.Show("Player 2 a castigat!" + "\n Felicitari!");
                            Application.Restart();
                        }
                    }
            }
        }
        public bool CheckAndMarkPattern(Player player, Button[,] buttons, int current_i, int current_j, int index_directie, int planenumber)
        {//orientation 1
            if (index_directie == 1)
            {
                if (buttons[current_i, current_j].BackColor == Color.White && buttons[current_i, current_j].Enabled == true &&
                buttons[current_i + 1, current_j - 1].Enabled && buttons[current_i + 1, current_j - 1].BackColor == Color.White &&
                buttons[current_i + 1, current_j].Enabled && buttons[current_i + 1, current_j].BackColor == Color.White &&
                buttons[current_i + 1, current_j + 1].Enabled && buttons[current_i + 1, current_j + 1].BackColor == Color.White &&
                buttons[current_i + 2, current_j].Enabled && buttons[current_i + 2, current_j].BackColor == Color.White &&
                buttons[current_i + 3, current_j].Enabled && buttons[current_i + 3, current_j].BackColor == Color.White)
                {
                    // The pattern was found, so perform the actions
                    buttons[current_i, current_j].BackColor = Color.Red;
                    buttons[current_i, current_j].Enabled = false;
                    player.Planes[planenumber + 1].Buttons[0].X = current_i;
                    player.Planes[planenumber + 1].Buttons[0].Y = current_j;

                    buttons[current_i + 1, current_j - 1].BackColor = Color.Blue;
                    buttons[current_i + 1, current_j - 1].Enabled = false;
                    player.Planes[planenumber + 1].Buttons[1].X = current_i + 1;
                    player.Planes[planenumber + 1].Buttons[1].Y = current_j - 1;

                    buttons[current_i + 1, current_j].BackColor = Color.Blue;
                    buttons[current_i + 1, current_j].Enabled = false;
                    player.Planes[planenumber + 1].Buttons[2].X = current_i + 1;
                    player.Planes[planenumber + 1].Buttons[2].Y = current_j;

                    buttons[current_i + 1, current_j + 1].BackColor = Color.Blue;
                    buttons[current_i + 1, current_j + 1].Enabled = false;
                    player.Planes[planenumber + 1].Buttons[3].X = current_i + 1;
                    player.Planes[planenumber + 1].Buttons[3].Y = current_j + 1;

                    buttons[current_i + 2, current_j].BackColor = Color.Blue;
                    buttons[current_i + 2, current_j].Enabled = false;
                    player.Planes[planenumber + 1].Buttons[4].X = current_i + 2;
                    player.Planes[planenumber + 1].Buttons[4].Y = current_j;

                    buttons[current_i + 3, current_j].BackColor = Color.Blue;
                    buttons[current_i + 3, current_j].Enabled = false;
                    player.Planes[planenumber + 1].Buttons[5].X = current_i + 3;
                    player.Planes[planenumber + 1].Buttons[5].Y = current_j;

                    return true;
                }
                return false;
            }
            //orientation 2
            else if (index_directie == 2)
            {
                if (buttons[current_i, current_j].BackColor == Color.White && buttons[current_i, current_j].Enabled == true &&
                buttons[current_i - 1, current_j - 1].Enabled && buttons[current_i - 1, current_j - 1].BackColor == Color.White &&
                buttons[current_i, current_j - 1].Enabled && buttons[current_i, current_j - 1].BackColor == Color.White &&
                buttons[current_i + 1, current_j - 1].Enabled && buttons[current_i + 1, current_j - 1].BackColor == Color.White &&
                buttons[current_i, current_j - 2].Enabled && buttons[current_i, current_j - 2].BackColor == Color.White &&
                buttons[current_i, current_j - 3].Enabled && buttons[current_i, current_j - 3].BackColor == Color.White)
                {
                    // The pattern was found, so perform the actions
                    buttons[current_i, current_j].BackColor = Color.Red;
                    buttons[current_i, current_j].Enabled = false;
                    player.Planes[planenumber + 1].Buttons[0].X = current_i;
                    player.Planes[planenumber + 1].Buttons[0].Y = current_j;

                    buttons[current_i - 1, current_j - 1].BackColor = Color.Blue;
                    buttons[current_i - 1, current_j - 1].Enabled = false;
                    player.Planes[planenumber + 1].Buttons[1].X = current_i - 1;
                    player.Planes[planenumber + 1].Buttons[1].Y = current_j - 1;

                    buttons[current_i, current_j - 1].BackColor = Color.Blue;
                    buttons[current_i, current_j - 1].Enabled = false;
                    player.Planes[planenumber + 1].Buttons[2].X = current_i;
                    player.Planes[planenumber + 1].Buttons[2].Y = current_j - 1;

                    buttons[current_i + 1, current_j - 1].BackColor = Color.Blue;
                    buttons[current_i + 1, current_j - 1].Enabled = false;
                    player.Planes[planenumber + 1].Buttons[3].X = current_i + 1;
                    player.Planes[planenumber + 1].Buttons[3].Y = current_j - 1;

                    buttons[current_i, current_j - 2].BackColor = Color.Blue;
                    buttons[current_i, current_j - 2].Enabled = false;
                    player.Planes[planenumber + 1].Buttons[4].X = current_i;
                    player.Planes[planenumber + 1].Buttons[4].Y = current_j - 2;

                    buttons[current_i, current_j - 3].BackColor = Color.Blue;
                    buttons[current_i, current_j - 3].Enabled = false;
                    player.Planes[planenumber + 1].Buttons[5].X = current_i;
                    player.Planes[planenumber + 1].Buttons[5].Y = current_j;

                    return true;
                }
                return false;
            }
            //orientation 3
            else if (index_directie == 3)
            {
                if (buttons[current_i, current_j].BackColor == Color.White && buttons[current_i, current_j].Enabled == true &&
                buttons[current_i - 1, current_j - 1].Enabled && buttons[current_i - 1, current_j - 1].BackColor == Color.White &&
                buttons[current_i - 1, current_j].Enabled && buttons[current_i - 1, current_j].BackColor == Color.White &&
                buttons[current_i - 1, current_j + 1].Enabled && buttons[current_i - 1, current_j + 1].BackColor == Color.White &&
                buttons[current_i - 2, current_j].Enabled && buttons[current_i - 2, current_j].BackColor == Color.White &&
                buttons[current_i - 3, current_j].Enabled && buttons[current_i - 3, current_j].BackColor == Color.White)
                {
                    // The pattern was found, so perform the actions
                    buttons[current_i, current_j].BackColor = Color.Red;
                    buttons[current_i, current_j].Enabled = false;
                    player.Planes[planenumber + 1].Buttons[0].X = current_i;
                    player.Planes[planenumber + 1].Buttons[0].Y = current_j;

                    buttons[current_i - 1, current_j - 1].BackColor = Color.Blue;
                    buttons[current_i - 1, current_j - 1].Enabled = false;
                    player.Planes[planenumber + 1].Buttons[1].X = current_i - 1;
                    player.Planes[planenumber + 1].Buttons[1].Y = current_j - 1;

                    buttons[current_i - 1, current_j].BackColor = Color.Blue;
                    buttons[current_i - 1, current_j].Enabled = false;
                    player.Planes[planenumber + 1].Buttons[2].X = current_i - 1;
                    player.Planes[planenumber + 1].Buttons[2].Y = current_j;

                    buttons[current_i - 1, current_j + 1].BackColor = Color.Blue;
                    buttons[current_i - 1, current_j + 1].Enabled = false;
                    player.Planes[planenumber + 1].Buttons[3].X = current_i - 1;
                    player.Planes[planenumber + 1].Buttons[3].Y = current_j + 1;

                    buttons[current_i - 2, current_j].BackColor = Color.Blue;
                    buttons[current_i - 2, current_j].Enabled = false;
                    player.Planes[planenumber + 1].Buttons[4].X = current_i - 2;
                    player.Planes[planenumber + 1].Buttons[4].Y = current_j;

                    buttons[current_i - 3, current_j].BackColor = Color.Blue;
                    buttons[current_i - 3, current_j].Enabled = false;
                    player.Planes[planenumber + 1].Buttons[5].X = current_i - 3;
                    player.Planes[planenumber + 1].Buttons[5].Y = current_j;

                    return true;
                }
                return false;
            }
            // Orientation 0
            else
            {
                if (buttons[current_i, current_j].BackColor == Color.White && buttons[current_i, current_j].Enabled == true &&
                buttons[current_i - 1, current_j + 1].Enabled && buttons[current_i - 1, current_j + 1].BackColor == Color.White &&
                buttons[current_i, current_j + 1].Enabled && buttons[current_i, current_j + 1].BackColor == Color.White &&
                buttons[current_i + 1, current_j + 1].Enabled && buttons[current_i + 1, current_j + 1].BackColor == Color.White &&
                buttons[current_i, current_j + 2].Enabled && buttons[current_i, current_j + 2].BackColor == Color.White &&
                buttons[current_i, current_j + 3].Enabled && buttons[current_i, current_j + 3].BackColor == Color.White)
                {
                    // The pattern was found, so perform the actions
                    buttons[current_i, current_j].BackColor = Color.Red;
                    buttons[current_i, current_j].Enabled = false;
                    player.Planes[planenumber + 1].Buttons[0].X = current_i;
                    player.Planes[planenumber + 1].Buttons[0].Y = current_j;

                    buttons[current_i - 1, current_j + 1].BackColor = Color.Blue;
                    buttons[current_i - 1, current_j + 1].Enabled = false;
                    player.Planes[planenumber + 1].Buttons[1].X = current_i - 1;
                    player.Planes[planenumber + 1].Buttons[1].Y = current_j + 1;

                    buttons[current_i - 1, current_j].BackColor = Color.Blue;
                    buttons[current_i - 1, current_j].Enabled = false;
                    player.Planes[planenumber + 1].Buttons[2].X = current_i - 1;
                    player.Planes[planenumber + 1].Buttons[2].Y = current_j;

                    buttons[current_i - 1, current_j - 1].BackColor = Color.Blue;
                    buttons[current_i - 1, current_j - 1].Enabled = false;
                    player.Planes[planenumber + 1].Buttons[3].X = current_i - 1;
                    player.Planes[planenumber + 1].Buttons[3].Y = current_j - 1;

                    buttons[current_i - 2, current_j].BackColor = Color.Blue;
                    buttons[current_i - 2, current_j].Enabled = false;
                    player.Planes[planenumber + 1].Buttons[4].X = current_i - 2;
                    player.Planes[planenumber + 1].Buttons[4].Y = current_j;

                    buttons[current_i - 3, current_j].BackColor = Color.Blue;
                    buttons[current_i - 3, current_j].Enabled = false;
                    player.Planes[planenumber + 1].Buttons[5].X = current_i - 3;
                    player.Planes[planenumber + 1].Buttons[5].Y = current_j;

                    return true;
                }
                return false;
            }
        }

        public void changeBoard(Button[,] buttons, bool bvalue)
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    buttons[i, j].Enabled = bvalue;
        }

        private void readyBtn_Click(object sender, EventArgs e)
        {
            readyBtn.Text = "Start!";
            index_faza++;

            if (index_faza==1)
                if (current_player == 1)
                {
                    for (int i = 0; i < 10; i++)
                        for (int j = 0; j < 10; j++)
                            buttons1[i, j].BackColor = Color.White;
                    MessageBox.Show("Randul oponentului!" + "\n Pozitioneaza cele 3 avioane identice pe tabla ta de joc -> Dreapta");
                    changeBoard(buttons1, false);
                    changeBoard(buttons2, true);
                    current_player = 2;
                }
                else
                {
                    for (int i = 0; i < 10; i++)
                        for (int j = 0; j < 10; j++)
                            buttons2[i, j].BackColor = Color.White;
                    MessageBox.Show("Randul oponentului!" + "\n Pozitioneaza cele 3 avioane identice pe tabla ta de joc -> Stanga");
                    changeBoard(buttons2, false);
                    changeBoard(buttons1, true);
                    current_player = 1;
                }
            else
            {//Coloreaza patratele oponentului cu randul 2 in alb.
                if (current_player == 1)
                {
                    for (int i = 0; i < 10; i++)
                        for (int j = 0; j < 10; j++)
                            buttons1[i, j].BackColor = Color.White;
                }
                else
                {
                    for (int i = 0; i < 10; i++)
                        for (int j = 0; j < 10; j++)
                            buttons2[i, j].BackColor = Color.White;
                }
            }
        }

        private void rotateBtn_Click(object sender, EventArgs e)
        {
            if (index_directie < 3)
                index_directie++;
            else
                index_directie = 0;

            if (index_directie == 0)
            {
                imagineOrientare.Image = Resources.Orientare_0;
                imagineOrientare.Size = new Size(310, 220);
                imagineOrientare.Location = new Point(1540, 603);
                imagineOrientare.Visible = true;
                imagineOrientare2.Visible = false;

            }
            else if (index_directie == 1)
            {
                imagineOrientare2.Image = Resources.Orientare_1;
                imagineOrientare2.Location = new Point(1540, 517);
                imagineOrientare2.Size = new Size(310, 440);
                imagineOrientare.Visible = false;
                imagineOrientare2.Visible = true;
            }
            else if (index_directie == 2)
            {
                imagineOrientare.Image = Resources.Orientare_2;
                imagineOrientare.Size = new Size(310, 220);
                imagineOrientare.Location = new Point(1540, 603);
                imagineOrientare.Visible = true;
                imagineOrientare2.Visible = false;
            }
            else if (index_directie == 3)
            {
                imagineOrientare2.Image = Resources.Orientare_3;
                imagineOrientare2.Size = new Size(310, 440);
                imagineOrientare2.Location = new Point(1540, 517);
                imagineOrientare.Visible = false;
                imagineOrientare2.Visible = true;
            }
            
        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}