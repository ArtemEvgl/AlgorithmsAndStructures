using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Fibonachi.GetFibo(5));
            string s1 = "ABCDGH";
            string s2 = "AEDFHR";

            Console.WriteLine(LCS.GetLcs(s1, s2)); // ADH
            Console.ReadLine();
        }
    }
}
