using lab_4_1_common;
using System;

namespace lab_6_1_common
{
    public class DataMaker
    {
        public static Data MakeRandomData()
        {
            var data = new Data();
            var r = new Random();
            var n = (uint)r.Next((int)Constants.MinArraySize, (int)Constants.MaxArraySize);
            data.Values = Utility.MakeRandomArray(r, n, Constants.MinArrayValue, Constants.MaxArrayValue);
            return data;
        }
    }
}
