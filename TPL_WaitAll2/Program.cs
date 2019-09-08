using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL_WaitAll2
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = DateTime.Now;
            var t1 = Task.Factory.StartNew(() => DosomeImportantWork(1, 1500));
            var t2 = Task.Factory.StartNew(() => DosomeImportantWork(2, 3000));
            var t3 = Task.Factory.StartNew(() => DosomeImportantWork(3, 1000));

            //doing some independent work
            Independent id = new Independent();
            var t4 = Task.Factory.StartNew(()=>id.Do());
            //and after all the independent work is done continue with the below work
            Task.WaitAll(new[] {t1,t2,t3,t4 });
            Console.WriteLine(DateTime.Now-dt);
            Console.WriteLine("press any key");
            Console.ReadKey();
        }
        static void DosomeImportantWork(int id, int sleeptime)
        {
            Console.WriteLine("task {0} is beginning", id);
            Thread.Sleep(sleeptime);
            Console.WriteLine("task {0} has ended", id);
        }
    }
    class Independent
    {
        public void Do()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Doing some independent work for {0}", i);
                Thread.Sleep(100);
                Console.WriteLine("Work {0} has been done", i);
            }
        }
    }
}
