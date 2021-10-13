using System;
using LispLib;

namespace CLRLisp
{
    class Program
    {
        static void Main (string[] args) {
            Interpreter.Initialize ();
            System.Console.WriteLine ("foo");
        }
    }
}
