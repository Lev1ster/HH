using System;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientUI
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!int.TryParse(ConfigurationManager.AppSettings["ServerPort"], out var port))
            {
                Console.WriteLine("Неверный Port");
            }
            else
            {
                var ip = new IPEndPoint(IPAddress.Parse(ConfigurationManager.AppSettings["ServerIP"]), port);
                while (true)
                {
                    using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                    {
                        try
                        {
                            socket.Connect(ip);

                            Console.Write("Введите путь к файлу: ");
                            string message = Console.ReadLine();
							
							if(File.Exists(message)
							{
								using (FileStream fileStream = new FileStream(message))
								{
									handler.SendFile(fileStream);
								}
							}
							

                            if (message.ToUpper() == "QUIT" || message.ToUpper() == "ВЫХОД")
                            {
                                socket.Shutdown(SocketShutdown.Both);
                                socket.Close();
                                break;
                            }

                            byte[] data = new byte[256];
                            var builder = new StringBuilder();
							
                            do
                            {
                                int bytes = socket.Receive(data, data.Length, 0);
                                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                            }
                            while (socket.Available > 0);

                            Console.WriteLine("Ответ сервера: " + builder.ToString());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            continue;
                        }
                    }
                }
            }
        }
    }
}

