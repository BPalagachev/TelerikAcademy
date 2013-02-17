// Write methods that calculate the surface of a triangle by given:
// Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.

using System;

class TriagleSurface
{
    static void Main()
    {
        double a = 3.0;
        double b = 3.0;
        double c = 3.0;
        double angleD = 60.0; // degrees
        double angleR = Math.PI / 3.0;
        double ha = Math.Sqrt(c * c - (a / 2) * (a / 2));
        Console.WriteLine(CalcTriagleSurface(a, ha));
        Console.WriteLine(CalcTriagleSurface(a, b, c));
        Console.WriteLine(CalcTriagleSurface(a, b, angleD, "deg"));
        Console.WriteLine(CalcTriagleSurface(a, b, angleR, "rad"));
    }
    static double CalcTriagleSurface(double a, double ha)
    {
        return 0.5 * (a * ha);
    }
    static double CalcTriagleSurface(double a, double b, double c)
    {
        double p = (a + b + c) * 0.5;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }
    static double CalcTriagleSurface(double a, double b, double angle, string units = "deg")
    {
        if (units == "rad")
        {
            return 0.5 * (a * b * Math.Sin(angle));
        }
        else
        {
            double radians = (angle / 180) * Math.PI;
            return 0.5 * (a * b * Math.Sin(radians));
        }
    }
}