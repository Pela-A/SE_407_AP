using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics
{
    // This class contains advanced mathematic functions.
    public class AdvMath
    {
        // This function calculates the area given a height and width of type double
        public double CalculateArea(double height, double width)
        {
            return height * width;
        }

        // This function returns the average from a list of doubles

        public double CalculateAverage(double[] list)
        {
            int length = list.Length;

            double sum = 0;
            // Loop to get sum
            for (int i = 0; i < length; i++)
            {
                sum += list[i];
            }

            // Divide sum by length number of integers
            return sum / length;
        }

        // This function calculates the square of a number?

        public double CalculateSquare(double number)
        {
            // Using Math.Pow in case we ever want to change it to cube etc.
            return Math.Pow(number, 2);
        }

        // This function calculates the value of C in the pythagorean theorem
        // a^2 + b^2 = c^2
        public double CalculatePythagorean(double a, double b)
        {
            return Math.Sqrt(CalculateSquare(a) + CalculateSquare(b));
        }
    }
}
