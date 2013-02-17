using System;
using System.Collections.Generic;
using System.Linq;

class Employees
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        string[] priority = new string[N];
        for (int i = 0; i < N; i++)
        {
            priority[i] = Console.ReadLine();
        }
        int M = int.Parse(Console.ReadLine());
        string[] employeeList = new string[M];
        for (int i = 0; i < M; i++)
        {
            employeeList[i] = Console.ReadLine();
        }

        SortedDictionary<string, int> ratePros = new SortedDictionary<string, int>();
        for (int i = 0; i < priority.Length; i++)
        {
            //string[] temp = priority[i].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            string glupust = priority[i];
            string[] temp = MySplit(priority[i]);
            if (!ratePros.ContainsKey(temp[0].Trim()))
            {
                ratePros.Add(temp[0].Trim(), int.Parse(temp[1]));
            }



        }
        SortedDictionary<string, string> namePos = new SortedDictionary<string, string>();
        for (int i = 0; i < employeeList.Length; i++)
        {
            //string[] temp = employeeList[i].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            string[] temp = MySplit(employeeList[i]);
            namePos.Add(temp[0].Trim(), temp[1].Trim());

        }
        SortedDictionary<string, int> ranks = new SortedDictionary<string, int>();

        foreach (var item in namePos)
        {
            if (ratePros.ContainsKey(item.Value))
            {
                ranks.Add(item.Key, ratePros[item.Value]);
            }

            //ranks.Add(ratePros[item.Value], item.Key);
        }
        //Console.WriteLine(new string('-', 30));

        var sorted = ranks.OrderByDescending(k => k.Value).ThenBy(p => p.Key.Split(' ')[1]).ThenBy(p => p.Key.Split(' ')[0]);
        foreach (var item in sorted)
        {
            Console.WriteLine(item.Key);
            //Console.WriteLine("{0} - {1}",item.Key, item.Value);
        }

    }
    static string[] MySplit(string line)
    {
        int index = 0;
        for (int i = line.Length - 1; i >= 0; i--)
        {
            if (line[i] == ' ' && line[i - 1] == '-' && line[i - 2] == ' ')
            {
                index = i + 1;
                break;
            }
        }

        return new string[] { line.Substring(0, index - 3), line.Substring(index) };
    }
    static List<int> Merge(List<int> left, List<int> right)
    {
        List<int> result = new List<int>();
        while (left.Count > 0 || right.Count > 0)
        {
            if (left.Count > 0 && right.Count > 0)
            {
                if (left[0] <= right[0])
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }
            else if (left.Count > 0)
            {
                result.Add(left[0]);
                left.RemoveAt(0);
            }
            else if (right.Count > 0)
            {
                result.Add(right[0]);
                right.RemoveAt(0);
            }
        }
        return result;
    }
}