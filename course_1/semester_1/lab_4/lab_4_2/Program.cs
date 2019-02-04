using System;

namespace lab_4_2
{
    class Program
    {
        static readonly uint Rows = 12;
        static readonly uint Columns = 12;
        static readonly int MinRandomValue = 1;
        static readonly int MaxRandomValue = 5;

        static Matrix<int> MakeRandomMatrix()
        {
            var random = new Random();
            var result = new Matrix<int>(Rows, Columns);

            for (uint row = 0; row < result.Rows; ++row)
            {
                for (uint column = 0; column < result.Columns; ++column)
                {
                    result[row, column] = random.Next(MinRandomValue, MaxRandomValue);
                }
            }

            return result;
        }

        static void PrintMatrix(Matrix<int> m)
        {
            for (uint row = 0; row < m.Rows; ++row)
            {
                for (uint column = 0; column < m.Columns; ++column)
                {
                    Console.Write("{0, 5} ", m[row, column]);
                }

                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            var m = MakeRandomMatrix();
            PrintMatrix(m);

            double k = 1;
            for (uint row = 0; row < m.Rows; ++row)
            {
                for (uint column = m.Rows - row - 1; column < m.Columns; ++column)
                {
                    k *= m[row, column];
                }
            }

            Console.WriteLine("Answer: {0}", k);
        }
    }
}
