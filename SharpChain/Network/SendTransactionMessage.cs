using SharpChain;

namespace Miner
{
    public class SendTransactionMessage : NetworkMessage
    {
        public Transaction Transaction{ get; set; }
    }
}