using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LispLib
{
    public class Reader
    {
        static void DiscardWhitespace (TextReader textReader) {
            while (char.IsWhiteSpace ((char) textReader.Peek())) {
                textReader.Read ();
            }
        }

        static bool IsTokenConstituent (char c) {
            return char.IsLetterOrDigit (c) || char.IsPunctuation (c);
        }

        static string ReadToken (TextReader textReader) {
            StringBuilder stringBuilder = new StringBuilder ();
            while (IsTokenConstituent ((char) textReader.Peek())) {
                stringBuilder.Append (textReader.Read ());
            }
            return stringBuilder.ToString ();
        }

        public static object Read (TextReader textReader, bool isEofError, object eofValue, bool isRecursive) {

            DiscardWhitespace (textReader);

            int i = textReader.Peek ();
            if (i == -1) {
                if (isEofError) {
                    throw new EndOfFileError ();
                } else {
                    return eofValue;
                }
            }

            string token = ReadToken (textReader);
            if (double.TryParse (token, out double doubleValue))
                return doubleValue;
            if (int.TryParse (token, out int intValue))
                return intValue;
            return string.Intern (token);
        }
    }
}
