using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboNova
{

    public partial class StairClimb : ContentPage
    {
        public StairClimb()
        {
            InitializeComponent();
        }
        public void OnStairClimbClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var xxx = btn.CommandParameter;
            BluetoothConnection.SendCmd("[" + xxx);
        }
    }
}
