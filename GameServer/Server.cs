using System.Net;
using System.Net.Sockets;
using System.Text;
using System;
using System.Threading;
using GameServer.Unit;

class Server
{
    static void Main()
    {
        try
        {
            AbstractConnectUnit unit = new LoginUnit();
            unit.StartLisen();
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: " + e);
        }

        Console.WriteLine("\n伺服器已關閉...");
        Console.ReadLine();
    }
}
