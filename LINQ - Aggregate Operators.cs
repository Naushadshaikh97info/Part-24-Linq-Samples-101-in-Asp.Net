using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class LINQ___Aggregate_Operators
{
	public LINQ___Aggregate_Operators()
	{
        //LINQ - Aggregate Operators
	}

    //Count - Simple  

    //This sample uses Count to get the number of unique factors of 300.

    public void Linq73()
    {
        int[] factorsOf300 = { 2, 2, 3, 5, 5 };

        int uniqueFactors = factorsOf300.Distinct().Count();

        Console.WriteLine("There are {0} unique factors of 300.", uniqueFactors);
    }

    //Result

    //There are 3 unique factors of 300.


    //Count - Conditional

    //This sample uses Count to get the number of odd ints in the array.

    public void Linq74()
    {
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

        int oddNumbers = numbers.Count(n => n % 2 == 1);

        Console.WriteLine("There are {0} odd numbers in the list.", oddNumbers);
    }

    //Result

    //There are 5 odd numbers in the list.



    //Count - Nested

    //This sample uses Count to return a list of customers and how many orders each has.

    public void Linq76()
    {
        List<Customer> customers = GetCustomerList();

        var orderCounts =
            from c in customers
            select new { c.CustomerID, OrderCount = c.Orders.Count() };

        ObjectDumper.Write(orderCounts);
    }

    //Result

    //CustomerID=ALFKI                          OrderCount=6                         
    //CustomerID=ANATR                          OrderCount=4
    //CustomerID=ANTON                          OrderCount=7
    //CustomerID=AROUT                          OrderCount=13
    //CustomerID=BERGS                          OrderCount=18
    //CustomerID=BLAUS                          OrderCount=7
    //CustomerID=BLONP                          OrderCount=11
    //CustomerID=BOLID                          OrderCount=3
    //CustomerID=BONAP                          OrderCount=17
    //CustomerID=BOTTM                          OrderCount=14
    //CustomerID=BSBEV                          OrderCount=10
    //CustomerID=CACTU                          OrderCount=6
    //CustomerID=CENTC                          OrderCount=1
    //CustomerID=CHOPS                          OrderCount=8
    //CustomerID=COMMI                          OrderCount=5
    //CustomerID=CONSH                          OrderCount=3


    //Count - Grouped

    //This sample uses Count to return a list of categories and how many products each has.

    public void Linq77()
    {
    List<Product> products = GetProductList();
 
    var categoryCounts =
        from p in products
        group p by p.Category into g
        select new { Category = g.Key, ProductCount = g.Count() };
 
    ObjectDumper.Write(categoryCounts
    }


    //Result


    //Category=Beverages                ProductCount=12                 
    //Category=Condiments               ProductCount=12
    //Category=Produce                  ProductCount=5
    //Category=Meat/Poultry             ProductCount=6
    //Category=Seafood                  ProductCount=12
    //Category=Dairy Products           ProductCount=10
    //Category=Confections              ProductCount=13
    //Category=Grains/Cereals           ProductCount=7

           
    
    
    //Sum - Simple       
    
    //This sample uses Sum to get the total of the numbers in an array.        

    public void Linq78()
    {
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

        double numSum = numbers.Sum();

        Console.WriteLine("The sum of the numbers is {0}.", numSum);
    }
    
     //Result

    //The sum of the numbers is 45.


    //Sum - Projection

    //This sample uses Sum to get the total number of characters of all words in the array.


    public void Linq79()
    {
        string[] words = { "cherry", "apple", "blueberry" };

        double totalChars = words.Sum(w => w.Length);

        Console.WriteLine("There are a total of {0} characters in these words.", totalChars);
    }

    //Result

    //There are a total of 20 characters in these words.


    //Sum - Grouped

    //This sample uses Sum to get the total units in stock for each product category.


    public void Linq80()
    {
        List<Product> products = GetProductList();

        var categories =
            from p in products
            group p by p.Category into g
            select new { Category = g.Key, TotalUnitsInStock = g.Sum(p => p.UnitsInStock) };

        ObjectDumper.Write(categories);
    }

    //Result

    //Category=Beverages                       TotalUnitsInStock=559
    //Category=Condiments                      TotalUnitsInStock=507
    //Category=Produce                         TotalUnitsInStock=100
    //Category=Meat/Poultry                    TotalUnitsInStock=165
    //Category=Seafood                         TotalUnitsInStock=701
    //Category=Dairy Products                  TotalUnitsInStock=393
    //Category=Confections                     TotalUnitsInStock=386
    //Category=Grains/Cereals                  TotalUnitsInStock=308


    //Min - Simple

    //This sample uses Min to get the lowest number in an array.

    public void Linq81()
    {
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

        int minNum = numbers.Min();

        Console.WriteLine("The minimum number is {0}.", minNum);
    }

    //Result

    //The minimum number is 0.



    //Min - Projection

    //This sample uses Min to get the length of the shortest word in an array.


    public void Linq82()
    {
        string[] words = { "cherry", "apple", "blueberry" };

        int shortestWord = words.Min(w => w.Length);

        Console.WriteLine("The shortest word is {0} characters long.", shortestWord);
    }

    //Result

    //The shortest word is 5 characters long.


    //Min - Grouped

    //This sample uses Min to get the cheapest price among each category's products.


    public void Linq83()
    {
        List<Product> products = GetProductList();

        var categories =
            from p in products
            group p by p.Category into g
            select new { Category = g.Key, CheapestPrice = g.Min(p => p.UnitPrice) };

        ObjectDumper.Write(categories);
    }

    //Result


    //Category=Beverages                 CheapestPrice=4.5000
    //Category=Condiments                CheapestPrice=10.000
    //Category=Produce                   CheapestPrice=10.000
    //Category=Meat/Poultry              CheapestPrice=7.4500
    //Category=Seafood                   CheapestPrice=6.0000
    //Category=Dairy Products            CheapestPrice=2.5000
    //Category=Confections               CheapestPrice=9.2000
    //Category=Grains/Cereals            CheapestPrice=7.0000



    //Min - Elements

    //This sample uses Min to get the products with the cheapest price in each category.

    public void Linq84()
    {
        List<Product> products = GetProductList();

        var categories =
            from p in products
            group p by p.Category into g
            let minPrice = g.Min(p => p.UnitPrice)
            select new { Category = g.Key, CheapestProducts = g.Where(p => p.UnitPrice == minPrice) };

        ObjectDumper.Write(categories, 1);
    }

    //Result

    //Category=Beverages      CheapestProducts=...
    //  CheapestProducts: ProductID=24  ProductName=GuaranÃ¡ FantÃ¡stica  Category=Beverages      UnitPrice=4.5000        UnitsInStock=20
    //Category=Condiments    CheapestProducts=...
    //  CheapestProducts: ProductID=3  ProductName=Aniseed Syrup      Category=Condiments    UnitPrice=10.0000      UnitsInStock=13
    //Category=Produce        CheapestProducts=...
    //  CheapestProducts: ProductID=74  ProductName=Longlife Tofu      Category=Produce        UnitPrice=10.0000      UnitsInStock=4
    //Category=Meat/Poultry  CheapestProducts=...
    //  CheapestProducts: ProductID=54  ProductName=TourtiÃ¨re  Category=Meat/Poultry  UnitPrice=7.4500        UnitsInStock=21
    //Category=Seafood        CheapestProducts=... 


    //Max - Simple

    //This sample uses Max to get the highest number in an array.

    public void Linq85()
    {
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

        int maxNum = numbers.Max();

        Console.WriteLine("The maximum number is {0}.", maxNum);
    }

    //Result

    //The maximum number is 9.



    //Max - Projection

    //This sample uses Max to get the length of the longest word in an array.

    public void Linq86()
    {
        string[] words = { "cherry", "apple", "blueberry" };

        int longestLength = words.Max(w => w.Length);

        Console.WriteLine("The longest word is {0} characters long.", longestLength);
    }


    //Result

    //The longest word is 9 characters long.




    //Max - Grouped

    //This sample uses Max to get the most expensive price among each category's products.


    public void Linq87()
    {
        List<Product> products = GetProductList();

        var categories =
            from p in products
            group p by p.Category into g
            select new { Category = g.Key, MostExpensivePrice = g.Max(p => p.UnitPrice) };

        ObjectDumper.Write(categories);
    }

    //Result
        

    //Category=Beverages                            MostExpensivePrice=263.500
    //Category=Condiments                           MostExpensivePrice=43.9000
    //Category=Produce                              MostExpensivePrice=53.0000
    //Category=Meat/Poultry                         MostExpensivePrice=123.790
    //Category=Seafood                              MostExpensivePrice=62.5000
    //Category=Dairy Products                       MostExpensivePrice=55.0000
    //Category=Confections                          MostExpensivePrice=81.0000
    //Category=Grains/Cereals                       MostExpensivePrice=38.0000


    //Max - Elements
     
    //This sample uses Max to get the products with the most expensive price in each category.


    public void Linq88()
    {
        List<Product> products = GetProductList();

        var categories =
            from p in products
            group p by p.Category into g
            let maxPrice = g.Max(p => p.UnitPrice)
            select new { Category = g.Key, MostExpensiveProducts = g.Where(p => p.UnitPrice == maxPrice) };

        ObjectDumper.Write(categories, 1);
    }


    //Result


    //Category=Beverages      MostExpensiveProducts=...
    //MostExpensiveProducts: ProductID=38    ProductName=CÃ´te de Blaye      Category=Beverages      UnitPrice=263.5000      UnitsInStock=17
    //Category=Condiments    MostExpensiveProducts=...
    //  MostExpensiveProducts: ProductID=63    ProductName=Vegie-spread        Category=Condiments    UnitPrice=43.9000      UnitsInStock=24
    //Category=Produce        MostExpensiveProducts=...
    //  MostExpensiveProducts: ProductID=51    ProductName=Manjimup Dried Apples      Category=Produce        UnitPrice=53.0000      UnitsInStock=20
    //Category=Meat/Poultry  MostExpensiveProducts=...
    //  MostExpensiveProducts: ProductID=29    ProductName=ThÃ¼ringer Rostbratwurst    Category=Meat/Poultry  UnitPrice=123.7900      UnitsInStock=0
    //Category=Seafood        MostExpensiveProducts=...
    //  MostExpensiveProducts: ProductID=18    ProductName=Carnarvon Tigers    Category=Seafood        UnitPrice=62.5000      UnitsInStock=42
    //Category=Dairy Products        MostExpensiveProducts=... 
        
        

    //Average - Simple
        
    //This sample uses Average to get the average of all numbers in an array.

    public void Linq89()
    {
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

        double averageNum = numbers.Average();

        Console.WriteLine("The average number is {0}.", averageNum);
    }
    
    //Result

    //The average number is 4.5.


    //Average - Projection

    //This sample uses Average to get the average length of the words in the array.

    public void Linq90()
    {
        string[] words = { "cherry", "apple", "blueberry" };

        double averageLength = words.Average(w => w.Length);

        Console.WriteLine("The average word length is {0} characters.", averageLength);
    }
    
    //Result

    //The average word length is 6.66666666666667 characters.


    //Average - Grouped

    //This sample uses Average to get the average price of each category's products.

    public void Linq91()
    {
        List<Product> products = GetProductList();

        var categories =
            from p in products
            group p by p.Category into g
            select new { Category = g.Key, AveragePrice = g.Average(p => p.UnitPrice) };

        ObjectDumper.Write(categories);
    }
    
    //Result

    //Category=Beverages                            AveragePrice=37.979166666666666666666666667
    //Category=Condiments                           AveragePrice=23.0625
    //Category=Produce                              AveragePrice=32.3700
    //Category=Meat/Poultry                         AveragePrice=54.006666666666666666666666667
    //Category=Seafood                              AveragePrice=20.6825
    //Category=Dairy Products                       AveragePrice=28.7300
    //Category=Confections                          AveragePrice=25.1600
    //Category=Grains/Cereals                       AveragePrice=20.2500


    //Aggregate - Simple

    //This sample uses Aggregate to create a running product on the array that calculates the total product of all elements

    public void Linq92()
    {
        double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };

        double product = doubles.Aggregate((runningProduct, nextFactor) => runningProduct * nextFactor);

        Console.WriteLine("Total product of all numbers: {0}", product);
    }
    
    //Result

    //Total product of all numbers: 88.33081


    //Aggregate - Seed

    //This sample uses Aggregate to create a running account balance that subtracts each withdrawal from the initial balance of 100, as long as the balance never drops below 0.


    public void Linq93()
    {
        double startBalance = 100.0;

        int[] attemptedWithdrawals = { 20, 10, 40, 50, 10, 70, 30 };

        double endBalance =
            attemptedWithdrawals.Aggregate(startBalance,
                (balance, nextWithdrawal) =>
                    ((nextWithdrawal <= balance) ? (balance - nextWithdrawal) : balance));

        Console.WriteLine("Ending balance: {0}", endBalance);
    }
        

    //Result

    //Ending balance: 20
        
        
        
        
        
        
        
        
        
        
        
        

 
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}