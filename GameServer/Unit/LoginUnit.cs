using System.Net.Sockets;
using System.Net;

namespace GameServer.Unit
{
    public class LoginUnit : AbstractConnectUnit
    {
        public LoginUnit() 
        {
            Port = 8001;
            Lisenter = new TcpListener(IPAddress.Any, Port); 
        }
    }
}
