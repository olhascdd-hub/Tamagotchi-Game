using System; // Imports the System namespace for basic types
using System.Collections.Generic;
using System.Drawing; // Imports classes for colours and fonts
using System.Windows.Forms; // Imports Windows Forms classes for GUI
using WMPLib;

namespace Tamagotchi // Groups all classes under the Tamagotchi namespace
{
    public enum StatZone
    {
        Critical,
        Medium,
        Good
    }
    public partial class Form1 : Form // Form1 inherits from the Form class
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();

        private Pet? _pet;  // Stores the current pet object. Null until created
        private int _day;   // Stores the current day number

        // Small window size shown at the start of the program
        private Size _startWindowSize = new Size(1250, 200);

        // Large window size shown after the pet is created
        private Size _gameWindowSize = new Size(1250, 700);

        // Helper methods-stops the rock sound if it is playing
        private void StopRockSound()
        {
            player.controls.stop();
        }

        // Returns which zone the stat belongs to
        // reverse = true means high value is bad (used for Hunger)
        // reverse = false means high value is good (used for other stats)
        private StatZone GetStatZone(int value, bool reverse)
        {
            // Keeps the value inside the valid range
            if (value < 0) value = 0;
            if (value > 100) value = 100;

            // Hunger uses reverse logic: low hunger = good, high hunger = bad
            if (reverse)
            {
                if (value <= 33)
                    return StatZone.Good;
                else if (value <= 66)
                    return StatZone.Medium;
                else
                    return StatZone.Critical;
            }
            else
            {
                // low value = bad, high value = good
                if (value <= 33)
                    return StatZone.Critical;
                else if (value <= 66)
                    return StatZone.Medium;
                else
                    return StatZone.Good;
            }
        }

        // Converts a zone into text for the labels
        private string GetZoneText(StatZone zone)
        {
            switch (zone)
            {
                case StatZone.Critical:
                    return "Critical";

                case StatZone.Medium:
                    return "Medium";

                case StatZone.Good:
                    return "Good";

                default:
                    return "";
            }
        }

        // Changes the label colour depending on the zone
        private void ApplyZoneColor(Label lbl, StatZone zone)
        {
            switch (zone)
            {
                case StatZone.Critical:
                    lbl.ForeColor = Color.Red;
                    break;

                case StatZone.Medium:
                    lbl.ForeColor = Color.Goldenrod;
                    break;

                case StatZone.Good:
                    lbl.ForeColor = Color.Green;
                    break;
            }
        }

