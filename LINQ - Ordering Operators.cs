using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class LINQ___Ordering_Operators
{
    public LINQ___Ordering_Operators()
    {
        //LINQ - Ordering Operators
    }

    //OrderBy - Simple 1

    //This sample uses orderby to sort a list of words alphabetically.

    public void Linq28()
    {
        string[] words = { "cherry", "apple", "blueberry" };

        var sortedWords =
            from w in words
            orderby w
            select w;

        Console.WriteLine("The sorted list of words:");
        foreach (var w in sortedWords)
        {
            Console.WriteLine(w);
        }
    }

    //Result

    //The sorted list of words:
    //apple
    //blueberry
    //cherry

    //OrderBy - Simple 2

    //This sample uses orderby to sort a list of words by length.

    public void Linq29()
    {
        string[] words = { "cherry", "apple", "blueberry" };

        var sortedWords =
            from w in words
            orderby w.Length
            select w;

        Console.WriteLine("The sorted list of words (by length):");
        foreach (var w in sortedWords)
        {
            Console.WriteLine(w);
        }
    }

    //Result

    //The sorted list of words (by length):
    //apple
    //cherry
    //blueberry

    //OrderBy - Simple 3

    //This sample uses orderby to sort a list of products by name.

    public void Linq30()
    {
        List<Product> products = GetProductList();

        var sortedProducts =
            from p in products
            orderby p.ProductName
            select p;

        ObjectDumper.Write(sortedProducts);

    }

    //Result

    //ProductID=17 ProductName=Alice Mutton Category=Meat/Poultry UnitPrice=39.0000 UnitsInStock=0
    //ProductID=3 ProductName=Aniseed Syrup Category=Condiments UnitPrice=10.0000 UnitsInStock=13
    //ProductID=40 ProductName=Boston Crab Meat Category=Seafood UnitPrice=18.4000 UnitsInStock=123
    //ProductID=60 ProductName=Camembert Pierrot Category=Dairy Products UnitPrice=34.0000 UnitsInStock=19
    //ProductID=18 ProductName=Carnarvon Tigers Category=Seafood UnitPrice=62.5000 UnitsInStock=42
    //ProductID=1 ProductName=Chai Category=Beverages UnitPrice=18.0000 UnitsInStock=39
    //ProductID=2 ProductName=Chang Category=Beverages UnitPrice=19.0000 UnitsInStock=17
    //ProductID=39 ProductName=Chartreuse verte Category=Beverages UnitPrice=18.0000 UnitsInStock=69
    //ProductID=4 ProductName=Chef Anton's Cajun Seasoning Category=Condiments UnitPrice=22.0000 UnitsInStock=53
    //ProductID=5 ProductName=Chef Anton's Gumbo Mix Category=Condiments UnitPrice=21.3500 UnitsInStock=0
    //ProductID=48 ProductName=Chocolade Category=Confections UnitPrice=12.7500 UnitsInStock=15
    //ProductID=38 ProductName=CÃ´te de Blaye Category=Beverages UnitPrice=263.5000 UnitsInStock=17
    //ProductID=58 ProductName=Escargots de Bourgogne Category=Seafood UnitPrice=13.2500 UnitsInStock=62
    //ProductID=52 ProductName=Filo Mix Category=Grains/Cereals UnitPrice=7.0000 UnitsInStock=38
    //ProductID=71 ProductName=Flotemysost Category=Dairy Products UnitPrice=21.5000 UnitsInStock=26
    //ProductID=33 ProductName=Geitost Category=Dairy Products UnitPrice=2.5000 UnitsInStock=112
    //ProductID=15 ProductName=Genen Shouyu Category=Condiments UnitPrice=15.5000 UnitsInStock=39
    //ProductID=56 ProductName=Gnocchi di nonna Alice Category=Grains/Cereals UnitPrice=38.0000 UnitsInStock=21
    //ProductID=31 ProductName=Gorgonzola Telino Category=Dairy Products UnitPrice=12.5000 UnitsInStock=0
    //ProductID=6 ProductName=Grandma's Boysenberry Spread Category=Condiments UnitPrice=25.0000 UnitsInStock=120
    //ProductID=37 ProductName=Gravad lax Category=Seafood UnitPrice=26.0000 UnitsInStock=11
    //ProductID=24 ProductName=GuaranÃ¡ FantÃ¡stica Category=Beverages UnitPrice=4.5000 UnitsInStock=20
    //ProductID=69 ProductName=Gudbrandsdalsost Category=Dairy Products UnitPrice=36.0000 UnitsInStock=26
    //ProductID=44 ProductName=Gula Malacca Category=Condiments UnitPrice=19.4500 UnitsInStock=27

    //OrderBy - Comparer

    //This sample uses an OrderBy clause with a custom comparer to do a case-insensitive sort of the words in an array.

    public void Linq31()
    {
        string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

        var sortedWords = words.OrderBy(a => a, new CaseInsensitiveComparer());

        ObjectDumper.Write(sortedWords);
    }

    public class CaseInsensitiveComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
        }
    }

    //Result

    //AbAcUs
    //aPPLE
    //BlUeBeRrY
    //bRaNcH
    //cHeRry
    //ClOvEr

    //OrderByDescending - Simple 1

    //This sample uses orderby and descending to sort a list of doubles from highest to lowest.

    public void Linq32()
    {
        double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };

        var sortedDoubles =
            from d in doubles
            orderby d descending
            select d;

        Console.WriteLine("The doubles from highest to lowest:");
        foreach (var d in sortedDoubles)
        {
            Console.WriteLine(d);
        }
    }

        //Result

        //The doubles from highest to lowest:
        //4.1
        //2.9
        //2.3
        //1.9
        //1.7

    //OrderByDescending - Simple 2

    //This sample uses orderby to sort a list of products by units in stock from highest to lowest.

    public void Linq33()
    {
        List<Product> products = GetProductList();

        var sortedProducts =
            from p in products
            orderby p.UnitsInStock descending
            select p;

        ObjectDumper.Write(sortedProducts);
    }

    //Result

    //ProductID=75 ProductName=RhÃ¶nbrÃ¤u Klosterbier Category=Beverages UnitPrice=7.7500 UnitsInStock=125
    //ProductID=40 ProductName=Boston Crab Meat Category=Seafood UnitPrice=18.4000 UnitsInStock=123
    //ProductID=6 ProductName=Grandma's Boysenberry Spread Category=Condiments UnitPrice=25.0000 UnitsInStock=120
    //ProductID=55 ProductName=PÃ¢tÃ© chinois Category=Meat/Poultry UnitPrice=24.0000 UnitsInStock=115
    //ProductID=61 ProductName=Sirop d'Ã©rable Category=Condiments UnitPrice=28.5000 UnitsInStock=113
    //ProductID=33 ProductName=Geitost Category=Dairy Products UnitPrice=2.5000 UnitsInStock=112
    //ProductID=36 ProductName=Inlagd Sill Category=Seafood UnitPrice=19.0000 UnitsInStock=112
    //ProductID=34 ProductName=Sasquatch Ale Category=Beverages UnitPrice=14.0000 UnitsInStock=111
    //ProductID=22 ProductName=Gustaf's KnÃ¤ckebrÃ¶d Category=Grains/Cereals UnitPrice=21.0000 UnitsInStock=104
    //ProductID=73 ProductName=RÃ¶d Kaviar Category=Seafood UnitPrice=15.0000 UnitsInStock=101
    //ProductID=46 ProductName=Spegesild Category=Seafood UnitPrice=12.0000 UnitsInStock=95
    //ProductID=12 ProductName=Queso Manchego La Pastora Category=Dairy Products UnitPrice=38.0000 UnitsInStock=86
    //ProductID=41 ProductName=Jack's New England Clam Chowder Category=Seafood UnitPrice=9.6500 UnitsInStock=85
    //ProductID=59 ProductName=Raclette Courdavault Category=Dairy Products UnitPrice=55.0000 UnitsInStock=79
    //ProductID=25 ProductName=NuNuCa NuÃŸ-Nougat-Creme Category=Confections UnitPrice=14.0000 UnitsInStock=76
    //ProductID=65 ProductName=Louisiana Fiery Hot Pepper Sauce Category=Condiments UnitPrice=21.0500 UnitsInStock=76
    //ProductID=39 ProductName=Chartreuse verte Category=Beverages UnitPrice=18.0000 UnitsInStock=69
    //ProductID=50 ProductName=Valkoinen suklaa Category=Confections UnitPrice=16.2500 UnitsInStock=65
    //ProductID=58 ProductName=Escargots de Bourgogne Category=Seafood UnitPrice=13.2500 UnitsInStock=62
    //ProductID=23 ProductName=TunnbrÃ¶d Category=Grains/Cereals UnitPrice=9.0000 UnitsInStock=61

    //OrderByDescending - Comparer

    //This sample uses an OrderBy clause with a custom comparer to do a case-insensitive descending sort of the words in an array.

    public void Linq34()
    {
        string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

        var sortedWords = words.OrderByDescending(a => a, new CaseInsensitiveComparer());

        ObjectDumper.Write(sortedWords);
    }

    public class CaseInsensitiveComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
        }
    }

    //Result

    //ClOvEr
    //cHeRry
    //bRaNcH
    //BlUeBeRrY
    //aPPLE
    //AbAcUs

    //ThenBy - Simple

    //This sample uses a compound orderby to sort a list of digits, first by length of their name, and then alphabetically by the name itself.

    public void Linq35()
    {
        string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        var sortedDigits =
            from d in digits
            orderby d.Length, d
            select d;

        Console.WriteLine("Sorted digits:");
        foreach (var d in sortedDigits)
        {
            Console.WriteLine(d);
        }
    }

    //Result

    //Sorted digits:
    //            one
    //            six
    //            two
    //            five
    //            four
    //            nine
    //            zero
    //            eight
    //            seven
    //            three
   
    //ThenBy - Comparer

    //This sample uses an OrderBy and a ThenBy clause with a custom comparer to sort first by word length and then by a case-insensitive sort of the words in an array.

    public void Linq36()
    {
        string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

        var sortedWords =
            words.OrderBy(a => a.Length)
                 .ThenBy(a => a, new CaseInsensitiveComparer());

        ObjectDumper.Write(sortedWords);
    }

    public class CaseInsensitiveComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
        }
    }

    //Result

    //aPPLE
    //AbAcUs
    //bRaNcH
    //cHeRry
    //ClOvEr
    //BlUeBeRrY

    //ThenByDescending - Simple

    //This sample uses a compound orderby to sort a list of products, first by category, and then by unit price, from highest to lowest.

    public void Linq37()
    {
        List<Product> products = GetProductList();

        var sortedProducts =
            from p in products
            orderby p.Category, p.UnitPrice descending
            select p;

        ObjectDumper.Write(sortedProducts);
    }

    //Result

    //ProductID=38 ProductName=CÃ´te de Blaye Category=Beverages UnitPrice=263.5000 UnitsInStock=17
    //ProductID=43 ProductName=Ipoh Coffee Category=Beverages UnitPrice=46.0000 UnitsInStock=17
    //ProductID=2 ProductName=Chang Category=Beverages UnitPrice=19.0000 UnitsInStock=17
    //ProductID=1 ProductName=Chai Category=Beverages UnitPrice=18.0000 UnitsInStock=39
    //ProductID=35 ProductName=Steeleye Stout Category=Beverages UnitPrice=18.0000 UnitsInStock=20
    //ProductID=39 ProductName=Chartreuse verte Category=Beverages UnitPrice=18.0000 UnitsInStock=69
    //ProductID=76 ProductName=LakkalikÃ¶Ã¶ri Category=Beverages UnitPrice=18.0000 UnitsInStock=57
    //ProductID=70 ProductName=Outback Lager Category=Beverages UnitPrice=15.0000 UnitsInStock=15
    //ProductID=34 ProductName=Sasquatch Ale Category=Beverages UnitPrice=14.0000 UnitsInStock=111
    //ProductID=67 ProductName=Laughing Lumberjack Lager Category=Beverages UnitPrice=14.0000 UnitsInStock=52
    //ProductID=75 ProductName=RhÃ¶nbrÃ¤u Klosterbier Category=Beverages UnitPrice=7.7500 UnitsInStock=125
    //ProductID=24 ProductName=GuaranÃ¡ FantÃ¡stica Category=Beverages UnitPrice=4.5000 UnitsInStock=20
    //ProductID=63 ProductName=Vegie-spread Category=Condiments UnitPrice=43.9000 UnitsInStock=24


    //ThenByDescending - Comparer

    //This sample uses an OrderBy and a ThenBy clause with a custom comparer to sort first by word length and then by a case-insensitive descending sort of the words in an array.

    public void Linq38()
    {
        string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

        var sortedWords =
            words.OrderBy(a => a.Length)
                 .ThenByDescending(a => a, new CaseInsensitiveComparer());

        ObjectDumper.Write(sortedWords);
    }

    public class CaseInsensitiveComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
        }
    }

    //Result
    //aPPLE
    //ClOvEr
    //cHeRry
    //bRaNcH
    //AbAcUs
    //BlUeBeRrY

    //Reverse

    //This sample uses Reverse to create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.

    public void Linq39()
    {
        string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        var reversedIDigits = (
            from d in digits
            where d[1] == 'i'
            select d)
            .Reverse();

        Console.WriteLine("A backwards list of the digits with a second character of 'i':");
        foreach (var d in reversedIDigits)
        {
            Console.WriteLine(d);
        }
    }

    //Result

    //A backwards list of the digits with a second character of 'i':
    //nine
    //eight
    //six
    //five
}