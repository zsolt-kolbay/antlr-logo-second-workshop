using Antlr4.Runtime;
using System.Collections.Generic;
using System.IO;

namespace Turtle.Grammar
{
    public class LogoLexerErrorListener : IAntlrErrorListener<int>
    {
        public List<LogoErrorMessage> ErrorMessages { get; } = new();

        public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            ErrorMessages.Add(new LogoErrorMessage
            {
                Message = $"Line {line}: {msg}",
                Line = line,
                Column = charPositionInLine,
            });
        }
    }
}
