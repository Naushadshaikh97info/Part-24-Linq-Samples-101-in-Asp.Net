using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class LINQ___Quantifiers
{
	public LINQ___Quantifiers()
	{
        //LINQ - Quantifiers
	}

    //Any - Simple

    //This sample uses Any to determine if any of the words in the array contain the substring 'ei'.

    public void Linq67()
    {
        string[] words = { "believe", "relief", "receipt", "field" };

        bool iAfterE = words.Any(w => w.Contains("ei"));

        Console.WriteLine("There is a word that contains in the list that contains 'ei': {0}", iAfterE);
    }

    //Result

    //There is a word that contains in the list that contains 'ei': True

    //Any - Grouped

    //This sample uses Any to return a grouped a list of products only for categories that have at least one product that is out of stock.

    public void Linq69()
    {
        List<Product> products = GetProductList();
        var productGroups =
            from p in products
            group p by p.Category into g
            where g.Any(p => p.UnitsInStock == 0)
            select new { Category = g.Key, Products = g };

        ObjectDumper.Write(productGroups, 1);
    }

    //Result

    //Category=Condiments    Products=... 
    //Products: ProductID=3  ProductName=Aniseed Syrup      Category=Condiments    UnitPrice=10.0000      UnitsInStock=13 
    //Products: ProductID=4  ProductName=Chef Anton's Cajun Seasoning        Category=Condiments    UnitPrice=22.0000      UnitsInStock=53 
    //Products: ProductID=5  ProductName=Chef Anton's Gumbo Mix      Category=Condiments    UnitPrice=21.3500      UnitsInStock=0 
    //Products: ProductID=6  ProductName=Grandma's Boysenberry Spread        Category=Condiments    UnitPrice=25.0000      UnitsInStock=120 
    //Products: ProductID=8  ProductName=Northwoods Cranberry Sauce  Category=Condiments    UnitPrice=40.0000      UnitsInStock=6 
    //Products: ProductID=15  ProductName=Genen Shouyu        Category=Condiments    UnitPrice=15.5000      UnitsInStock=39 
    //Products: ProductID=44  ProductName=Gula Malacca        Category=Condiments    UnitPrice=19.4500      UnitsInStock=27 
    //Products: ProductID=61  ProductName=Sirop d'Ã©rable      Category=Condiments    UnitPrice=28.5000      UnitsInStock=113 
    //Products: ProductID=63  ProductName=Vegie-spread        Category=Condiments    UnitPrice=43.9000      UnitsInStock=24 
    //Products: ProductID=65  ProductName=Louisiana Fiery Hot Pepper Sauce    Category=Condiments    UnitPrice=21.0500      UnitsInStock=76 
    //Products: ProductID=66  ProductName=Louisiana Hot Spiced Okra  Category=Condiments    UnitPrice=17.0000      UnitsInStock=4 
    //Products: ProductID=77  ProductName=Original Frankfurter grÃ¼ne SoÃŸe    Category=Condiments    UnitPrice=13.0000      UnitsInStock=32 

    //All - Simple

    //This sample uses All to determine whether an array contains only odd numbers.

    public void Linq70()
    {
        int[] numbers = { 1, 11, 3, 19, 41, 65, 19 };

        bool onlyOdd = numbers.All(n => n % 2 == 1);

        Console.WriteLine("The list contains only odd numbers: {0}", onlyOdd);
    }

     //Result

     //The list contains only odd numbers: True

    //All - Grouped

    //This sample uses All to return a grouped a list of products only for categories that have all of their products in stock.

    public void Linq72()
    {
        List<Product> products = GetProductList();

        var productGroups =
            from p in products
            group p by p.Category into g
            where g.All(p => p.UnitsInStock > 0)
            select new { Category = g.Key, Products = g };

        ObjectDumper.Write(productGroups, 1);
    }

    //Result

    //Category=Beverages      Products=... 
    //Products: ProductID=1  ProductName=Chai        Category=Beverages      UnitPrice=18.0000      UnitsInStock=39 
    //Products: ProductID=2  ProductName=Chang      Category=Beverages      UnitPrice=19.0000      UnitsInStock=17 
    //Products: ProductID=24  ProductName=GuaranÃ¡ FantÃ¡stica  Category=Beverages      UnitPrice=4.5000        UnitsInStock=20 
    //Products: ProductID=34  ProductName=Sasquatch Ale      Category=Beverages      UnitPrice=14.0000      UnitsInStock=111 
    //Products: ProductID=35  ProductName=Steeleye Stout      Category=Beverages      UnitPrice=18.0000      UnitsInStock=20 
    //Products: ProductID=38  ProductName=CÃ´te de Blaye      Category=Beverages      UnitPrice=263.5000      UnitsInStock=17 
    //Products: ProductID=39  ProductName=Chartreuse verte    Category=Beverages      UnitPrice=18.0000      UnitsInStock=69 
    //Products: ProductID=43  ProductName=Ipoh Coffee        Category=Beverages      UnitPrice=46.0000      UnitsInStock=17 
    //Products: ProductID=67  ProductName=Laughing Lumberjack Lager  Category=Beverages      UnitPrice=14.0000      UnitsInStock=52 
    //Products: ProductID=70  ProductName=Outback Lager      Category=Beverages      UnitPrice=15.0000      UnitsInStock=15 
    //Products: ProductID=75  ProductName=RhÃ¶nbrÃ¤u Klosterbier        Category=Beverages      UnitPrice=7.7500        UnitsInStock=125 
    //Products: ProductID=76  ProductName=LakkalikÃ¶Ã¶ri        Category=Beverages      UnitPrice=18.0000      UnitsInStock=57 



}