// Automatically generated.  Don't bother to edit.

using LispLib;

class Dumper
{
    object Read () =>
        new List (
            new List (
                Symbol.Intern ("declare"),
                new List (
                    Symbol.Intern ("usual-integrations"))),
            new List (
                Symbol.Intern ("define"),
                Symbol.Intern ("file->list"),
                new List (
                    Symbol.Intern ("lambda"),
                    new List (
                        Symbol.Intern ("file")),
                    new List (
                        Symbol.Intern ("call-with-input-file"),
                        Symbol.Intern ("file"),
                        new List (
                            Symbol.Intern ("lambda"),
                            new List (
                                Symbol.Intern ("port")),
                            new List (
                                Symbol.Intern ("port->list"),
                                Symbol.Intern ("port")))))),
            new List (
                Symbol.Intern ("define"),
                Symbol.Intern ("port->list"),
                new List (
                    Symbol.Intern ("lambda"),
                    new List (
                        Symbol.Intern ("port")),
                    new List (
                        Symbol.Intern ("let"),
                        new List (
                            new List (
                                Symbol.Intern ("item"),
                                new List (
                                    Symbol.Intern ("read"),
                                    Symbol.Intern ("port")))),
                        new List (
                            Symbol.Intern ("if"),
                            new List (
                                Symbol.Intern ("eof-object?"),
                                Symbol.Intern ("item")),
                            new List (
                                Symbol.Intern ("quote"),
                                null),
                            new List (
                                Symbol.Intern ("cons"),
                                Symbol.Intern ("item"),
                                new List (
                                    Symbol.Intern ("port->list"),
                                    Symbol.Intern ("port"))))))),
            new List (
                Symbol.Intern ("define"),
                Symbol.Intern ("process-file"),
                new List (
                    Symbol.Intern ("lambda"),
                    new List (
                        Symbol.Intern ("infile"),
                        Symbol.Intern ("outfile"),
                        Symbol.Intern ("id")),
                    new List (
                        Symbol.Intern ("call-with-output-file"),
                        Symbol.Intern ("outfile"),
                        new List (
                            Symbol.Intern ("lambda"),
                            new List (
                                Symbol.Intern ("port")),
                            new List (
                                Symbol.Intern ("write-string"),
                                "// Automatically generated.  Don't bother to edit.",
                                Symbol.Intern ("port")),
                            new List (
                                Symbol.Intern ("newline"),
                                Symbol.Intern ("port")),
                            new List (
                                Symbol.Intern ("newline"),
                                Symbol.Intern ("port")),
                            new List (
                                Symbol.Intern ("write-string"),
                                "using LispLib;",
                                Symbol.Intern ("port")),
                            new List (
                                Symbol.Intern ("newline"),
                                Symbol.Intern ("port")),
                            new List (
                                Symbol.Intern ("newline"),
                                Symbol.Intern ("port")),
                            new List (
                                Symbol.Intern ("write-string"),
                                "class ",
                                Symbol.Intern ("port")),
                            new List (
                                Symbol.Intern ("write-string"),
                                Symbol.Intern ("id"),
                                Symbol.Intern ("port")),
                            new List (
                                Symbol.Intern ("newline"),
                                Symbol.Intern ("port")),
                            new List (
                                Symbol.Intern ("write-string"),
                                "{",
                                Symbol.Intern ("port")),
                            new List (
                                Symbol.Intern ("newline"),
                                Symbol.Intern ("port")),
                            new List (
                                Symbol.Intern ("write-string"),
                                "    object Read () =>",
                                Symbol.Intern ("port")),
                            new List (
                                Symbol.Intern ("newline"),
                                Symbol.Intern ("port")),
                            new List (
                                Symbol.Intern ("dump-object"),
                                new List (
                                    Symbol.Intern ("file->list"),
                                    Symbol.Intern ("infile")),
                                Symbol.Intern ("port"),
                                8),
                            new List (
                                Symbol.Intern ("write-string"),
                                ";",
                                Symbol.Intern ("port")),
                            new List (
                                Symbol.Intern ("newline"),
                                Symbol.Intern ("port")),
                            new List (
                                Symbol.Intern ("write-string"),
                                "}",
                                Symbol.Intern ("port")),
                            new List (
                                Symbol.Intern ("newline"),
                                Symbol.Intern ("port")))))),
            new List (
                Symbol.Intern ("define"),
                Symbol.Intern ("indent"),
                new List (
                    Symbol.Intern ("lambda"),
                    new List (
                        Symbol.Intern ("indentation"),
                        Symbol.Intern ("stream")),
                    new List (
                        Symbol.Intern ("unless"),
                        new List (
                            Symbol.Intern ("zero?"),
                            Symbol.Intern ("indentation")),
                        new List (
                            Symbol.Intern ("write-char"),
                            ' ',
                            Symbol.Intern ("stream")),
                        new List (
                            Symbol.Intern ("indent"),
                            new List (
                                Symbol.Intern ("-"),
                                Symbol.Intern ("indentation"),
                                1),
                            Symbol.Intern ("stream"))))),
            new List (
                Symbol.Intern ("define"),
                Symbol.Intern ("dump-object"),
                new List (
                    Symbol.Intern ("lambda"),
                    new List (
                        Symbol.Intern ("object"),
                        Symbol.Intern ("stream"),
                        Symbol.Intern ("indentation")),
                    new List (
                        Symbol.Intern ("indent"),
                        Symbol.Intern ("indentation"),
                        Symbol.Intern ("stream")),
                    new List (
                        Symbol.Intern ("cond"),
                        new List (
                            new List (
                                Symbol.Intern ("null?"),
                                Symbol.Intern ("object")),
                            new List (
                                Symbol.Intern ("write-string"),
                                "null",
                                Symbol.Intern ("stream"))),
                        new List (
                            new List (
                                Symbol.Intern ("char?"),
                                Symbol.Intern ("object")),
                            new List (
                                Symbol.Intern ("dump-char"),
                                Symbol.Intern ("object"),
                                Symbol.Intern ("stream"))),
                        new List (
                            new List (
                                Symbol.Intern ("list?"),
                                Symbol.Intern ("object")),
                            new List (
                                Symbol.Intern ("dump-list"),
                                Symbol.Intern ("object"),
                                Symbol.Intern ("stream"),
                                Symbol.Intern ("indentation"))),
                        new List (
                            new List (
                                Symbol.Intern ("number?"),
                                Symbol.Intern ("object")),
                            new List (
                                Symbol.Intern ("write"),
                                Symbol.Intern ("object"),
                                Symbol.Intern ("stream"))),
                        new List (
                            new List (
                                Symbol.Intern ("string?"),
                                Symbol.Intern ("object")),
                            new List (
                                Symbol.Intern ("dump-string"),
                                Symbol.Intern ("object"),
                                Symbol.Intern ("stream"))),
                        new List (
                            new List (
                                Symbol.Intern ("symbol?"),
                                Symbol.Intern ("object")),
                            new List (
                                Symbol.Intern ("dump-symbol"),
                                Symbol.Intern ("object"),
                                Symbol.Intern ("stream"))),
                        new List (
                            Symbol.Intern ("else"),
                            new List (
                                Symbol.Intern ("error"),
                                "Can't dump: ",
                                Symbol.Intern ("object")))))),
            new List (
                Symbol.Intern ("define"),
                Symbol.Intern ("dump-char"),
                new List (
                    Symbol.Intern ("lambda"),
                    new List (
                        Symbol.Intern ("char"),
                        Symbol.Intern ("stream")),
                    new List (
                        Symbol.Intern ("write-string"),
                        "'",
                        Symbol.Intern ("stream")),
                    new List (
                        Symbol.Intern ("write-char"),
                        Symbol.Intern ("char"),
                        Symbol.Intern ("stream")),
                    new List (
                        Symbol.Intern ("write-string"),
                        "'",
                        Symbol.Intern ("stream")))),
            new List (
                Symbol.Intern ("define"),
                Symbol.Intern ("dump-list"),
                new List (
                    Symbol.Intern ("lambda"),
                    new List (
                        Symbol.Intern ("list"),
                        Symbol.Intern ("stream"),
                        Symbol.Intern ("indentation")),
                    new List (
                        Symbol.Intern ("write-string"),
                        "new List (",
                        Symbol.Intern ("stream")),
                    new List (
                        Symbol.Intern ("newline"),
                        Symbol.Intern ("stream")),
                    new List (
                        Symbol.Intern ("if"),
                        new List (
                            Symbol.Intern ("null?"),
                            Symbol.Intern ("list")),
                        new List (
                            Symbol.Intern ("write-string"),
                            ")",
                            Symbol.Intern ("stream")),
                        new List (
                            Symbol.Intern ("let"),
                            Symbol.Intern ("loop"),
                            new List (
                                new List (
                                    Symbol.Intern ("head"),
                                    new List (
                                        Symbol.Intern ("car"),
                                        Symbol.Intern ("list"))),
                                new List (
                                    Symbol.Intern ("tail"),
                                    new List (
                                        Symbol.Intern ("cdr"),
                                        Symbol.Intern ("list")))),
                            new List (
                                Symbol.Intern ("if"),
                                new List (
                                    Symbol.Intern ("null?"),
                                    Symbol.Intern ("tail")),
                                new List (
                                    Symbol.Intern ("begin"),
                                    new List (
                                        Symbol.Intern ("dump-object"),
                                        Symbol.Intern ("head"),
                                        Symbol.Intern ("stream"),
                                        new List (
                                            Symbol.Intern ("+"),
                                            Symbol.Intern ("indentation"),
                                            4)),
                                    new List (
                                        Symbol.Intern ("write-string"),
                                        ")",
                                        Symbol.Intern ("stream"))),
                                new List (
                                    Symbol.Intern ("begin"),
                                    new List (
                                        Symbol.Intern ("dump-object"),
                                        Symbol.Intern ("head"),
                                        Symbol.Intern ("stream"),
                                        new List (
                                            Symbol.Intern ("+"),
                                            Symbol.Intern ("indentation"),
                                            4)),
                                    new List (
                                        Symbol.Intern ("write-string"),
                                        ",",
                                        Symbol.Intern ("stream")),
                                    new List (
                                        Symbol.Intern ("newline"),
                                        Symbol.Intern ("stream")),
                                    new List (
                                        Symbol.Intern ("loop"),
                                        new List (
                                            Symbol.Intern ("car"),
                                            Symbol.Intern ("tail")),
                                        new List (
                                            Symbol.Intern ("cdr"),
                                            Symbol.Intern ("tail"))))))))),
            new List (
                Symbol.Intern ("define"),
                Symbol.Intern ("dump-string"),
                new List (
                    Symbol.Intern ("lambda"),
                    new List (
                        Symbol.Intern ("string"),
                        Symbol.Intern ("stream")),
                    new List (
                        Symbol.Intern ("write-char"),
                        '"',
                        Symbol.Intern ("stream")),
                    new List (
                        Symbol.Intern ("write-string"),
                        Symbol.Intern ("string"),
                        Symbol.Intern ("stream")),
                    new List (
                        Symbol.Intern ("write-char"),
                        '"',
                        Symbol.Intern ("stream")))),
            new List (
                Symbol.Intern ("define"),
                Symbol.Intern ("dump-symbol"),
                new List (
                    Symbol.Intern ("lambda"),
                    new List (
                        Symbol.Intern ("symbol"),
                        Symbol.Intern ("stream")),
                    new List (
                        Symbol.Intern ("write-string"),
                        "Symbol.Intern (",
                        Symbol.Intern ("stream")),
                    new List (
                        Symbol.Intern ("write-char"),
                        '"',
                        Symbol.Intern ("stream")),
                    new List (
                        Symbol.Intern ("write-string"),
                        new List (
                            Symbol.Intern ("symbol-name"),
                            Symbol.Intern ("symbol")),
                        Symbol.Intern ("stream")),
                    new List (
                        Symbol.Intern ("write-char"),
                        '"',
                        Symbol.Intern ("stream")),
                    new List (
                        Symbol.Intern ("write-string"),
                        ")",
                        Symbol.Intern ("stream")))));
}
