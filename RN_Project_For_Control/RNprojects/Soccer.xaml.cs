using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboNova
{

    public partial class Soccer : ContentPage
    {

        public Soccer()
        {
            InitializeComponent();
        }
        public void OnSoccerClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var xxx = btn.CommandParameter;
            BluetoothConnection.SendCmd("[" + xxx);
        }
    }

}
