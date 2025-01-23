// Apply any libraries here

namespace Mathematics.ConsoleApp
{
    // Program class
    public class Program
    {

        // Main method
        static void Main(string[] args)
        {
            try
            {
                // Define vars
                string operation;
                double operand1, operand2;
                double[] doubleList;
                ValidateArguments(args, out operation, out operand1, out operand2, out doubleList );
                BasicMath basicMathInstance = new BasicMath();
                AdvMath advMathInstance = new AdvMath();
                double result;
                

                // Depending on operation provided we perform the correct function
                switch (operation)
                {
                    case "+":
                    {
                        result = basicMathInstance.AddNumbers(operand1, operand2);
                        Console.WriteLine($"{operand1} plus {operand2} is {result}");
                        break;
                    }
                    case "-":
                    {
                        result = basicMathInstance.SubtractNumbers(operand1, operand2);
                        Console.WriteLine($"{operand1} minus {operand2} is {result}");
                        break;
                    }
                    case "*":
                    {
                        result = basicMathInstance.MultiplyNumbers(operand1, operand2);
                        Console.WriteLine($"{operand1} multiplied by {operand2} is {result}");
                        break;
                    }
                    case "/":
                    {
                        result = basicMathInstance.DivideNumbers(operand1, operand2);
                        Console.WriteLine($"{operand1} divided by {operand2} is {result}");
                        break;
                    }
                    case "area": 
                    {
                        result = advMathInstance.CalculateArea(operand1, operand2);
                        Console.WriteLine($"The area of a shape of height {operand1} and width {operand2} is {result}");
                        break;
                    }
                    case "avg":
                    {
                            
                        result = advMathInstance.CalculateAverage(doubleList);
                        Console.WriteLine($"The average of the list is {result}");
                        break;
                    }
                    case "sqr":
                    {
                        result = advMathInstance.CalculateSquare(operand1);
                        Console.WriteLine($"The square of {operand1} is {result}");
                        break;
                    }
                    case "pythagorean":
                    {
                        result = advMathInstance.CalculatePythagorean(operand1, operand2);
                        Console.WriteLine($"Pythagorean calculation where a={operand1}, and b={operand2}: c={result}");
                        break;
                    }
                    default:
                    {
                        // Could throw an exception instead
                        result = -1;
                        Console.WriteLine($"Error!");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Something went wrong: { ex.ToString()} ");
            }
        }

        // Okay so we need to expand our console to work with 4 new functions

        // For CalculateArea, Operation is "area"

        // For CalculateAverage, Operation is "avg"

        // For CalculateSquare, Operation is "sqr"

        // For CalculatePythagorean, Operation is "pythagorean"
        private static void ValidateArguments(string[] args, out string operation, out double operand1, out double operand2, out double[] doubleList)
        {
            // Define different arrays that will be used to catagorize what validation technique will be used.
            string[] operators = { "+", "-", "*", "/", "area", "pythagorean" };
            string[] singleOps = { "sqr" };
            string[] multiOps = { "avg" };

            // Get first arg and check if the arg is in any of the arrays
            string op = args[0];
            bool isOperator = operators.Contains(op);
            bool isSingle = singleOps.Contains(op);
            bool isMulti = multiOps.Contains(op);

            // Validate Operator
            if (!isOperator && !isSingle && !isMulti)
            {
                throw new ArgumentException("First argument must be a valid operator.");
            }
            else
            {
                operation = args[0];
            }

            // Now depending on the operator type we perform certain validation/operations here
            if (isOperator)
            {
                // Validate first digit
                if (!double.TryParse(args[1], out operand1))
                {
                    throw new ArgumentException("Second argument must be a valid integer");
                }

                // Validate second digit
                if (!double.TryParse(args[2], out operand2))
                {
                    throw new ArgumentException("Third argument must be a valid integer");
                }
                doubleList = [0];
            }
            else if (isSingle)
            {
                // Validate first digit
                if (!double.TryParse(args[1], out operand1))
                {
                    throw new ArgumentException("Second argument must be a valid integer");
                }
                operand2 = 0;
                doubleList = [0];
            }
            else
            {
                List<double> list = new List<double>();
                for (int i = 1; i < args.Length; i++)
                {
                    if (double.TryParse(args[i], out double result))
                    {
                        list.Add(result); // Add to the list
                    }
                    else
                    {
                        Console.WriteLine($"Invalid number: {args[i]}");
                        throw new ArgumentException($"Bad argument at argument {i + 1}");
                    }
                }
                //
                operand1 = 0;
                operand2 = 0;
                doubleList = list.ToArray();
            }
        }

    }
}
