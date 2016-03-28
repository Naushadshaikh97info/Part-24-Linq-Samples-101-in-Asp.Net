using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class LINQ___Query_Execution
{
	public LINQ___Query_Execution()
	{
        //LINQ - Query Execution
	}

    //Deferred Execution

    //The following sample shows how query execution is deferred until the query is enumerated at a foreach statement.

    public void Linq99()
    {
        // Sequence operators form first-class queries that
        // are not executed until you enumerate over them.

        int[] numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

        int i = 0;
        var q =
            from n in numbers
            select ++i;

        // Note, the local variable 'i' is not incremented
        // until each element is evaluated (as a side-effect):
        foreach (var v in q)
        {
            Console.WriteLine("v = {0}, i = {1}", v, i);
        }
    }

     //Result

     //v = 1, i = 1
     //v = 2, i = 2
     //v = 3, i = 3
     //v = 4, i = 4
     //v = 5, i = 5
     //v = 6, i = 6
     //v = 7, i = 7
     //v = 8, i = 8
     //v = 9, i = 9
     //v = 10, i = 10

    //Immediate Execution

    //The following sample shows how queries can be executed immediately with operators such as ToList().

    public void Linq100()
    {
        // Methods like ToList() cause the query to be
        // executed immediately, caching the results.

        int[] numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

        int i = 0;
        var q = (
            from n in numbers
            select ++i)
            .ToList();

        // The local variable i has already been fully
        // incremented before we iterate the results:
        foreach (var v in q)
        {
            Console.WriteLine("v = {0}, i = {1}", v, i);
        }
    }

    //Result

    //v = 1, i = 10
    //v = 2, i = 10
    //v = 3, i = 10
    //v = 4, i = 10
    //v = 5, i = 10
    //v = 6, i = 10
    //v = 7, i = 10
    //v = 8, i = 10
    //v = 9, i = 10
    //v = 10, i = 10

    //Query Reuse

    //The following sample shows how, because of deferred execution, queries can be used again after data changes and will then operate on the new data.

    public void Linq101()
    {
        // Deferred execution lets us define a query once
        // and then reuse it later after data changes.

        int[] numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        var lowNumbers =
            from n in numbers
            where n <= 3
            select n;

        Console.WriteLine("First run numbers <= 3:");
        foreach (int n in lowNumbers)
        {
            Console.WriteLine(n);
        }

        for (int i = 0; i < 10; i++)
        {
            numbers[i] = -numbers[i];
        }

        // During this second run, the same query object,
        // lowNumbers, will be iterating over the new state
        // of numbers[], producing different results:
        Console.WriteLine("Second run numbers <= 3:");
        foreach (int n in lowNumbers)
        {
            Console.WriteLine(n);
        }
    }

    //Result

    //First run numbers <= 3:
    //1
    //3
    //2
    //0
    //Second run numbers <= 3:
    //-5
    //-4
    //-1
    //-3
    //-9
    //-8
    //-6
    //-7
    //-2
    //0
}