using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearRegressionLeastSquaresCriterion
{
    public static class LeastSquaresCriterion
    {
        public static (double, double) Execute(List<(double, double)> inputData)
        {
            var slope = CalculateSlope(inputData);
            var intercept = CalculateIntercept(inputData, slope);

            return (slope, intercept);
        }

        private static double CalculateSlope(List<(double, double)> inputData)
        {
            double sumOfX = 0;
            double sumOfY = 0;
            double sumOfXY = 0;
            double sumOfXSquare = 0;

            foreach (var item in inputData)
            {
                sumOfX += item.Item1;
                sumOfXSquare += Math.Pow(item.Item1, 2);
                sumOfY += item.Item2;
                sumOfXY += item.Item1 * item.Item2;
            }

            return (sumOfXY - sumOfX * sumOfY / inputData.Count) / (sumOfXSquare - Math.Pow(sumOfX, 2) / inputData.Count);
        }

        private static double CalculateIntercept(List<(double, double)> inputData, double slope)
        {
            double sumOfX = 0;
            double sumOfY = 0;

            foreach (var item in inputData)
            {
                sumOfX += item.Item1;
                sumOfY += item.Item2;
            }

            return (sumOfY - slope * sumOfX) / inputData.Count;
        }
    }
}
