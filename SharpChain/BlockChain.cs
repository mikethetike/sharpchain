using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpChain
{
    public class BlockChain
    {
        private Block _topBlock;
        private readonly Queue<Transaction> _pendingTransactions;
        private Block _rootBlock;

        public BlockChain()
        {
            _pendingTransactions = new Queue<Transaction>();
            _rootBlock = Block.CreateRootBlock();
        }
        
        public void AddTransaction(Transaction transaction)
        {
            if (VerifyTransaction(transaction))
            {
                _pendingTransactions.Enqueue(transaction);
            }
        }

        private bool VerifyTransaction(Transaction transaction)
        {
            return true;
        }

        public Block GetCurrentBlock()
        {
            return _topBlock;
        }

        public void AddBlock(byte[] parent, Block block)
        {
            if (_topBlock.Hash != parent)
            {
                throw new NotImplementedException();
            }

            if (!VerifyBlock(block))
            {
                throw new NotImplementedException();
            }

            var chainBlock = block.CloneAndAddParent(_topBlock);
            _topBlock = chainBlock;
        }

        private bool VerifyBlock(Block block)
        {
            throw new NotImplementedException();
        }

        public Block BuildBlock(int nonce)
        {
            var block = new Block(_topBlock.Hash, nonce, _pendingTransactions);
            AddBlock(_topBlock.Hash, block);
            return block;
        }
    }
}
