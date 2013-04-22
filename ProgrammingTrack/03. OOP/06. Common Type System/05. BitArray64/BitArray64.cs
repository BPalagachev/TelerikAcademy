using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _05.BitArray64
{
    // Task 4 - Define a class BitArray64 to hold 64 bit values inside an ulong value.
    // Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.
    public class BitArray64 : IEnumerable<int>
    {
        public const int Capacity = 64;
        private ulong bitStorage;

        public BitArray64(ulong value)
        {
            this.bitStorage = value;
        }

        public ulong BitStorage
        {
            get
            {
                return this.bitStorage;
            }
        }

        public int this[int i]
        {
            get
            {
                if ((this.bitStorage & (1ul << i)) != 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            set
            {
                if (value == 0)
                {
                    this.bitStorage = this.bitStorage & ~(1ul << i);
                }
                else if (value == 1)
                {
                    this.bitStorage = this.bitStorage | (1ul << i);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("The only allowed bit values are 1 or 0!");
                }
            }
        }

        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !first.Equals(second);
        }

        public static BitArray64 Parse(string binaryValue)
        {
            ulong ulongRepresentation = 0;
            if (binaryValue.Length >= 64)
            {
                throw new ArgumentOutOfRangeException("String binaryValue must not be longer then 64 symbols!");
            }

            int bitPosition = 0;
            foreach (char bit in binaryValue)
            {
                if (!(bit == '0' || bit == '1'))
                {
                    throw new ArgumentException("String binaryValue must only contain values 1 or zero!");
                }

                if (bit == '1')
                {
                    ulongRepresentation = ulongRepresentation | (1ul << bitPosition);
                }

                bitPosition++;
            }

            return new BitArray64(ulongRepresentation);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = Capacity - 1; i >= 0; i--)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is BitArray64))
            {
                throw new ArgumentException("One BitArray64 can be only compared to another istance of the same class!");
            }

            BitArray64 tempArray = obj as BitArray64;

            for (int i = 0; i < BitArray64.Capacity; i++)
            {
                if (this[i] != tempArray[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = 1;
            foreach (var item in this)
            {
                hashCode += item.GetHashCode();
            }

            return hashCode;
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            foreach (int item in this)
            {
                info.Append(item);
            }

            return info.ToString();
        }
    }
}
