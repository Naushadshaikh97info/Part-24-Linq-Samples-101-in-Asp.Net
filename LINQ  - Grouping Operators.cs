using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class LINQ____Grouping_Operators
{
	public LINQ____Grouping_Operators()
	{
        //LINQ - Grouping Operators
	}
   
    //GroupBy - Simple 1

    //This sample uses group by to partition a list of numbers by their remainder when divided by 5.

    public void Linq40()
    {
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

        var numberGroups =
            from n in numbers
            group n by n % 5 into g
            select new { Remainder = g.Key, Numbers = g };

        foreach (var g in numberGroups)
        {
            Console.WriteLine("Numbers with a remainder of {0} when divided by 5:", g.Remainder);
            foreach (var n in g.Numbers)
            {
                Console.WriteLine(n);
            }
        }
    }

    //     Result
    
    //Numbers with a remainder of 0 when divided by 5:
    //5
    //0
    //Numbers with a remainder of 4 when divided by 5:
    //4
    //9
    //Numbers with a remainder of 1 when divided by 5:
    //1
    //6
    //Numbers with a remainder of 3 when divided by 5:
    //3
    //8
    //Numbers with a remainder of 2 when divided by 5:
    //7
    //2


    //GroupBy - Simple 2
    //This sample uses group by to partition a list of words by their first letter.

    public void Linq41()
    {
        string[] words = { "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese" };

        var wordGroups =
            from w in words
            group w by w[0] into g
            select new { FirstLetter = g.Key, Words = g };

        foreach (var g in wordGroups)
        {
            Console.WriteLine("Words that start with the letter '{0}':", g.FirstLetter);
            foreach (var w in g.Words)
            {
                Console.WriteLine(w);
            }
        }
    }

    //Result 

    //Words that start with the letter 'b':
    //blueberry
    //banana
    //Words that start with the letter 'c':
    //chimpanzee
    //cheese
    //Words that start with the letter 'a':
    //abacus
    //apple

    //GroupBy - Simple 3

    //This sample uses group by to partition a list of products by category.


    public void Linq42()
    {
        List<Product> products = GetProductList();

        var orderGroups =
            from p in products
            group p by p.Category into g
            select new { Category = g.Key, Products = g };

        ObjectDumper.Write(orderGroups, 1);
    }

    //Result

    //Category=Beverages Products=...
    //Products: ProductID=1 ProductName=Chai Category=Beverages UnitPrice=18.0000 UnitsInStock=39
    //Products: ProductID=2 ProductName=Chang Category=Beverages UnitPrice=19.0000 UnitsInStock=17
    //Products: ProductID=24 ProductName=GuaranÃ¡ FantÃ¡stica Category=Beverages UnitPrice=4.5000 UnitsInStock=20
    //Products: ProductID=34 ProductName=Sasquatch Ale Category=Beverages UnitPrice=14.0000 UnitsInStock=111
    //Products: ProductID=35 ProductName=Steeleye Stout Category=Beverages UnitPrice=18.0000 UnitsInStock=20
    //Products: ProductID=38 ProductName=CÃ´te de Blaye Category=Beverages UnitPrice=263.5000 UnitsInStock=17
    //Products: ProductID=39 ProductName=Chartreuse verte Category=Beverages UnitPrice=18.0000 UnitsInStock=69
    //Products: ProductID=43 ProductName=Ipoh Coffee Category=Beverages UnitPrice=46.0000 UnitsInStock=17
    //Products: ProductID=67 ProductName=Laughing Lumberjack Lager Category=Beverages UnitPrice=14.0000 UnitsInStock=52
    //Products: ProductID=70 ProductName=Outback Lager Category=Beverages UnitPrice=15.0000 UnitsInStock=15
    //Products: ProductID=75 ProductName=RhÃ¶nbrÃ¤u Klosterbier Category=Beverages UnitPrice=7.7500 UnitsInStock=125
    //Products: ProductID=76 ProductName=LakkalikÃ¶Ã¶ri Category=Beverages UnitPrice=18.0000 UnitsInStock=57
    //Category=Condiments Products=...
    //Products: ProductID=3 ProductName=Aniseed Syrup Category=Condiments UnitPrice=10.0000 UnitsInStock=13
    //Products: ProductID=4 ProductName=Chef Anton's Cajun Seasoning Category=Condiments UnitPrice=22.0000 UnitsInStock=53
    //Products: ProductID=5 ProductName=Chef Anton's Gumbo Mix Category=Condiments UnitPrice=21.3500 UnitsInStock=0
    //Products: ProductID=6 ProductName=Grandma's Boysenberry Spread Category=Condiments UnitPrice=25.0000 UnitsInStock=120
    //Products: ProductID=8 ProductName=Northwoods Cranberry Sauce Category=Condiments UnitPrice=40.0000 UnitsInStock=6
    //Products: ProductID=15 ProductName=Genen Shouyu Category=Condiments UnitPrice=15.5000 UnitsInStock=39
    //Products: ProductID=44 ProductName=Gula Malacca Category=Condiments UnitPrice=19.4500 UnitsInStock=27
    //Products: ProductID=61 ProductName=Sirop d'Ã©rable Category=Condiments UnitPrice=28.5000 UnitsInStock=113
    //Products: ProductID=63 ProductName=Vegie-spread Category=Condiments UnitPrice=43.9000 UnitsInStock=24
    //Products: ProductID=65 ProductName=Louisiana Fiery Hot Pepper Sauce Category=Condiments UnitPrice=21.0500 UnitsInStock=76
    //Products: ProductID=66 ProductName=Louisiana Hot Spiced Okra Category=Condiments UnitPrice=17.0000 UnitsInStock=4
    //Products: ProductID=77 ProductName=Original Frankfurter grÃ¼ne SoÃŸe Category=Condiments UnitPrice=13.0000 UnitsInStock=32
    //Category=Produce Products=...
    //Products: ProductID=7 ProductName=Uncle Bob's Organic Dried Pears Category=Produce UnitPrice=30.0000 UnitsInStock=15
    //Products: ProductID=14 ProductName=Tofu Category=Produce UnitPrice=23.2500 UnitsInStock=35
    //Products: ProductID=28 ProductName=RÃ¶ssle Sauerkraut Category=Produce UnitPrice=45.6000 UnitsInStock=26
    //Products: ProductID=51 ProductName=Manjimup Dried Apples Category=Produce UnitPrice=53.0000 UnitsInStock=20
    //Products: ProductID=74 ProductName=Longlife Tofu Category=Produce UnitPrice=10.0000 UnitsInStock=4

    //GroupBy - Nested

    //This sample uses group by to partition a list of each customer's orders, first by year, and then by month.

    public void Linq43()
    {
        List<Customer> customers = GetCustomerList();

        var customerOrderGroups =
            from c in customers
            select
                new
                {
                    c.CompanyName,
                    YearGroups =
                        from o in c.Orders
                        group o by o.OrderDate.Year into yg
                        select
                            new
                            {
                                Year = yg.Key,
                                MonthGroups =
                                    from o in yg
                                    group o by o.OrderDate.Month into mg
                                    select new { Month = mg.Key, Orders = mg }
                            }
                };

        ObjectDumper.Write(customerOrderGroups, 3);
    }

    //Result

    //CompanyName=Alfreds Futterkiste YearGroups=...
    //YearGroups: Year=1997 MonthGroups=...
    //MonthGroups: Month=8 Orders=...
    //Orders: OrderID=10643 OrderDate=8/25/1997 Total=814.50
    //MonthGroups: Month=10 Orders=...
    //Orders: OrderID=10692 OrderDate=10/3/1997 Total=878.00
    //Orders: OrderID=10702 OrderDate=10/13/1997 Total=330.00
    //YearGroups: Year=1998 MonthGroups=...
    //MonthGroups: Month=1 Orders=...
    //Orders: OrderID=10835 OrderDate=1/15/1998 Total=845.80
    //MonthGroups: Month=3 Orders=...
    //Orders: OrderID=10952 OrderDate=3/16/1998 Total=471.20
    //MonthGroups: Month=4 Orders=...
    //Orders: OrderID=11011 OrderDate=4/9/1998 Total=933.50
    //CompanyName=Ana Trujillo Emparedados y helados YearGroups=...
    //YearGroups: Year=1996 MonthGroups=...
    //MonthGroups: Month=9 Orders=...
    //Orders: OrderID=10308 OrderDate=9/18/1996 Total=88.80
    //YearGroups: Year=1997 MonthGroups=...
    //MonthGroups: Month=8 Orders=...
    //Orders: OrderID=10625 OrderDate=8/8/1997 Total=479.75
    //MonthGroups: Month=11 Orders=...
    //Orders: OrderID=10759 OrderDate=11/28/1997 Total=320.00
    //YearGroups: Year=1998 MonthGroups=...
    //MonthGroups: Month=3 Orders=...
    //Orders: OrderID=10926 OrderDate=3/4/1998 Total=514.40
    //CompanyName=Antonio Moreno TaquerÃ­a YearGroups=...
    //YearGroups: Year=1996 MonthGroups=...
    //MonthGroups: Month=11 Orders=...
    //Orders: OrderID=10365 OrderDate=11/27/1996 Total=403.20
    //YearGroups: Year=1997 MonthGroups=...
    //MonthGroups: Month=4 Orders=...
    //Orders: OrderID=10507 OrderDate=4/15/1997 Total=749.06

    //GroupBy - Comparer

    //This sample uses GroupBy to partition trimmed elements of an array using a custom comparer that matches words that are anagrams of each other.

    public void Linq44()
    {
        string[] anagrams = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };

        var orderGroups = anagrams.GroupBy(w => w.Trim(), new AnagramEqualityComparer());

        ObjectDumper.Write(orderGroups, 1);
    }

    public class AnagramEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return getCanonicalString(x) == getCanonicalString(y);
        }

        public int GetHashCode(string obj)
        {
            return getCanonicalString(obj).GetHashCode();
        }

        private string getCanonicalString(string word)
        {
            char[] wordChars = word.ToCharArray();
            Array.Sort<char>(wordChars);
            return new string(wordChars);
        }
    }

    //Result

    //...
    //from
    //form
    //...
    //salt
    //last
    //...
    //earn
    //near

    //GroupBy - Comparer, Mapped

    //This sample uses GroupBy to partition trimmed elements of an array using a custom comparer that matches words that are anagrams of each other, and then converts the results to uppercase.

    public void Linq45()
    {
        string[] anagrams = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };

        var orderGroups = anagrams.GroupBy(
                    w => w.Trim(),
                    a => a.ToUpper(),
                    new AnagramEqualityComparer()
                    );

        ObjectDumper.Write(orderGroups, 1);
    }

    public class AnagramEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return getCanonicalString(x) == getCanonicalString(y);
        }

        public int GetHashCode(string obj)
        {
            return getCanonicalString(obj).GetHashCode();
        }

        private string getCanonicalString(string word)
        {
            char[] wordChars = word.ToCharArray();
            Array.Sort<char>(wordChars);
            return new string(wordChars);
        }
    }

     //Result

    //...
    //FROM
    //FORM
    //...
    //SALT
    //LAST
    //...
    //EARN
    //NEAR
}