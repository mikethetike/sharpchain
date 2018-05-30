using System;
using System.Threading;
using System.Threading.Tasks;
using SharpChain;

namespace Miner
{
    internal class LoggingProofOfWorkGenerator : ProofOfWorkGenerator
    {
        private int _count;

        public LoggingProofOfWorkGenerator()
        {
            _count = 0;
        }

        public override Block FindBlock(BlockBuilder block, int difficulty,
            CancellationToken token)
        {
            var result = base.FindBlock(block, difficulty, token);
            Console.WriteLine("Nonce found: " + result.Nonce);
            Console.WriteLine("Hash found: " + Convert.ToBase64String(result.Hash));
            return result;
        }

        protected override byte[] CreateHash(byte[] previousBlock, byte[] merkleRoot, long nonce)
        {

            var res = base.CreateHash(previousBlock, merkleRoot, nonce);
            _count++;
            if (_count % 10000 == 0)
            {
                Console.Write(".");
            }

            return res;
        }
    }
}