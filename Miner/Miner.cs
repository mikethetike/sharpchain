using System;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using SharpChain;

namespace Miner
{
    internal class Miner : IMessageHandler
    {
        private BlockBuilder _block;
        private PeerNetworkListener _peers;

        internal void Run(CancellationToken cancellationToken)
        {
            ConnectToNetwork(cancellationToken);

            var lastBlock = GetBlocks();
            var difficulty = GetDifficulty();

            var miner = new LoggingProofOfWorkGenerator();
                
            _block = new BlockBuilder(lastBlock.Hash);
            
            while (true)
            {
                var block = miner.FindBlock(_block, difficulty, cancellationToken);
                SendBlockToPeers(block);
                _block = new BlockBuilder(block.Hash);
            }
        }

        private void SendBlockToPeers(Block block)
        {
        
        }

        public void NewTransaction(SendTransactionMessage message)
        {
            if (VerifyTransaction(message.Transaction))
            {
                _block.AddTransaction(message.Transaction);
            }
        }

        private bool VerifyTransaction(Transaction transaction)
        {
            return true;
        }

        
        private static int GetDifficulty()
        {
            return 2;
        }

        private static Block GetBlocks()
        {
            return new Block(new byte[32], 0);
        }

        private void ConnectToNetwork(CancellationToken cancellationToken)
        {
            _peers = new PeerNetworkListener(100, this);
            Task.Factory.StartNew(() => _peers.StartAsync(cancellationToken), cancellationToken);
        }
    }
}