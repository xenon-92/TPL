﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL_WaitAll
{
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = Task.Factory.StartNew(() => DosomeImportantWork(1, 1500));
            var t2 = Task.Factory.StartNew(() => DosomeImportantWork(2, 3000));
            var t3 = Task.Factory.StartNew(() => DosomeImportantWork(3, 1000));
            // now wait for all the task to wait and proceed only when the above task are done
            Task.WaitAll(new[] { t1, t2, t3 });
            //this ensures only when the above task are done the compiler comes to the next line
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
}
