using System;
using lab_4_1_common;

namespace lab_4_1_a
{
    class Program
    {
        static void Main(string[] args)
        {
            var values = Utility.MakeRandomArray();
            Console.WriteLine("Find biggest value and move it to the end of array");
            Utility.PrintArray("Initial array: ", values);
            Utility.MoveLastMaxBack(values);
            Utility.PrintArray("Modified array: ", values);
        }
    }
}
