using System;

class ThreeDMAXWalk
{
    static void Main()
    {
        string demention = Console.ReadLine();
        string[] dementions = demention.Split(' ');
        int width = int.Parse(dementions[0]);
        int height = int.Parse(dementions[1]);
        int depth = int.Parse(dementions[2]);

        int[, ,] cube = new int[width, height, depth];
        for (int h = 0; h < height; h++)
        {
            string[] input = Console.ReadLine().Split('|');
            for (int d = 0; d < depth; d++)
            {
                string[] number = input[d].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int w = 0; w < width; w++)
                {
                    cube[w, h, d] = int.Parse(number[w]);
                }
            }
        }

        bool[, ,] beenThreDoneThat = new bool[width, height, depth];

        int maxSum = Int32.MinValue;
        int currentWidth = width / 2;
        int currentHeight = height / 2;
        int currentDepth = depth / 2;

        int globalSum = cube[currentWidth, currentHeight, currentDepth];

        int lastWidth = 0;
        int lastHeight = 0;
        int lastDepth = 0;

        while (true)
        {
            // check width
            int counter = 0;
            maxSum = Int32.MinValue;

            for (int i = 0; i < width; i++)
            {
                if (i == currentWidth)
                {
                    continue;
                }
                if (cube[i, currentHeight, currentDepth] > maxSum)
                {
                    maxSum = cube[i, currentHeight, currentDepth];
                    counter = 1;

                    lastWidth = i;
                    lastHeight = currentHeight;
                    lastDepth = currentDepth;
                }
                else if (cube[i, currentHeight, currentDepth] == maxSum)
                {
                    counter++;
                }
            }
            // check height
            for (int i = 0; i < height; i++)
            {
                if (i == currentHeight)
                {
                    continue;
                }
                if (cube[currentWidth, i, currentDepth] > maxSum)
                {
                    maxSum = cube[currentWidth, i, currentDepth];
                    counter = 1;

                    lastWidth = currentWidth;
                    lastHeight = i;
                    lastDepth = currentDepth;
                }
                else if (cube[currentWidth, i, currentDepth] == maxSum)
                {
                    counter++;
                }
            }
            // check depth
            for (int i = 0; i < depth; i++)
            {
                if (i == currentDepth)
                {
                    continue;
                }
                if (cube[currentWidth, currentHeight, i] > maxSum)
                {
                    maxSum = cube[currentWidth, currentHeight, i];
                    counter = 1;

                    lastWidth = currentWidth;
                    lastHeight = currentHeight;
                    lastDepth = i;
                }
                else if (cube[currentWidth, currentHeight, i] == maxSum)
                {
                    counter++;
                }
            }

            if (counter > 1)
            {
                // done
                Console.WriteLine(globalSum);
                return;
            }
            else
            {
                currentWidth = lastWidth;
                currentHeight = lastHeight;
                currentDepth = lastDepth;
            }
            if (beenThreDoneThat[currentWidth, currentHeight, currentDepth])
            {
                // done
                Console.WriteLine(globalSum);
                return;
            }
            else
            {
                beenThreDoneThat[currentWidth, currentHeight, currentDepth] = true;
                globalSum += cube[currentWidth, currentHeight, currentDepth];

            }
        }



    }
}