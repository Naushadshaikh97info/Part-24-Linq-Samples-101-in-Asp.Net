using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class LINQ___Join_Operators
{
	public LINQ___Join_Operators()
	{
        //LINQ - Join Operators
	}

    //Cross Join

    //This sample shows how to efficiently join elements of two sequences based on equality between key expressions over the two.

    public void Linq102()
    {

        string[] categories = new string[]{ 
        "Beverages",  
        "Condiments",  
        "Vegetables",  
        "Dairy Products",  
        "Seafood" };

        List<Product> products = GetProductList();

        var q =
            from c in categories
            join p in products on c equals p.Category
            select new { Category = c, p.ProductName };

        foreach (var v in q)
        {
            Console.WriteLine(v.ProductName + ": " + v.Category);
        }
    }

    //Result

    //Chai: Beverages
    //Chang: Beverages
    //GuaranÃ¡ FantÃ¡stica: Beverages
    //Sasquatch Ale: Beverages
    //Steeleye Stout: Beverages
    //CÃ´te de Blaye: Beverages
    //Chartreuse verte: Beverages
    //Ipoh Coffee: Beverages
    //Laughing Lumberjack Lager: Beverages
    //Outback Lager: Beverages
    //RhÃ¶nbrÃ¤u Klosterbier: Beverages
    //LakkalikÃ¶Ã¶ri: Beverages
    //Aniseed Syrup: Condiments
    //Chef Anton's Cajun Seasoning: Condiments
    //Chef Anton's Gumbo Mix: Condiments
    //Grandma's Boysenberry Spread: Condiments
    //Northwoods Cranberry Sauce: Condiments
    //Genen Shouyu: Condiments
    //Gula Malacca: Condiments
    //Sirop d'Ã©rable: Condiments
    //Vegie-spread: Condiments
    //Louisiana Fiery Hot Pepper Sauce: Condiments
    //Louisiana Hot Spiced Okra: Condiments
    //Original Frankfurter grÃ¼ne SoÃŸe: Condiments
    //Queso Cabrales: Dairy Products
    //Queso Manchego La Pastora: Dairy Products
    //Gorgonzola Telino: Dairy Products
    //Mascarpone Fabioli: Dairy Products
    //Geitost: Dairy Products

    //Group Join

    //Using a group join you can get all the products that match a given category bundled as a sequence.

    public void Linq103()
    {
        string[] categories = new string[]{ 
        "Beverages", 
        "Condiments", 
        "Vegetables", 
        "Dairy Products", 
        "Seafood" };

        List<Product> products = GetProductList();

        var q =
            from c in categories
            join p in products on c equals p.Category into ps
            select new { Category = c, Products = ps };

        foreach (var v in q)
        {
            Console.WriteLine(v.Category + ":");
            foreach (var p in v.Products)
            {
                Console.WriteLine("   " + p.ProductName);
            }
        }
    }

    //Result

    //Beverages:
    //Chai
    //Chang
    //GuaranÃ¡ FantÃ¡stica
    //Sasquatch Ale
    //Steeleye Stout
    //CÃ´te de Blaye
    //Chartreuse verte
    //Ipoh Coffee
    //Laughing Lumberjack Lager
    //Outback Lager
    //RhÃ¶nbrÃ¤u Klosterbier
    //LakkalikÃ¶Ã¶ri
    //Condiments:
    //Aniseed Syrup
    //Chef Anton's Cajun Seasoning
    //Chef Anton's Gumbo Mix
    //Grandma's Boysenberry Spread
    //Northwoods Cranberry Sauce
    //Genen Shouyu
    //Gula Malacca
    //Sirop d'Ã©rable
    //Vegie-spread
    //Louisiana Fiery Hot Pepper Sauce
    //Louisiana Hot Spiced Okra
    //Original Frankfurter grÃ¼ne SoÃŸe
    //Vegetables:

    //Cross Join with Group Join

    //The group join operator is more general than join, as this slightly more verbose version of the cross join sample shows.

    public void Linq104()
    {
        string[] categories = new string[]{  
        "Beverages", 
        "Condiments", 
        "Vegetables",
        "Dairy Products",  
        "Seafood" };

        List<Product> products = GetProductList();



        var q =
            from c in categories
            join p in products on c equals p.Category into ps
            from p in ps
            select new { Category = c, p.ProductName };

        foreach (var v in q)
        {
            Console.WriteLine(v.ProductName + ": " + v.Category);
        }
    }

    //Result

    //Chai: Beverages
    //Chang: Beverages
    //GuaranÃ¡ FantÃ¡stica: Beverages
    //Sasquatch Ale: Beverages
    //Steeleye Stout: Beverages
    //CÃ´te de Blaye: Beverages
    //Chartreuse verte: Beverages
    //Ipoh Coffee: Beverages
    //Laughing Lumberjack Lager: Beverages
    //Outback Lager: Beverages
    //RhÃ¶nbrÃ¤u Klosterbier: Beverages
    //LakkalikÃ¶Ã¶ri: Beverages
    //Aniseed Syrup: Condiments
    //Chef Anton's Cajun Seasoning: Condiments
    //Chef Anton's Gumbo Mix: Condiments
    //Grandma's Boysenberry Spread: Condiments
    //Northwoods Cranberry Sauce: Condiments
    //Genen Shouyu: Condiments
    //Gula Malacca: Condiments
    //Sirop d'Ã©rable: Condiments
    //Vegie-spread: Condiments

    //Left Outer Join

    //A so-called outer join can be expressed with a group join. A left outer joinis like a cross join, except that all the left hand side elements get included at least once, even if they don't match any right hand side elements. Note how Vegetablesshows up in the output even though it has no matching products.

    public void Linq105()
    {
        string[] categories = new string[]{  
        "Beverages", 
        "Condiments",  
        "Vegetables",  
        "Dairy Products", 
        "Seafood" };

        List<Product> products = GetProductList();



        var q =
            from c in categories
            join p in products on c equals p.Category into ps
            from p in ps.DefaultIfEmpty()
            select new { Category = c, ProductName = p == null ? "(No products)" : p.ProductName };

        foreach (var v in q)
        {
            Console.WriteLine(v.ProductName + ": " + v.Category);
        }
    }

    //Result

    //Chai: Beverages
    //Chang: Beverages
    //GuaranÃ¡ FantÃ¡stica: Beverages
    //Sasquatch Ale: Beverages
    //Steeleye Stout: Beverages
    //CÃ´te de Blaye: Beverages
    //Chartreuse verte: Beverages
    //Ipoh Coffee: Beverages
    //Laughing Lumberjack Lager: Beverages
    //Outback Lager: Beverages
    //RhÃ¶nbrÃ¤u Klosterbier: Beverages
    //LakkalikÃ¶Ã¶ri: Beverages
    //Aniseed Syrup: Condiments
    //Chef Anton's Cajun Seasoning: Condiments
    //Chef Anton's Gumbo Mix: Condiments
    //Grandma's Boysenberry Spread: Condiments
    //Northwoods Cranberry Sauce: Condiments
    //Genen Shouyu: Condiments
    //Gula Malacca: Condiments
    //Sirop d'Ã©rable: Condiments
    //Vegie-spread: Condiments
    //Louisiana Fiery Hot Pepper Sauce: Condiments
    //Louisiana Hot Spiced Okra: Condiments
}