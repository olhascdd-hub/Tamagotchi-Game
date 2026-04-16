using System; 
namespace Tamagotchi // Groups all classes
{
    // Abstract base class for all pets. Cannot be created directly  
    //Subclasses (Bunny, Duck, Kitten) inherit from this class
    public abstract class Pet // Declares an abstract class called Pet
    {
        // Properties (Encapsulation) 

        public string Name { get; set; } // Stores the pet's name. Can be read and changed

        public abstract string Species { get; } // Each subclass must return its own species name


        // Stats are between 0 and 100. Only this class can change them (private set)
        public int Hunger { get; private set; }      // Stores hunger level. Lower is better
        public int Happiness { get; private set; }    // Stores happiness level. Higher is better
        public int Energy { get; private set; }       // Stores energy level. Higher is better
        public int Cleanliness { get; private set; }  // Stores cleanliness level. Higher is better

        // Critical Days Tracking

        private int _daysNoEnergy = 0;  // Counts how many days in a row energy is zero
        private int _daysFilthy = 0;    // Counts how many days in a row cleanliness is zero
        private const int DaysUntilDeath = 3; // Pet dies after this many zero-stat days

        // Public read-only access so the form can show warnings
        public int DaysNoEnergy { get { return _daysNoEnergy; } }   // Returns days with no energy
        public int DaysFilthy { get { return _daysFilthy; } }       // Returns days with no cleanliness
        public int CriticalDays { get { return DaysUntilDeath; } }  // Returns the death threshold


        // Protected constructor. Only subclasses can call it
        protected Pet(string name) // Takes the pet's name as a parameter
        {
            Name = name;           // Sets the pet's name
            Hunger = 30;           // Sets starting hunger to 30
            Happiness = 70;        
            Energy = 70;           
            Cleanliness = 80;      
        }

        public string GetMood() // Public method that returns a mood word
        {
            // Calculates average wellbeing 
            int wellbeing = (Energy + Cleanliness + (100 - Hunger)) / 3; 

            if (wellbeing >= 70) 
                return "Happy";  
            if (wellbeing >= 40) 
                return "Okay";   
            return "Sad";       
        }

        // Actions 
        public string Feed() // Returns a message string for the form to display
        {
            ChangeHunger(-25);    // Decreases hunger by 25 
            ChangeHappiness(+5);  // Increases happiness by 5 
            return Name + " is eating... yumy!"; // Returns a status message
        }

        // Increases happiness but costs energy and cleanliness
        public string Play() 
        {
            ChangeHappiness(+15);  
            ChangeEnergy(-15);     
            ChangeCleanliness(-10); 
            return Name + " is playing!"; 
        }

        //Increases happiness, costs some energy
        public string Rock() 
        {
            ChangeHappiness(+20);   
            ChangeEnergy(-10);      
            ChangeCleanliness(-5);  
            return Name + " is rocking out on the guitar!";
        }

        // Increases energy but increases hunger
        public string Sleep() 
        {
            ChangeEnergy(+30);   
            ChangeHunger(+10);   
            return Name + " is sleeping... Zzz"; 
        }

        // Increases cleanliness and a little happiness
        public string Clean() 
        {
            ChangeCleanliness(+30); 
            ChangeHappiness(+3);    
            return Name + " is getting cleaned!"; 
        }

        // Small hunger help, happiness depends on cleanliness
        public string Treat() 
        {
            ChangeHunger(-5); // small treat

            if (Cleanliness < 20) // If the pet is very dirty
            {
                ChangeHappiness(0); // no happiness gain 
            }
            else if (Cleanliness < 40) // If the pet is somewhat dirty
            {
                ChangeHappiness(+5); // small happiness gain
            }
            else // If the pet is clean enough
            {
                ChangeHappiness(+12); //full happiness gain
            }

            ChangeEnergy(-5);       
            ChangeCleanliness(-15); // treat makes mess
            return Name + " got a treat!"; 
        }

        public string Wait() 
        {
            return Name + " is resting..."; 
        }

        //Day Simulation
        public void PassDay() // Called after every action
        {
            ChangeHunger(+8);      
            ChangeEnergy(-8);      
            ChangeCleanliness(-5); 

            // Penalties for bad conditions
            if (Cleanliness < 40) 
                ChangeHappiness(-10); 
            if (Cleanliness < 20) 
                ChangeHappiness(-20); 
            if (Hunger > 70) 
                ChangeHappiness(-10); 

            // Update critical day counters
            if (Energy <= 0) 
                _daysNoEnergy = _daysNoEnergy + 1; 
            else 
                _daysNoEnergy = 0; 

            if (Cleanliness <= 0) 
                _daysFilthy = _daysFilthy + 1; 
            else 
                _daysFilthy = 0; 

            DailyBonus(); // Calls the virtual method for bonus
        }

        // Game Over Check 

        public bool IsGameOver(out string reason) // gives the reason
        {
            if (Hunger >= 100) 
            {
                reason = "Your pet starved! (Hunger reached 100)"; 
                return true; 
            }

            if (Happiness <= 0) 
            {
                reason = "Your pet became too unhappy! (Happiness reached 0)"; 
                return true; 
            }

            if (_daysNoEnergy >= DaysUntilDeath) 
            {
                reason = "Your pet was exhausted for " + DaysUntilDeath + " days!"; 
                return true; 
            }

            if (_daysFilthy >= DaysUntilDeath) 
            {
                reason = "Your pet was filthy for " + DaysUntilDeath + " days!"; 
                return true; 
            }

            reason = ""; // No game over
            return false; // Game continues
        }

        // Protected Helpers (Encapsulation)
        // These methods change stats safely. Value is always clamped to 0-100
        protected void ChangeHunger(int amount) // Changes hunger by the given amount
        {
            Hunger = Clamp(Hunger + amount); // Adds amount and clamps to 0-100
        }

        protected void ChangeHappiness(int amount) 
        {
            Happiness = Clamp(Happiness + amount); 
        }

        protected void ChangeEnergy(int amount) 
        {
            Energy = Clamp(Energy + amount); 
        }

        protected void ChangeCleanliness(int amount) 
        {
            Cleanliness = Clamp(Cleanliness + amount); 
        }

        // Clamps a value between 0 and 100
        private int Clamp(int value) // Takes an integer value
        {
            if (value < 0) return 0;     // If below 0, return 0
            if (value > 100) return 100; // If above 100, return 100
            return value;                // Otherwise return the value unchanged
        }

        // Polymorphism 
        // Virtual method. Subclasses override this for species-specific daily effects
        protected virtual void DailyBonus() // Called once per day in PassDay()
        {
            // Default: nothing happens. Subclasses can override
        }
    }
}
