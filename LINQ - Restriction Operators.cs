using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class LINQ___Restriction_Operators
{
	public LINQ___Restriction_Operators()
	{
        //LINQ - Restriction Operators
	}

    //Where - Simple 1

    //This sample uses where to find all elements of an array less than 5.

    public void Linq1()
    {
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

        var lowNums =
            from n in numbers
            where n < 5
            select n;

        Console.WriteLine("Numbers < 5:");
        foreach (var x in lowNums)
        {
            Console.WriteLine(x);
        }
    }

    //Result

    //Numbers < 5:
    //4
    //1
    //3
    //2
    //0

    //Where - Simple 2

    //This sample uses where to find all products that are out of stock.

    public void Linq2()
    {
        List<Product> products = GetProductList();

        var soldOutProducts =
            from p in products
            where p.UnitsInStock == 0
            select p;

        Console.WriteLine("Sold out products:");
        foreach (var product in soldOutProducts)
        {
            Console.WriteLine("{0} is sold out!", product.ProductName);
        }
    }

    //Result

    //Sold out products:
    //Chef Anton's Gumbo Mix is sold out!
    //Alice Mutton is sold out!
    //ThÃ¼ringer Rostbratwurst is sold out!
    //Gorgonzola Telino is sold out!
    //Perth Pasties is sold out!

    //Where - Simple 3

    //This sample uses where to find all products that are in stock and cost more than 3.00 per unit.

    public void Linq3()
    {
        List<Product> products = GetProductList();

        var expensiveInStockProducts =
            from p in products
            where p.UnitsInStock > 0 && p.UnitPrice > 3.00M
            select p;

        Console.WriteLine("In-stock products that cost more than 3.00:");
        foreach (var product in expensiveInStockProducts)
        {
            Console.WriteLine("{0} is in stock and costs more than 3.00.", product.ProductName);
        }
    }

    //Result

    //In-stock products that cost more than 3.00:
    //Chai is in stock and costs more than 3.00.
    //Chang is in stock and costs more than 3.00.
    //Aniseed Syrup is in stock and costs more than 3.00.
    //Chef Anton's Cajun Seasoning is in stock and costs more than 3.00.
    //Grandma's Boysenberry Spread is in stock and costs more than 3.00.
    //Uncle Bob's Organic Dried Pears is in stock and costs more than 3.00.
    //Northwoods Cranberry Sauce is in stock and costs more than 3.00.
    //Mishi Kobe Niku is in stock and costs more than 3.00.
    //Ikura is in stock and costs more than 3.00.
    //Queso Cabrales is in stock and costs more than 3.00.
    //Queso Manchego La Pastora is in stock and costs more than 3.00.
    //Konbu is in stock and costs more than 3.00.
    //Tofu is in stock and costs more than 3.00.
    //Genen Shouyu is in stock and costs more than 3.00.
    //Pavlova is in stock and costs more than 3.00.
    //Carnarvon Tigers is in stock and costs more than 3.00.
    //Teatime Chocolate Biscuits is in stock and costs more than 3.00.
    //Sir Rodney's Marmalade is in stock and costs more than 3.00. 

    //Where - Drilldown

    //This sample uses where to find all customers in Washington and then uses the resulting sequence to drill down into their orders.

    public void Linq4()
    {
        List<Customer> customers = GetCustomerList();

        var waCustomers =
            from c in customers
            where c.Region == "WA"
            select c;

        Console.WriteLine("Customers from Washington and their orders:");
        foreach (var customer in waCustomers)
        {
            Console.WriteLine("Customer {0}: {1}", customer.CustomerID, customer.CompanyName);
            foreach (var order in customer.Orders)
            {
                Console.WriteLine("  Order {0}: {1}", order.OrderID, order.OrderDate);
            }
        }
    }

    //Result

    //Customers from Washington and their orders:
    //Customer LAZYK: Lazy K Kountry Store
    //Order 10482: 3/21/1997 12:00:00 AM
    //Order 10545: 5/22/1997 12:00:00 AM
    //Customer TRAIH: Trail's Head Gourmet Provisioners
    //Order 10574: 6/19/1997 12:00:00 AM
    //Order 10577: 6/23/1997 12:00:00 AM
    //Order 10822: 1/8/1998 12:00:00 AM
    //Customer WHITC: White Clover Markets
    //Order 10269: 7/31/1996 12:00:00 AM
    //Order 10344: 11/1/1996 12:00:00 AM
    //Order 10469: 3/10/1997 12:00:00 AM
    //Order 10483: 3/24/1997 12:00:00 AM
    //Order 10504: 4/11/1997 12:00:00 AM
    //Order 10596: 7/11/1997 12:00:00 AM
    //Order 10693: 10/6/1997 12:00:00 AM
    //Order 10696: 10/8/1997 12:00:00 AM
    //Order 10723: 10/30/1997 12:00:00 AM
    //Order 10740: 11/13/1997 12:00:00 AM
    //Order 10861: 1/30/1998 12:00:00 AM
    //Order 10904: 2/24/1998 12:00:00 AM
    //Order 11032: 4/17/1998 12:00:00 AM

    //Where - Indexed

    //This sample demonstrates an indexed Where clause that returns digits whose name is shorter than their value.

    public void Linq5()
    {
        string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        var shortDigits = digits.Where((digit, index) => digit.Length < index);

        Console.WriteLine("Short digits:");
        foreach (var d in shortDigits)
        {
            Console.WriteLine("The word {0} is shorter than its value.", d);
        }
    }

    //Result

    //Short digits:
    //The word five is shorter than its value.
    //The word six is shorter than its value.
    //The word seven is shorter than its value.
    //The word eight is shorter than its value.
    //The word nine is shorter than its value.
}