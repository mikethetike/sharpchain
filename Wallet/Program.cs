using System;
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;
using SharpChain;

namespace Wallet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        
            var client = new SharpChainClient();
            while (true)
            {
                var command = Console.ReadLine().ToLower().Trim();
                if (command == "exit")
                {
                    return;
                }

                if (command == "send")
                {
                    client.SendTransaction("a", "b", 100);
                }
            }
        }
    }

    internal class SharpChainClient
    {
        private List<Peer> _peers;

        public SharpChainClient()
        {
            _peers = new List<Peer>();
        }

        public void SendTransaction(string previousTransactionHash, string address, decimal amount)
        {
            var transaction = new TransactionBuilder();
            
            transaction.AddIn(previousTransactionHash);
            transaction.AddOut(address, amount);
            var message = new SendTransactionMessage(transaction.Build());
            SendToPeers(message);
        }

        private void SendToPeers(SendTransactionMessage message)
        {
            foreach (var VARIABLE in _peers)
            {
                
            }
        }
    }

    internal class Peer
    {
    }

    internal class SendTransactionMessage
    {
        private readonly Transaction _build;

        public SendTransactionMessage(Transaction build)
        {
            _build = build;
        }
    }

    internal class TransactionBuilder
    {
        public void AddIn(string transactionHash)
        {
            
        }

        public void AddOut(string address, decimal amount)
        {
            
        }


        public Transaction Build()
        {
            throw new NotImplementedException();
        }
    }
}
