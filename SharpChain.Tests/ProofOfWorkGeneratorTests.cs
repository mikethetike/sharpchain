using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace SharpChain.Tests
{
    public class ProofOfWorkGeneratorTests
    {
        [TestCase(1, 17)]
        [TestCase(2, 62634)]
        [TestCase(3, 15237991)]
        public void TestFindNonce(int difficulty, long expected)
        {
            throw new NotImplementedException();
            var generator = new ProofOfWorkGenerator();
            //var nonce = generator.FindBlock(new byte[256], new byte[256], difficulty, CancellationToken.None).Result;
            //nonce.Should().Be(expected);
        }
    }
}
