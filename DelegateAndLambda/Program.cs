using System;
using System.Linq;

namespace DelegateAndLambda
{
    public class Program
    {
        public delegate string Reverse(string s);

        static string ReverseString(string s)
        {
            return new string(s.Reverse().ToArray());
        }

        static void Main(string[] args)
        {
            Reverse rev = ReverseString;

            Console.WriteLine(rev("a string"));
        }
    }
}