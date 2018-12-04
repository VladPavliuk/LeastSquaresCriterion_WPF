using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LinearRegressionLeastSquaresCriterion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int oneUnitLength = 12;

        public List<(double, double)> inputData = new List<(double, double)>
            {
                (1, 1),
                (2, 2),
                (3, 1.3),
                (4, 3.75),
                (5, 2.25)
            };

        public MainWindow()
        {
            InitializeComponent();
            var regresionLine = LeastSquaresCriterion.Execute(inputData);

            DrawNet();

            DrawLinearGragh(regresionLine.Item1, regresionLine.Item2);

            GraphLable.Content = $"y = {Math.Round(regresionLine.Item1, 4)} x" +
                (regresionLine.Item2 < 0 ? " - " : " + ") +
                $"{Math.Abs(Math.Round(regresionLine.Item2, 4))}";
        }

        private void DrawLinearGragh(double slope, double intercept)
        {
            var rangeOfX = (-10_000, 10_000);

            DrawLine(
                (rangeOfX.Item1, (int)(slope * rangeOfX.Item1 + intercept)),
                (rangeOfX.Item2, (int)(slope * rangeOfX.Item2 + intercept))
            );
        }

        private void DrawNet()
        {
            var canvasWidth = GraphPlain.Width;
            var canvasHeight = GraphPlain.Height;

            for (var i = 0; i < canvasWidth; i++)
            {
                GraphPlain.Children.Add(
                    new Line()
                    {
                        Stroke = Brushes.LightSteelBlue,
                        X1 = i * oneUnitLength,
                        Y1 = 0,
                        X2 = i * oneUnitLength,
                        Y2 = canvasHeight
                    });
            }

            for (var j = 0; j < canvasHeight; j++)
            {
                GraphPlain.Children.Add(new Line()
                {
                    Stroke = Brushes.LightSteelBlue,
                    X1 = 0,
                    Y1 = j * oneUnitLength,
                    X2 = canvasWidth,
                    Y2 = j * oneUnitLength
                });
            }

            GraphPlain.Children.Add(new Line()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 3,
                X1 = canvasWidth / 2,
                Y1 = 0,
                X2 = canvasWidth / 2,
                Y2 = canvasHeight
            });

            GraphPlain.Children.Add(new Line()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 3,
                X1 = 0,
                Y1 = canvasHeight / 2,
                X2 = canvasWidth,
                Y2 = canvasHeight / 2
            });
        }

        private void DrawLine((int, int) firstPoint, (int, int) secondPoint)
        {
            var canvasWidth = GraphPlain.Width;
            var canvasHeight = GraphPlain.Height;

            Line line = new Line();

            line.Stroke = SystemColors.WindowFrameBrush;
            line.X1 = canvasWidth / 2 + firstPoint.Item1 * oneUnitLength;
            line.Y1 = canvasHeight / 2 - firstPoint.Item2 * oneUnitLength;
            line.X2 = canvasWidth / 2 + secondPoint.Item1 * oneUnitLength;
            line.Y2 = canvasHeight / 2 - secondPoint.Item2 * oneUnitLength;

            GraphPlain.Children.Add(line);
        }
    }
}
