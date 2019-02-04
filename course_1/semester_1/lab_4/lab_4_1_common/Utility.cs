using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace lab_4_1_common
{
    public delegate T MakeDefaultValue<T>();

    public static class Utility
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        public static void PrintArray<T>(string title, T[] arr)
        {
            Console.Write(title);
            foreach (T value in arr)
            {
                Console.Write("{0} ", value);
            }
            Console.WriteLine();
        }

        public static TestType[] MakeRandomArray(Random r, uint length, int minValue, int maxValue)
        {
            var result = new TestType[length];
            for (uint i = 0; i < length; ++i)
            {
                var e = new TestType();
                e.Value = r.Next(minValue, maxValue);
                e.Value2 = i;
                result[i] = e;
            }

            return result;
        }

        public static TestType[] MakeRandomArray()
        {
            var rnd = new Random();
            var length = (uint)rnd.Next((int)Constants.MinArraySize, (int)Constants.MaxArraySize);
            var values = Utility.MakeRandomArray(rnd, length, Constants.MinArrayValue, Constants.MaxArrayValue);
            return values;
        }

        public static uint FindLastMaxValueIndex<T>(T[] arr)
            where T : IComparable
        {
            if (arr.Length < 1)
            {
                throw new ArgumentException();
            }

            uint maxIndex = 0;
            for (uint i = 1; i < arr.Length; ++i)
            {
                if (arr[i].CompareTo(arr[maxIndex]) >= 0)
                {
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        public static void MoveLastMaxBack<T>(T[] arr)
            where T : IComparable
        {
            if (arr.Length > 0)
            {
                var idx = Utility.FindLastMaxValueIndex(arr);
                var last = (uint)arr.Length - 1;
                if (idx != last)
                {
                    Swap(ref arr[idx], ref arr[last]);
                }
            }
        }

        static DataContractJsonSerializer MakeSerializerJSON<T>()
        {
            DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
            settings.UseSimpleDictionaryFormat = true;
            var serializer = new DataContractJsonSerializer(typeof(T), settings);
            return serializer;
        }

        public static T ReadJSON<T>(string filename)
        {
            using (var file = File.Open(filename, FileMode.Open))
            {
                var serializer = MakeSerializerJSON<T>();
                return (T)serializer.ReadObject(file);
            }
        }

        public static void SaveJSON<T>(T value, string filename)
        {
            using (var file = File.Open(filename, FileMode.OpenOrCreate))
            {
                using (var writer = JsonReaderWriterFactory.CreateJsonWriter(file, Encoding.UTF8, ownsStream: true, indent: true, indentChars: "  "))
                {
                    var serializer = MakeSerializerJSON<T>();
                    serializer.WriteObject(writer, value);
                }
            }
        }

        public static T ReadOrMakeDefault<T>(string filename, MakeDefaultValue<T> valueMaker)
        {
            if (File.Exists(filename))
            {
                return Utility.ReadJSON<T>(filename);
            }

            return valueMaker();
        }

        public static void SwapTwoBiggest<T>(T[] arr)
            where T : IComparable
        {
            if (arr.Length < 2)
            {
                throw new ArgumentException();
            }

            var copy = new T[arr.Length];
            Array.Copy(arr, copy, arr.Length);
            Array.Sort(copy);
            var a = copy[copy.Length - 1];
            var b = copy[copy.Length - 2];
            var k = a.CompareTo(b) == 0 ? a : b;
            var i1 = Array.IndexOf(arr, a);
            var i2 = Array.LastIndexOf(arr, k);
            Swap(ref arr[i1], ref arr[i2]);
        }
    }
}
