using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL_ContinueWith_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = Task.Factory.StartNew(() => DosomeImportantWork(1, 1500)).ContinueWith((prev)=> DosomeOtherImportantWork(1,3000));
            var t2 = Task.Factory.StartNew(() => DosomeImportantWork(2, 3000)).ContinueWith((prev) => DosomeOtherImportantWork(2, 1500));
            var t3 = Task.Factory.StartNew(() => DosomeImportantWork(3, 1000)).ContinueWith((prev) => DosomeOtherImportantWork(3, 2000));
            Console.WriteLine("press any key");
            Console.ReadKey();
        }
        static void DosomeImportantWork(int id, int sleeptime)
        {
            Console.WriteLine("task {0} is beginning", id);
            Thread.Sleep(sleeptime);
            Console.WriteLine("task {0} has ended", id);
        }
        static void DosomeOtherImportantWork(int id, int sleeptime)
        {
            Console.WriteLine("task {0} is beginning other work", id);
            Thread.Sleep(sleeptime);
            Console.WriteLine("task {0} has ended the other work", id);
        }
    }
}
