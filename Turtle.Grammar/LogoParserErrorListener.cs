using Antlr4.Runtime;
using System.Collections.Generic;
using System.IO;

namespace Turtle.Grammar
{
    public class LogoParserErrorListener : BaseErrorListener
    {
        public List<LogoErrorMessage> ErrorMessages { get; } = new();

        public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            ErrorMessages.Add(new LogoErrorMessage
            {
                Message = $"Line {line}: {msg}",
                Line = line,
                Column = charPositionInLine,
            });

            base.SyntaxError(output, recognizer, offendingSymbol, line, charPositionInLine, msg, e);
        }
    }
}
