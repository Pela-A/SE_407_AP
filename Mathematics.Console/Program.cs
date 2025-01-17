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

                ValidateArguments(args, out operation, out operand1, out operand2);


                BasicMath basicMathInstance = new BasicMath();

                double result;
                string operationDesc;
                switch (operation)
                {
                    case "+":
                    {
                        result = basicMathInstance.AddNumbers(operand1, operand2);
                        operationDesc = "plus";
                        break;
                    }
                    case "-":
                    {
                        result = basicMathInstance.SubtractNumbers(operand1, operand2);
                        operationDesc = "minus";
                        break;
                    }
                    case "*":
                    {
                        result = basicMathInstance.MultiplyNumbers(operand1, operand2);
                        operationDesc = "multiply by";
                        break;
                    }
                    case "/":
                    {
                        result = basicMathInstance.DivideNumbers(operand1, operand2);
                        operationDesc = "divide by";
                        break;
                    }
                    default:
                    {
                            // Could throw an exception instead
                            result = -1;
                            operationDesc = "Error";
                            break;
                    }
                }

                if (operationDesc == "Error")
                {
                    Console.WriteLine("An error occured with the operator");
                }
                Console.WriteLine($"{operand1} {operationDesc} {operand2} is equal to {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Something went wrong: { ex.ToString()} ");
            }



            //string[] args = Environment.GetCommandLineArgs();
            //foreach (var a in args)
            //{
            //    Console.WriteLine(a);
            //}
            //Console.ReadLine();
        }

        private static void ValidateArguments(string[] args, out string operation, out double operand1, out double operand2)
        {
            // Validate Operator
            if (args[0] != "+" && args[0] != "-" && args[0] != "*" && args[0] != "/")
            {
                throw new ArgumentException("First argument must be a math operator.");
            }
            else
            {
                operation = args[0];
            }

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
        }

    }
}
