using Antlr4.Runtime;

namespace Turtle.Grammar
{
    public static class LogoLanguageHelper
    {
        public static void ParseAndExecuteLogoScript(string sourceCode, ITurtle turtle)
        {
            // create a stream from the source code
            // pass that stream to the Lexer
            var lexer = new LogoLexer(new AntlrInputStream(sourceCode));

            // create a stream of tokens from the Lexer
            var tokenStream = new CommonTokenStream(lexer);

            // pass that stream to the Parser
            var parser = new LogoParser(tokenStream);

            // get the root node of the parsed syntax tree
            LogoParser.ProgramContext context = parser.program();

            // pass that root node to a Visitor object
            var visitor = new TurtleVisitor(turtle);
            visitor.VisitProgram(context);
        }
    }
}
