namespace Calculator;

public class Ui
{
    public const string EXIT_WORD = "exit";

    public bool ProgramExit(string input)
    {
        return input.ToLower() == EXIT_WORD;
    }

    public void Run()
    {

        Console.WriteLine("==== Simple calculator ====");

        while (true)
        {

            char operation;
            double a;
            double b;

            while (true)
            {
                Console.Write($"Enter operation ({string.Join(' ', Logic.ALLOWED_SYMBOLS.ToCharArray())} || {EXIT_WORD}): ");
                string input = Console.ReadLine();
                if (ProgramExit(input))
                {
                    return;
                }
                if (Logic.TryParseOperation(input, out operation, out string error))
                    break;
                Console.WriteLine($"\n! >> {error}");
            }

            Console.WriteLine($"\n==== a {operation} b ====\n");

            while (true)
            {
                Console.Write("Enter number a: ");
                string input = Console.ReadLine();
                if (ProgramExit(input))
                {
                    return;
                }
                if (Logic.TryParseNumber(input, out a, out string error))
                    break;
                Console.WriteLine($"\n! >> {error}");
            }

            while (true)
            {
                Console.Write("Enter number b: ");
                string input = Console.ReadLine();
                if (ProgramExit(input))
                {
                    return;
                }
                if (Logic.TryParseNumber(input, out b, out string error))
                    break;
                Console.WriteLine($"\n! >> {error}");
            }

            try
            {
                double result = operation switch
                {
                    '+' => Logic.Add(a, b),
                    '-' => Logic.Subtract(a, b),
                    '*' => Logic.Multiply(a, b),
                    '/' => Logic.Divide(a, b),
                    '^' => Logic.Power(a, b),
                    '%' => Logic.Percent(a, b),
                    _ => throw new InvalidOperationException()
                };

                Console.WriteLine($"\n{a} {operation} {b} = {result}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("\n! >> Divided by zero!");
            }

            Console.WriteLine("\n===========================\n");
        }
    }
}