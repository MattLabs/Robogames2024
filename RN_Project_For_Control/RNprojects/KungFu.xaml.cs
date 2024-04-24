using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboNova
{

    public partial class KungFu : ContentPage
    {

        public KungFu()
        {
            InitializeComponent();
        }
        public void OnKungFuClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var xxx = btn.CommandParameter;
            BluetoothConnection.SendCmd("[" + xxx);
        }
    }
}
