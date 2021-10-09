using System.Windows;
using System.Windows.Controls;
using Turtle.Grammar;
using Turtle.Main;

namespace Turtle
{
    public partial class MainWindow
    {
        private const string InitialCode =
@"repeat 8 {
  forward 150
  turn 144
}";

        public MainWindow()
        {
            InitializeComponent();
            CodeTextBox.Text = InitialCode;
        }

        private void RunButtonClicked(object sender, RoutedEventArgs e)
        {
            ResetCanvas();

            var turtle = new GraphicTurtle(DrawingCanvas, TurtleShape, TurtleRotatation);
            LogoLanguageHelper.ParseAndExecuteLogoScript(CodeTextBox.Text, turtle);
        }

        private void ResetCanvas()
        {
            DrawingCanvas.Children.Clear();
            DrawingCanvas.Children.Add(TurtleShape);
            Canvas.SetLeft(TurtleShape, (DrawingCanvas.ActualWidth - TurtleShape.ActualWidth) / 2);
            Canvas.SetTop(TurtleShape, (DrawingCanvas.ActualHeight - TurtleShape.ActualHeight) / 2);
            TurtleRotatation.Angle = 0;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ResetCanvas();
        }
    }
}
