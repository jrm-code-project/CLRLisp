// Automatically generated.  Don't bother to edit.

using LispLib;

class Boot
{
    public static List Read () =>
        new List (
            new List (
                new List (
                    Symbol.Intern ("lambda"),
                    new List (
                        Symbol.Intern ("message"),
                        Symbol.Intern ("stream")),
                    new List (
                        Symbol.Intern (".writeline"),
                        Symbol.Intern ("stream"),
                        Symbol.Intern ("message"))),
                "Hello World!",
                new List (Symbol.Intern ("system.console.out$"))));
}
