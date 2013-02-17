// Write a program to calculate n! for each n in the range [1..100]. 
// Hint: Implement first a method that multiplies a number represented
// as array of digits by given integer number. 

using System;
using System.Text;

class Factorial100
{
    static void Main()
    {
        LargeNumber number = new LargeNumber(Console.ReadLine());

        Console.WriteLine("Factorial of {0} is: {1}", number.ToString(), Factorial(number).ToString());

    }
    static LargeNumber Factorial(LargeNumber number)
    {
        LargeNumber factorial = new LargeNumber("1");
        LargeNumber zero = new LargeNumber("0");
        LargeNumber one = new LargeNumber("1");
        while (number != zero)
        {
            factorial *= number;
            number -= one;
        }
        return factorial;
    }

}
class LargeNumber
{
    // adds, substracts and multiplies numbers with 10000 digits. Uses overwritten + , -
    const int LargeNumberSize = 10001;

    private sbyte[] arrayRepresentation;
    private int length;
    private bool isPositive = true;


    public LargeNumber(string stringRepresentation)
    {
        this.length = stringRepresentation.Length;
        this.arrayRepresentation = new sbyte[LargeNumberSize];
        int index = 0;
        for (int i = stringRepresentation.Length - 1; i >= 0; i--)
        {
            if (stringRepresentation[i] == '-')
            {
                this.length--;
                isPositive = false;
                break;
            }
            this.arrayRepresentation[this.arrayRepresentation.Length - 1 - index] = (sbyte)(stringRepresentation[i] - '0');
            index++;
        }
    }
    public LargeNumber()
        : this("")
    {
    }

    public override string ToString()
    {
        StringBuilder stringRepresentation = new StringBuilder();
        for (int i = this.arrayRepresentation.Length - this.length; i < this.arrayRepresentation.Length; i++)
        {
            stringRepresentation.Append(this.arrayRepresentation[i]);
        }
        if (!this.isPositive)
        {
            return "-" + stringRepresentation.ToString();
        }
        return stringRepresentation.ToString();
    }
    static private LargeNumber AddLargeNumbers(LargeNumber firstLargeNumber, LargeNumber secondLargeNumber)
    {
        LargeNumber result = new LargeNumber();
        bool oneInMind = false;
        for (int i = LargeNumberSize - 1; i > 0; i--)
        {
            int sum = firstLargeNumber.arrayRepresentation[i] + secondLargeNumber.arrayRepresentation[i];
            if (!oneInMind)
            {
                result.arrayRepresentation[i] = (sbyte)(sum % 10);

            }
            else
            {
                result.arrayRepresentation[i] = (sbyte)(sum % 10 + 1);
            }
            if (sum >= 10)
            {
                oneInMind = true;
            }
            else
            {
                oneInMind = false;
            }
        }
        result.length = GetLength(result);
        return result;
    }
    static private LargeNumber SubstractLargeNumbers(LargeNumber firstLargeNumber, LargeNumber secondLargeNumber)
    {
        LargeNumber result = new LargeNumber();
        for (int i = LargeNumberSize - 1; i > 0; i--)
        {
            int substraction = firstLargeNumber.arrayRepresentation[i] - secondLargeNumber.arrayRepresentation[i];

            if (substraction < 0)
            {
                substraction += 10;
                result.arrayRepresentation[i - 1] -= 1;
            }
            result.arrayRepresentation[i] += (sbyte)(substraction % 10);
        }
        result.length = GetLength(result);
        return result;
    }
    static private LargeNumber MultiplyLargeNumbers(LargeNumber firstLargeNumber, LargeNumber secondLargeNumber)
    {

        LargeNumber result = new LargeNumber();
        int overflow = 0;
        for (int j = 0; j < secondLargeNumber.length; j++)
        {
            LargeNumber temp = new LargeNumber();
            for (int i = LargeNumberSize - 1; i >= LargeNumberSize - firstLargeNumber.length - 1; i--)
            {
                int multiplication = firstLargeNumber.arrayRepresentation[i] * secondLargeNumber.arrayRepresentation[LargeNumberSize - 1 - j];
                multiplication += overflow;
                temp.arrayRepresentation[i - j] += (sbyte)(multiplication % 10);
                if (multiplication > 9)
                {
                    multiplication /= 10;
                    overflow = (sbyte)(multiplication % 10);
                }
                else
                {
                    overflow = 0;
                }

            }
            result = AddLargeNumbers(result, temp);
        }

        result.length = GetLength(result);
        return result;
    }
    static private int GetLength(LargeNumber number)
    {
        int numberOfLeadingZeros = 0;
        while (number.arrayRepresentation[numberOfLeadingZeros] == 0)
        {
            if (numberOfLeadingZeros > LargeNumberSize - 2)
            {
                break;
            }
            numberOfLeadingZeros++;
        }
        return LargeNumberSize - numberOfLeadingZeros;
    }

