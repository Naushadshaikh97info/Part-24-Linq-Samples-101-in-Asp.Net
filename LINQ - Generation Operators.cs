using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class LINQ___Generation_Operators
{
	public LINQ___Generation_Operators()
	{
        //LINQ - Generation Operators
	}

    //Range

    //This sample uses Range to generate a sequence of numbers from 100 to 149 that is used to find which numbers in that range are odd and even.

    public void Linq65()
    {
        var numbers =
            from n in Enumerable.Range(100, 50)

            select new { Number = n, OddEven = n % 2 == 1 ? "odd" : "even" };

        foreach (var n in numbers)
        {
            Console.WriteLine("The number {0} is {1}.", n.Number, n.OddEven);
        }
    }

    //Result

    //The number 100 is even.
    //The number 101 is odd.
    //The number 102 is even.
    //The number 103 is odd.
    //The number 104 is even.
    //The number 105 is odd.
    //The number 106 is even.
    //The number 107 is odd.
    //The number 108 is even.
    //The number 109 is odd.
    //The number 110 is even.
    //The number 111 is odd.
    //The number 112 is even.
    //The number 113 is odd.
    //The number 114 is even.
    //The number 115 is odd.
    //The number 116 is even.
    //The number 117 is odd.
    //The number 118 is even.
    //The number 119 is odd.
    //The number 120 is even.

    //........

    //The number 149 is odd.

    //Repeat

    public void Linq66()
    {
        var numbers = Enumerable.Repeat(7, 10);

        foreach (var n in numbers)
        {
            Console.WriteLine(n);
        }
    }

    //Result

    //7
    //7
    //7
    //7
    //7
    //7
    //7
    //7
    //7
    //7
}