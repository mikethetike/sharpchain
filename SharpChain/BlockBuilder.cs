using System;
using System.Collections.Generic;
using System.Text;

namespace SharpChain
{
    public class BlockBuilder
    {
        private MerkleTree _transactionTree;
        public byte[] LastBlockHash { get; }

        public BlockBuilder(byte[] lastBlockHash)
        {
            LastBlockHash = lastBlockHash;
            _transactionTree = new MerkleTree();
        }

        public byte[] MerkleRoot => new byte[32];
        public long Nonce { get; set; }


        public void AddTransaction(Transaction transaction)
        {
            _transactionTree.Add(transaction);
        }

        public Block CreateCandidate()
        {
            return new Block(LastBlockHash, Nonce);
        }
    }

    public class MerkleTree
    {
        public void Add(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
