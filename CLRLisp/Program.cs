using System;
using LispLib;

namespace CLRLisp
{
    class Program
    {
        static void Main (string[] args) {
            List foo = new ('a', "this is a test", 42);
            foo.Mapc (Console.WriteLine);
            List expr = new (
                Symbol.Intern ("System.Console.WriteLine"),
                "Hello World!");
            Console.WriteLine (expr.Eval (LispLib.Environment.User));
        }
    }
}
