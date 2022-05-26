using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerLibrary
{
	static string[] whitelist =
        {
            "127.0.0.1"
        };
		
    public class Server
    {
        IPEndPoint ip;
        IControl control;

        public Server(string ip, int port, IControl control)
        {
            this.ip = new IPEndPoint(IPAddress.Parse(ip), port);
            this.control = control;
        }

        public void Connect()
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    socket.Bind(ip);
                    socket.Listen(10);
                    control.PrintLine("Сервер включен...");
                }
                catch (Exception ex)
                {
                    control.PrintLine(ex.Message);
                }

                bool isExit = true;

                while (true)
                {
                    var handler = socket.Accept();				
					bool isWhiteList = false;
					
					foreach(var ip in whitelist)
					{
						if(ip != (handler.LocalEndPoint.ToString().Split(':')[0])
						{
							control.PrintLine("IP не в белом листе");
						}
						else
						{
							isWhiteList = true;
						}
					}
					if(isWhiteList)
					{
						if (isExit)
						{
							control.PrintLine(handler.LocalEndPoint.ToString() + " (" + DateTime.Now.ToShortTimeString() + ") - Подключился");
	
							isExit = !isExit;
						}
	
						var builder = new StringBuilder();
						byte[] data = new byte[256];
		
						try
						{
							do
							{
								int bytes = handler.Receive(data);
								builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
							}
							while (handler.Available > 0);
			
							if (builder.ToString().ToUpper() == "QUIT" || builder.ToString().ToUpper() == "ВЫХОД")
							{
								control.PrintLine(handler.LocalEndPoint.ToString() + " (" + DateTime.Now.ToShortTimeString() + ") - Отключился");
								
								isExit = !isExit;
								handler.Shutdown(SocketShutdown.Both);
								handler.Close();
							}
							else
							{
								control.PrintLine(handler.LocalEndPoint.ToString() + " (" + DateTime.Now.ToShortTimeString() + "): " + builder.ToString());
								
								string message = "Ваше сообщение доставлено";
								data = Encoding.Unicode.GetBytes(message);
																
								handler.Send(data);
								
								if(File.Exists(builder.ToString()))
								{
									using (FileStream fileStream = new FileStream(builder.ToString()))
									{
										handler.SendFile(fileStream);
									}
								}
							}
						}
						catch (Exception ex)
						{
							control.PrintLine(ex.Message);
							handler.Shutdown(SocketShutdown.Both);
							handler.Close();
							isExit = !isExit;
						}
					} 
                }
            }
        }
    }
}
