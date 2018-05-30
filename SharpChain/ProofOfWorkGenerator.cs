using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace SharpChain
{
    public class ProofOfWorkGenerator
    {
        private readonly SHA256 _sha256;

        public ProofOfWorkGenerator()
        {
            _sha256 = SHA256.Create();
        }

        public virtual Block FindBlock(BlockBuilder block, int difficulty,
            CancellationToken cancellationToken)
        {
            long nonce = 0;
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                block.Nonce = nonce;
                var candidate = block.CreateCandidate();
                var hash = CreateHash(candidate.PreviousHash, block.MerkleRoot, block.Nonce);

                if (PassesDifficulty(difficulty, hash))
                {
                    candidate.Hash = hash;
                    return candidate;
                }

                nonce++;
            }
        }

        private static bool PassesDifficulty(int difficulty, byte[] hash)
        {
            for (int i = 0; i < difficulty; i++)
            {
                if (hash[i] != 0)
                {
                    return false;
                }
            }

            return true;
        }

        protected virtual byte[] CreateHash(byte[] previousBlock, byte[] merkleRoot, long nonce)
        {
            var toHash = new byte[32 + 32 + sizeof(long)];
            Array.Copy(previousBlock, toHash, 32);
            Array.Copy(merkleRoot, 0, toHash, 32, 32);
            Array.Copy(BitConverter.GetBytes(nonce), 0, toHash, 64, sizeof(long));
            return _sha256.ComputeHash(toHash);
        }
    }
}