using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class BottledMesseges
{
    class ElementKeyPair
    {
        public string Key { get; set; }
        public char Letter { get; set; }
    }
    class Node
    {
        public string Decoded { get; set; }
        public string Left { get; set; }
    }
    static void Main()
    {
        string msg = Console.ReadLine();
        string key = Console.ReadLine();
        //string msg = "1122"; 
        //string key = "A1B12C11D2";

        List<ElementKeyPair> cipher = BuildeCipher(key);
        List<Node> words = new List<Node>();
        words.Add(new Node { Decoded = "", Left = msg });
        List<string> result = new List<string>();

        int index = 0;
        while (index < words.Count)
        {
            Node currentNode = words[index];
            index++;
            foreach (var pair in cipher)
            {
                if (currentNode.Left.StartsWith(pair.Key))
                {
                    Node newNode = new Node();
                    newNode.Left = currentNode.Left.Remove(0, pair.Key.Length);
                    newNode.Decoded = currentNode.Decoded + pair.Letter.ToString();
                    if (newNode.Left.Length == 0)
                    {
                        result.Add(newNode.Decoded);
                    }
                    else
                    {
                        words.Add(newNode);
                    }
                }

            }
        }
        result.Sort();
        Console.WriteLine(result.Count);
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }


    }

    private static List<ElementKeyPair> BuildeCipher(string key)
    {
        List<ElementKeyPair> cipher = new List<ElementKeyPair>();
        StringBuilder digits = new StringBuilder();
        key += "z";
        char? letter = null;

        foreach (var currentChar in key)
        {
            if (char.IsLetter(currentChar))
            {
                if (letter != null)
                {
                    ElementKeyPair newPair = new ElementKeyPair();
                    newPair.Key = digits.ToString();
                    newPair.Letter = letter.Value;
                    digits.Clear();
                    cipher.Add(newPair);

                }
                letter = currentChar;
            }
            else
            {
                digits.Append(currentChar);
            }
        }
        return cipher;
    }
}