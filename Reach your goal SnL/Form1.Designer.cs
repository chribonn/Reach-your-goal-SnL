namespace Snakes_and_Ladders
{
    partial class FormReachYourGoalSnL
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReachYourGoalSnL));
            this.pbDisplay = new System.Windows.Forms.PictureBox();
            this.btnRoll = new System.Windows.Forms.Button();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.pbGamePiece = new System.Windows.Forms.PictureBox();
            this.pbDice = new System.Windows.Forms.PictureBox();
            this.pbLogos = new System.Windows.Forms.PictureBox();
            this.timerWait = new System.Windows.Forms.Timer(this.components);
            this.timerMoveCounter = new System.Windows.Forms.Timer(this.components);
            this.timerRoll = new System.Windows.Forms.Timer(this.components);
            this.rtbInstruct = new System.Windows.Forms.RichTextBox();
            this.panelAvatar = new System.Windows.Forms.Panel();
            this.btnDelGame = new System.Windows.Forms.Button();
            this.btnPlayRound = new System.Windows.Forms.Button();
            this.txtP4 = new System.Windows.Forms.TextBox();
            this.txtP5 = new System.Windows.Forms.TextBox();
            this.nudP5 = new System.Windows.Forms.NumericUpDown();
            this.nudP4 = new System.Windows.Forms.NumericUpDown();
            this.nudP3 = new System.Windows.Forms.NumericUpDown();
            this.nudP2 = new System.Windows.Forms.NumericUpDown();
            this.nudP1 = new System.Windows.Forms.NumericUpDown();
            this.nudP0 = new System.Windows.Forms.NumericUpDown();
            this.lblDiceRolls = new System.Windows.Forms.Label();
            this.txtGameName = new System.Windows.Forms.TextBox();
            this.btnSaveGame = new System.Windows.Forms.Button();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnLoadGame = new System.Windows.Forms.Button();
            this.cbGames = new System.Windows.Forms.ComboBox();
            this.lblP6 = new System.Windows.Forms.Label();
            this.cbAvatarP5 = new System.Windows.Forms.ComboBox();
            this.lblP5 = new System.Windows.Forms.Label();
            this.cbAvatarP4 = new System.Windows.Forms.ComboBox();
            this.lblP4 = new System.Windows.Forms.Label();
            this.cbAvatarP3 = new System.Windows.Forms.ComboBox();
            this.txtP3 = new System.Windows.Forms.TextBox();
            this.lblP3 = new System.Windows.Forms.Label();
            this.cbAvatarP2 = new System.Windows.Forms.ComboBox();
            this.txtP2 = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblP2 = new System.Windows.Forms.Label();
            this.lblP1 = new System.Windows.Forms.Label();
            this.cbAvatarP1 = new System.Windows.Forms.ComboBox();
            this.txtP1 = new System.Windows.Forms.TextBox();
            this.lblGamePiece = new System.Windows.Forms.Label();
            this.cbAvatarP0 = new System.Windows.Forms.ComboBox();
            this.txtP0 = new System.Windows.Forms.TextBox();
            this.llQuit = new System.Windows.Forms.LinkLabel();
            this.timerUpLadderDownSnake = new System.Windows.Forms.Timer(this.components);
            this.llAbout = new System.Windows.Forms.LinkLabel();
            this.linkRestart = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbDisplay)).BeginInit();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGamePiece)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogos)).BeginInit();
            this.panelAvatar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudP5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudP4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudP3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudP2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudP1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudP0)).BeginInit();
            this.SuspendLayout();
            // 
            // pbDisplay
            // 
            this.pbDisplay.BackColor = System.Drawing.Color.White;
            this.pbDisplay.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbDisplay.InitialImage")));
            this.pbDisplay.Location = new System.Drawing.Point(623, 15);
            this.pbDisplay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbDisplay.Name = "pbDisplay";
            this.pbDisplay.Size = new System.Drawing.Size(827, 763);
            this.pbDisplay.TabIndex = 0;
            this.pbDisplay.TabStop = false;
            this.pbDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.pbDisplay_Paint);
            // 
            // btnRoll
            // 
            this.btnRoll.Location = new System.Drawing.Point(28, 615);
            this.btnRoll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRoll.Name = "btnRoll";
            this.btnRoll.Size = new System.Drawing.Size(533, 47);
            this.btnRoll.TabIndex = 2;
            this.btnRoll.Text = "Roll";
            this.btnRoll.UseVisualStyleBackColor = true;
            this.btnRoll.Click += new System.EventHandler(this.btnRoll_Click);
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction.Location = new System.Drawing.Point(120, 748);
            this.lblInstruction.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(0, 29);
            this.lblInstruction.TabIndex = 4;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMain.Controls.Add(this.pbGamePiece);
            this.panelMain.Controls.Add(this.pbDice);
            this.panelMain.Location = new System.Drawing.Point(28, 369);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(532, 166);
            this.panelMain.TabIndex = 5;
            // 
            // pbGamePiece
            // 
            this.pbGamePiece.BackColor = System.Drawing.Color.Transparent;
            this.pbGamePiece.Location = new System.Drawing.Point(95, 17);
            this.pbGamePiece.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbGamePiece.Name = "pbGamePiece";
            this.pbGamePiece.Size = new System.Drawing.Size(147, 135);
            this.pbGamePiece.TabIndex = 5;
            this.pbGamePiece.TabStop = false;
            // 
            // pbDice
            // 
            this.pbDice.BackColor = System.Drawing.Color.White;
            this.pbDice.Location = new System.Drawing.Point(281, 39);
            this.pbDice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbDice.Name = "pbDice";
            this.pbDice.Size = new System.Drawing.Size(93, 86);
            this.pbDice.TabIndex = 4;
            this.pbDice.TabStop = false;
            // 
            // pbLogos
            // 
            this.pbLogos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbLogos.BackgroundImage")));
            this.pbLogos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbLogos.Image = ((System.Drawing.Image)(resources.GetObject("pbLogos.Image")));
            this.pbLogos.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbLogos.InitialImage")));
            this.pbLogos.Location = new System.Drawing.Point(4, 15);
            this.pbLogos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbLogos.Name = "pbLogos";
            this.pbLogos.Size = new System.Drawing.Size(596, 204);
            this.pbLogos.TabIndex = 6;
            this.pbLogos.TabStop = false;
            // 
            // timerWait
            // 
            this.timerWait.Interval = 500;
            this.timerWait.Tick += new System.EventHandler(this.timerWait_Tick);
            // 
            // timerMoveCounter
            // 
            this.timerMoveCounter.Interval = 200;
            this.timerMoveCounter.Tick += new System.EventHandler(this.timerMoveCounter_Tick);
            // 
            // timerRoll
            // 
            this.timerRoll.Tick += new System.EventHandler(this.timerRoll_Tick);
            // 
            // rtbInstruct
            // 
            this.rtbInstruct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rtbInstruct.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbInstruct.Location = new System.Drawing.Point(741, 228);
            this.rtbInstruct.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtbInstruct.Name = "rtbInstruct";
            this.rtbInstruct.Size = new System.Drawing.Size(567, 384);
            this.rtbInstruct.TabIndex = 9;
            this.rtbInstruct.Text = resources.GetString("rtbInstruct.Text");
            // 
            // panelAvatar
            // 
            this.panelAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panelAvatar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelAvatar.Controls.Add(this.btnDelGame);
            this.panelAvatar.Controls.Add(this.btnPlayRound);
            this.panelAvatar.Controls.Add(this.txtP4);
            this.panelAvatar.Controls.Add(this.txtP5);
            this.panelAvatar.Controls.Add(this.nudP5);
            this.panelAvatar.Controls.Add(this.nudP4);
            this.panelAvatar.Controls.Add(this.nudP3);
            this.panelAvatar.Controls.Add(this.nudP2);
            this.panelAvatar.Controls.Add(this.nudP1);
            this.panelAvatar.Controls.Add(this.nudP0);
            this.panelAvatar.Controls.Add(this.lblDiceRolls);
            this.panelAvatar.Controls.Add(this.txtGameName);
            this.panelAvatar.Controls.Add(this.btnSaveGame);
            this.panelAvatar.Controls.Add(this.btnNewGame);
            this.panelAvatar.Controls.Add(this.btnLoadGame);
            this.panelAvatar.Controls.Add(this.cbGames);
            this.panelAvatar.Controls.Add(this.lblP6);
            this.panelAvatar.Controls.Add(this.cbAvatarP5);
            this.panelAvatar.Controls.Add(this.lblP5);
            this.panelAvatar.Controls.Add(this.cbAvatarP4);
            this.panelAvatar.Controls.Add(this.lblP4);
            this.panelAvatar.Controls.Add(this.cbAvatarP3);
            this.panelAvatar.Controls.Add(this.txtP3);
            this.panelAvatar.Controls.Add(this.lblP3);
            this.panelAvatar.Controls.Add(this.cbAvatarP2);
            this.panelAvatar.Controls.Add(this.txtP2);
            this.panelAvatar.Controls.Add(this.lblName);
            this.panelAvatar.Controls.Add(this.lblP2);
            this.panelAvatar.Controls.Add(this.lblP1);
            this.panelAvatar.Controls.Add(this.cbAvatarP1);
            this.panelAvatar.Controls.Add(this.txtP1);
            this.panelAvatar.Controls.Add(this.lblGamePiece);
            this.panelAvatar.Controls.Add(this.cbAvatarP0);
            this.panelAvatar.Controls.Add(this.txtP0);
            this.panelAvatar.Location = new System.Drawing.Point(4, 235);
            this.panelAvatar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelAvatar.Name = "panelAvatar";
            this.panelAvatar.Size = new System.Drawing.Size(595, 495);
            this.panelAvatar.TabIndex = 10;
            // 
            // btnDelGame
            // 
            this.btnDelGame.Location = new System.Drawing.Point(449, 21);
            this.btnDelGame.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelGame.Name = "btnDelGame";
            this.btnDelGame.Size = new System.Drawing.Size(123, 28);
            this.btnDelGame.TabIndex = 3;
            this.btnDelGame.Text = "Delete Game";
            this.btnDelGame.UseVisualStyleBackColor = true;
            this.btnDelGame.Click += new System.EventHandler(this.btnDelGame_Click);
            // 
            // btnPlayRound
            // 
            this.btnPlayRound.Location = new System.Drawing.Point(108, 459);
            this.btnPlayRound.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPlayRound.Name = "btnPlayRound";
            this.btnPlayRound.Size = new System.Drawing.Size(369, 28);
            this.btnPlayRound.TabIndex = 25;
            this.btnPlayRound.Text = "PlayRound";
            this.btnPlayRound.UseVisualStyleBackColor = true;
            this.btnPlayRound.Click += new System.EventHandler(this.btnPlayRound_Click);
            // 
            // txtP4
            // 
            this.txtP4.Enabled = false;
            this.txtP4.Location = new System.Drawing.Point(108, 329);
            this.txtP4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtP4.Name = "txtP4";
            this.txtP4.Size = new System.Drawing.Size(132, 22);
            this.txtP4.TabIndex = 18;
            // 
            // txtP5
            // 
            this.txtP5.Enabled = false;
            this.txtP5.Location = new System.Drawing.Point(108, 377);
            this.txtP5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtP5.Name = "txtP5";
            this.txtP5.Size = new System.Drawing.Size(132, 22);
            this.txtP5.TabIndex = 21;
            // 
            // nudP5
            // 
            this.nudP5.Enabled = false;
            this.nudP5.Location = new System.Drawing.Point(431, 380);
            this.nudP5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudP5.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudP5.Name = "nudP5";
            this.nudP5.Size = new System.Drawing.Size(121, 22);
            this.nudP5.TabIndex = 23;
            // 
            // nudP4
            // 
            this.nudP4.Enabled = false;
            this.nudP4.Location = new System.Drawing.Point(431, 330);
            this.nudP4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudP4.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudP4.Name = "nudP4";
            this.nudP4.Size = new System.Drawing.Size(121, 22);
            this.nudP4.TabIndex = 20;
            // 
            // nudP3
            // 
            this.nudP3.Enabled = false;
            this.nudP3.Location = new System.Drawing.Point(431, 283);
            this.nudP3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudP3.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudP3.Name = "nudP3";
            this.nudP3.Size = new System.Drawing.Size(121, 22);
            this.nudP3.TabIndex = 17;
            // 
            // nudP2
            // 
            this.nudP2.Enabled = false;
            this.nudP2.Location = new System.Drawing.Point(431, 239);
            this.nudP2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudP2.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudP2.Name = "nudP2";
            this.nudP2.Size = new System.Drawing.Size(121, 22);
            this.nudP2.TabIndex = 14;
            // 
            // nudP1
            // 
            this.nudP1.Enabled = false;
            this.nudP1.Location = new System.Drawing.Point(431, 196);
            this.nudP1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudP1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudP1.Name = "nudP1";
            this.nudP1.Size = new System.Drawing.Size(121, 22);
            this.nudP1.TabIndex = 11;
            // 
            // nudP0
            // 
            this.nudP0.Enabled = false;
            this.nudP0.Location = new System.Drawing.Point(431, 148);
            this.nudP0.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudP0.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudP0.Name = "nudP0";
            this.nudP0.Size = new System.Drawing.Size(121, 22);
            this.nudP0.TabIndex = 8;
            // 
            // lblDiceRolls
            // 
            this.lblDiceRolls.AutoSize = true;
            this.lblDiceRolls.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiceRolls.Location = new System.Drawing.Point(444, 114);
            this.lblDiceRolls.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiceRolls.Name = "lblDiceRolls";
            this.lblDiceRolls.Size = new System.Drawing.Size(91, 25);
            this.lblDiceRolls.TabIndex = 53;
            this.lblDiceRolls.Text = "Dice rolls";
            // 
            // txtGameName
            // 
            this.txtGameName.Enabled = false;
            this.txtGameName.Location = new System.Drawing.Point(300, 69);
            this.txtGameName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGameName.Name = "txtGameName";
            this.txtGameName.Size = new System.Drawing.Size(197, 22);
            this.txtGameName.TabIndex = 5;
            // 
            // btnSaveGame
            // 
            this.btnSaveGame.Location = new System.Drawing.Point(108, 423);
            this.btnSaveGame.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveGame.Name = "btnSaveGame";
            this.btnSaveGame.Size = new System.Drawing.Size(369, 28);
            this.btnSaveGame.TabIndex = 24;
            this.btnSaveGame.Text = "Save Game";
            this.btnSaveGame.UseVisualStyleBackColor = true;
            this.btnSaveGame.Click += new System.EventHandler(this.btnSaveGame_Click);
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(43, 69);
            this.btnNewGame.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(199, 28);
            this.btnNewGame.TabIndex = 4;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // btnLoadGame
            // 
            this.btnLoadGame.Location = new System.Drawing.Point(300, 21);
            this.btnLoadGame.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoadGame.Name = "btnLoadGame";
            this.btnLoadGame.Size = new System.Drawing.Size(123, 28);
            this.btnLoadGame.TabIndex = 2;
            this.btnLoadGame.Text = "Load Game";
            this.btnLoadGame.UseVisualStyleBackColor = true;
            this.btnLoadGame.Click += new System.EventHandler(this.btnLoadGame_Click);
            // 
            // cbGames
            // 
            this.cbGames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGames.Enabled = false;
            this.cbGames.FormattingEnabled = true;
            this.cbGames.Location = new System.Drawing.Point(43, 23);
            this.cbGames.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbGames.Name = "cbGames";
            this.cbGames.Size = new System.Drawing.Size(197, 24);
            this.cbGames.TabIndex = 1;
            // 
            // lblP6
            // 
            this.lblP6.AutoSize = true;
            this.lblP6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP6.Location = new System.Drawing.Point(13, 377);
            this.lblP6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblP6.Name = "lblP6";
            this.lblP6.Size = new System.Drawing.Size(83, 25);
            this.lblP6.TabIndex = 50;
            this.lblP6.Text = "Player 6";
            // 
            // cbAvatarP5
            // 
            this.cbAvatarP5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAvatarP5.Enabled = false;
            this.cbAvatarP5.FormattingEnabled = true;
            this.cbAvatarP5.Location = new System.Drawing.Point(267, 375);
            this.cbAvatarP5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbAvatarP5.Name = "cbAvatarP5";
            this.cbAvatarP5.Size = new System.Drawing.Size(131, 24);
            this.cbAvatarP5.TabIndex = 22;
            // 
            // lblP5
            // 
            this.lblP5.AutoSize = true;
            this.lblP5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP5.Location = new System.Drawing.Point(13, 326);
            this.lblP5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblP5.Name = "lblP5";
            this.lblP5.Size = new System.Drawing.Size(83, 25);
            this.lblP5.TabIndex = 43;
            this.lblP5.Text = "Player 5";
            // 
            // cbAvatarP4
            // 
            this.cbAvatarP4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAvatarP4.Enabled = false;
            this.cbAvatarP4.FormattingEnabled = true;
            this.cbAvatarP4.Location = new System.Drawing.Point(267, 327);
            this.cbAvatarP4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbAvatarP4.Name = "cbAvatarP4";
            this.cbAvatarP4.Size = new System.Drawing.Size(131, 24);
            this.cbAvatarP4.TabIndex = 19;
            // 
            // lblP4
            // 
            this.lblP4.AutoSize = true;
            this.lblP4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP4.Location = new System.Drawing.Point(13, 279);
            this.lblP4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblP4.Name = "lblP4";
            this.lblP4.Size = new System.Drawing.Size(83, 25);
            this.lblP4.TabIndex = 40;
            this.lblP4.Text = "Player 4";
            // 
            // cbAvatarP3
            // 
            this.cbAvatarP3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAvatarP3.Enabled = false;
            this.cbAvatarP3.FormattingEnabled = true;
            this.cbAvatarP3.Location = new System.Drawing.Point(267, 281);
            this.cbAvatarP3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbAvatarP3.Name = "cbAvatarP3";
            this.cbAvatarP3.Size = new System.Drawing.Size(131, 24);
            this.cbAvatarP3.TabIndex = 16;
            // 
            // txtP3
            // 
            this.txtP3.Enabled = false;
            this.txtP3.Location = new System.Drawing.Point(108, 282);
            this.txtP3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtP3.Name = "txtP3";
            this.txtP3.Size = new System.Drawing.Size(132, 22);
            this.txtP3.TabIndex = 15;
            // 
            // lblP3
            // 
            this.lblP3.AutoSize = true;
            this.lblP3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP3.Location = new System.Drawing.Point(13, 235);
            this.lblP3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblP3.Name = "lblP3";
            this.lblP3.Size = new System.Drawing.Size(83, 25);
            this.lblP3.TabIndex = 37;
            this.lblP3.Text = "Player 3";
            // 
            // cbAvatarP2
            // 
            this.cbAvatarP2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAvatarP2.Enabled = false;
            this.cbAvatarP2.FormattingEnabled = true;
            this.cbAvatarP2.Location = new System.Drawing.Point(267, 236);
            this.cbAvatarP2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbAvatarP2.Name = "cbAvatarP2";
            this.cbAvatarP2.Size = new System.Drawing.Size(131, 24);
            this.cbAvatarP2.TabIndex = 13;
            // 
            // txtP2
            // 
            this.txtP2.Enabled = false;
            this.txtP2.Location = new System.Drawing.Point(108, 238);
            this.txtP2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtP2.Name = "txtP2";
            this.txtP2.Size = new System.Drawing.Size(132, 22);
            this.txtP2.TabIndex = 12;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(121, 114);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(64, 25);
            this.lblName.TabIndex = 34;
            this.lblName.Text = "Name";
            // 
            // lblP2
            // 
            this.lblP2.AutoSize = true;
            this.lblP2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP2.Location = new System.Drawing.Point(13, 193);
            this.lblP2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblP2.Name = "lblP2";
            this.lblP2.Size = new System.Drawing.Size(83, 25);
            this.lblP2.TabIndex = 33;
            this.lblP2.Text = "Player 2";
            // 
            // lblP1
            // 
            this.lblP1.AutoSize = true;
            this.lblP1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP1.Location = new System.Drawing.Point(13, 149);
            this.lblP1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblP1.Name = "lblP1";
            this.lblP1.Size = new System.Drawing.Size(83, 25);
            this.lblP1.TabIndex = 32;
            this.lblP1.Text = "Player 1";
            // 
            // cbAvatarP1
            // 
            this.cbAvatarP1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAvatarP1.Enabled = false;
            this.cbAvatarP1.FormattingEnabled = true;
            this.cbAvatarP1.Location = new System.Drawing.Point(267, 194);
            this.cbAvatarP1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbAvatarP1.Name = "cbAvatarP1";
            this.cbAvatarP1.Size = new System.Drawing.Size(131, 24);
            this.cbAvatarP1.TabIndex = 10;
            // 
            // txtP1
            // 
            this.txtP1.Enabled = false;
            this.txtP1.Location = new System.Drawing.Point(108, 196);
            this.txtP1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtP1.Name = "txtP1";
            this.txtP1.Size = new System.Drawing.Size(132, 22);
            this.txtP1.TabIndex = 9;
            // 
            // lblGamePiece
            // 
            this.lblGamePiece.AutoSize = true;
            this.lblGamePiece.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGamePiece.Location = new System.Drawing.Point(267, 114);
            this.lblGamePiece.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGamePiece.Name = "lblGamePiece";
            this.lblGamePiece.Size = new System.Drawing.Size(117, 25);
            this.lblGamePiece.TabIndex = 24;
            this.lblGamePiece.Text = "Game piece";
            // 
            // cbAvatarP0
            // 
            this.cbAvatarP0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAvatarP0.Enabled = false;
            this.cbAvatarP0.FormattingEnabled = true;
            this.cbAvatarP0.Location = new System.Drawing.Point(267, 148);
            this.cbAvatarP0.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbAvatarP0.Name = "cbAvatarP0";
            this.cbAvatarP0.Size = new System.Drawing.Size(131, 24);
            this.cbAvatarP0.TabIndex = 7;
            // 
            // txtP0
            // 
            this.txtP0.Enabled = false;
            this.txtP0.Location = new System.Drawing.Point(108, 149);
            this.txtP0.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtP0.Name = "txtP0";
            this.txtP0.Size = new System.Drawing.Size(132, 22);
            this.txtP0.TabIndex = 6;
            // 
            // llQuit
            // 
            this.llQuit.AutoSize = true;
            this.llQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llQuit.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llQuit.LinkColor = System.Drawing.Color.Black;
            this.llQuit.Location = new System.Drawing.Point(1367, 786);
            this.llQuit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llQuit.Name = "llQuit";
            this.llQuit.Size = new System.Drawing.Size(48, 25);
            this.llQuit.TabIndex = 100;
            this.llQuit.TabStop = true;
            this.llQuit.Text = "Quit";
            this.llQuit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llQuit_LinkClicked);
            // 
            // timerUpLadderDownSnake
            // 
            this.timerUpLadderDownSnake.Interval = 10;
            this.timerUpLadderDownSnake.Tick += new System.EventHandler(this.timerUpLadderDownSnake_Tick);
            // 
            // llAbout
            // 
            this.llAbout.AutoSize = true;
            this.llAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llAbout.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llAbout.LinkColor = System.Drawing.Color.Black;
            this.llAbout.Location = new System.Drawing.Point(1012, 786);
            this.llAbout.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llAbout.Name = "llAbout";
            this.llAbout.Size = new System.Drawing.Size(64, 25);
            this.llAbout.TabIndex = 101;
            this.llAbout.TabStop = true;
            this.llAbout.Text = "About";
            this.llAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llAbout_LinkClicked);
            // 
            // linkRestart
            // 
            this.linkRestart.AutoSize = true;
            this.linkRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkRestart.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkRestart.LinkColor = System.Drawing.Color.Black;
            this.linkRestart.Location = new System.Drawing.Point(1185, 786);
            this.linkRestart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkRestart.Name = "linkRestart";
            this.linkRestart.Size = new System.Drawing.Size(73, 25);
            this.linkRestart.TabIndex = 102;
            this.linkRestart.TabStop = true;
            this.linkRestart.Text = "Restart";
            this.linkRestart.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRestart_LinkClicked);
            // 
            // FormReachYourGoalSnL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(182)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(1465, 821);
            this.Controls.Add(this.linkRestart);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.btnRoll);
            this.Controls.Add(this.llAbout);
            this.Controls.Add(this.llQuit);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.pbLogos);
            this.Controls.Add(this.rtbInstruct);
            this.Controls.Add(this.panelAvatar);
            this.Controls.Add(this.pbDisplay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(1483, 869);
            this.Name = "FormReachYourGoalSnL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reach your goal SnL by ACB";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormReachyourgoalSnL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbDisplay)).EndInit();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbGamePiece)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogos)).EndInit();
            this.panelAvatar.ResumeLayout(false);
            this.panelAvatar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudP5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudP4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudP3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudP2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudP1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudP0)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbDisplay;
        private System.Windows.Forms.Button btnRoll;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.PictureBox pbLogos;
        private System.Windows.Forms.Timer timerWait;
        private System.Windows.Forms.Timer timerMoveCounter;
        private System.Windows.Forms.Timer timerRoll;
        private System.Windows.Forms.RichTextBox rtbInstruct;
        private System.Windows.Forms.Panel panelAvatar;
        private System.Windows.Forms.PictureBox pbDice;
        private System.Windows.Forms.Label lblP2;
        private System.Windows.Forms.Label lblP1;
        private System.Windows.Forms.ComboBox cbAvatarP1;
        private System.Windows.Forms.TextBox txtP1;
        private System.Windows.Forms.Label lblGamePiece;
        private System.Windows.Forms.ComboBox cbAvatarP0;
        private System.Windows.Forms.TextBox txtP0;
        private System.Windows.Forms.LinkLabel llQuit;
        private System.Windows.Forms.Timer timerUpLadderDownSnake;
        private System.Windows.Forms.ComboBox cbAvatarP5;
        private System.Windows.Forms.TextBox txtP5;
        private System.Windows.Forms.Label lblP5;
        private System.Windows.Forms.ComboBox cbAvatarP4;
        private System.Windows.Forms.TextBox txtP4;
        private System.Windows.Forms.Label lblP4;
        private System.Windows.Forms.ComboBox cbAvatarP3;
        private System.Windows.Forms.TextBox txtP3;
        private System.Windows.Forms.Label lblP3;
        private System.Windows.Forms.ComboBox cbAvatarP2;
        private System.Windows.Forms.TextBox txtP2;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnLoadGame;
        private System.Windows.Forms.ComboBox cbGames;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Label lblP6;
        private System.Windows.Forms.Button btnSaveGame;
        private System.Windows.Forms.LinkLabel llAbout;
        private System.Windows.Forms.TextBox txtGameName;
        private System.Windows.Forms.Button btnPlayRound;
        private System.Windows.Forms.NumericUpDown nudP5;
        private System.Windows.Forms.NumericUpDown nudP4;
        private System.Windows.Forms.NumericUpDown nudP3;
        private System.Windows.Forms.NumericUpDown nudP2;
        private System.Windows.Forms.NumericUpDown nudP1;
        private System.Windows.Forms.NumericUpDown nudP0;
        private System.Windows.Forms.Label lblDiceRolls;
        private System.Windows.Forms.Button btnDelGame;
        private System.Windows.Forms.LinkLabel linkRestart;
        private System.Windows.Forms.PictureBox pbGamePiece;
    }
}

