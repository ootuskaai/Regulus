using System;
using System.Net;

namespace Regulus.Network.RUDP
{
    public interface IRecevieable
    {        
        SocketMessage[] Received();        
    }
}