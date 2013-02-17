using System;

class EnglishPronunciation
{
    static void Main()
    {
        string[] lowNumbers = { "","one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen" };
        string[] decimals = { "twenty ", "thirty " };
        string ty = "ty ";
        string teen = "teen ";

        int number = int.Parse(Console.ReadLine());
        int reminder1, reminder2, reminder3;
        string pronun = "";

        reminder1 = number % 10;
        number /= 10;
        reminder2 = number % 10;
        number /= 10;
        reminder3 = number % 10;
        number /= 10;


        switch (reminder2)
        {
            case 0:
                pronun = lowNumbers[reminder1];
                break;
            case 1:
                switch (reminder1)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        pronun = lowNumbers[reminder1 + 10];
                        break;
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                        pronun = lowNumbers[reminder1] + teen;
                        break;

                }
                break;
            case 2:
                pronun = decimals[0];
                pronun = pronun + lowNumbers[reminder1];
                break;
            case 3: 
                pronun = decimals[1];
                pronun = pronun + lowNumbers[reminder1];
                break;
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
                pronun = lowNumbers[reminder2] + ty;
                pronun = pronun + lowNumbers[reminder1];
                break;
        }

        switch (reminder3)
        {
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
                pronun = lowNumbers[reminder3] + " hundred and " + pronun;
                if (reminder1 == 0  && reminder2 == 0)
                {
                    pronun = lowNumbers[reminder3] + " hundred";
                }
                break;

        }
        if (reminder1 == 0 && reminder2 == 0 && reminder3 == 0)
        {
            pronun = "zero";
        }
        Console.WriteLine(pronun);

    }
}
