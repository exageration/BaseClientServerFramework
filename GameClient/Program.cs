using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main()
    {
        try
        {
            // 伺服器 IP 位址與埠號
            string serverIp = "20.210.233.93"; // 輸入你的伺服器 IP 位址
            int port = 8001; // 輸入你的伺服器埠號

            // 建立 TcpClient
            TcpClient client = new TcpClient(serverIp, port);
            Console.WriteLine("已連線至伺服器...");

            // 獲取網路串流
            NetworkStream stream = client.GetStream();

            while (true)
            {
                Console.Write("請輸入訊息 (輸入 'exit' 結束): ");
                string message = Console.ReadLine();

                // 將訊息轉換為位元組資料
                byte[] data = Encoding.ASCII.GetBytes(message);

                // 發送資料到伺服器
                stream.Write(data, 0, data.Length);

                // 如果輸入 'exit'，則中斷迴圈並關閉連線
                if (message.ToLower() == "exit")
                    break;
            }

            // 關閉連線
            stream.Close();
            client.Close();
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: " + e);
        }

        Console.WriteLine("\n已斷開連線...");
        Console.ReadLine();
    }
}
