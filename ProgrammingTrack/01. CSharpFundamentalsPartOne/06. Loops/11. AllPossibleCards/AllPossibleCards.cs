using System;

class AllPossibleCards
{
    static void Main()
    {
        string[] cards = new string[] { "Deuce", "Three", "Four", "Five" , "Six", "Seven" , "Eight" , "Nine", "Ten", "Jack", "Queen", "King", "Ace" };
        string[] colors = new string[] { "spades", "diamons", "clubs", "hearths"};

        foreach (string color in colors)
        {
            switch (color)
            {
                case "spades":
                case "clubs":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "diamons":
                case "hearths":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
            foreach (string card in cards)
            {
                Console.WriteLine("{0} of {1}", card , color);
            }
        }
    }
}