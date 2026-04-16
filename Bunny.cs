namespace Tamagotchi 
{
    public sealed class Bunny : Pet // Creates a Bunny pet that inherits from Pet
    {
        public Bunny(string name) : base(name) // Sends the pet name to the base class constructor
        {
           
        }

        public override string Species // Returns the species name for this pet
        {
            get { return "Bunny"; } 
        }

        protected override void DailyBonus() // Runs once per day to give a small special bonus
        {
            ChangeCleanliness(+2); // Adds +2 cleanliness 
        }
    }
}
