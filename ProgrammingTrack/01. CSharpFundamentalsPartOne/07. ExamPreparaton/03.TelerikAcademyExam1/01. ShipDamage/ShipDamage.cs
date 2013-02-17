using System;
using System.Text;
using System.Threading;
using System.Globalization;

class ShipDamage
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        int damage = 0;

        int Sx1 = int.Parse(Console.ReadLine());
        int Sy1 = int.Parse(Console.ReadLine());
        int Sx2 = int.Parse(Console.ReadLine());
        int Sy2 = int.Parse(Console.ReadLine());

        int H = int.Parse(Console.ReadLine());

        int[] Cx = new int[3];
        int[] Cy = new int[3];
        for (int i = 0; i < 3; i++)
        {
            Cx[i] = int.Parse(Console.ReadLine());
            Cy[i] = int.Parse(Console.ReadLine());
        }

        int XLarger = (Sx1 >= Sx2 ? Sx1 : Sx2);
        int XSmaller = (Sx1 < Sx2 ? Sx1 : Sx2);

        int YLarger = (Sy1 >= Sy2 ? Sy1 : Sy2);
        int YSmaller = (Sy1 < Sy2 ? Sy1 : Sy2);

        YLarger = YLarger - H;
        YSmaller = YSmaller - H;

        for (int i = 0; i < 3; i++)
        {
            Cy[i] = H -Cy[i];
        }
       

        for (int i = 0; i < 3; i++)
        {
            if (Cx[i] < XLarger && Cx[i] > XSmaller && Cy[i] < YLarger && Cy[i] > YSmaller)
            {
                damage += 100;
            }
            else if ( (Cx[i] == XLarger || Cx[i] == XSmaller) && (Cy[i] == YSmaller || Cy[i] == YLarger) )
            {
                damage += 25;
            }
            else if ((Cx[i] < XLarger && Cx[i] > XSmaller) && (Cy[i] == YSmaller || Cy[i] == YLarger))
            {
                damage += 50;
            }
            else if ((Cy[i] < YLarger && Cy[i] > YSmaller) && (Cx[i] == XSmaller || Cx[i] == XLarger))
            {
                damage += 50;
            }
            
        }

        Console.WriteLine("{0}%", damage);

    }
}