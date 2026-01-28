using P2PApp.src.accounts;
using P2PApp.src.commands;
using P2PApp.src.network;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            IBankRepository repo = new JsonBankRepo();
            Task.Run(() =>
            {
                var web = new WebHost(repo);
                web.Start();
            });

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
                    Logger.Log("New device connected");

                    Task.Run(() => HandleClient(client, repo));
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

        static void HandleClient(TcpClient client, IBankRepository repo)
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

                    ICommand command = CommandFactory.Create(data,repo);
                    Logger.Log($"Command received: {data}");

                    string result = command.Execute();
                    Logger.Log($"Command executed: {data} => {result}");

                    byte[] message2 = Encoding.ASCII.GetBytes(result + "\n");
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
                Logger.Log("Device disconnected");
            }
            

            
        }
    }
}
