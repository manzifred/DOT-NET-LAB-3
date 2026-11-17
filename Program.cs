using System.Windows.Forms;
using LandRegistrationSystem.Views;

namespace LandRegistrationSystem;

internal static class Program
{
    [System.STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}
