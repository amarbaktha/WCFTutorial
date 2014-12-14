using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UDPServiceWPFClient.HelloService;

namespace UDPServiceWPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string Protocol = string.Empty;
        HelloClient proxy;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Protocol == string.Empty)
                {
                    MessageBox.Show("Please select the Protocol");
                }
                else
                {
                    switch (Protocol)
                    {
                        case "TCP":
                            proxy = new HelloClient("NetTcpBinding_IHello");
                            break;
                        case "UDP":
                            proxy = new HelloClient("UdpBinding_IHello");
                            break;
                        case "HTTP":
                            proxy = new HelloClient("BasicHttpBinding_IHello");
                            break;
                    }
                }
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                for (int i = 0; i <= 2; i++)
                {
                    MessagePost msg = new MessagePost()
                    {
                        MessageDetails = "My message post no. " + i.ToString() + "with Protocol " + Protocol
                    };
                    proxy.PostMessages(msg);
                }
                stopwatch.Stop();
                if (Protocol == "TCP")
                {
                    txtTCP.Text += stopwatch.ElapsedMilliseconds;
                }
                if (Protocol == "UDP")
                {
                    txtUDP.Text += stopwatch.ElapsedMilliseconds;
                }
                if (Protocol == "HTTP")
                {
                    txtHTTP.Text += stopwatch.ElapsedMilliseconds;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tcpRadio_Checked(object sender, RoutedEventArgs e)
        {
            Protocol = "TCP";
        }

        private void udpRadio_Checked(object sender, RoutedEventArgs e)
        {
            Protocol = "UDP";
        }

        private void httpRadio_Checked(object sender, RoutedEventArgs e)
        {
            Protocol = "HTTP";
        }
    }
}
