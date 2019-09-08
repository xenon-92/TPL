using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var t1 = new Task(() => DosomeImportantWork(1, 1500));
            t1.Start();
            var t2 = new Task(() => DosomeImportantWork(2, 3000));
            t2.Start();
            var t3 = new Task(() => DosomeImportantWork(3, 1000));
            t3.Start();            
            Console.ReadKey();
            
        }
        static void DosomeImportantWork(int id,int sleeptime)
        {
            Console.WriteLine("task {0} is beginning",id);
            Thread.Sleep(sleeptime);
            Console.WriteLine("task {0} has ended",id);
        }
    }

    
}
