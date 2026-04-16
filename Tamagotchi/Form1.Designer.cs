namespace Tamagotchi // Groups all classes under the Tamagotchi namespace
{
    // Partial class: Form1 is split into two files (Designer + logic)
    partial class Form1 // This part contains only the UI layout code
    {
        // Container for components. Used by the Dispose method
        private System.ComponentModel.IContainer components = null; // Starts as null

        // Dispose method. Cleans up resources when the form closes
        protected override void Dispose(bool disposing) // Called when the form is closing
        {
            if (disposing && (components != null)) // If we are disposing and components exist...
            {
                components.Dispose(); // ...dispose of them to free memory
            }
            base.Dispose(disposing); // Calls the base class Dispose method
        }

        #region Windows Form Designer generated code

        // This method creates and positions all controls on the form
        private void InitializeComponent() // Called in the Form1 constructor
        {
            grpSetup = new System.Windows.Forms.GroupBox();
            lblNamePrompt = new System.Windows.Forms.Label();
            txtName = new System.Windows.Forms.TextBox();
            rbDuck = new System.Windows.Forms.RadioButton();
            rbBunny = new System.Windows.Forms.RadioButton();
            rbKitten = new System.Windows.Forms.RadioButton();
            btnCreate = new System.Windows.Forms.Button();
            pnlGame = new System.Windows.Forms.Panel();
            picPet = new System.Windows.Forms.PictureBox();
            lblPetName = new System.Windows.Forms.Label();
            lblSpecies = new System.Windows.Forms.Label();
            lblDay = new System.Windows.Forms.Label();
            lblHunger = new System.Windows.Forms.Label();
            barHunger = new System.Windows.Forms.ProgressBar();
            lblHappiness = new System.Windows.Forms.Label();
            barHappiness = new System.Windows.Forms.ProgressBar();
            lblEnergy = new System.Windows.Forms.Label();
            barEnergy = new System.Windows.Forms.ProgressBar();
            lblCleanliness = new System.Windows.Forms.Label();
            barCleanliness = new System.Windows.Forms.ProgressBar();
            lblMood = new System.Windows.Forms.Label();
            lblWarning = new System.Windows.Forms.Label();
            lblStatus = new System.Windows.Forms.Label();
            btnFeed = new System.Windows.Forms.Button();
            btnPlay = new System.Windows.Forms.Button();
            btnRock = new System.Windows.Forms.Button();
            btnSleep = new System.Windows.Forms.Button();
            btnClean = new System.Windows.Forms.Button();
            btnTreat = new System.Windows.Forms.Button();
            btnWait = new System.Windows.Forms.Button();
            grpSetup.SuspendLayout();
            pnlGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPet).BeginInit();
            SuspendLayout();
           
            grpSetup.Controls.Add(lblNamePrompt);
            grpSetup.Controls.Add(txtName);
            grpSetup.Controls.Add(rbDuck);
            grpSetup.Controls.Add(rbBunny);
            grpSetup.Controls.Add(rbKitten);
            grpSetup.Controls.Add(btnCreate);
            grpSetup.Location = new System.Drawing.Point(12, 12);
            grpSetup.Name = "grpSetup";
            grpSetup.Size = new System.Drawing.Size(1198, 90);
            grpSetup.TabIndex = 0;
            grpSetup.TabStop = false;
            grpSetup.Text = "Create Your Pet";
          
            lblNamePrompt.AutoSize = true;
            lblNamePrompt.Location = new System.Drawing.Point(6, 35);
            lblNamePrompt.Name = "lblNamePrompt";
            lblNamePrompt.Size = new System.Drawing.Size(83, 32);
            lblNamePrompt.TabIndex = 0;
            lblNamePrompt.Text = "Name:";
          
            txtName.Location = new System.Drawing.Point(112, 35);
            txtName.Name = "txtName";
            txtName.Size = new System.Drawing.Size(306, 39);
            txtName.TabIndex = 1;
            txtName.Text = "Buddy";
         
            rbDuck.AutoSize = true;
            rbDuck.Checked = true;
            rbDuck.Location = new System.Drawing.Point(590, 38);
            rbDuck.Name = "rbDuck";
            rbDuck.Size = new System.Drawing.Size(99, 36);
            rbDuck.TabIndex = 2;
            rbDuck.TabStop = true;
            rbDuck.Text = "Duck";
          
            rbBunny.AutoSize = true;
            rbBunny.Location = new System.Drawing.Point(717, 38);
            rbBunny.Name = "rbBunny";
            rbBunny.Size = new System.Drawing.Size(113, 36);
            rbBunny.TabIndex = 3;
            rbBunny.Text = "Bunny";
           
            rbKitten.AutoSize = true;
            rbKitten.Location = new System.Drawing.Point(846, 38);
            rbKitten.Name = "rbKitten";
            rbKitten.Size = new System.Drawing.Size(108, 36);
            rbKitten.TabIndex = 4;
            rbKitten.Text = "Kitten";
        
            btnCreate.Location = new System.Drawing.Point(995, 34);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new System.Drawing.Size(139, 44);
            btnCreate.TabIndex = 5;
            btnCreate.Text = "Create Pet";
            btnCreate.Click += btnCreate_Click;
          
            pnlGame.Controls.Add(picPet);
            pnlGame.Controls.Add(lblPetName);
            pnlGame.Controls.Add(lblSpecies);
            pnlGame.Controls.Add(lblDay);
            pnlGame.Controls.Add(lblHunger);
            pnlGame.Controls.Add(barHunger);
            pnlGame.Controls.Add(lblHappiness);
            pnlGame.Controls.Add(barHappiness);
            pnlGame.Controls.Add(lblEnergy);
            pnlGame.Controls.Add(barEnergy);
            pnlGame.Controls.Add(lblCleanliness);
            pnlGame.Controls.Add(barCleanliness);
            pnlGame.Controls.Add(lblMood);
            pnlGame.Controls.Add(lblWarning);
            pnlGame.Controls.Add(lblStatus);
            pnlGame.Controls.Add(btnFeed);
            pnlGame.Controls.Add(btnPlay);
            pnlGame.Controls.Add(btnRock);
            pnlGame.Controls.Add(btnSleep);
            pnlGame.Controls.Add(btnClean);
            pnlGame.Controls.Add(btnTreat);
            pnlGame.Controls.Add(btnWait);
            pnlGame.Location = new System.Drawing.Point(12, 108);
            pnlGame.Name = "pnlGame";
            pnlGame.Size = new System.Drawing.Size(1198, 604);
            pnlGame.TabIndex = 1;
            pnlGame.Visible = false;
          
            picPet.Image = Properties.Resources.Duck_Wait;
            picPet.Location = new System.Drawing.Point(737, 3);
            picPet.Name = "picPet";
            picPet.Size = new System.Drawing.Size(397, 336);
            picPet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picPet.TabIndex = 22;
            picPet.TabStop = false;
           
            lblPetName.AutoSize = true;
            lblPetName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblPetName.Location = new System.Drawing.Point(5, 5);
            lblPetName.Name = "lblPetName";
            lblPetName.Size = new System.Drawing.Size(91, 41);
            lblPetName.TabIndex = 0;
            lblPetName.Text = "Pet: -";
            
            lblSpecies.AutoSize = true;
            lblSpecies.Location = new System.Drawing.Point(432, 14);
            lblSpecies.Name = "lblSpecies";
            lblSpecies.Size = new System.Drawing.Size(116, 32);
            lblSpecies.TabIndex = 1;
            lblSpecies.Text = "Species: -";
           
            lblDay.AutoSize = true;
            lblDay.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblDay.Location = new System.Drawing.Point(897, 353);
            lblDay.Name = "lblDay";
            lblDay.Size = new System.Drawing.Size(105, 41);
            lblDay.TabIndex = 2;
            lblDay.Text = "Day: 1";
            
            lblHunger.AutoSize = true;
            lblHunger.Location = new System.Drawing.Point(10, 263);
            lblHunger.Name = "lblHunger";
            lblHunger.Size = new System.Drawing.Size(132, 32);
            lblHunger.TabIndex = 4;
            lblHunger.Text = "Hunger: 30";
      
            barHunger.Location = new System.Drawing.Point(298, 273);
            barHunger.Name = "barHunger";
            barHunger.Size = new System.Drawing.Size(250, 22);
            barHunger.TabIndex = 5;
            barHunger.Value = 30;
           
            lblHappiness.AutoSize = true;
            lblHappiness.Location = new System.Drawing.Point(10, 225);
            lblHappiness.Name = "lblHappiness";
            lblHappiness.Size = new System.Drawing.Size(162, 32);
            lblHappiness.TabIndex = 6;
            lblHappiness.Text = "Happiness: 70";
           
            barHappiness.Location = new System.Drawing.Point(298, 235);
            barHappiness.Name = "barHappiness";
            barHappiness.Size = new System.Drawing.Size(250, 22);
            barHappiness.TabIndex = 7;
            barHappiness.Value = 70;
            
            lblEnergy.AutoSize = true;
            lblEnergy.Location = new System.Drawing.Point(10, 186);
            lblEnergy.Name = "lblEnergy";
            lblEnergy.Size = new System.Drawing.Size(125, 32);
            lblEnergy.TabIndex = 8;
            lblEnergy.Text = "Energy: 70";
             
            barEnergy.Location = new System.Drawing.Point(298, 196);
            barEnergy.Name = "barEnergy";
            barEnergy.Size = new System.Drawing.Size(250, 22);
            barEnergy.TabIndex = 9;
            barEnergy.Value = 70;
            
            lblCleanliness.AutoSize = true;
            lblCleanliness.Location = new System.Drawing.Point(6, 145);
            lblCleanliness.Name = "lblCleanliness";
            lblCleanliness.Size = new System.Drawing.Size(171, 32);
            lblCleanliness.TabIndex = 10;
            lblCleanliness.Text = "Cleanliness: 80";
            
            barCleanliness.Location = new System.Drawing.Point(298, 155);
            barCleanliness.Name = "barCleanliness";
            barCleanliness.Size = new System.Drawing.Size(250, 22);
            barCleanliness.TabIndex = 11;
            barCleanliness.Value = 80;
           
            lblMood.AutoSize = true;
            lblMood.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblMood.Location = new System.Drawing.Point(189, 332);
            lblMood.Name = "lblMood";
            lblMood.Size = new System.Drawing.Size(193, 37);
            lblMood.TabIndex = 12;
            lblMood.Text = "Mood: Happy";
          
            lblWarning.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblWarning.ForeColor = System.Drawing.Color.Red;
            lblWarning.Location = new System.Drawing.Point(462, 394);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new System.Drawing.Size(733, 76);
            lblWarning.TabIndex = 13;
           
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            lblStatus.ForeColor = System.Drawing.Color.FromArgb(0, 100, 0);
            lblStatus.Location = new System.Drawing.Point(189, 394);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(376, 76);
            lblStatus.TabIndex = 14;
            lblStatus.Text = "Choose an action!";
           
            btnFeed.Location = new System.Drawing.Point(10, 500);
            btnFeed.Name = "btnFeed";
            btnFeed.Size = new System.Drawing.Size(100, 40);
            btnFeed.TabIndex = 15;
            btnFeed.Text = "Feed";
            btnFeed.Click += btnFeed_Click;
            
            btnPlay.Location = new System.Drawing.Point(156, 500);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new System.Drawing.Size(100, 40);
            btnPlay.TabIndex = 16;
            btnPlay.Text = "Play";
            btnPlay.Click += btnPlay_Click;
            
            btnRock.Location = new System.Drawing.Point(846, 500);
            btnRock.Name = "btnRock";
            btnRock.Size = new System.Drawing.Size(100, 40);
            btnRock.TabIndex = 21;
            btnRock.Text = "Rock";
            btnRock.UseVisualStyleBackColor = true;
            btnRock.Click += btnRock_Click;
          
            btnSleep.Location = new System.Drawing.Point(298, 500);
            btnSleep.Name = "btnSleep";
            btnSleep.Size = new System.Drawing.Size(100, 40);
            btnSleep.TabIndex = 17;
            btnSleep.Text = "Sleep";
            btnSleep.Click += btnSleep_Click;
            
            btnClean.Location = new System.Drawing.Point(432, 500);
            btnClean.Name = "btnClean";
            btnClean.Size = new System.Drawing.Size(100, 40);
            btnClean.TabIndex = 18;
            btnClean.Text = "Clean";
            btnClean.Click += btnClean_Click;
          
            btnTreat.Location = new System.Drawing.Point(573, 500);
            btnTreat.Name = "btnTreat";
            btnTreat.Size = new System.Drawing.Size(100, 40);
            btnTreat.TabIndex = 19;
            btnTreat.Text = "Treat";
            btnTreat.Click += btnTreat_Click;
           
            btnWait.Location = new System.Drawing.Point(707, 500);
            btnWait.Name = "btnWait";
            btnWait.Size = new System.Drawing.Size(100, 40);
            btnWait.TabIndex = 20;
            btnWait.Text = "Wait";
            btnWait.Click += btnWait_Click;
            
            ClientSize = new System.Drawing.Size(1224, 729);
            Controls.Add(grpSetup);
            Controls.Add(pnlGame);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Tamagotchi - Virtual Pet";
            Load += Form1_Load;
            grpSetup.ResumeLayout(false);
            grpSetup.PerformLayout();
            pnlGame.ResumeLayout(false);
            pnlGame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPet).EndInit();
            ResumeLayout(false);
        }

        #endregion

        // These fields store references to every control on the form

        // Setup area controls
        private System.Windows.Forms.GroupBox grpSetup;        // Group box for the setup area
        private System.Windows.Forms.Label lblNamePrompt;      // Name label
        private System.Windows.Forms.TextBox txtName;          // Text box for pet name input
        private System.Windows.Forms.RadioButton rbDuck;       // Radio button for Duck
        private System.Windows.Forms.RadioButton rbBunny;      // Radio button for Bunny
        private System.Windows.Forms.RadioButton rbKitten;     // Radio button for Kitten
        private System.Windows.Forms.Button btnCreate;         // Button to create the pet

        private System.Windows.Forms.Panel pnlGame;           // Panel for the game area

        // Pet info labels
        private System.Windows.Forms.Label lblPetName;         // Shows the pet's name
        private System.Windows.Forms.Label lblSpecies;         
        private System.Windows.Forms.Label lblDay;             // Shows the current day number

        // Stat labels
        private System.Windows.Forms.Label lblHunger;          // Shows hunger value
        private System.Windows.Forms.Label lblHappiness;       
        private System.Windows.Forms.Label lblEnergy;          
        private System.Windows.Forms.Label lblCleanliness;     
        private System.Windows.Forms.Label lblMood;            

        // Progress bars
        private System.Windows.Forms.ProgressBar barHunger;     
        private System.Windows.Forms.ProgressBar barHappiness;  
        private System.Windows.Forms.ProgressBar barEnergy;     
        private System.Windows.Forms.ProgressBar barCleanliness; 

        // Warning and status labels
        private System.Windows.Forms.Label lblWarning;         // Shows warning messages in red
        private System.Windows.Forms.Label lblStatus;          // Shows action status messages

        // Action buttons.
        private System.Windows.Forms.Button btnFeed;           
        private System.Windows.Forms.Button btnPlay;           
        private System.Windows.Forms.Button btnRock;           
        private System.Windows.Forms.Button btnSleep;          
        private System.Windows.Forms.Button btnClean;          
        private System.Windows.Forms.Button btnTreat;          
        private System.Windows.Forms.Button btnWait;           
        private System.Windows.Forms.PictureBox picPet;
    }
}
