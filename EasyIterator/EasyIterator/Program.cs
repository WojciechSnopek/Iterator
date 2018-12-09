using System;
using System.Collections;
using System.Collections.Generic;

public class EasyIterator
{
    static void Main()
    {
        foreach (int i in Power(2, 8))
        {
            Console.Write("{0} ", i);
        }
        Console.ReadKey();
    }

    public static System.Collections.Generic.IEnumerable<int> Power(int number, int exponent)
    {
        int result = 1;

        for (int i = 0; i < exponent; i++)
        {
            result = result * number;
            yield return result;
        }
    }
}