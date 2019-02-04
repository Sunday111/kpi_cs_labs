using lab_4_1_common;
using lab_6_1_common;

namespace lab_6_1_b
{
    class Program
    {
        static readonly string InputFileName = "input.json";
        static readonly string OutputFileName = "output.json";

        static void Main(string[] args)
        {
            System.Console.WriteLine("Swap two biggest values in array");
            var data = Utility.ReadOrMakeDefault(InputFileName, DataMaker.MakeRandomData);
            Utility.PrintArray("Initial array: ", data.Values);
            Utility.SwapTwoBiggest(data.Values);
            Utility.PrintArray("Modified array: ", data.Values);
            Utility.SaveJSON(data, OutputFileName);
        }
    }
}
