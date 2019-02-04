using System.Runtime.Serialization;

namespace lab_4_2
{
    [DataContract]
    class Matrix<T>
    {
        public Matrix(uint rows, uint columns)
        {
            this.columns = columns;
            data = new T[rows * columns];
        }

        public uint Rows
        {
            get
            {
                uint length = (uint)data.Length;
                return length / columns;
            }
        }

        public uint Columns
        {
            get
            {
                return columns;
            }
        }

        public T this[uint row, uint column]
        {
            get
            {
                return data[AbsoluteIndex(row, column)];
            }

            set
            {
                data[AbsoluteIndex(row, column)] = value;
            }
        }

        protected uint AbsoluteIndex(uint row, uint column)
        {
            return row * columns + column;
        }

        [DataMember]
        private uint columns;

        [DataMember]
        private T[] data;
    };
}
