namespace Miner
{
    public interface IMessageHandler
    {
        void NewTransaction(SendTransactionMessage message);
    }
}