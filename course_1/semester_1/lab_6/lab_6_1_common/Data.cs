using lab_4_1_common;
using System.Runtime.Serialization;

namespace lab_6_1_common
{
    [DataContract]
    public class Data
    {
        [DataMember]
        public TestType[] Values;
    }
}