    static public LargeNumber GetMaxAbs(LargeNumber firstLargeNumber, LargeNumber secondLargeNumber)
    {
        LargeNumber n1 = new LargeNumber(firstLargeNumber.ToString());
        n1.isPositive = true;
        LargeNumber n2 = new LargeNumber(secondLargeNumber.ToString());
        n2.isPositive = true;
        if (n1 > n2)
        {
            return firstLargeNumber;
        }
        else if (n1 < n2)
        {
            return secondLargeNumber;
        }
        else
        {
            return firstLargeNumber;
        }
    }
    static public LargeNumber GetMinAbs(LargeNumber firstLargeNumber, LargeNumber secondLargeNumber)
    {
        LargeNumber n1 = new LargeNumber(firstLargeNumber.ToString());
        n1.isPositive = true;
        LargeNumber n2 = new LargeNumber(secondLargeNumber.ToString());
        n2.isPositive = true;
        if (n1 < n2)
        {
            return firstLargeNumber;
        }
        else if (n1 > n2)
        {
            return secondLargeNumber;
        }
        else
        {
            return firstLargeNumber;
        }

    }

    static public bool operator >(LargeNumber n1, LargeNumber n2)
    {
        if (n1.isPositive != n2.isPositive)
        {
            return n1.isPositive ? true : false;
        }
        int index = 0;
        while (n1.arrayRepresentation[index] == n2.arrayRepresentation[index])
        {
            index++;
            if (index == LargeNumberSize)
            {
                return false;
            }
        }
        if (n1.arrayRepresentation[index] > n2.arrayRepresentation[index])
        {
            return true;
        }
        return false;
    }
    static public bool operator <(LargeNumber n1, LargeNumber n2)
    {
        if (n1.isPositive != n2.isPositive)
        {
            return n1.isPositive ? false : true;
        }
        int index = 0;
        while (n1.arrayRepresentation[index] == n2.arrayRepresentation[index])
        {
            index++;
            if (index == LargeNumberSize)
            {
                return false;
            }
        }
        if (n1.arrayRepresentation[index] < n2.arrayRepresentation[index])
        {
            return true;
        }
        return false;
    }
    static public bool operator ==(LargeNumber n1, LargeNumber n2)
    {
        int index = 0;
        while (n1.arrayRepresentation[index] == n2.arrayRepresentation[index])
        {
            index++;
            if (index == LargeNumberSize)
            {
                return true;
            }
        }
        return false;
    }
    static public bool operator !=(LargeNumber n1, LargeNumber n2)
    {
        int index = 0;
        while (n1.arrayRepresentation[index] == n2.arrayRepresentation[index])
        {
            index++;
            if (index == LargeNumberSize)
            {
                return false;
            }
        }
        return true;
    }
    static public LargeNumber operator +(LargeNumber n1, LargeNumber n2)
    {
        LargeNumber result = new LargeNumber();
        if (n1.isPositive && n2.isPositive)
        {
            return AddLargeNumbers(n1, n2);
        }
        else if (!n1.isPositive && !n2.isPositive)
        {
            result = AddLargeNumbers(n1, n2);
            result.isPositive = false;
            return result;
        }
        else
        {
            bool sign = GetMaxAbs(n1, n2).isPositive;
            result = SubstractLargeNumbers(GetMaxAbs(n1, n2), GetMinAbs(n1, n2));
            result.isPositive = sign;
            return result;
        }
    }
    static public LargeNumber operator -(LargeNumber n1, LargeNumber n2)
    {

        LargeNumber temp = new LargeNumber();
        if (n1.isPositive && n2.isPositive)
        {
            temp = new LargeNumber(n2.ToString());
            temp.isPositive = false;
            return n1 + temp;
        }
        else if (!n1.isPositive && !n2.isPositive)
        {
            temp = new LargeNumber(n2.ToString());
            temp.isPositive = true;
            return n1 + temp;
        }
        else
        {
            if (!n2.isPositive)
            {
                temp = new LargeNumber(n2.ToString());
                temp.isPositive = true;
                return n1 + temp;
            }
            else if (!n1.isPositive)
            {
                temp = new LargeNumber(n1.ToString());
                temp.isPositive = true;
                temp = temp + n2;
                temp.isPositive = false;
                return temp;
            }
        }
        return null;
    }
    static public LargeNumber operator *(LargeNumber n1, LargeNumber n2)
    {
        LargeNumber temp = MultiplyLargeNumbers(n1, n2);
        if ((n1.isPositive && n2.isPositive) || (!n1.isPositive && !n2.isPositive))
        {
            return temp;
        }
        temp.isPositive = false;
        return temp;
    }

}