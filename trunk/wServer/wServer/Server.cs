using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using wParams;

namespace wServer
{
    class Server
    {
        private TcpListener tcpListener;
        private Thread listenThread;
        private TcpClient client;
        private EnviParams someData = new EnviParams();

        public Server()
        {
            Console.WriteLine("Listening on port 3000...");
            this.tcpListener = new TcpListener(IPAddress.Any, 3000);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();
        }
        private void ListenForClients()
        {
            this.tcpListener.Start();

            while (true)
            {
                //blocks until a client has connected to the server
                client = this.tcpListener.AcceptTcpClient();

                //create a thread to handle communication 
                //with connected client
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }
        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;
                Random random = new Random();
                someData.WindDirection = random.Next(1, 8); ;
                someData.Windforce = random.Next(10, 100); ;

                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    //a socket error has occured
                    break;
                }

                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    break;
                }

                //message has successfully been received
                ASCIIEncoding encoder = new ASCIIEncoding();
                Console.WriteLine("Recived data:" + encoder.GetString(message, 0, bytesRead));
                if (encoder.GetString(message, 0, bytesRead) == "gibe_me_some_stats")
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(clientStream, someData);
                }
            }

            tcpClient.Close();
        }
    }
}
