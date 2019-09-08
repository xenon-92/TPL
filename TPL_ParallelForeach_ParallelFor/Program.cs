using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPL_ParallelForeach_ParallelFor
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * The Parallel function are thread blocking and and only after the work is done
             * it goes back to the next line for execution
             * **/
            List<int> ints = new List<int> { 1, 12, 124, 45, 16, 17, 18, 0, 21, 23, 14, 45, 56 };
            ParallelLoopResult p = Parallel.ForEach(ints, (i) =>
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                    
                }

            });
            Console.WriteLine(p.IsCompleted);
            Console.WriteLine("Parallel.ForEach is a thread blocking code");
            ParallelLoopResult pFor = Parallel.For(0, 100, (i) => {
                if (i%2==0)
                {
                    Console.WriteLine(i);
                }
            });
            Console.WriteLine("Parallel.For is a thread blocking code");
            Console.ReadKey();
        }
    }
}