        // Constructor - runs when the form is created
        public Form1()
        {
            InitializeComponent(); // Calls the Designer method to create all controls
            _pet = null;           // No pet exists yet
            _day = 0;              // Day counter starts at 0

            // Start with a small window and place it in the centre of the screen
            this.ClientSize = _startWindowSize;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(
                (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, 0
            );
        }

        // CREATE PET BUTTON
        // Runs when the user clicks the "Create Pet" button
        private void btnCreate_Click(object sender, EventArgs e) // Event handler for Create button
        {
            StopRockSound(); // Stops the previous rock music if it is still playing

            // Get the name from the text box
            string name = txtName.Text.Trim(); // Gets the text and removes spaces from edges

            if (name == "") // If the name is empty
            {
                name = "Buddy"; // use the default name "Buddy"
            }

            // Create the pet based on which radio button is selected
            // This is polymorphism: _pet variable is type Pet, but holds a subclass
            if (rbDuck.Checked) // If the Duck radio button is selected
            {
                _pet = new Duck(name); // create a new Duck object
            }
            else if (rbBunny.Checked) // If the Bunny radio button is selected
            {
                _pet = new Bunny(name); // create a new Bunny object
            }
            else // If the Kitten radio button is selected
            {
                _pet = new Kitten(name); // create a new Kitten object
            }

            ShowPetImage(PetAction.Idle);

            _day = 1; // Reset the day counter to 1

            // Show the game panel and disable the setup area
            pnlGame.Visible = true;    // Makes the game panel visible
            grpSetup.Enabled = false;  // Disables the setup controls (cannot change pet)

            // Make the window bigger after creating a pet
            this.ClientSize = _gameWindowSize;

            // Enable all action buttons
            SetButtonsEnabled(true); // Calls helper method to enable buttons

            // Update the display with the new pet's information
            UpdateDisplay(); // Calls the display update method
            ShowPetImage(PetAction.Idle);
        }

        // ACTION BUTTON
        // Runs when the user clicks the "Feed" button
        private void btnFeed_Click(object sender, EventArgs e) // Event handler for Feed button
        {
            DoAction(PetAction.Feed); // Calls the shared action method with Feed
        }

        private void btnPlay_Click(object sender, EventArgs e) // Event handler for Play button
        {
            DoAction(PetAction.Play); // Calls the shared action method with Play
        }

        private void btnRock_Click(object sender, EventArgs e) // Event handler for Rock button
        {
            StopRockSound();         // Stops old sound before starting again
            player.URL = "rock.mp3"; // Loads the rock mp3 file
            player.controls.play();  // Starts the sound
            DoAction(PetAction.Rock); // Calls the shared action method with Rock
        }

        private void btnSleep_Click(object sender, EventArgs e) // Event handler for Sleep button
        {
            DoAction(PetAction.Sleep); // Calls the shared action method with Sleep
        }

        private void btnClean_Click(object sender, EventArgs e) // Event handler for Clean button
        {
            DoAction(PetAction.Clean); // Calls the shared action method with Clean
        }

        private void btnTreat_Click(object sender, EventArgs e) // Event handler for Treat button
        {
            DoAction(PetAction.Treat); // Calls the shared action method with Treat
        }

        private void btnWait_Click(object sender, EventArgs e) // Event handler for Wait button
        {
            DoAction(PetAction.Wait); // Calls the shared action method with Wait
        }

        //  SHARED ACTION METHOD 
        private void DoAction(PetAction action) // Takes a PetAction enum value
        {
            if (_pet == null) return; // If no pet exists, do nothing and return

            // Stop the rock sound when the user presses any action except Rock
            if (action != PetAction.Rock)
            {
                StopRockSound();
            }

            // Perform the action and get a status message
            string message = ""; // Variable to hold the status message

            switch (action) // Checks which action was chosen
            {
                case PetAction.Feed:
                    message = _pet.Feed();
                    break;

                case PetAction.Play:
                    message = _pet.Play();
                    break;

                case PetAction.Rock:
                    message = _pet.Rock();
                    break;

                case PetAction.Sleep:
                    message = _pet.Sleep();
                    break;

                case PetAction.Clean:
                    message = _pet.Clean();
                    break;

                case PetAction.Treat:
                    message = _pet.Treat();
                    break;

                case PetAction.Wait:
                    message = _pet.Wait();
                    break;
            }

            // Show the status message
            lblStatus.Text = message; // Updates the status label with the action message

            // One day passes
            _pet.PassDay(); // Calls PassDay to simulate time passing
            _day = _day + 1; // Increases the day counter by 1

            // Update all labels and progress bars
            UpdateDisplay(); // Refreshes the entire display

            ShowPetImage(action); // Shows the correct picture for the action

            // Check if the game is over
            string reason; // Variable to hold the game-over reason
            if (_pet.IsGameOver(out reason))
            {
                ShowGameOver(reason); // show the game over message
            }
        }

        //  DISPLAY UPDATE METHOD 

        private void UpdateDisplay() // Called after every action
        {
            if (_pet == null) return; // If no pet exists, do nothing

            // Update pet info labels
            lblPetName.Text = "Pet: " + _pet.Name;       // Shows the pet's name
            lblSpecies.Text = "Species: " + _pet.Species;
            lblDay.Text = "Day: " + _day;

            // Gets the current zone for each stat
            // Hunger uses reverse logic because high hunger is bad
            StatZone hungerZone = GetStatZone(_pet.Hunger, true);
            StatZone happinessZone = GetStatZone(_pet.Happiness, false);
            StatZone energyZone = GetStatZone(_pet.Energy, false);
            StatZone cleanlinessZone = GetStatZone(_pet.Cleanliness, false);

            // Update stat labels with current values and zone text
            lblHunger.Text = "Hunger: " + _pet.Hunger + " (" + GetZoneText(hungerZone) + ")";
            lblHappiness.Text = "Happiness: " + _pet.Happiness + " (" + GetZoneText(happinessZone) + ")";
            lblEnergy.Text = "Energy: " + _pet.Energy + " (" + GetZoneText(energyZone) + ")";
            lblCleanliness.Text = "Cleanliness: " + _pet.Cleanliness + " (" + GetZoneText(cleanlinessZone) + ")";

            // Change label colours depending on the zone
            ApplyZoneColor(lblHunger, hungerZone);
            ApplyZoneColor(lblHappiness, happinessZone);
            ApplyZoneColor(lblEnergy, energyZone);
            ApplyZoneColor(lblCleanliness, cleanlinessZone);

            // Update progress bars with current values
            barHunger.Value = _pet.Hunger;
            barHappiness.Value = _pet.Happiness;
            barEnergy.Value = _pet.Energy;
            barCleanliness.Value = _pet.Cleanliness;

            // Update mood label
            lblMood.Text = "Mood: " + _pet.GetMood(); // Shows the mood text

            // Update warning label
            UpdateWarnings(); // Calls the warning update method
        }

        // Checks if any stats are critically low and shows warnings
        private void UpdateWarnings()
        {
            string warning = "";

            // Check if energy has been zero for one or more days
            if (_pet.DaysNoEnergy > 0)
            {
                warning = warning + "WARNING: Energy is 0 for "
                    + _pet.DaysNoEnergy + "/" + _pet.CriticalDays + " days!  ";
            }

            // Check if cleanliness has been zero for one or more days
            if (_pet.DaysFilthy > 0)
            {
                warning = warning + "WARNING: Cleanliness is 0 for "
                    + _pet.DaysFilthy + "/" + _pet.CriticalDays + " days!";
            }

            lblWarning.Text = warning; // Sets the warning label text
        }

        private void ShowGameOver(string reason) // Takes the death reason as a parameter
        {
            // Disable all action buttons
            SetButtonsEnabled(false); // Player cannot do more actions

            // Build the game over message
            string message = "GAME OVER!\n\n" // First line: game over title
                + reason + "\n\n"              // Second line
                + "You survived " + (_day - 1) + " days.\n\n"
                + "Do you want to play again?";

            // Show a message box with Yes and No buttons
            DialogResult result = MessageBox.Show(
                message,
                "Game Over",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
            );

            if (result == DialogResult.Yes)
            {
                RestartGame();
            }
            else
            {
                Application.Exit();
            }
        }

        // Resets the game so the player can create a new pet
        private void RestartGame() // Called when player wants to play again
        {
            StopRockSound();          // Stops the rock music
            _pet = null;              // Removes the current pet
            _day = 0;                 // Resets the day counter
            pnlGame.Visible = false;  // Hides the game panel
            grpSetup.Enabled = true;  // Re-enables the setup controls
            this.ClientSize = _startWindowSize; // Returns the form to the small start size
            txtName.Text = "Buddy";   // Resets the name text box
            rbDuck.Checked = true;    // Selects Duck as default
            lblWarning.Text = "";     // Clears the warning label
            lblStatus.Text = "Choose an action!"; // Resets the status label
        }

        //  HELPER METHOD
        // Enables or disables all action buttons at once
        private void SetButtonsEnabled(bool enabled) // Takes a boolean parameter
        {
            btnFeed.Enabled = enabled;
            btnPlay.Enabled = enabled;
            btnRock.Enabled = enabled;
            btnSleep.Enabled = enabled;
            btnClean.Enabled = enabled;
            btnTreat.Enabled = enabled;
            btnWait.Enabled = enabled;
        }

        private void ShowPetImage(PetAction action) // Shows the correct image for the selected action
        {
            if (_pet == null) // Checks if the pet is not created yet
            {
                picPet.Image = null; // Clears the picture box image
                return; // Stops the method
            }

            if (_pet.Species == "Kitten") // Checks if the current pet is a Kitten
            {
                switch (action)
                {
                    case PetAction.Idle:
                        picPet.Image = Properties.Resources.Kitten_Idle;
                        break;

                    case PetAction.Feed:
                        picPet.Image = Properties.Resources.Kitten_Feed;
                        break;

                    case PetAction.Play:
                        picPet.Image = Properties.Resources.Kitten_Play;
                        break;

                    case PetAction.Rock:
                        picPet.Image = Properties.Resources.Kitten_Rock;
                        break;

                    case PetAction.Sleep:
                        picPet.Image = Properties.Resources.Kitten_Sleep;
                        break;

                    case PetAction.Clean:
                        picPet.Image = Properties.Resources.Kitten_Clean;
                        break;

                    case PetAction.Treat:
                        picPet.Image = Properties.Resources.Kitten_Treat;
                        break;

                    case PetAction.Wait:
                        picPet.Image = Properties.Resources.Kitten_Wait;
                        break;

                    default:
                        picPet.Image = Properties.Resources.Kitten_Idle;
                        break;
                }

                return;
            }
            else if (_pet.Species == "Bunny")
            {
                switch (action)
                {
                    case PetAction.Idle:
                        picPet.Image = Properties.Resources.Bunny_Idle;
                        break;

                    case PetAction.Feed:
                        picPet.Image = Properties.Resources.Bunny_Feed;
                        break;

                    case PetAction.Play:
                        picPet.Image = Properties.Resources.Bunny_Play;
                        break;

                    case PetAction.Rock:
                        picPet.Image = Properties.Resources.Bunny_Rock;
                        break;

                    case PetAction.Sleep:
                        picPet.Image = Properties.Resources.Bunny_Sleep;
                        break;

                    case PetAction.Clean:
                        picPet.Image = Properties.Resources.Bunny_Clean;
                        break;

                    case PetAction.Treat:
                        picPet.Image = Properties.Resources.Bunny_Treat;
                        break;

                    case PetAction.Wait:
                        picPet.Image = Properties.Resources.Bunny_Wait;
                        break;

                    default:
                        picPet.Image = Properties.Resources.Bunny_Idle;
                        break;
                }

                return;
            }
            else if (_pet.Species == "Duck")
            {
                switch (action)
                {
                    case PetAction.Idle:
                        picPet.Image = Properties.Resources.Duck_Idle;
                        break;

                    case PetAction.Feed:
                        picPet.Image = Properties.Resources.Duck_Feed;
                        break;

                    case PetAction.Play:
                        picPet.Image = Properties.Resources.Duck_Play;
                        break;

                    case PetAction.Rock:
                        picPet.Image = Properties.Resources.Duck_Rock;
                        break;

                    case PetAction.Sleep:
                        picPet.Image = Properties.Resources.Duck_Sleep;
                        break;

                    case PetAction.Clean:
                        picPet.Image = Properties.Resources.Duck_Clean;
                        break;

                    case PetAction.Treat:
                        picPet.Image = Properties.Resources.Duck_Treat;
                        break;

                    case PetAction.Wait:
                        picPet.Image = Properties.Resources.Duck_Wait;
                        break;

                    default:
                        picPet.Image = Properties.Resources.Duck_Idle;
                        break;
                }

                return;
            }
            // If you do not have images for other pets yet
            picPet.Image = null;
        }

        private void Form1_Load(object sender, EventArgs e) // Icon
        {
            this.Icon = Properties.Resources.t;
        }
    }
}