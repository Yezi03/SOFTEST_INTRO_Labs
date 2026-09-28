namespace SOFTEST_INTRO_Calculator;

public class Calculator
{
    public double Add(double a, double b) => a + b;
    public double Subtract(double a, double b) => a - b;
    public double Multiply(double a, double b) => a * b;

    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new ArgumentException("Cannot divide by zero.");
        }
        return a / b;
    }

    public double DoOperation(double a, double b, string op)
    {
        return op switch
        {
            "a" => Add(a, b),
            "s" => Subtract(a, b),
            "m" => Multiply(a, b),
            "d" => Divide(a, b),
            _ => throw new ArgumentException("Unknown operation.")
        };
    }

    public long Factorial(int n)
    {
        if (n < 0 || n > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "n must be between 0 and 20 inclusive.");
        }

        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    public double TriangleArea(double height, double width)
    {
        if (height < 0 || width < 0)
        {
            throw new ArgumentOutOfRangeException(
                height < 0 ? nameof(height) : nameof(width),
                "Dimensions cannot be negative.");
        }
        return 0.5 * height * width;
    }

    public double CircleArea(double radius)
    {
        if (radius < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(radius), "Radius cannot be negative.");
        }
        return Math.PI * radius * radius;
    }

    public long UnknownFunctionA(int n, int r)
    {
        ValidateNAndR(n, r);
        return Factorial(n) / Factorial(n - r);
    }

    public long UnknownFunctionB(int n, int r)
    {
        ValidateNAndR(n, r);
        return Factorial(n) / (Factorial(r) * Factorial(n - r));
    }

    private static void ValidateNAndR(int n, int r)
    {
        if (n < 0 || n > 20 || r < 0 || r > n)
        {
            throw new ArgumentOutOfRangeException(
                nameof(n), "Requires 0 <= r <= n <= 20.");
        }
    }

    public double GenMagicNum(
    int choice, string path, IFileReader fileReader)
    {
        ArgumentNullException.ThrowIfNull(fileReader);

        if (choice < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(choice));
        }

        string[] magicStrings = fileReader.Read(path);

        if (choice >= magicStrings.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(choice));
        }

        double magicNumber = double.Parse(magicStrings[choice]);
        return 2 * Math.Abs(magicNumber);
    }

    // ---------- Part II: Reliability calculations ----------

    // operating time / number of failures. Both must be positive.
    public double Mtbf(double operatingTime, double numberOfFailures)
    {
        if (operatingTime <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(operatingTime), "Operating time must be positive.");
        }
        if (numberOfFailures <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(numberOfFailures), "Number of failures must be positive.");
        }
        return operatingTime / numberOfFailures;
    }

    // MTBF / (MTBF + MTTR), using MTTF ≈ MTBF. Neither may be negative; their sum must be positive.
    public double Availability(double mtbf, double mttr)
    {
        if (mtbf < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(mtbf), "MTBF cannot be negative.");
        }
        if (mttr < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(mttr), "MTTR cannot be negative.");
        }

        double denominator = mtbf + mttr;
        if (denominator <= 0)
        {
            throw new ArgumentException("MTBF + MTTR must be positive.");
        }

        return mtbf / denominator;
    }

    // Basic Musa model. lambda0 > 0, nu0 > 0, tau >= 0.
    public double CurrentFailureIntensity(double lambda0, double nu0, double tau)
    {
        ValidateBasicMusaInputs(lambda0, nu0, tau);
        return lambda0 * Math.Exp(-lambda0 * tau / nu0);
    }

    public double ExpectedCumulativeFailures(double lambda0, double nu0, double tau)
    {
        ValidateBasicMusaInputs(lambda0, nu0, tau);
        return nu0 * (1 - Math.Exp(-lambda0 * tau / nu0));
    }

    private static void ValidateBasicMusaInputs(double lambda0, double nu0, double tau)
    {
        if (lambda0 <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(lambda0), "Initial failure intensity (lambda0) must be positive.");
        }
        if (nu0 <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(nu0), "Expected total failures (nu0) must be positive.");
        }
        if (tau < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(tau), "Execution time (tau) cannot be negative.");
        }
    }
}