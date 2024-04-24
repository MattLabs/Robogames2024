using Syncfusion.Maui.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion;
using InTheHand.Net.Bluetooth;
using InTheHand.Bluetooth;
using InTheHand.Net.Sockets;
using System.Diagnostics;
using System.IO;
//using Android.OS;


namespace RoboNova
{
    public partial class BluetoothConnection : ContentPage
    {
        static BluetoothClient client = null;
        public BluetoothDeviceInfo device = null!;

        static public Stream stream = null!;

        public BluetoothConnection()
        {
            InitializeComponent();
            client = new BluetoothClient();
        }

        public async void OnConnectClicked(object sender, EventArgs e) {
            //int Version = (int)Build.VERSION.SdkInt;
            //if (Version < 10) {
                PermissionStatus status = await Permissions.CheckStatusAsync<InTheHand.Bluetooth.Permissions.Bluetooth>();

                status = await Permissions.RequestAsync<InTheHand.Bluetooth.Permissions.Bluetooth>();
            //}

            var picker = new BluetoothDevicePicker();
            //picker.ClassOfDevices.Add(new ClassOfDevice(DeviceClass.AudioVideoUnclassified, ServiceClass.Audio));
            device = await picker.PickSingleDeviceAsync();

            if (!device.Authenticated)
            {
                BluetoothSecurity.PairRequest(device.DeviceAddress, "1234");
            }
            device.Refresh();

            client.Connect(device.DeviceAddress, BluetoothService.SerialPort);
            var timeout = 10;
            while (!client.Connected)
            {
                if (timeout == 0) break;
                timeout -= 1;
                Thread.Sleep(1000);
            }
            if (client.Connected)
            {
                stream = client.GetStream();
            }
        }

              /*
            async Task StreamLoop()
            {
                byte[] buffer = new byte[1024];

                while (client.Connected)
                {
                    int readBytes = await stream.ReadAsync(buffer, 0, 80);
                    var text = System.Text.Encoding.ASCII.GetString(buffer, 0, readBytes);
                    var split = text.Split('\r');
                    foreach (string line in split)
                    {
                        Debug.WriteLine(line);

                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            if (line.StartsWith("AT+BRSF"))
                            {
                                // report no optional features
                                //stream.WriteString("BRSF:0");
                                //stream.WriteString("OK");
                            }
                        }
                    }
                }
            } */

        public static void SendCmd(string Str)
        {
            if (client.Connected)
            {
                stream = client.GetStream();
                byte[] messageBuffer = Encoding.ASCII.GetBytes(Str);
                stream.Write(messageBuffer, 0, messageBuffer.Length);
            }
        }
    }

}

