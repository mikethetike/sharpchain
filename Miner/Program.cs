using System;
using System.Threading;
using System.Threading.Tasks;
using SharpChain;

namespace Miner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Starting mining");

            var m = new Miner();
            var cancellationSource = new CancellationTokenSource();

            var task = Task.Run(() => m.Run(cancellationSource.Token), cancellationSource.Token);

            Console.ReadLine();

            cancellationSource.Cancel();
            try
            {
                task.Wait(TimeSpan.FromSeconds(20));
            }
            catch (AggregateException e)
            {
                if (e.InnerException is TaskCanceledException)
                {
                    return;
                }

                Console.Error.WriteLine(e);
                Console.ReadLine();
            }
        }

        private static async Task<Transaction> WaitForTransactionAsync(CancellationToken cancellationToken)
        {
            var random = new Random();
            await Task.Delay(TimeSpan.FromSeconds(random.Next(20, 60)), cancellationToken);
            return new Transaction(null, null);
        }

    }
}