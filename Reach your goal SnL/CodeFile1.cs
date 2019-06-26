using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Snakes_and_Ladders
{
    public partial class FormReachYourGoalSnL
    {
        private bool LoadAvatars()
        {
            bool filesFound = false;
            string avatarName;
            FileInfo[] filesInDir;
            DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + dirGamePiece);
            try
            {
                filesInDir = hdDirectoryInWhichToSearch.GetFiles("*.png");
            }
            catch
            {
                return filesFound;
            }

            cbAvatarP0.Items.Clear();
            cbAvatarP1.Items.Clear();
            cbAvatarP2.Items.Clear();
            cbAvatarP3.Items.Clear();
            cbAvatarP4.Items.Clear();
            cbAvatarP5.Items.Clear();

            foreach (FileInfo foundFile in filesInDir)
            {
                string fullName = foundFile.FullName;
                avatarName = Path.GetFileNameWithoutExtension(fullName);
                lstAvatars.Add(avatarName);
                // Populate the drop down lists
                cbAvatarP0.Items.Add(avatarName);
                cbAvatarP1.Items.Add(avatarName);
                cbAvatarP2.Items.Add(avatarName);
                cbAvatarP3.Items.Add(avatarName);
                cbAvatarP4.Items.Add(avatarName);
                cbAvatarP5.Items.Add(avatarName);

                filesFound = true;
            }

            return filesFound;
        }

        // Returns true or fa
        private bool DiceRollsAvailable()
        {
            bool foundNonZero = false;

            // to play a round at least one player has to have a non zero roll of the dice
            string ctrlName;
            for (int i = 0; i < 6; i++)
            {
                if (activePlayer[i])
                {
                    // enable to numeric up down control
                    ctrlName = "nudP" + i.ToString();
                    Control[] matches3 = this.Controls.Find(ctrlName, true);
                    if (matches3.Length > 0 && matches3[0] is NumericUpDown)
                    {
                        NumericUpDown nud = (NumericUpDown)matches3[0];
                        if (nud.Value != 0)
                        {
                            foundNonZero = true;
                            break;
                        }
                    }
                }
            }
            return foundNonZero;
        }
        // Loads the Saved Games
        private bool LoadGames()
        {
            bool gamesLoaded = true;
            string gameName;
            FileInfo[] filesInDir;
 
            cbGames.Enabled = false;
            cbGames.Items.Clear();

            DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + dirGameState);
            // If the directory does not exist, create it
            if (!Directory.Exists(hdDirectoryInWhichToSearch.ToString()))
            {
                Directory.CreateDirectory(hdDirectoryInWhichToSearch.ToString());
            }

            // Go through the directory and read in any games stored on this machine
            try
            {
                filesInDir = hdDirectoryInWhichToSearch.GetFiles("Game_*.txt");
            }
            catch
            {
                gamesLoaded = false;
                return gamesLoaded;
            }

            foreach (FileInfo foundFile in filesInDir)
            {
                string fullName = foundFile.FullName;
                gameName = Path.GetFileNameWithoutExtension(fullName);

                cbGames.Items.Add(gameName.Substring(5, gameName.Length - 5));
                gamesLoaded = true;
            }

            if (gamesLoaded)
                cbGames.Enabled = true;

            return gamesLoaded;
        }

        // computer the hash of the passed string
        private string ComputerStrHash(string checkSumStr)
        {
            string hash;
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                hash = BitConverter.ToString(
                  md5.ComputeHash(Encoding.UTF8.GetBytes(checkSumStr))
                ).Replace("-", String.Empty);
            }

            return hash;
        }

        // Delete a game. Return null if OK otherwise the error message
        private string DeleteGame(string GameName)
        {
            DirectoryInfo gameDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + dirGameState);
            var fileName = Path.Combine(gameDir.ToString(), ("Game_" + GameName + ".txt"));

            try
            {
                // Check if file exists with its full path    
                if (File.Exists(fileName))
                    File.Delete(fileName);
                else
                    return "File not found";
            }
            catch (IOException ioExp)
            {
                return ioExp.Message;
            }

            return "";
        }

        // Read in the game that was previously saved
        // There is no need to perform any checks as the Save options saves a true representation of all 
        private bool LoadGame(string GameName)
        {
            string checkSumString = "";
            string fileHash = "";
            string ctrlName;
             
            string line;
            int counter = -1;

            TextBox tb = null;
            ComboBox cb = null;
            NumericUpDown nud = null;

            bool success = true;
            DirectoryInfo gameDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + dirGameState);
            var fileName = Path.Combine(gameDir.ToString(), ("Game_" + GameName + ".txt"));

            // reset the game state
            initialize();

            using (StreamReader file = new StreamReader(fileName))
            {
                try
                {
                    while ((line = file.ReadLine()) != null && counter < 7)
                    {
                        ++counter;
                        // last line is the file hash
                        if (counter == 6)
                        {
                            fileHash = line;
                            if (ComputerStrHash(checkSumString) != fileHash)
                                success = false;
                        }
                        else
                        {
                            checkSumString += line;
                            // add the string to the checkSumString to ensure the file has not been tampered with
                            string[] player = line.Split('\t');
                            gamePosition[counter] = Convert.ToInt32(player[0]);

                            ctrlName = "txtP" + counter.ToString();
                            Control[] matches = this.Controls.Find(ctrlName, true);
                            if (matches.Length > 0 && matches[0] is TextBox)
                            {
                                tb = (TextBox)matches[0];
                                tb.Text = player[1];
                                tb.Enabled = false;
                            }

                            if (tb.Text != "")
                            {
                                ctrlName = "cbAvatarP" + counter.ToString();
                                Control[] matches2 = this.Controls.Find(ctrlName, true);
                                if (matches2.Length > 0 && matches2[0] is ComboBox)
                                {
                                    cb = (ComboBox)matches2[0];
                                    cb.SelectedIndex = cb.FindString(player[2]);
                                    cb.Enabled = false;
                                }

                                // enable to numeric up down control
                                ctrlName = "nudP" + counter.ToString();
                                Control[] matches3 = this.Controls.Find(ctrlName, true);
                                if (matches3.Length > 0 && matches3[0] is NumericUpDown)
                                {
                                    nud = (NumericUpDown)matches3[0];
                                    nud.Enabled = true;
                                }

                                activePlayer[counter] = true;
                            }
                            else
                            {
                                ctrlName = "cbAvatarP" + counter.ToString();
                                Control[] matches2 = this.Controls.Find(ctrlName, true);
                                if (matches2.Length > 0 && matches2[0] is ComboBox)
                                {
                                    cb = (ComboBox)matches2[0];
                                    cb.SelectedIndex = -1;
                                    cb.Enabled = false;
                                }

                                // enable to numeric up down control
                                ctrlName = "nudP" + counter.ToString();
                                Control[] matches3 = this.Controls.Find(ctrlName, true);
                                if (matches3.Length > 0 && matches3[0] is NumericUpDown)
                                {
                                    nud = (NumericUpDown)matches3[0];
                                    nud.Enabled = false;
                                }

                                activePlayer[counter] = false;
                            }

                            iBeforeXP[counter] = Convert.ToInt32(player[3]);
                            iBeforeYP[counter] = Convert.ToInt32(player[4]);
                            avatarUser[counter] = player[5].StringToImage();
                        }
                    }
                }
                catch (IOException ex)
                {
                    return false;
                }
                finally
                {
                    if (file != null)
                        file.Dispose();
                }
            }

            // If this is an active player draw the avatar ont the board
            for (int i = 0; i < 6; i++)
            {
                if (activePlayer[i])
                {
                    if (gamePosition[i] > 0)
                    {
                        drawAvatar(iBeforeXP[i], iBeforeYP[i]);
                    }
                }
            }
            return success;
        }

        // returns a null string if the game is setup correctly otherwise it will return the error message.
        // This function does not check whether the spinneretts are setup correctly 
        // 
        // Do not use ActivePlayers here are this property is not defined int he SaveGame function which shares this module
        //
        private string GameSetupCorrectly()
        {
            Control[] matches;
            Control[] matches2;
            TextBox tb = null; ;
            ComboBox cb;
            string errTxt = "";
            byte playerCnt = 0;

            // check that at least two controls are filled in
            string ctrlName;
            for (int i = 0; i < 6; i++)
            {
                ctrlName = "txtP" + i.ToString();
                matches = this.Controls.Find(ctrlName, true);
                if (matches.Length > 0 && matches[0] is TextBox)
                {
                    tb = (TextBox)matches[0];
                    tb.Text = tb.Text.Trim();
                    if (tb.Text != "")
                    {
                        playerCnt++;

                        // A player is defined. Check that he has an avatar
                        ctrlName = "cbAvatarP" + i.ToString();
                        matches2 = this.Controls.Find(ctrlName, true);
                        if (matches2.Length > 0 && matches2[0] is ComboBox)
                        {
                            cb = (ComboBox)matches2[0];
                            if (cb.SelectedIndex <= -1)
                            {
                                if (errTxt != "")
                                    errTxt += "\n";
                                errTxt += "Game Piece for player " + (i + 1).ToString() + "not selected";
                            }
                        }
                    }
                }
            }
            if (playerCnt < 2)
            {
                if (errTxt != "")
                    errTxt += "\n";
                errTxt += "At least two players must be defined\n";
            }

            return errTxt;

        }

        private void NewGame()
        {
            string ctrlName;

            txtGameName.Enabled = true;

            for (int i = 0; i < 6; i++)
            {
                ctrlName = "txtP" + i.ToString();
                Control[] matches = this.Controls.Find(ctrlName, true);
                if (matches.Length > 0 && matches[0] is TextBox)
                {
                    TextBox tb = (TextBox)matches[0];
                    tb.Enabled = true;
                }

                ctrlName = "cbAvatarP" + i.ToString();
                Control[] matches2 = this.Controls.Find(ctrlName, true);
                if (matches2.Length > 0 && matches2[0] is ComboBox)
                {
                    ComboBox cb = (ComboBox)matches2[0];
                    cb.Enabled = true;
                }

                // enable to numeric up down control
                ctrlName = "nudP" + i.ToString();
                Control[] matches3 = this.Controls.Find(ctrlName, true);
                if (matches3.Length > 0 && matches3[0] is NumericUpDown)
                {
                    NumericUpDown nud = (NumericUpDown)matches3[0];
                    nud.Enabled = true;
                }
            }
        }

        // Attempt to read in the file
        private string SaveGame(string GameName)
        {
            Control[] matches;
            Control[] matches2;
            TextBox tb = null; 
            ComboBox cb;
            string errTxt = "";
            string checkSumString = "";
            string fileHash = "";
            string gamePiece = "";
            string ctrlName;
            string line;
            

            errTxt = GameSetupCorrectly();

            // Do not save it there is an error
            if (errTxt != "")
                return errTxt;

            // All OK. Save Game computer checksum
            DirectoryInfo gameDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + dirGameState);
            var fileName = Path.Combine(gameDir.ToString(), ("Game_" + GameName + ".txt"));

            // If the file exists delete it
            try
            {
                // Check if file exists with its full path    
                if (File.Exists(fileName))
                    File.Delete(fileName);
            }
            catch (IOException ioExp)
            {
                return "Delete file: " + ioExp.Message;
            }


            using (StreamWriter file = new StreamWriter(fileName))
            {
                try
                {
                    for (int i = 0; i < 6; i++)
                    {
                        ctrlName = "txtP" + i.ToString();
                        matches = this.Controls.Find(ctrlName, true);
                        if (matches.Length > 0 && matches[0] is TextBox)
                        {
                            tb = (TextBox)matches[0];
                        }

                        // if a username is not defined erase any avatar that might have been set and any score
                        if (tb.Text == "")
                        {
                            gamePiece = "";
                            gamePosition[i] = 0;
                        }
                        else
                        {
                            ctrlName = "cbAvatarP" + i.ToString();
                            matches2 = this.Controls.Find(ctrlName, true);
                            if (matches2.Length > 0 && matches2[0] is ComboBox)
                            {
                                cb = (ComboBox)matches2[0];
                                if (cb.SelectedIndex > -1)
                                {
                                    gamePiece = cb.Items[cb.SelectedIndex].ToString();

                                    // Load the Avatar in memory
                                    DirectoryInfo GamePieceDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + dirGamePiece);
                                    var fileGamePiece = Path.Combine(GamePieceDir.ToString(), (cb.Items[cb.SelectedIndex].ToString() + ".png"));
                                    avatarUser[i] = Image.FromFile(fileGamePiece);
                                }
                                else
                                {
                                    gamePiece = "";
                                }
                            }
                        }

                        line = gamePosition[i].ToString() + "\t" + tb.Text + "\t" + gamePiece + "\t" + iBeforeXP[i].ToString() + "\t" + iBeforeYP[i].ToString() + "\t" + avatarUser[i].ImageToString();
                        file.WriteLine(line);
                        checkSumString += line;
                    }

                    // Compute the hash and add it to the file
                    fileHash = ComputerStrHash(checkSumString);
                    file.WriteLine(fileHash);

                    file.Close();
                }
                catch (IOException ioExp)
                {
                    return "Create file: " + ioExp.Message;
                }
                finally
                {
                    if (file != null)
                        file.Dispose();
                }
            }
            return errTxt;
        }

        // this function return the next player or -999 if there are no more dice plays possible
        // it also updates the spinerette of the user
        private int GetNextPlayer(int LastPlayer)
        {
            NumericUpDown nud = null;
            string ctrlName;
            byte tries = 0;

            // increment the next player
            int NextPlayer = ++LastPlayer;

            while (tries++ < 7)
            {
                if (NextPlayer > 5)
                    NextPlayer = 0;
                if (activePlayer[NextPlayer])
                {
                    // enable to numeric up down control
                    ctrlName = "nudP" + NextPlayer.ToString();
                    Control[] matches3 = this.Controls.Find(ctrlName, true);
                    if (matches3.Length > 0 && matches3[0] is NumericUpDown)
                    {
                        nud = (NumericUpDown)matches3[0];
                        if (nud.Value > 0)
                        {
                            --nud.Value;
                            return NextPlayer;
                        }
                        else
                        {
                            ++NextPlayer;
                        }
                    }

                }
                else
                    ++NextPlayer;
            }

            // there are no gameplay left
            return -999;

        }
        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}