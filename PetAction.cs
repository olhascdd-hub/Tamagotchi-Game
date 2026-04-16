namespace Tamagotchi // Groups all classes under the Tamagotchi namespace
{
    // Enum lists all the actions a player can do with their pet
    public enum PetAction // Declares a public enum called PetAction
    {
        Idle,   // default state
        Feed,   // The player feeds the pet
        Play,   // The player plays with the pet
        Sleep,  // The player puts the pet to sleep
        Clean,  // The player cleans the pet
        Treat,  // The player gives a treat to the pet
        Wait,    // The player waits and does nothing
        Rock    // The player lets the pet rock with a guitar
    }
}
