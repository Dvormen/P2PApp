using P2PApp.src.commands;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace P2PApp.src
{
    internal class Program
    {
        /// <summary>
        /// Main Application loop
        /// </summary>
        static void Main(string[] args)
        {

            Int32 port = 65525;
            IPAddress localAddress = IPAddress.Parse("127.0.0.1");

            TcpListener server = null;

            try
            {
                server = new TcpListener(localAddress, port);
                server.Start();

                Console.WriteLine("=== P2P Bank Node ===");
                Console.WriteLine("Waiting for connection...");

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("New device connected");

                    Task.Run(() => HandleClient(client));
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine($"SocketException: {e}");
            }
            finally
            {
                server.Stop();
            }
        }

        static void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();

            byte[] buffer = new byte[256];
            int count;
            try
            {
                byte[] message1 = Encoding.ASCII.GetBytes("=== P2P Bank Node ===\n");
                stream.Write(message1, 0, message1.Length);

                while ((count = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string data = Encoding.ASCII.GetString(buffer, 0, count);

                    string cleanData = data.Trim();
                    if (string.IsNullOrEmpty(cleanData))
                    {
                        continue;
                    }

                    ICommand command = CommandFactory.Create(data);

                    byte[] message2 = Encoding.ASCII.GetBytes(command.Execute());
                    stream.Write(message2, 0, message2.Length);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                client.Close();
                Console.WriteLine("Device disconnected.");
            }
            

            
        }
    }
}
