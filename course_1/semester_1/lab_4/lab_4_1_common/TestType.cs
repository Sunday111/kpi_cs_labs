using System;
using System.Runtime.Serialization;

namespace lab_4_1_common
{
    [DataContract]
    public class TestType : IComparable
    {
        public int CompareTo(object obj)
        {
            var casted = obj as TestType;
            return Value.CompareTo(casted.Value);
        }

        public override string ToString()
        {
            return '{' + Value2.ToString() + ", " + Value.ToString() + '}';
        }

        [DataMember]
        public int Value;

        [DataMember]
        public uint Value2;
    }
}
