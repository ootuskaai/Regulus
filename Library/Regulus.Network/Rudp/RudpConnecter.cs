using System;
using System.Net;
using System.Net.Sockets;
using Regulus.Network.RUDP;

namespace Regulus.Network
{
    public class RudpConnecter : IPeerConnectable
    {
        private readonly Agent _Agent;
        private IRudpPeer _RudpPeer;

        public RudpConnecter(Regulus.Network.RUDP.Agent agent)
        {
            _Agent = agent;
        }
        EndPoint IPeer.RemoteEndPoint
        {
            get { return _RudpPeer.EndPoint; }
        }

        EndPoint IPeer.LocalEndPoint
        {
            get { return _RudpPeer.EndPoint; }
        }

        bool IPeer.Connected
        {
            get { return _RudpPeer.Status == PEER_STATUS.TRANSMISSION; }
        }

        void IPeer.Receive(byte[] readed_byte, int offset, int count, Action<int, SocketError> readed)
        {
            _RudpPeer.Receive(readed_byte , offset , count , readed);
        }

        void IPeer.Send(byte[] buffer, int offset_i, int buffer_length, Action<int, SocketError> write_completion)
        {
            _RudpPeer.Send(buffer , offset_i , buffer_length , write_completion);
        }

        void IPeer.Close()
        {
            _RudpPeer.Disconnect();
        }

        void IPeerConnectable.Connect(EndPoint endpoint, Action<bool> result)
        {
            _RudpPeer = _Agent.Connect(endpoint,result);
            
        }
    }
}