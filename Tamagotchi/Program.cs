using System; // Imports the System namespace for basic types
using System.Windows.Forms; // Imports Windows Forms classes for GUI

namespace Tamagotchi // Groups all classes under the Tamagotchi namespace
{
    // Program class contains the entry point of the application
    internal static class Program // Static class
    {
        // Main method is the entry point. Application starts here
        [STAThread] // Required attribute for Windows Forms applications
        static void Main() // The first method that runs when the program starts
        {
            Application.EnableVisualStyles();         // Enables modern Windows visual styles
            Application.SetCompatibleTextRenderingDefault(false); // Uses GDI+ for text rendering
            Application.Run(new Form1());             // Creates Form1 and starts the application loop
        }
    }
}
