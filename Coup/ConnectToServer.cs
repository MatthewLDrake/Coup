using System.Net;
using System.Windows.Forms;
using System.Net.Sockets;

namespace Coup
{
    public class ConnectToServer : Form
    {
        private Socket client;
        private int number;
        public ConnectToServer()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, System.EventArgs e)
        {
            Connect(ip.Text,int.Parse(socket.Text));
        }
        private void Connect(string ip, int port)
        {
            byte[] buffer = new byte[1024];

            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName()); 
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

            client = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            client.Connect(remoteEP);

            client.Receive(buffer);

            string s = System.Text.Encoding.UTF8.GetString(buffer, 0, buffer.Length);

            MessageBox.Show(s);
            number = int.Parse(s.Replace("Player ",""));
            buffer = new byte[1024];
            client.Receive(buffer);

            s = System.Text.Encoding.UTF8.GetString(buffer, 0, buffer.Length);

            if (s.Equals("Cancel"))
            {
                client.Shutdown(SocketShutdown.Both);
                client.Close();
                client = null;
            }
            

            Close();
        }
        public int GetNumber()
        {
            return number;
        }
        public Socket GetSocket()
        {
            return client;
        }


        private Label label1;
        private Label label2;
        private Button button1;
        private TextBox socket;
        private TextBox ip;
        private TableLayoutPanel tableLayoutPanel1;

        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ip = new System.Windows.Forms.TextBox();
            this.socket = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.socket, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ip, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(260, 152);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Of Server:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Socket Number:";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.button1, 2);
            this.button1.Location = new System.Drawing.Point(92, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ip
            // 
            this.ip.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ip.Location = new System.Drawing.Point(133, 15);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(100, 20);
            this.ip.TabIndex = 3;
            // 
            // socket
            // 
            this.socket.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.socket.Location = new System.Drawing.Point(133, 65);
            this.socket.Name = "socket";
            this.socket.Size = new System.Drawing.Size(100, 20);
            this.socket.TabIndex = 4;
            // 
            // ConnectToServer
            // 
            this.ClientSize = new System.Drawing.Size(284, 206);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ConnectToServer";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}