using System;
using System.Collections.Generic;
using System.Text;

namespace Express.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Query q = new Query();
            string s = q.GetExpressStatus("117889690257");
            Console.WriteLine(s.ToString());
        }
    }
}
