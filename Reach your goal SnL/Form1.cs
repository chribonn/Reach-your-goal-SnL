using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace Snakes_and_Ladders
{
    public partial class FormReachYourGoalSnL : Form
    {
        // Stores the avatars that can be used in the game
        const string dirGamePiece = "\\Reach your goal SnL\\Game_Piece";
        // Stores the different game states
        const string dirGameState = "\\Reach your goal SnL\\Game_State";

        // the active player
        int currentPlayer = 0;
        // this stores the player's position on the board
        int[] gamePosition = new int[] { 0, 0, 0, 0, 0, 0 };
        //images to store the player's avatar
        Image[] avatarUser = new Image[] {null, null, null, null, null, null};
        // this is used to hold which of the 6 slots contains players. 
        bool[] activePlayer = new bool[] { false, false, false, false, false, false };
        //coordinates to hold the position of the stationary avatar(the players that are not rolling the dice)
        int[] iBeforeXP = new int[] { 0, 0, 0, 0, 0, 0 };
        int[] iBeforeYP = new int[] { 0, 0, 0, 0, 0, 0 };

        // holds the avatars that are used
        List<string> lstAvatars = new List<string>();

        //array to link square number to row+column
        int[,] mainArray = new int[10, 10];
        //array to where the snakes or ladders start
        int[] hotspotArray = new int[12];
        //array to where the snakes or ladders moves you
        int[] hotspotEndArray = new int[12];
        //image to hold the template
        Image myTemplate = null;

        //bitmap to draw the background image on the picturebox
        Bitmap mainBitmap;
        //bitmap to draw the counters on the picturebox
        Bitmap counterBitmap;
        //bitmap to draw the dice
        Bitmap diceBitmap;

        //graphics to draw to counterBitmap
        Graphics g;
        //graphics to draw to mainBitmap
        Graphics gBack;
        //graphics to draw to diceBitmap
        Graphics gDice;
        //Pens and Brushes to draw the grid and numbers
        Pen myPen = new Pen(Color.Black, 1);
        Pen myBoldPen = new Pen(Color.Black, 8);
        Brush myBrush = new SolidBrush(Color.Black);
        Brush myBlueBrush = new SolidBrush(Color.LightBlue);
        Font drawFont = new Font("Arial", 10, FontStyle.Regular);

        int iCount2 = 0;

        //generate random number
        Random rnd = new Random();

        //counter variables to go throught array
        int i = 0, j = 0;

        //the width and height of bitmap
        int width, height;

        //increment to link row+column to pixel location
        int iIncrement;

        //integer to hold the random number
        int randNum;

        //distance to draw smaller images
        int iDistance = 8;

        //distance value for dice
        int iDiceDistance = 8;

       //flag to check for rollover when you don't roll exact 100
        int iFlagRollover = 0;
         //the position of the player before rolling the dice
        int iOriginalSum;
        //the position of the player in a global variable
        int iGlobalSum;

        //integer that tells what template the player chose
        // int iTemplate = 0;
        //integer to store rise,run,y2,y1,x2,x1
        int rise, run;
        int x1 = 0, x2 = 0, y1 = 0, y2 = 0;

        public FormReachYourGoalSnL()
        {
            InitializeComponent();

            //hide or show appropiate buttons, labels, radio button, panel, picturebox, ect
            panelMain.Hide();
            btnRoll.Hide();
            rtbInstruct.Hide();
            lblInstruction.Hide();
            width = pbDisplay.Width;
            height = pbDisplay.Height;
            pbDice.Hide();
 
            //initialize mainBitmap/counterBitmap to the size of the pictureBox
            mainBitmap = new Bitmap(width, height);
            counterBitmap = new Bitmap(width, height);

            //initialize diceBitmap to the size of pbDice
            diceBitmap = new Bitmap(pbDice.Width, pbDice.Height);

            //set graphics to appropiate bitmap
            g = Graphics.FromImage(counterBitmap);
            gBack = Graphics.FromImage(mainBitmap);
            gDice = Graphics.FromImage(diceBitmap);

            //set the incrment to 1/10 the width length of picturebox
            iIncrement = width / 10;

            //call functions to draw the grid with numbers and display the snakes template
            gBack.Clear(Color.Transparent);
            fillObjects();
            drawObjects();
            drawNumbers();

            setArray();
            //pbLogos.BackgroundImage = Image.FromFile("Reach your goal SnL.JPG");
            myTemplate = Properties.Resources.Snakes_Template_2;
            gBack.DrawImage(myTemplate, 0, 0, 620, 620);

            pbDisplay.Invalidate();
            //make the backgroundImage of pbDisplay to mainBitmap
            pbDisplay.BackgroundImage = mainBitmap;
            // Load the avatars into memory
            panelAvatar.Show();

            // Load the avatars into the directory. If there is a problem give out an alert and don't allow game to start.
            if (!LoadAvatars())
            {
                MessageBox.Show("Problem loading avatars.\nReach your goal SnL cannot be initialised.", "Game Initialisation", MessageBoxButtons.OK);
                Application.Exit();
            }

            if (!LoadGames())
            {
                MessageBox.Show("Problem loading existing games.\nReach your goal SnL cannot be initialised.", "Game Initialisation", MessageBoxButtons.OK);
                Application.Exit();
            }

        }
        void initialize()
        {
            string ctrlName;
            TextBox tb = null;
            ComboBox cb = null;
            NumericUpDown nud = null;

            //set all variables to default in the beginning
            timerRoll.Stop();
            timerMoveCounter.Stop();
            timerUpLadderDownSnake.Stop();
            for (int i=0; i<6; i++)
            {
                gamePosition[i] = 0;
                avatarUser[i] = null;
                activePlayer[i] = false;
                iBeforeXP[i] = 0;
                iBeforeYP[i] = 0;

                ctrlName = "txtP" + i.ToString();
                Control[] matches = this.Controls.Find(ctrlName, true);
                if (matches.Length > 0 && matches[0] is TextBox)
                {
                    tb = (TextBox)matches[0];
                    tb.Text = "";
                    tb.Enabled = false;
                }

                ctrlName = "cbAvatarP" + i.ToString();
                Control[] matches2 = this.Controls.Find(ctrlName, true);
                if (matches2.Length > 0 && matches2[0] is ComboBox)
                {
                    cb = (ComboBox)matches2[0];
                    cb.Items.Clear();
                    cb.Items.AddRange(lstAvatars.ToArray());
                    cb.SelectedIndex = -1;
                    cb.Enabled = false;
                }

                // enable to numeric up down control
                ctrlName = "nudP" + i.ToString();
                Control[] matches3 = this.Controls.Find(ctrlName, true);
                if (matches3.Length > 0 && matches3[0] is NumericUpDown)
                {
                    nud = (NumericUpDown)matches3[0];
                    nud.Value = 0;
                    nud.Enabled = false;
                }

            }

            txtGameName.Text = "";
            if (!LoadGames())
            {
                MessageBox.Show("Problem loading existing games.\nReach your goal SnL cannot be initialised.", "Game Initialisation", MessageBoxButtons.OK);
                Application.Exit();
            }

            btnRoll.Hide();
            btnRoll.Enabled = true;
            g.Clear(Color.Transparent);
            lblInstruction.Hide();
            panelMain.Hide();
            btnRoll.Hide();
            pbDice.Hide();
            panelAvatar.Show();

            //call functions to draw the grid with numbers and display the snakes template
            gBack.Clear(Color.Transparent);
            fillObjects();
            drawObjects();
            drawNumbers();

            setArray();
            //pbLogos.BackgroundImage = Image.FromFile("Reach your goal SnL.JPG");
            myTemplate = Properties.Resources.Snakes_Template_2;
            gBack.DrawImage(myTemplate, 0, 0, 620, 620);

            pbDisplay.Invalidate();
            //make the backgroundImage of pbDisplay to mainBitmap
            pbDisplay.BackgroundImage = mainBitmap;
            // Load the avatars into memory
            panelAvatar.Show();

        }

        private void setArray()
        {
            hotspotArray[0] = 2;
            hotspotArray[1] = 9;
            hotspotArray[2] = 18;
            hotspotArray[3] = 49;
            hotspotArray[4] = 65;
            hotspotArray[5] = 67;
            hotspotArray[6] = 26;
            hotspotArray[7] = 45;
            hotspotArray[8] = 60;
            hotspotArray[9] = 68;
            hotspotArray[10] = 93;
            hotspotArray[11] = 98;
            hotspotEndArray[0] = 39;
            hotspotEndArray[1] = 32;
            hotspotEndArray[2] = 64;
            hotspotEndArray[3] = 54;
            hotspotEndArray[4] = 96;
            hotspotEndArray[5] = 86;
            hotspotEndArray[6] = 5;
            hotspotEndArray[7] = 34;
            hotspotEndArray[8] = 17;
            hotspotEndArray[9] = 13;
            hotspotEndArray[10] = 71;
            hotspotEndArray[11] = 80;
        }
         //show the instructions on how to play game
        private void llAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (rtbInstruct.Visible)
                rtbInstruct.Hide();
            else
                rtbInstruct.Show();

        }
        //draw the gridline
        void drawObjects()
        {

            gBack.DrawRectangle(myBoldPen, 0, 0, width - 1, height - 1);


            for (i = 0; i < 10; i++)
            {
                gBack.DrawLine(myPen, 0, i * iIncrement, width, i * iIncrement);

            }
            for (i = 0; i < 10; i++)
            {
                gBack.DrawLine(myPen, i * iIncrement, 0, i * iIncrement, height);

            }

        }
        //fill the grid line to blue and white
        void fillObjects()
        {
            for (i = 0; i < 10; i += 2)
            {
                for (j = 1; j < 11; j += 2)
                {
                    gBack.FillRectangle(myBlueBrush, i * iIncrement, j * iIncrement, iIncrement, iIncrement);
                }
            }
            for (i = 1; i < 11; i += 2)
            {
                for (j = 0; j < 10; j += 2)
                {
                    gBack.FillRectangle(myBlueBrush, i * iIncrement, j * iIncrement, iIncrement, iIncrement);
                }
            }
        }
        //draw the numbers on the gridline
        void drawNumbers()
        {
            int iDisplayNumber = 100;
            int iDistance = 5;
            for (i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    for (j = 0; j < 10; j++)
                    {
                        gBack.DrawString(iDisplayNumber.ToString(), drawFont, myBrush, iDistance + j * iIncrement, iDistance + i * iIncrement);
                        mainArray[i, j] = iDisplayNumber;
                        iDisplayNumber--;
                    }
                }
                else
                {

                    for (j = 9; j >= 0; j--)
                    {
                        gBack.DrawString(iDisplayNumber.ToString(), drawFont, myBrush, iDistance + j * iIncrement, iDistance + i * iIncrement);
                        mainArray[i, j] = iDisplayNumber;
                        iDisplayNumber--;
                    }
                }

            }
        }
        void drawAvatar(int x1, int y1)
        {
            //clear the drawing surface
            g.Clear(Color.Transparent);

            // Each player except the active one update their avatar
            for (int i = 0; i < 6; i++)
            {
                if (activePlayer[i])
                {
                    if (i == currentPlayer)
                    {
                        g.DrawImage(avatarUser[i], x1 * iIncrement + iDistance, y1 * iIncrement + iDistance, iIncrement - 2 * iDistance, iIncrement - 2 * iDistance);
                    }
                    else
                    {
                        if (gamePosition[i] > 0)
                        {
                            g.DrawImage(avatarUser[i], iBeforeXP[i] * iIncrement + iDistance, iBeforeYP[i] * iIncrement + iDistance, iIncrement - 2 * iDistance, iIncrement - 2 * iDistance);
                        }
                    }
                }
            }

            // when not initialised (currentPlayer == -999) do nothing. This happens when a game is loaded before gameplay begins.
            if (currentPlayer != -999)
            {
                //set the picture box to the bitmap
                pbDisplay.Image = counterBitmap;
                iBeforeXP[currentPlayer] = x1;
                iBeforeYP[currentPlayer] = y1;
            }

        }
        void drawDice(int randNum)
        {
            //draw the dice depending on the randon number rolled
            gDice.Clear(Color.White);
            gDice.DrawRectangle(myPen, 0, 0, pbDice.Width - 1, pbDice.Height - 1);

            if (randNum == 1 || randNum == 3 || randNum == 5)
            {
                gDice.FillEllipse(myBrush, pbDice.Width / 2 - iDiceDistance, pbDice.Height / 2 - iDiceDistance, iDiceDistance * 2, iDiceDistance * 2);
                if (randNum == 3 || randNum == 5)
                {
                    gDice.FillEllipse(myBrush, iDiceDistance, pbDice.Height - 3 * iDiceDistance, iDiceDistance * 2, iDiceDistance * 2);
                    gDice.FillEllipse(myBrush, pbDice.Width - 3 * iDiceDistance, iDiceDistance, iDiceDistance * 2, iDiceDistance * 2);
                    if (randNum == 5)
                    {
                        gDice.FillEllipse(myBrush, iDiceDistance, iDiceDistance, iDiceDistance * 2, iDiceDistance * 2);
                        gDice.FillEllipse(myBrush, pbDice.Width - 3 * iDiceDistance, pbDice.Height - 3 * iDiceDistance, iDiceDistance * 2, iDiceDistance * 2);
                    }
                }

            }
            if (randNum == 2 || randNum == 4 || randNum == 6)
            {
                gDice.FillEllipse(myBrush, iDiceDistance, iDiceDistance, iDiceDistance * 2, iDiceDistance * 2);
                gDice.FillEllipse(myBrush, pbDice.Width - 3 * iDiceDistance, pbDice.Height - 3 * iDiceDistance, iDiceDistance * 2, iDiceDistance * 2);
                if (randNum == 4 || randNum == 6)
                {
                    gDice.FillEllipse(myBrush, iDiceDistance, pbDice.Height - 3 * iDiceDistance, iDiceDistance * 2, iDiceDistance * 2);
                    gDice.FillEllipse(myBrush, pbDice.Width - 3 * iDiceDistance, iDiceDistance, iDiceDistance * 2, iDiceDistance * 2);
                    if (randNum == 6)
                    {
                        gDice.FillEllipse(myBrush, pbDice.Width / 2 - iDiceDistance, iDiceDistance, iDiceDistance * 2, iDiceDistance * 2);
                        gDice.FillEllipse(myBrush, pbDice.Width / 2 - iDiceDistance, pbDice.Height - 3 * iDiceDistance, iDiceDistance * 2, iDiceDistance * 2);
                    }
                }

            }



            pbDice.Image = diceBitmap;
        }
        //method to calculate the new position of the moving game counter
        void calculateMove(ref int iSum)
        {
            iOriginalSum = iSum + 1;
            iSum += randNum;

            iGlobalSum = iSum;

            timerMoveCounter.Start();
        }
        void animateMove(ref int iOriginalSum, ref int iSum)
        {

            int iPrevSum;
            //loop to check if the game piece hits a snake or ladder
            for (i = 0; i < 12; i++)
            {
                if (hotspotArray[i] == iSum && iOriginalSum == iSum)
                {
                    iFlagRollover = 0;
                    iPrevSum = iSum;
                    iOriginalSum = hotspotEndArray[i];
                    iSum = hotspotEndArray[i];
                    gamePosition[currentPlayer] = hotspotEndArray[i];
                    timerMoveCounter.Stop();
                    SnakesandLaddersAnimation(iPrevSum, iSum);
                    return;
                }
            }
            //loop to draw the avatar based on the position the game piece is on
            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 10; j++)
                {
                    if (mainArray[i, j] == iOriginalSum)
                    {
                        drawAvatar(j, i);
                        goto here;
                    }
                }
            }
        here:
            //loop to stop drawing additional avatars and stop the timer
            if (iOriginalSum == iSum)
            {
                //to move the counter backwards if you don't roll exactly 100
                if (iFlagRollover == 1)
                {
                    iFlagRollover = 0;
                    gamePosition[currentPlayer] = iSum;
                }
                timerMoveCounter.Stop();
                //if the player rolls exactly 100, go to win method
                if (iSum == 100)
                {
                    win();
                    return;
                }

                timerWait.Start();
                return;
            }
            //conditions to deal with rollover
            if (iFlagRollover == 0)
            {
                iOriginalSum++;
            }
            if (iFlagRollover == 1)
            {
                iOriginalSum--;
            }
            if (iOriginalSum > 100)
            {
                iFlagRollover = 1;
                iSum = 200 - iSum;
                iOriginalSum = 200 - iOriginalSum;
            }


        }
        void SnakesandLaddersAnimation(int iPrevSum, int iSum)
        {
            //to animate the counter up the snake or down the ladder, calculate: rise,run before calling the timer
            int iPositiveRiseFlag = 0;
            int iNegativeRunFlag = 0;
            int Gcf;
            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 10; j++)
                {
                    if (mainArray[i, j] == iPrevSum)
                    {
                        x1 = j * iIncrement;
                        y1 = i * iIncrement;
                    }
                    if (mainArray[i, j] == iSum)
                    {
                        x2 = j * iIncrement;
                        y2 = i * iIncrement;
                        iBeforeXP[currentPlayer] = j;
                        iBeforeYP[currentPlayer] = i;
                    }
                }
            }
            rise = y2 - y1;
            run = x2 - x1;
            if (rise > 0)
            {
                iPositiveRiseFlag = 1;
            }
            if (run < 0)
            {
                iNegativeRunFlag = 1;
            }
            rise = Math.Abs(y2 - y1);
            run = Math.Abs(x2 - x1);
            Gcf = gcf(rise, run);
            //divide rise and run by GCF to reduce to lowest terms
            run /= Gcf;
            rise /= Gcf;
            //account for positive/negative rise/run since the gcf function only works for positive numbers
            if (iPositiveRiseFlag == 1)
            {
                rise = rise * -1;
            }
            if (iNegativeRunFlag == 1)
            {
                run = run * -1;
            }

            timerUpLadderDownSnake.Start();

        }
        int gcf(int rise, int run)
        {
            //copied from internet, algorithm to find the gcf of the rise and run
            while (rise != 0 && run != 0)
            {
                if (rise > run)
                    rise %= run;
                else
                    run %= rise;
            }

            if (rise == 0)
                return run;
            else
                return rise;
        }

        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            // Hide the instructions if they happen to be showing
            rtbInstruct.Hide();

            // Save the Game Name and restore it at the end (LoadGames initialises everything)
            string GameName = cbGames.SelectedItem.ToString();
            // Something was selected
            if (cbGames.SelectedIndex > -1)
            {
                if (!LoadGame(cbGames.SelectedItem.ToString()))
                {
                    MessageBox.Show("Unable to parse Reach your goal SnL Game file", "Cannot Load Game", MessageBoxButtons.OK);
                }
            }

            cbGames.SelectedIndex = cbGames.Items.IndexOf(GameName);
        }

        private void btnDelGame_Click(object sender, EventArgs e)
        {
            // Hide the instructions if they happen to be showing
            rtbInstruct.Hide();

            string errMsg;
            // Something was selected
            if (cbGames.SelectedIndex > -1)
            {
                if (MessageBox.Show("Are you sure?", "Delete Game", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    errMsg = DeleteGame(cbGames.SelectedItem.ToString());
                    if (errMsg != "")
                    {
                        MessageBox.Show(errMsg, "Cannot Delete Game", MessageBoxButtons.OK);
                        return;
                    }

                    cbGames.Items.Remove(cbGames.SelectedIndex);
                    initialize();
                }
            }

        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            // Hide the instructions if they happen to be showing
            rtbInstruct.Hide();

            // if there is a game loaded, ask user to confirm
            if (cbGames.SelectedIndex > -1)
            {
                if (MessageBox.Show("Game in Progress. Do you want to quit?", "Quit Game", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    initialize();
                    NewGame();
                    txtGameName.Focus();
                }
                else
                {
                    // Clear the New Game State
                    txtGameName.Text = "";
                }
            }
            else
            {
                initialize();
                NewGame();
                txtGameName.Focus();
            }
        }
        private void timerUpLadderDownSnake_Tick(object sender, EventArgs e)
        {
            //set various endpoints based on rise and run
            if (run == 0 && rise > 0)
            {
                rise = 5;
            }
            else if (run == 0 && rise < 0)
            {
                rise = -5;
            }
            if (rise > 0 && run >= 0)
            {
                if (x1 >= x2 && y1 < y2)
                {
                    timerUpLadderDownSnake.Stop();
                    timerWait.Start();
                }
            }
            else if (rise >= 0 && run < 0)
            {
                if (x1 <= x2 && y1 < y2)
                {
                    timerUpLadderDownSnake.Stop();
                    timerWait.Start();
                }
            }
            else if (rise < 0 && run < 0)
            {
                if (x1 <= x2 && y1 > y2)
                {
                    timerUpLadderDownSnake.Stop();
                    timerWait.Start();
                }
            }
            else if (rise < 0 && run >= 0)
            {
                if (x1 >= x2 && y1 > y2)
                {

                    timerUpLadderDownSnake.Stop();
                    timerWait.Start();
                }
            }
            //draw the avatar slowly from current coordinate to endpoint
            drawAnimatedAvatar(x1, y1);
            //add the rise/run to the coordinate         
            x1 += run;
            y1 -= rise;

        }
        void drawAnimatedAvatar(int x1, int y1)
        {
            //clear the previous graphics
            g.Clear(Color.Transparent);
            //draw the avatar but also draw the location of the non moving game piece
            for (int i = 0; i < 6; i++)
            {
                if (activePlayer[i])
                {
                    if (i == currentPlayer)
                    {
                        g.DrawImage(avatarUser[i], x1 + iDistance, y1 + iDistance, iIncrement - 2 * iDistance, iIncrement - 2 * iDistance);
                    }
                    else
                    {
                        if (gamePosition[i] > 0)
                        {
                            g.DrawImage(avatarUser[i], iBeforeXP[i] * iIncrement + iDistance, iBeforeYP[i] * iIncrement + iDistance, iIncrement - 2 * iDistance, iIncrement - 2 * iDistance);
                        }
                    }
                }
            }

            pbDisplay.Image = counterBitmap;
        }

        private void btnSaveGame_Click(object sender, EventArgs e)
        {
            // Hide the instructions if they happen to be showing
            rtbInstruct.Hide();

            txtGameName.Text = txtGameName.Text.Trim();

            if (txtGameName.Text == "")
            {
                // If txtGameName is blank, check if the combobox was selected
                if (cbGames.SelectedIndex > -1)
                {
                    txtGameName.Text = cbGames.SelectedItem.ToString();
                }
            }

            if (txtGameName.Text == "")
            {
                MessageBox.Show("You must specify a game name", "Save this game", MessageBoxButtons.OK);
                return;
            }

            string currGame = txtGameName.Text;

            string errTxt = SaveGame(txtGameName.Text);
            if (errTxt != "")
            {
                MessageBox.Show(errTxt, "Save this game", MessageBoxButtons.OK);
                txtGameName.Focus();
            }

 
            // Call the Load function to set the game state as it should
            if (!LoadGame(txtGameName.Text))
            {
                MessageBox.Show("Unable to parse Reach your goal SnL Game file", "Cannot Load Game", MessageBoxButtons.OK);
            }
            else
            {
                // Clear out the Save TextBox
                txtGameName.Text = "";
            }

            cbGames.SelectedIndex = cbGames.Items.IndexOf(currGame);

        }

        private void btnPlayRound_Click(object sender, EventArgs e)
        {
            // Hide the instructions if they happen to be showing
            rtbInstruct.Hide();

            string ctrlName;
            TextBox tb = null;
            DirectoryInfo gameDir;
            string GameName;
            Control[] matches;

            // Stores the person who is playing next.
            currentPlayer = -1;
            string errTxt = GameSetupCorrectly();

            // Do not allow the game to be played it there is an error
            if (errTxt != "")
            {
                MessageBox.Show(errTxt, "Pay a round", MessageBoxButtons.OK);
                return;
            }

            // if this game has not been saved, save it before continuing
            GameName = txtGameName.Text.Trim();
            if (GameName == "")
            {
                if (cbGames.SelectedIndex > -1)
                {
                    GameName = cbGames.SelectedItem.ToString();
                }
            }
            if (GameName != "")
            {
                gameDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + dirGameState);
                var fileName = Path.Combine(gameDir.ToString(), ("Game_" + GameName + ".txt"));

                // If the file does not exist, save it
                if (!File.Exists(fileName))
                    SaveGame(GameName);

                // Populate the array activePlayer
                for (int i = 0; i < 6; i++)
                {
                    ctrlName = "txtP" + i.ToString();
                    matches = this.Controls.Find(ctrlName, true);
                    if (matches.Length > 0 && matches[0] is TextBox)
                    {
                        tb = (TextBox)matches[0];

                        if (tb.Text != "")
                            activePlayer[i] = true;
                        else
                            activePlayer[i] = false;
                    }

                }
            }


            // Are there any dice rolls?
            if (!DiceRollsAvailable())
            {
                MessageBox.Show("At least one player needs to have a dice roll", "Pay Game", MessageBoxButtons.OK);
                return;
            }

            currentPlayer = GetNextPlayer(currentPlayer);
            if (currentPlayer == -999)
            {
                currentPlayer = 0;
                // Restore the windows
                lblInstruction.Text = "";
                pbGamePiece.Image = null;
                panelMain.Hide();
                lblInstruction.Hide();
                btnRoll.Hide();
                pbDice.Hide();
                panelAvatar.Show();
                panelAvatar.Focus();

                if (MessageBox.Show("No more Die plays. Save Game?", "Pay Game", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    errTxt = SaveGame(cbGames.SelectedItem.ToString());
                    if (errTxt != "")
                    {
                        MessageBox.Show(errTxt, "Save this game", MessageBoxButtons.OK);
                        return;
                    }
                }
            }

            // current Player plays turn
            ctrlName = "txtP" + currentPlayer.ToString();
            matches = this.Controls.Find(ctrlName, true);
            if (matches.Length > 0 && matches[0] is TextBox)
            {
                tb = (TextBox)matches[0];
                lblInstruction.Text = tb.Text + ": Roll the Die!";
                pbGamePiece.Image = ResizeImage(avatarUser[currentPlayer], 110, 110);
                panelAvatar.Hide();
                panelMain.Show();
                lblInstruction.Show();
                btnRoll.Show();
                btnRoll.Focus();
            }
        }

        void win()
        {
            string ctrlName;
            TextBox tb = null;
            string WinningTxt = "";
            string GameName;

            ctrlName = "txtP" + currentPlayer.ToString();
            Control[] matches = this.Controls.Find(ctrlName, true);
            if (matches.Length > 0 && matches[0] is TextBox)
            {
                tb = (TextBox)matches[0];
                WinningTxt = tb.Text + " wins!. Save game?";
            }

            if (MessageBox.Show(WinningTxt, "Victory!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // if this game has not been saved, save it before continuing
                GameName = txtGameName.Text.Trim();
                if (GameName == "")
                {
                    if (cbGames.SelectedIndex > -1)
                    {
                        GameName = cbGames.SelectedItem.ToString();
                    }
                }
                if (GameName != "")
                {
                    string errTxt = SaveGame(GameName);
                    if (errTxt != "")
                    {
                        MessageBox.Show(errTxt, "Save this game", MessageBoxButtons.OK);
                    }
                }
            }

            //initialize everything back to previous settings
            initialize();
            return;

        }

        private void linkRestart_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Hide the instructions if they happen to be showing
            rtbInstruct.Hide();

            // if there is a game loaded, ask user to confirm
            if (cbGames.SelectedIndex > -1)
            {
                if (MessageBox.Show("Game in Progress. Do you want to quit?", "Restart Game", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    initialize();
                }
            }
        }

        private void FormReachyourgoalSnL_Load(object sender, EventArgs e)
        {
            // no smaller than design time size
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);

            // no larger than screen size
            this.MaximumSize = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            // Hide the instructions if they happen to be showing
            rtbInstruct.Hide();

            //start the timer
            timerRoll.Start();
        }
        private void timerRoll_Tick(object sender, EventArgs e)
        {
            //show and hide controls as necessary
            lblInstruction.Text = "";
             pbDice.Show();
            btnRoll.Hide();
            pbLogos.Focus();
            //generate 10 random numbers before stopping
            if (iCount2 > 10)
            {
                //stop the timer
                timerRoll.Stop();
                //return the count to 0
                iCount2 = 0;
                //start the logic of moving the counter
                calculateMove(ref gamePosition[currentPlayer]);
                return;
            }

            //generation random number from 1-6 and draw appropiate dice
            randNum = rnd.Next(6) + 1;
            drawDice(randNum);

            //increment the count
            iCount2++;
        }

        private void timerWait_Tick(object sender, EventArgs e)
        {
            string ctrlName;
            TextBox tb = null;
            btnRoll.Enabled = true;

            // Unless we are at the end of the game, get the next player
            if (currentPlayer != -999)
            {
                currentPlayer = GetNextPlayer(currentPlayer);
            }
            if (currentPlayer == -999)
            {
                timerWait.Stop();
                // Restore the windows
                lblInstruction.Text = "";
                pbGamePiece.Image = null;
                panelMain.Hide();
                lblInstruction.Hide();
                btnRoll.Hide();
                pbDice.Hide();
                panelAvatar.Show();
                panelAvatar.Focus();
                return;
            }
        
            // Setup for the next player
            ctrlName = "txtP" + currentPlayer.ToString();
            Control[] matches = this.Controls.Find(ctrlName, true);
            if (matches.Length > 0 && matches[0] is TextBox)
            {
                tb = (TextBox)matches[0];
                lblInstruction.Text = tb.Text + ": Roll the Die!";
                pbGamePiece.Image = ResizeImage(avatarUser[currentPlayer], 110, 110);
                pbDice.Hide();
                btnRoll.Show();
                btnRoll.Focus();
            }

            timerWait.Stop();
            return;
        }
        private void timerMoveCounter_Tick(object sender, EventArgs e)
        {
            //start drawing to counter to new position
            animateMove(ref iOriginalSum, ref iGlobalSum);
        }
        private void pbDisplay_Paint(object sender, PaintEventArgs e)
        {
            //repaint the picturebox
            pbDisplay.BackgroundImage = mainBitmap;
        }
        private void llQuit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Hide the instructions if they happen to be showing
            rtbInstruct.Hide();

            // if there is a game loaded, ask user to confirm
            if (cbGames.SelectedIndex > -1)
            {
                if (MessageBox.Show("Game in Progress. Do you want to quit?", "Quit Game", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
        }
    }
}



