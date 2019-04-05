using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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

            ipLabels.Text = "IP: " + GetLocalIPAddress() + " on port " + 1000;
        }

        private string GetLocalIPAddress()
        {
            String url = "http://bot.whatismyipaddress.com/";
            String result = null;

            try
            {
                WebClient client = new WebClient();
                result = client.DownloadString(url);
                return result;
            }
            catch (Exception ex) { return "127.0.0.1"; }
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
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 1000);
            
            

            // Create a TCP/IP socket.  
            listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);


           

            listener.Bind(localEndPoint);
            // Bind the socket to the local endpoint and   
            // listen for incoming connections.  
            Thread listen = new Thread(ListenForPlayers);
            listen.Start();

        }
        private void ListenForPlayers()
        {
            try
            {
                
                listener.Listen(6);

                // Start listening for connections.  
                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    // Program is suspended while waiting for an incoming connection.  
                    players.Add(listener.Accept());
                    data = null;
                    string str = "Player " + players.Count;
                    players[players.Count - 1].Send(Encoding.UTF8.GetBytes(str));

                    playersLabel.Invoke(new MethodInvoker(delegate { playersLabel.Text = "Players Connected: " + players.Count; }));
                    
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
        private int currentTurn = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            foreach(Socket s in players)
            {
                s.Send(Encoding.UTF8.GetBytes("Start"));
            }
            Byte[] bytes = new Byte[1024];
            players[0].Receive(bytes);

            for(int i = 1; i < players.Count; i++)
            {
                players[i].Send(bytes);
            }


            while(true)
            {
                byte[] action = new byte[1];
                players[currentTurn].Receive(action);
                for(int i = 0; i < players.Count; i++)
                {
                    if (i == currentTurn) continue;
                    players[i].Send(action);
                }
                GetResponses();

            }
            
        }


        private void GetResponses()
        {
            for(int i = 0; i < players.Count; i++)
            {
                if (i == currentTurn) continue;
                Thread t = new Thread(() => ListenForResponse(i));
                t.Start();
            }
        }
        private void ListenForResponse(int i)
        {
            Byte[] buffer = new Byte[64];
            players[i].Receive(buffer);

            string s = System.Text.Encoding.UTF8.GetString(buffer, 0, buffer.Length);

            if (s.Equals("Challenge"))
            {
                
                // TODO: Have them listen for interuptions
                for(int j = 0; j < players.Count; j++)
                {
                    if(i == j)continue;

                    players[j].Send(Encoding.UTF8.GetBytes(i + ";Challenge"));
                }
            }

        }
    }
}
