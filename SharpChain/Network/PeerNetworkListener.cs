using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Miner
{
    class PeerNetworkListener
    {
        private readonly int _port;
        private readonly IMessageHandler _handler;

        public PeerNetworkListener(int port, IMessageHandler handler)
        {
            _port = port;
            _handler = handler;
        }

        public async Task StartAsync(CancellationToken token)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, _port);

            while (!token.IsCancellationRequested)
            {
                var client = await listener.AcceptTcpClientAsync();
                NewClient(client);
            }
            

        }

        private void NewClient(TcpClient client)
        {
            var message = MessageParser.Parse(client.GetStream());
            
            switch (message.Type)
            {
               case (byte) Messages.SendTransaction:
                   _handler.NewTransaction((SendTransactionMessage)message);
                   break;
               default:
                   throw  new NotImplementedException();
            }
        }

    
    }
}
