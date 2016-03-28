using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class LINQ___Partitioning_Operators
{
	public LINQ___Partitioning_Operators()
	{
        //LINQ - Partitioning Operators
	}

    //Take - Simple

    //This sample uses Take to get only the first 3 elements of the array.

    public void Linq20()
    {

        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };



        var first3Numbers = numbers.Take(3);



        Console.WriteLine("First 3 numbers:");

        foreach (var n in first3Numbers)
        {

            Console.WriteLine(n);

        }

    }

    //Result

    //First 3 numbers:
    //                5
    //                4
    //                1

    //Take - Nested

    //This sample uses Take to get the first 3 orders from customers in Washington.

    public void Linq21()
    {

        List<Customer> customers = GetCustomerList();



        var first3WAOrders = (

            from c in customers

            from o in c.Orders

            where c.Region == "WA"

            select new { c.CustomerID, o.OrderID, o.OrderDate })

            .Take(3);



        Console.WriteLine("First 3 orders in WA:");

        foreach (var order in first3WAOrders)
        {

            ObjectDumper.Write(order);

        }

    }

    //Result

    //First 3 orders in WA:
    //CustomerID=LAZYK OrderID=10482 OrderDate=3/21/1997
    //CustomerID=LAZYK OrderID=10545 OrderDate=5/22/1997
    //CustomerID=TRAIH OrderID=10574 OrderDate=6/19/1997

    //Skip - Simple

    //This sample uses Skip to get all but the first 4 elements of the array.

    public void Linq22()
    {

        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };



        var allButFirst4Numbers = numbers.Skip(4);



        Console.WriteLine("All but first 4 numbers:");

        foreach (var n in allButFirst4Numbers)
        {

            Console.WriteLine(n);

        }

    }

    //Result

    //All but first 4 numbers:
    //9
    //8
    //6
    //7
    //2
    //0

    //Skip - Nested

    //This sample uses Take to get all but the first 2 orders from customers in Washington.

    public void Linq23()
    {

        List<Customer> customers = GetCustomerList();



        var waOrders =

            from c in customers

            from o in c.Orders

            where c.Region == "WA"

            select new { c.CustomerID, o.OrderID, o.OrderDate };



        var allButFirst2Orders = waOrders.Skip(2);



        Console.WriteLine("All but first 2 orders in WA:");

        foreach (var order in allButFirst2Orders)
        {

            ObjectDumper.Write(order);

        }

    }

    //Result

    //All but first 2 orders in WA:
    //CustomerID=TRAIH OrderID=10574 OrderDate=6/19/1997
    //CustomerID=TRAIH OrderID=10577 OrderDate=6/23/1997
    //CustomerID=TRAIH OrderID=10822 OrderDate=1/8/1998
    //CustomerID=WHITC OrderID=10269 OrderDate=7/31/1996
    //CustomerID=WHITC OrderID=10344 OrderDate=11/1/1996
    //CustomerID=WHITC OrderID=10469 OrderDate=3/10/1997
    //CustomerID=WHITC OrderID=10483 OrderDate=3/24/1997
    //CustomerID=WHITC OrderID=10504 OrderDate=4/11/1997
    //CustomerID=WHITC OrderID=10596 OrderDate=7/11/1997
    //CustomerID=WHITC OrderID=10693 OrderDate=10/6/1997
    //CustomerID=WHITC OrderID=10696 OrderDate=10/8/1997
    //CustomerID=WHITC OrderID=10723 OrderDate=10/30/1997
    //CustomerID=WHITC OrderID=10740 OrderDate=11/13/1997
    //CustomerID=WHITC OrderID=10861 OrderDate=1/30/1998
    //CustomerID=WHITC OrderID=10904 OrderDate=2/24/1998
    //CustomerID=WHITC OrderID=11032 OrderDate=4/17/1998
    //CustomerID=WHITC OrderID=11066 OrderDate=5/1/1998

    //TakeWhile - Simple

    //This sample uses TakeWhile to return elements starting from the beginning of the array until a number is hit that is not less than 6.

    public void Linq24()
    {

        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };



        var firstNumbersLessThan6 = numbers.TakeWhile(n => n < 6);



        Console.WriteLine("First numbers less than 6:");

        foreach (var n in firstNumbersLessThan6)
        {

            Console.WriteLine(n);

        }

    }

    //Result

    //First numbers less than 6:
    //5
    //4
    //1
    //3


    //TakeWhile - Indexed

    //This sample uses TakeWhile to return elements starting from the beginning of the array until a number is hit that is less than its position in the array.

    public void Linq25()
    {

        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };



        var firstSmallNumbers = numbers.TakeWhile((n, index) => n >= index);



        Console.WriteLine("First numbers not less than their position:");

        foreach (var n in firstSmallNumbers)
        {

            Console.WriteLine(n);

        }

    }

    //Result

    //First numbers not less than their position:
    //5
    //4

    //SkipWhile - Simple

    //This sample uses SkipWhile to get the elements of the array starting from the first element divisible by 3.

    public void Linq26()
    {

        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };



        var allButFirst3Numbers = numbers.SkipWhile(n => n % 3 != 0);



        Console.WriteLine("All elements starting from first element divisible by 3:");

        foreach (var n in allButFirst3Numbers)
        {

            Console.WriteLine(n);

        }

    }

    //All elements starting from first element divisible by 3:
    //3
    //9
    //8
    //6
    //7
    //2
    //0

    //SkipWhile - Indexed

    //This sample uses SkipWhile to get the elements of the array starting from the first element less than its position.

    public void Linq27()
    {

        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };



        var laterNumbers = numbers.SkipWhile((n, index) => n >= index);



        Console.WriteLine("All elements starting from first element less than its position:");

        foreach (var n in laterNumbers)
        {

            Console.WriteLine(n);

        }

    }

    //Result

    //All elements starting from first element less than its position:
    //1
    //3
    //9
    //8
    //6
    //7
    //2
    //0
}

