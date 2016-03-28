using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class LINQ___Set_Operators
{
	public LINQ___Set_Operators()
	{
        //LINQ - Set Operators
	}

    //Distinct - 1

    //This sample uses Distinct to remove duplicate elements in a sequence of factors of 300.

    public void Linq46()
    {
        int[] factorsOf300 = { 2, 2, 3, 5, 5 };

        var uniqueFactors = factorsOf300.Distinct();

        Console.WriteLine("Prime factors of 300:");

        foreach (var f in uniqueFactors)
        {
            Console.WriteLine(f);
        }
    }

    //Result

    //Prime factors of 300:
    //2
    //3
    //5

    //Distinct - 2

    //This sample uses Distinct to find the unique Category names.

    public void Linq47()
    {
        List<Product> products = GetProductList();

        var categoryNames = (
            from p in products
            select p.Category)
            .Distinct();

        Console.WriteLine("Category names:");
        foreach (var n in categoryNames)
        {
            Console.WriteLine(n);
        }
    }

    // Result

    //Category names:
    //Beverages
    //Condiments
    //Produce
    //Meat/Poultry
    //Seafood
    //Dairy Products
    //Confections
    //Grains/Cereals

    //Union - 1

    //This sample uses Union to create one sequence that contains the unique values from both arrays.

    public void Linq48()
    {
        int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
        int[] numbersB = { 1, 3, 5, 7, 8 };

        var uniqueNumbers = numbersA.Union(numbersB);

        Console.WriteLine("Unique numbers from both arrays:");
        foreach (var n in uniqueNumbers)
        {
            Console.WriteLine(n);
        }
    }

    //Result

    //Unique numbers from both arrays:
    //0
    //2
    //4
    //5
    //6
    //8
    //9
    //1
    //3
    //7

    //Union - 2

    //This sample uses Union to create one sequence that contains the unique first letter from both product and customer names.

    public void Linq49()
    {
        List<Product> products = GetProductList();
        List<Customer> customers = GetCustomerList();

        var productFirstChars =
            from p in products
            select p.ProductName[0];
        var customerFirstChars =
            from c in customers
            select c.CompanyName[0];

        var uniqueFirstChars = productFirstChars.Union(customerFirstChars);

        Console.WriteLine("Unique first letters from Product names and Customer names:");
        foreach (var ch in uniqueFirstChars)
        {
            Console.WriteLine(ch);
        }
    }

    //Result

    //Unique first letters from Product names and Customer names:
    //C
    //A
    //G
    //U
    //N
    //M
    //I
    //Q
    //K
    //T
    //P
    //S
    //R
    //B
    //J
    //Z
    //V
    //F
    //E
    //W
    //L
    //O
    //D
    //H

    //Intersect - 1

    //This sample uses Intersect to create one sequence that contains the common values shared by both arrays.

    public void Linq50()
    {
        int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
        int[] numbersB = { 1, 3, 5, 7, 8 };

        var commonNumbers = numbersA.Intersect(numbersB);

        Console.WriteLine("Common numbers shared by both arrays:");
        foreach (var n in commonNumbers)
        {
            Console.WriteLine(n);
        }
    }

     //Result

     //Common numbers shared by both arrays:
     //5
     //8

    //Intersect - 2

    //This sample uses Intersect to create one sequence that contains the common first letter from both product and customer names.

    public void Linq51()
    {
        List<Product> products = GetProductList();
        List<Customer> customers = GetCustomerList();

        var productFirstChars =
            from p in products
            select p.ProductName[0];
        var customerFirstChars =
            from c in customers
            select c.CompanyName[0];

        var commonFirstChars = productFirstChars.Intersect(customerFirstChars);

        Console.WriteLine("Common first letters from Product names and Customer names:");
        foreach (var ch in commonFirstChars)
        {
            Console.WriteLine(ch);
        }
    }

    //Result

    //Common first letters from Product names and Customer names:
    //C
    //A
    //G
    //N
    //M
    //I
    //Q
    //K
    //T
    //P
    //S
    //R
    //B
    //V
    //F
    //E
    //W
    //L
    //O

    //Except - 1

    //This sample uses Except to create a sequence that contains the values from numbersAthat are not also in numbersB.

    public void Linq52()
    {
        int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
        int[] numbersB = { 1, 3, 5, 7, 8 };

        IEnumerable<int> aOnlyNumbers = numbersA.Except(numbersB);

        Console.WriteLine("Numbers in first array but not second array:");
        foreach (var n in aOnlyNumbers)
        {
            Console.WriteLine(n);
        }
    }

     //Result

     //Numbers in first array but not second array:
     //0
     //2
     //4
     //6
     //9

    //Except - 2

    //This sample uses Except to create one sequence that contains the first letters of product names that are not also first letters of customer names.

    public void Linq53()
    {
        List<Product> products = GetProductList();
        List<Customer> customers = GetCustomerList();

        var productFirstChars =
            from p in products
            select p.ProductName[0];
        var customerFirstChars =
            from c in customers
            select c.CompanyName[0];

        var productOnlyFirstChars = productFirstChars.Except(customerFirstChars);

        Console.WriteLine("First letters from Product names, but not from Customer names:");
        foreach (var ch in productOnlyFirstChars)
        {
            Console.WriteLine(ch);
        }
    }

    //Result

    //First letters from Product names, but not from Customer names:
    //U
    //J
    //Z
}