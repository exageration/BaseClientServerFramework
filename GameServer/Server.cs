using System.Net;
using System.Net.Sockets;
using System.Text;
using System;
using System.Threading;

class Server
{
    static void Main()
    {
        try
        {
            // 設定伺服器監聽端口
            int port = 8001;

            // 建立 TcpListener
            TcpListener server = new TcpListener(IPAddress.Any, port);

            // 開始監聽
            server.Start();
            Console.WriteLine($"server is running...{port}");

            // 等待客戶端連線
            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Client is connected...");

            // 獲取網路串流
            NetworkStream stream = client.GetStream();

            while (true)
            {
                // 用來存儲從客戶端接收到的資料
                byte[] data = new byte[1024];
                int bytesReceived = stream.Read(data, 0, data.Length);

                // 將接收到的資料轉換為字串
                string receivedMessage = Encoding.ASCII.GetString(data, 0, bytesReceived);
                Console.WriteLine("收到客戶端訊息: " + receivedMessage);

                // 如果收到特定訊息（例如 "exit"），則中斷迴圈並關閉連線
                if (receivedMessage.ToLower() == "exit")
                    break;
            }

            // 關閉連線
            stream.Close();
            client.Close();
            server.Stop();
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: " + e);
        }

        Console.WriteLine("\n伺服器已關閉...");
        Console.ReadLine();
    }
}
