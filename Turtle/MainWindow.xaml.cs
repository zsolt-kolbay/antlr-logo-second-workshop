using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Turtle.Grammar;
using Turtle.Main;

namespace Turtle
{
    public partial class MainWindow
    {
        private const string InitialCode =
@"pen up
turn 180
forward 100
pen down

repeat 5 {
 color green
 repeat 8 {
   forward 150
   turn 144
 }

 pen up
 forward 350
 pen down

 color red
 repeat 120 {
   forward 10
   turn 3
 }
}

save ""C:\LOGO\Images\sample.png""";

        public LogoErrorMessage[] ParserErrors = Array.Empty<LogoErrorMessage>();

        public MainWindow()
        {
            InitializeComponent();
            CodeTextBox.Text = InitialCode;
        }

        private void RunButtonClicked(object sender, RoutedEventArgs e)
        {
            ResetCanvas();

            var turtle = new GraphicTurtle(DrawingCanvas, TurtleShape, TurtleRotatation);
            ParserErrors = LogoLanguageHelper.ParseAndExecuteLogoScript(CodeTextBox.Text, turtle);

            ParserMessageList.Items.Clear();
            foreach (var error in ParserErrors)
            {
                ParserMessageList.Items.Add(error);
            }
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

        private async void ParserMessageList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ParserMessageList.SelectedItem is LogoErrorMessage logoError)
            {
                ParserMessageList.SelectedItem = null;
                await Task.Delay(50); // yeah, WPF sure has some strange behaviors
                CodeTextBox.Focus();
                CodeTextBox.CaretIndex = CodeTextBox.GetCharacterIndexFromLineIndex(logoError.Line - 1) + logoError.Column;
            }
        }
    }
}
