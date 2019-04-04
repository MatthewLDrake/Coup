using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoupServer
{
    public partial class Server : Form
    {
        private List<Socket> players;
        public Server()
        {
            InitializeComponent();
            players = new List<Socket>();
            
        }
        public string data = null;
        private Socket listener;

        public void StartListening()
        {
            // Data buffer for incoming data.  
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.  
            // Dns.GetHostName returns the name of the   
            // host running the application.  
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            ipLabels.Text = "IP: " + ipAddress.ToString();

            // Create a TCP/IP socket.  
            listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and   
            // listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(6);

                // Start listening for connections.  
                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    // Program is suspended while waiting for an incoming connection.  
                    players.Add( listener.Accept());
                    data = null;
                                        
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }


        private void GameOver()
        {
            foreach (Socket sock in players)
            {
                sock.Shutdown(SocketShutdown.Both);
                sock.Close();
            }

            listener.Shutdown(SocketShutdown.Both);
            listener.Close();


           
        }

        private void endButton_Click(object sender, EventArgs e)
        {
            GameOver();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartListening();
        }
    }
}
