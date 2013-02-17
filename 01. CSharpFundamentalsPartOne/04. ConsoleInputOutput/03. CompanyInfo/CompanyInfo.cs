using System;
using System.Text;
using System.Threading;
using System.Globalization;

class CompanyInfo
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.WriteLine("Please fill in company information:");
        Console.WriteLine("Company name: ");
        string companyName = Console.ReadLine();
        Console.WriteLine("Company address: ");
        string companyAddress = Console.ReadLine();
        Console.WriteLine("Company Phone Number ");
        string companyPhone = Console.ReadLine();
        Console.WriteLine("Company Fax: ");
        string companyFax = Console.ReadLine();
        Console.WriteLine("Company web site");
        string companyWebSite = Console.ReadLine();
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("Please fill in manager's information");
        Console.WriteLine("First Name: ");
        string managerFirstName = Console.ReadLine();
        Console.WriteLine("Last Name: ");
        string managerLastName = Console.ReadLine();
        Console.WriteLine("Age: ");
        string managerAge = Console.ReadLine();
        Console.WriteLine("Phone number");
        string managerPhoneNumber = Console.ReadLine();
        Console.WriteLine(new string('-', 40));
        
        Console.WriteLine("Company details");
        Console.WriteLine("\"{0}\" is located at \"{1}\".", companyName, companyAddress);
        Console.WriteLine("For Contacts: Phone number - {0}, fax - {1} or visit: {2}.", companyPhone, companyFax, companyWebSite);
        Console.WriteLine("Manager: {0} {1} who is {2} years old and can be reached at {3}.", managerFirstName, managerLastName, managerAge, managerPhoneNumber);

    }
}