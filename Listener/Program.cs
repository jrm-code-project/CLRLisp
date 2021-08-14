using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listener
{
    class Program
    {
        static void Main (string[] args) {
            while () {
                System.Console.Write ("> ");
                object form = LispLib.Reader.Read (System.Console.In, true, null, false);
                System.Console.Write ("\n");
                System.Console.Write (form.ToString ());
            }
        }
    }
}
