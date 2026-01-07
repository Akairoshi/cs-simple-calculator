namespace Calculator;

public static class Logic
{
    
    public const string ALLOWED_SYMBOLS = "+-*/^%";
    public static bool TryParseOperation(string input, out char operation, out string error)
    {
        operation = default;
        error = null;
        if (string.IsNullOrEmpty(input))
        {
            error = "Empty line!";
            return false;
        }
        if (input.Length != 1)
        {
            error = "Only one character allowed!";
            return false;
        }
        if (!ALLOWED_SYMBOLS.Contains(input))
        {
            error = $"Only allowed symbols: {string.Join(' ',ALLOWED_SYMBOLS.ToCharArray())}";
            return false;
        }
        operation = input[0];
        return true;
    }
    public static bool TryParseNumber(string input, out double num, out string error)
    {
        num = default;
        error = null;
        if (!double.TryParse(input, out num))
        {
            error = "Only number!";
            return false; 
        }

        return true;

    }

    public static double Add(double a, double b) =>  a + b;
    public static double Subtract(double a, double b) => a - b;
    public static double Multiply(double a, double b) => a * b;
    public static double Divide(double a, double b)
    {
        if(Math.Abs(b) < double.Epsilon)
        {
            throw new DivideByZeroException();
        }
        return a / b;   
    }
    public static double Power(double a, double b) => Math.Pow(a, b);
    public static double Percent(double a, double b) => a * b / 100;    

}