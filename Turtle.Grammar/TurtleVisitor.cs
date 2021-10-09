using System;

namespace Turtle.Grammar
{
    public class TurtleVisitor : LogoBaseVisitor<object>
    {
        private readonly ITurtle _turtle;

        public TurtleVisitor(ITurtle turtle)
        {
            if (turtle == null) throw new ArgumentNullException(nameof(turtle));

            _turtle = turtle;
        }

        public override object VisitForward(LogoParser.ForwardContext context)
        {
            int distance = int.Parse(context.NUMBER().GetText());
            _turtle.MoveForward(distance);

            return null;
        }

        public override object VisitTurn(LogoParser.TurnContext context)
        {
            int angle = int.Parse(context.NUMBER().GetText());
            _turtle.TurnByAngle(angle);

            return null;
        }

        public override object VisitRepeat(LogoParser.RepeatContext context)
        {
            int times = int.Parse(context.NUMBER().GetText());

            for (int i = 0; i < times; i++)
            {
                VisitCommandList(context.commandList());
            }

            return null;
        }
    }
}
