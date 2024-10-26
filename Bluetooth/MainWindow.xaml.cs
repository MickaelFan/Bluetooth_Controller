using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using InTheHand.Net.Sockets;
using InTheHand.Net.Bluetooth;
using SharpDX.XInput;
using Microsoft.Web.WebView2.Core; 

namespace Bluetooth
{
    public partial class MainWindow : Window
    {
        private BluetoothClient bluetoothClient;
        private List<BluetoothDeviceInfo> bluetoothDevices;
        private Stream bluetoothStream;
        private Controller controller;
        private bool isConnectedToController;

        public MainWindow()
        {
            InitializeComponent();
            bluetoothClient = new BluetoothClient();
            bluetoothDevices = new List<BluetoothDeviceInfo>();
            controller = new Controller(UserIndex.One);
            isConnectedToController = controller.IsConnected;

            
            if (isConnectedToController)
            {
                MessageBox.Show("Manette connectée.");
            }
            else
            {
                MessageBox.Show("Aucune manette trouvée.");
            }

            InitializeWebView(); 
        }

        private async void InitializeWebView()
        {
            
            await webBrowser.EnsureCoreWebView2Async(null);
        }

        private void btnDiscover_Click(object sender, RoutedEventArgs e)
        {
            DiscoverBluetoothDevices();
        }

        private void DiscoverBluetoothDevices()
        {
            listBoxDevices.Items.Clear();
            bluetoothDevices.Clear();

            try
            {
                var devices = bluetoothClient.DiscoverDevices();
                bluetoothDevices.AddRange(devices);

                foreach (var device in devices)
                {
                    listBoxDevices.Items.Add(device.DeviceName);
                }

                if (devices.Count == 0)
                {
                    MessageBox.Show("Aucun appareil Bluetooth trouvé.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la découverte des périphériques : " + ex.Message);
            }
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxDevices.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez sélectionner un périphérique Bluetooth.");
                return;
            }

            BluetoothDeviceInfo selectedDevice = bluetoothDevices[listBoxDevices.SelectedIndex];

            try
            {
                MessageBox.Show("Tentative de connexion à l'adresse : " + selectedDevice.DeviceAddress.ToString());

                bluetoothClient.Connect(selectedDevice.DeviceAddress, BluetoothService.SerialPort);
                bluetoothStream = bluetoothClient.GetStream();
                MessageBox.Show("Connecté à " + selectedDevice.DeviceName);

                
                StartListeningToController();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Échec de la connexion : " + ex.Message);
            }
        }

        private void StartListeningToController()
        {
            if (!isConnectedToController)
            {
                MessageBox.Show("Aucune manette n'est connectée.");
                return;
            }

            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += (s, args) =>
            {
                var state = controller.GetState();
                var buttons = state.Gamepad.Buttons;

                if (buttons.HasFlag(GamepadButtonFlags.Y))
                {
                    SendBluetoothMessage("Y");
                }
                else if (buttons.HasFlag(GamepadButtonFlags.A))
                {
                    SendBluetoothMessage("A");
                }
                else if (buttons.HasFlag(GamepadButtonFlags.B))
                {
                    SendBluetoothMessage("B");
                }
                else if (buttons.HasFlag(GamepadButtonFlags.X))
                {
                    SendBluetoothMessage("X");
                }
            };
            timer.Start();
        }

        private void SendBluetoothMessage(string message)
        {
            if (bluetoothStream == null)
            {
                MessageBox.Show("Veuillez d'abord vous connecter à un périphérique Bluetooth.");
                return;
            }

            try
            {
                byte[] messageBytes = System.Text.Encoding.ASCII.GetBytes(message);
                bluetoothStream.Write(messageBytes, 0, messageBytes.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'envoi du message : " + ex.Message);
            }
        }

        
        private void btnLoadUrl_Click(object sender, RoutedEventArgs e)
        {
            string url = txtUrl.Text;

            
            if (!string.IsNullOrWhiteSpace(url))
            {
                try
                {
                    webBrowser.CoreWebView2.Navigate(url); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors du chargement de la page : " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Veuillez entrer une URL valide.");
            }
        }
    }
}
