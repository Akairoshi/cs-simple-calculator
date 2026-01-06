class Calc
{
    private const string ALLOWED_SYMBOLS = "+-*/";
    public double safeInput_Num(string num)
    {
        while (true)
        {
            Console.Write($"Enter num {num}: ");
            if (double.TryParse(Console.ReadLine(), out double number))
            {
                return number;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Not a number!");
            }
        }
    }
    public char safeInput_Char()
    {
        while (true)
        {
            Console.Write("Enter operation: ");
            string opGet = Console.ReadLine();
            if (string.IsNullOrEmpty(opGet)){
                Console.Clear();
                Console.WriteLine("String is NULL!");
                continue;
            }
            if(opGet.Length == 1 && ALLOWED_SYMBOLS.Contains(opGet[0]))
            {
                return opGet[0];
            }
            else if (opGet.Length >= 2)
            {
                Console.Clear();
                Console.WriteLine("String lenght is out of range!");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Only allowed symbols! (+ - / *)");
            }
        }
    }
    public double Add(double a, double b)
    {
        return a + b;
    }
    public double Subs(double a, double b)
    {
        return a - b;
    }
    public double Mult(double a, double b)
    {
        return a * b;
    }
    public double Div(double a, double b)
    {
        if (Math.Abs(b) < double.Epsilon)
        {
            Console.WriteLine("Divided by zero!");
            return 0;
        }
        else return a / b;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Calc calc = new Calc();
        Console.Clear();
        char op = calc.safeInput_Char();
        Console.Clear();
        double a = calc.safeInput_Num("a");
        Console.Clear();
        double b = calc.safeInput_Num("b");
        Console.Clear();

        double result = 0;

        switch (op)
        {
            case '+':
                result = calc.Add(a, b);
                break;
            case '-':
                result = calc.Subs(a, b);
                break;
            case '*':
                result = calc.Mult(a, b);
                break;
            case '/':
                result = calc.Div(a, b);
                break;
            default:
                Console.WriteLine("Unknown operation");
                break;
        }
        Console.WriteLine($"{a} {op} {b} = {result}");
        Thread.Sleep(2000);
    }
}