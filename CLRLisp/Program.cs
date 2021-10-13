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
                    new List (
                        Symbol.Intern ("lambda"),
                        new List (Symbol.Intern ("write"),
                                  Symbol.Intern ("message"),
                                  Symbol.Intern ("port")),
                        new List (Symbol.Intern ("write"),
                                  Symbol.Intern ("port"),
                                  Symbol.Intern ("message"))),
                Symbol.Intern (".WriteLine"),
                "Hello World!",
                new List (Symbol.Intern ("System.Console.Out$")));
            Console.WriteLine (expr.Eval (LispLib.Environment.User));
        }
    }
}
