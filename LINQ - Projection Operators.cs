using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class LINQ___Projection_Operators
{
	public LINQ___Projection_Operators()
	{
       //LINQ - Projection Operators
	}


    //Select - Simple 1

    //This sample uses select to produce a sequence of ints one higher than those in an existing array of ints.

    public void Linq6()
    {
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

        var numsPlusOne =
            from n in numbers
            select n + 1;

        Console.WriteLine("Numbers + 1:");
        foreach (var i in numsPlusOne)
        {
            Console.WriteLine(i);
        }
    }

     //Result

    //Numbers + 1:
    //6
    //5
    //2
    //4
    //10
    //9
    //7
    //8
    //3
    //1

    //Select - Simple 2

    //This sample uses select to return a sequence of just the names of a list of products.

    public void Linq7()
    {
        List<Product> products = GetProductList();

        var productNames =
            from p in products
            select p.ProductName;

        Console.WriteLine("Product Names:");
        foreach (var productName in productNames)
        {
            Console.WriteLine(productName);
        }
    }

    //Result

    //Product Names:
    //Chai
    //Chang
    //Aniseed Syrup
    //Chef Anton's Cajun Seasoning
    //Chef Anton's Gumbo Mix
    //Grandma's Boysenberry Spread
    //Uncle Bob's Organic Dried Pears
    //Northwoods Cranberry Sauce
    //Mishi Kobe Niku
    //Ikura
    //Queso Cabrales
    //Queso Manchego La Pastora
    //Konbu
    //Tofu
    //Genen Shouyu
    //Pavlova
    //Alice Mutton

    //Select - Transformation

    //This sample uses select to produce a sequence of strings representing the text version of a sequence of ints.

    public void Linq8()
    {
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        var textNums =
            from n in numbers
            select strings[n];

        Console.WriteLine("Number strings:");
        foreach (var s in textNums)
        {
            Console.WriteLine(s);
        }
    }

    //Result

    //Number strings:
    //five
    //four
    //one
    //three
    //nine
    //eight
    //six
    //seven
    //two
    //zero

    //Select - Anonymous Types 1

    //This sample uses select to produce a sequence of the uppercase and lowercase versions of each word in the original array.

    public void Linq9()
    {
        string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

        var upperLowerWords =
            from w in words
            select new { Upper = w.ToUpper(), Lower = w.ToLower() };

        foreach (var ul in upperLowerWords)
        {
            Console.WriteLine("Uppercase: {0}, Lowercase: {1}", ul.Upper, ul.Lower);
        }
    }

    //Result

    //Uppercase: APPLE, Lowercase: apple
    //Uppercase: BLUEBERRY, Lowercase: blueberry
    //Uppercase: CHERRY, Lowercase: cherry

    //Select - Anonymous Types 2

    //This sample uses select to produce a sequence containing text representations of digits and whether their length is even or odd.

    public void Linq10()
    {
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        var digitOddEvens =
            from n in numbers
            select new { Digit = strings[n], Even = (n % 2 == 0) };

        foreach (var d in digitOddEvens)
        {
            Console.WriteLine("The digit {0} is {1}.", d.Digit, d.Even ? "even" : "odd");
        }
    }

    //Result

    //The digit five is odd.
    //The digit four is even.
    //The digit one is odd.
    //The digit three is odd.
    //The digit nine is odd.
    //The digit eight is even.
    //The digit six is even.
    //The digit seven is odd.
    //The digit two is even.
    //The digit zero is even.

    //Select - Anonymous Types 3

    //This sample uses select to produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.

    public void Linq11()
    {
        List<Product> products = GetProductList();

        var productInfos =
            from p in products
            select new { p.ProductName, p.Category, Price = p.UnitPrice };

        Console.WriteLine("Product Info:");
        foreach (var productInfo in productInfos)
        {
            Console.WriteLine("{0} is in the category {1} and costs {2} per unit.", productInfo.ProductName, productInfo.Category, productInfo.Price);
        }
    }

    //Result

    //Product Info:
    //Chai is in the category Beverages and costs 18.0000 per unit.
    //Chang is in the category Beverages and costs 19.0000 per unit.
    //Aniseed Syrup is in the category Condiments and costs 10.0000 per unit.
    //Chef Anton's Cajun Seasoning is in the category Condiments and costs 22.0000 per unit.
    //Chef Anton's Gumbo Mix is in the category Condiments and costs 21.3500 per unit.
    //Grandma's Boysenberry Spread is in the category Condiments and costs 25.0000 per unit.
    //Uncle Bob's Organic Dried Pears is in the category Produce and costs 30.0000 per unit.
    //Northwoods Cranberry Sauce is in the category Condiments and costs 40.0000 per unit.
    //Mishi Kobe Niku is in the category Meat/Poultry and costs 97.0000 per unit.
    //Ikura is in the category Seafood and costs 31.0000 per unit.
    //Queso Cabrales is in the category Dairy Products and costs 21.0000 per unit.
    //Queso Manchego La Pastora is in the category Dairy Products and costs 38.0000 per unit.
    //Konbu is in the category Seafood and costs 6.0000 per unit.
    //Tofu is in the category Produce and costs 23.2500 per unit.
    //Genen Shouyu is in the category Condiments and costs 15.5000 per unit.
    //Pavlova is in the category Confections and costs 17.4500 per unit.
    //Alice Mutton is in the category Meat/Poultry and costs 39.0000 per unit.
    //Carnarvon Tigers is in the category Seafood and costs 62.5000 per unit.
    //Teatime Chocolate Biscuits is in the category Confections and costs 9.2000 per unit.
    //Sir Rodney's Marmalade is in the category Confections and costs 81.0000 per unit.
    //Sir Rodney's Scones is in the category Confections and costs 10.0000 per unit.

    //Select - Indexed

    //This sample uses an indexed Select clause to determine if the value of ints in an array match their position in the array.

    public void Linq12()
    {
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

        var numsInPlace = numbers.Select((num, index) => new { Num = num, InPlace = (num == index) });

        Console.WriteLine("Number: In-place?");
        foreach (var n in numsInPlace)
        {
            Console.WriteLine("{0}: {1}", n.Num, n.InPlace);
        }
    }

    //Result

    //Number: In-place?
    //5: False
    //4: False
    //1: False
    //3: True
    //9: False
    //8: False
    //6: True
    //7: True
    //2: False
    //0: False

    //Select - Filtered

    //This sample combines select and where to make a simple query that returns the text form of each digit less than 5.

    public void Linq13()
    {
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        var lowNums =
            from n in numbers
            where n < 5
            select digits[n];

        Console.WriteLine("Numbers < 5:");
        foreach (var num in lowNums)
        {
            Console.WriteLine(num);
        }
    }

    //Result

    //Numbers < 5:
    //four
    //one
    //three
    //two
    //zero

    //SelectMany - Compound from 1

    //This sample uses a compound from clause to make a query that returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.

    public void Linq14()
    {
        int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
        int[] numbersB = { 1, 3, 5, 7, 8 };

        var pairs =
            from a in numbersA
            from b in numbersB
            where a < b
            select new { a, b };

        Console.WriteLine("Pairs where a < b:");
        foreach (var pair in pairs)
        {
            Console.WriteLine("{0} is less than {1}", pair.a, pair.b);
        }
    }

    //Result

    //Pairs where a < b:
    //0 is less than 1
    //0 is less than 3
    //0 is less than 5
    //0 is less than 7
    //0 is less than 8
    //2 is less than 3
    //2 is less than 5
    //2 is less than 7
    //2 is less than 8
    //4 is less than 5
    //4 is less than 7
    //4 is less than 8
    //5 is less than 7
    //5 is less than 8
    //6 is less than 7
    //6 is less than 8

    //SelectMany - Compound from 2

    //This sample uses a compound from clause to select all orders where the order total is less than 500.00.

    public void Linq15()
    {
        List<Customer> customers = GetCustomerList();

        var orders =
            from c in customers
            from o in c.Orders
            where o.Total < 500.00M
            select new { c.CustomerID, o.OrderID, o.Total };

        ObjectDumper.Write(orders);
    }

    //Result

    //CustomerID=ALFKI OrderID=10702 Total=330.00
    //CustomerID=ALFKI OrderID=10952 Total=471.20
    //CustomerID=ANATR OrderID=10308 Total=88.80
    //CustomerID=ANATR OrderID=10625 Total=479.75
    //CustomerID=ANATR OrderID=10759 Total=320.00
    //CustomerID=ANTON OrderID=10365 Total=403.20
    //CustomerID=ANTON OrderID=10682 Total=375.50
    //CustomerID=AROUT OrderID=10355 Total=480.00
    //CustomerID=AROUT OrderID=10453 Total=407.70
    //CustomerID=AROUT OrderID=10741 Total=228.00
    //CustomerID=AROUT OrderID=10743 Total=319.20
    //CustomerID=AROUT OrderID=10793 Total=191.10
    //CustomerID=AROUT OrderID=10864 Total=282.00
    //CustomerID=AROUT OrderID=10920 Total=390.00
    //CustomerID=AROUT OrderID=11016 Total=491.50
    //CustomerID=BERGS OrderID=10445 Total=174.90
    //CustomerID=BERGS OrderID=10689 Total=472.50
    //CustomerID=BERGS OrderID=10778 Total=96.50
    //CustomerID=BLAUS OrderID=10501 Total=149.00
    //CustomerID=BLAUS OrderID=10509 Total=136.80
    //CustomerID=BLAUS OrderID=10582 Total=330.00

    //SelectMany - Compound from 3

    //This sample uses a compound from clause to select all orders where the order was made in 1998 or later.

    public void Linq16()
    {
        List<Customer> customers = GetCustomerList();

        var orders =
            from c in customers
            from o in c.Orders
            where o.OrderDate >= new DateTime(1998, 1, 1)
            select new { c.CustomerID, o.OrderID, o.OrderDate };

        ObjectDumper.Write(orders);
    }

    //Result

    //CustomerID=ALFKI OrderID=10835 OrderDate=1/15/1998
    //CustomerID=ALFKI OrderID=10952 OrderDate=3/16/1998
    //CustomerID=ALFKI OrderID=11011 OrderDate=4/9/1998
    //CustomerID=ANATR OrderID=10926 OrderDate=3/4/1998
    //CustomerID=ANTON OrderID=10856 OrderDate=1/28/1998
    //CustomerID=AROUT OrderID=10864 OrderDate=2/2/1998
    //CustomerID=AROUT OrderID=10920 OrderDate=3/3/1998
    //CustomerID=AROUT OrderID=10953 OrderDate=3/16/1998
    //CustomerID=AROUT OrderID=11016 OrderDate=4/10/1998
    //CustomerID=BERGS OrderID=10837 OrderDate=1/16/1998
    //CustomerID=BERGS OrderID=10857 OrderDate=1/28/1998
    //CustomerID=BERGS OrderID=10866 OrderDate=2/3/1998
    //CustomerID=BERGS OrderID=10875 OrderDate=2/6/1998
    //CustomerID=BERGS OrderID=10924 OrderDate=3/4/1998
    //CustomerID=BLAUS OrderID=10853 OrderDate=1/27/1998
    //CustomerID=BLAUS OrderID=10956 OrderDate=3/17/1998
    //CustomerID=BLAUS OrderID=11058 OrderDate=4/29/1998
    //CustomerID=BLONP OrderID=10826 OrderDate=1/12/1998
    //CustomerID=BOLID OrderID=10970 OrderDate=3/24/1998
    //CustomerID=BONAP OrderID=10827 OrderDate=1/12/1998

    //SelectMany - from Assignment

    //This sample uses a compound from clause to select all orders where the order total is greater than 2000.00 and uses from assignment to avoid requesting the total twice.

    public void Linq17()
    {
        List<Customer> customers = GetCustomerList();

        var orders =
            from c in customers
            from o in c.Orders
            where o.Total >= 2000.0M
            select new { c.CustomerID, o.OrderID, o.Total };

        ObjectDumper.Write(orders);
    }

    //Result

    //CustomerID=ANTON OrderID=10573 Total=2082.00
    //CustomerID=AROUT OrderID=10558 Total=2142.90
    //CustomerID=AROUT OrderID=10953 Total=4441.25
    //CustomerID=BERGS OrderID=10384 Total=2222.40
    //CustomerID=BERGS OrderID=10524 Total=3192.65
    //CustomerID=BERGS OrderID=10672 Total=3815.25
    //CustomerID=BERGS OrderID=10857 Total=2048.21
    //CustomerID=BLONP OrderID=10360 Total=7390.20
    //CustomerID=BOLID OrderID=10801 Total=3026.85
    //CustomerID=BONAP OrderID=10340 Total=2436.18
    //CustomerID=BONAP OrderID=10511 Total=2550.00
    //CustomerID=BOTTM OrderID=10742 Total=3118.00
    //CustomerID=BOTTM OrderID=10949 Total=4422.00
    //CustomerID=CHOPS OrderID=10519 Total=2314.20
    //CustomerID=CHOPS OrderID=10746 Total=2311.70
    //CustomerID=COMMI OrderID=10290 Total=2169.00

    //SelectMany - Multiple from

    //This sample uses multiple from clauses so that filtering on customers can be done before selecting their orders. This makes the query more efficient by not selecting and then discarding orders for customers outside of Washington.

    public void Linq18()
    {
        List<Customer> customers = GetCustomerList();

        DateTime cutoffDate = new DateTime(1997, 1, 1);

        var orders =
            from c in customers
            where c.Region == "WA"
            from o in c.Orders
            where o.OrderDate >= cutoffDate
            select new { c.CustomerID, o.OrderID };

        ObjectDumper.Write(orders);
    }

//    Result

//    CustomerID=LAZYK OrderID=10482
//    CustomerID=LAZYK OrderID=10545
//    CustomerID=TRAIH OrderID=10574
//    CustomerID=TRAIH OrderID=10577
//    CustomerID=TRAIH OrderID=10822
//    CustomerID=WHITC OrderID=10469
//    CustomerID=WHITC OrderID=10483
//    CustomerID=WHITC OrderID=10504
//    CustomerID=WHITC OrderID=10596
//    CustomerID=WHITC OrderID=10693
//    CustomerID=WHITC OrderID=10696
//    CustomerID=WHITC OrderID=10723
//    CustomerID=WHITC OrderID=10740
//    CustomerID=WHITC OrderID=10861
//    CustomerID=WHITC OrderID=10904
//    CustomerID=WHITC OrderID=11032
//    CustomerID=WHITC OrderID=11066

      //SelectMany - Indexed

     //This sample uses an indexed SelectMany clause to select all orders, while referring to customers by the order in which they are returned from the query. 

    public void Linq19()
    {
        List<Customer> customers = GetCustomerList();

        var customerOrders =
            customers.SelectMany(
                (cust, custIndex) =>
                cust.Orders.Select(o => "Customer #" + (custIndex + 1) +
                                        " has an order with OrderID " + o.OrderID));

        ObjectDumper.Write(customerOrders);
    }

    //Result

    //Customer #1 has an order with OrderID 10643
    //Customer #1 has an order with OrderID 10692
    //Customer #1 has an order with OrderID 10702
    //Customer #1 has an order with OrderID 10835
    //Customer #1 has an order with OrderID 10952
    //Customer #1 has an order with OrderID 11011
    //Customer #2 has an order with OrderID 10308
    //Customer #2 has an order with OrderID 10625
    //Customer #2 has an order with OrderID 10759
    //Customer #2 has an order with OrderID 10926
}