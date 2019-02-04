using System;
using lab_4_1_common;

namespace lab_4_1_b
{
    class Program
    {
        static void Main(string[] args)
        {
            var values = Utility.MakeRandomArray();
            Console.WriteLine("Swap two biggest values in array");
            Utility.PrintArray("Initial array: ", values);
            Utility.SwapTwoBiggest(values);
            Utility.PrintArray("Modified array: ", values);
        }
    }
}
