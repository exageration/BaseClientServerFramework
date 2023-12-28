using System.Net.Sockets;
using System.Text;

namespace GameServer.Unit
{
    public class AbstractConnectUnit
    {
        public int Port { get; set; }

        public TcpListener Lisenter { get; set; }

        public void StartLisen()
        {
            Lisenter.Start();
            Console.WriteLine($"server is running...{Port}");
            TcpClient client = Lisenter.AcceptTcpClient();
            Console.WriteLine("Client is connected...");
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

            stream.Close();
            client.Close();
            Lisenter.Stop();
        }
    }
}
