namespace Tamagotchi 
{
    public sealed class Duck : Pet // Creates a Duck pet that inherits from Pet
    {
        public Duck(string name) : base(name) // Sends the pet name to the base class constructor
        {
           
        }

        public override string Species // Returns the species name for this pet
        {
            get { return "Duck"; } // Returns "Duck" as a string
        }

        protected override void DailyBonus() // Runs once per day to give a small special bonus
        {
            ChangeCleanliness(+4); // Adds +4 cleanliness 
        }
    }
}
