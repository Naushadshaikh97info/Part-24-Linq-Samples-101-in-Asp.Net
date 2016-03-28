using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class LINQ___Miscellaneous_Operators
{
	public LINQ___Miscellaneous_Operators()
	{
         //LINQ - Miscellaneous Operators
	}

    //Concat - 1

    //This sample uses Concat to create one sequence that contains each array's values, one after the other.

    public void Linq94()
    {
        int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
        int[] numbersB = { 1, 3, 5, 7, 8 };

        var allNumbers = numbersA.Concat(numbersB);

        Console.WriteLine("All numbers from both arrays:");
        foreach (var n in allNumbers)
        {
            Console.WriteLine(n);
        }
    }

    //Result

    //All numbers from both arrays: 
    //                              0 
    //                              2 
    //                              4 
    //                              5 
    //                              6 
    //                              8 
    //                              9 
    //                              1 
    //                              3 
    //                              5 
    //                              7 
    //                              8

    //Concat - 2

    //This sample uses Concat to create one sequence that contains the names of all customers and products, including any duplicates.

    public void Linq95()
    {
        List<Customer> customers = GetCustomerList();
        List<Product> products = GetProductList();

        var customerNames =
            from c in customers
            select c.CompanyName;
        var productNames =
            from p in products
            select p.ProductName;

        var allNames = customerNames.Concat(productNames);

        Console.WriteLine("Customer and product names:");
        foreach (var n in allNames)
        {
            Console.WriteLine(n);
        }
    }

    //Result

    //Customer and product names:
    //Alfreds Futterkiste
    //Ana Trujillo Emparedados y helados
    //Antonio Moreno TaquerÃ­a
    //Around the Horn
    //Berglunds snabbkÃ¶p
    //Blauer See Delikatessen
    //Blondel pÃ¨re et fils
    //BÃ³lido Comidas preparadas
    //Bon app'
    //Bottom-Dollar Markets
    //B's Beverages
    //Cactus Comidas para llevar
    //Centro comercial Moctezuma
    //Chop-suey Chinese
    //ComÃ©rcio Mineiro
    //Consolidated Holdings
    //Drachenblut Delikatessen
    //Du monde entier
    //Eastern Connection
    //Ernst Handel
    //Familia Arquibaldo
    //FISSA Fabrica Inter. Salchichas S.A.
    //Folies gourmandes
    //Folk och fÃ¤ HB
    //Frankenversand
    //France restauration
    //Franchi S.p.A.

    //EqualAll - 1

    //This sample uses EqualAll to see if two sequences match on all elements in the same order.

    public void Linq96()
    {
        var wordsA = new string[] { "cherry", "apple", "blueberry" };
        var wordsB = new string[] { "cherry", "apple", "blueberry" };

        bool match = wordsA.SequenceEqual(wordsB);

        Console.WriteLine("The sequences match: {0}", match);
    }

    //Result

    //The sequences match: True

     
    //EqualAll - 2

    //This sample uses EqualAll to see if two sequences match on all elements in the same order.

    public void Linq97()
    {
        var wordsA = new string[] { "cherry", "apple", "blueberry" };
        var wordsB = new string[] { "apple", "blueberry", "cherry" };

        bool match = wordsA.SequenceEqual(wordsB);

        Console.WriteLine("The sequences match: {0}", match);
    }

    //Result

    //The sequences match: False
}