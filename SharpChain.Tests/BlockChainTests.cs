using System;
using System.Collections.Generic;
using System.Text;

namespace SharpChain.Tests
{
    class BlockChainTests
    {

        public void AddNewBlock()
        {
            var blockChain = new BlockChain();
            var nonce = 1;
            var block = blockChain.BuildBlock(nonce);
        }
    }
}
