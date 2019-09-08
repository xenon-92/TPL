using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL_CancellationToken
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = new CancellationTokenSource();
            try
            {
                var t1 = Task.Factory.StartNew(()=> { DosomeImportantWork(1, 1500, source.Token); }).ContinueWith((prev)=> { DosomeOtherImportantWork(1,3000, source.Token); });
                var t2 = Task.Factory.StartNew(() => DosomeImportantWork(2, 3000, source.Token)).ContinueWith((prev) => DosomeOtherImportantWork(2, 1500, source.Token));
                var t3 = Task.Factory.StartNew(() => DosomeImportantWork(3, 1000,source.Token)).ContinueWith((prev) => DosomeOtherImportantWork(3, 2000,source.Token));
                Thread.Sleep(1500);//to check how the thread work, with changing cancelltion token
                source.Cancel();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.GetType());
            }
            Console.WriteLine("press any key");
            Console.ReadKey();
        }
        static void DosomeImportantWork(int id, int sleeptime,CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine("CancellationRequested");
                cancellationToken.ThrowIfCancellationRequested();
            }
            Console.WriteLine("task {0} is beginning", id);
            Thread.Sleep(sleeptime);
            Console.WriteLine("task {0} has ended", id);
        }
        static void DosomeOtherImportantWork(int id, int sleeptime, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine("CancellationRequested");
                cancellationToken.ThrowIfCancellationRequested();
            }
            Console.WriteLine("task {0} is beginning other work", id);
            Thread.Sleep(sleeptime);
            Console.WriteLine("task {0} has ended the other work", id);
        }
    }
}
