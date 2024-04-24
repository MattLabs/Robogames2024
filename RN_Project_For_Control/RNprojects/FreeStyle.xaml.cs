using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RoboNova
{


    public partial class FreeStyle : ContentPage
    {
        public FreeStyle()
        {
            InitializeComponent();
        }

        public void OnFreeStyleClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var xxx = btn.CommandParameter;
            BluetoothConnection.SendCmd("[" + xxx);
        }
    }
}
