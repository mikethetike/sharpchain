using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace SharpChain
{
    public class Block
    {
        private readonly ImmutableArray<Transaction> _transactions;
        private const int TransactionsPerBlock = 5;
        public byte[] Hash { get; set; }
        public byte[] PreviousHash { get; }
        public long Nonce { get; set; }

        public Block(byte[] parent, long nonce)
        {
            PreviousHash = parent;
            Nonce = nonce;
            _transactions = new ImmutableArray<Transaction>();
            Hash = new byte[32];
        }

        public Block(byte[] parent, int nonce, Queue<Transaction> pendingTransactions)
        {
            PreviousHash = parent;
            Nonce = nonce;
            _transactions = pendingTransactions.Take(TransactionsPerBlock).ToImmutableArray();
        }
        
        public static Block CreateRootBlock()
        {
            throw new NotImplementedException();
        }

        public Block CloneAndAddParent(Block parent)
        {
            throw new NotImplementedException();

        }
    }
}