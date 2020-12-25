using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bluetooth_cli
{
    class Program
    {
        static void Main(string[] args)
        {
            //Serial Port for communication with the client's device
            var serviceClass = BluetoothService.SerialPort;
            BluetoothClient _cli = new BluetoothClient();
            
            //Device Discovery 
            var bluetoothDeviceInfos = _cli.DiscoverDevices();
            var deviceInfos = bluetoothDeviceInfos.ToList();

            BluetoothDeviceInfo device = null; // Device info object of the device of interest(DOI)
            BluetoothAddress btAddress = null; //Address of the DOI

            //Looking for the DOI

            foreach (var bluetoothDeviceInfo in deviceInfos)
            {
                var scannedDeviceAddress = bluetoothDeviceInfo.DeviceAddress;

                if (scannedDeviceAddress == btAddress)
                {
                    device = bluetoothDeviceInfo;
                }
            }
            var btendPoint= new BluetoothEndPoint(device.DeviceAddress, serviceClass);
            try
            {
                if (!device.Connected)
                {
                    _cli.Connect(btendPoint);
                }
            }
            catch (System.Net.Sockets.SocketException)
            {
                _cli.Close();
                /*_isConnected = false;*/
                return;
            }

            /*_isConnected = true;*/




            /*            BluetoothClient client = new BluetoothClient();
                        List<BluetoothDeviceInfo> items = new List<BluetoothDeviceInfo>();
                        BluetoothDeviceInfo[] devices = client.Dsi;
                        foreach (BluetoothDeviceInfo d in devices)
                        {
                            items.Add(d);
                        }
                        Console.Write(items);
                        foreach (var item in items)
                        {
                            if (item.DeviceName == "Adeeb's Airpods")
                            {
                                client.Connect
                            }
                            Console.WriteLine(item);*/
        }
    }
}

