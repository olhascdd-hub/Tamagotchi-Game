namespace Tamagotchi // Groups all classes in project
{
    public sealed class Kitten : Pet // Creates a Kitten pet that inherits from Pet
    {
        public Kitten(string name) : base(name) // Sends the pet name to the base class constructor
        {
            
        }

        public override string Species // Returns the species name for this pet
        {
            get { return "Kitten"; } // Returns "Kitten" as a string
        }

        protected override void DailyBonus() // Runs once per day to give a small special bonus
        {
            ChangeCleanliness(+3); // Adds +3 cleanliness 
        }
    }
}
