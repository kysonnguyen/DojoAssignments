using System;
using System.Collections.Generic;

namespace boxing_unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> list = new List<object>();
            list.Add(7);
            list.Add(28);
            list.Add(-1);
            list.Add(true);
            list.Add("chair");

            int sum = 0;
            foreach (var obj in list)
            {
                Console.WriteLine(obj);
                if(obj is int)
                {
                    sum += (int)obj;
                }
            }
            Console.WriteLine("sum: {0}", sum);
        }
    }
}
