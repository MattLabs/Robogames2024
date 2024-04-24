using System.IO;

namespace RoboNova
{

    public partial class CloseApp : ContentPage
    {
        public CloseApp()
        {
            Application.Current.Quit();

        }

    }
}
