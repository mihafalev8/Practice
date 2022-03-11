using System;
using System.Collections.Generic;
using System.Linq;

namespace FMA_Task_07
{
    class Program
    {
        private static void Shuffle<T>(IList<T> arr)
        {
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                var rndInd = rnd.Next(0, arr.Count());
                var rndInd2 = rnd.Next(0, arr.Count());
                var temp = arr[rndInd];
                arr[rndInd] = arr[rndInd2];
                arr[rndInd2] = temp;
            }
        }

        private static void Main(string[] args)
        {
            var a = new[] { 19, 12, 2, 4, 34, 9, 81, 12, 8, 11, 54, 63, 2 };
            Shuffle(a);
            Console.WriteLine(string.Join(" ", a));
            Console.ReadKey();
        }
    }
}
