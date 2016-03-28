using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class LINQ___Custom_Sequence_Operators
{
	public LINQ___Custom_Sequence_Operators()
	{
        //LINQ - Custom Sequence Operators
	}

    //Combine

    //This sample calculates the dot product of two integer vectors. It uses a user-created sequence operator, Combine, to calculate the dot product, passing it a lambda function to multiply two arrays, element by element, and sum the result.

    public static class CustomSequenceOperators
    {
        public static IEnumerable Combine(this IEnumerable first, IEnumerable second,
        Func func)
        {
            using (IEnumerator e1 = first.GetEnumerator(), e2 = second.GetEnumerator())
            {
                while (e1.MoveNext() && e2.MoveNext())
                {
                    yield return func(e1.Current, e2.Current);
                }
            }
        }
    }

    public void Linq98()
    {
        int[] vectorA = { 0, 2, 4, 5, 6 };
        int[] vectorB = { 1, 3, 5, 7, 8 };

        int dotProduct = vectorA.Combine(vectorB, (a, b) => a * b).Sum();

        Console.WriteLine("Dot product: {0}", dotProduct);
    }

    //Result

    //Dot product: 109
}