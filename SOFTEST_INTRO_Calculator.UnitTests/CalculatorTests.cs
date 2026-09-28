using SOFTEST_INTRO_Calculator;
using NUnit.Framework;

namespace SOFTEST_INTRO_Calculator.UnitTests;

public class CalculatorTests
{
    private Calculator _calculator = null!;

    [SetUp]
    public void SetUp()
    {
        _calculator = new Calculator();
    }

    // ---------- Add ----------

    [Test]
    public void Add_TwoPositiveNumbers_ReturnsSum()
    {
        double result = _calculator.Add(10, 20);
        Assert.That(result, Is.EqualTo(30));
    }

    [TestCase(0, 0, 0)]
    [TestCase(0, 5, 5)]
    [TestCase(-3, 8, 5)]
    [TestCase(0.1, 0.2, 0.3)]
    public void Add_RepresentativeInputs_ReturnsSum(double a, double b, double expected)
    {
        double result = _calculator.Add(a, b);
        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }

    // ---------- Subtract ----------

    [TestCase(10, 4, 6)]
    [TestCase(0, 0, 0)]
    [TestCase(-5, -5, 0)]
    [TestCase(-3, 4, -7)]
    public void Subtract_RepresentativeInputs_ReturnsDifference(double a, double b, double expected)
    {
        double result = _calculator.Subtract(a, b);
        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }

    // ---------- Multiply ----------

    [TestCase(3, 4, 12)]
    [TestCase(0, 100, 0)]
    [TestCase(-2, 5, -10)]
    [TestCase(-3, -3, 9)]
    public void Multiply_RepresentativeInputs_ReturnsProduct(double a, double b, double expected)
    {
        double result = _calculator.Multiply(a, b);
        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }

    // ---------- Divide ----------

    [TestCase(1, 2, 0.5)]
    [TestCase(0, 15, 0)]
    [TestCase(15, -3, -5)]
    public void Divide_ValidInputs_ReturnsQuotient(double a, double b, double expected)
    {
        double result = _calculator.Divide(a, b);
        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(15, 0)]
    [TestCase(0, 0)]
    public void Divide_ZeroDivisor_ThrowsArgumentException(double a, double b)
    {
        Assert.That(() => _calculator.Divide(a, b),
            Throws.TypeOf<ArgumentException>());
    }

    // ---------- Factorial ----------

    [Test]
    public void Factorial_Zero_ReturnsOne()
    {
        long result = _calculator.Factorial(0);
        Assert.That(result, Is.EqualTo(1L));
    }

    [TestCase(1, 1L)]
    [TestCase(5, 120L)]
    [TestCase(20, 2432902008176640000L)]
    public void Factorial_ValidInputs_ReturnsExpected(int n, long expected)
    {
        long result = _calculator.Factorial(n);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(-1)]
    [TestCase(21)]
    public void Factorial_OutOfRange_ThrowsArgumentOutOfRangeException(int n)
    {
        Assert.That(() => _calculator.Factorial(n),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    // ---------- TriangleArea ----------

    [TestCase(3, 4, 6)]
    [TestCase(0, 5, 0)]
    [TestCase(5, 0, 0)]
    public void TriangleArea_ValidInputs_ReturnsExpected(double height, double width, double expected)
    {
        double result = _calculator.TriangleArea(height, width);
        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(-1, 4)]
    [TestCase(3, -4)]
    public void TriangleArea_NegativeDimension_ThrowsArgumentOutOfRangeException(double height, double width)
    {
        Assert.That(() => _calculator.TriangleArea(height, width),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    // ---------- CircleArea ----------

    [Test]
    public void CircleArea_RadiusOne_ReturnsPi()
    {
        double result = _calculator.CircleArea(1);
        Assert.That(result, Is.EqualTo(Math.PI).Within(1e-9));
    }

    [Test]
    public void CircleArea_RadiusZero_ReturnsZero()
    {
        double result = _calculator.CircleArea(0);
        Assert.That(result, Is.EqualTo(0).Within(1e-9));
    }

    [Test]
    public void CircleArea_NegativeRadius_ThrowsArgumentOutOfRangeException()
    {
        Assert.That(() => _calculator.CircleArea(-1),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    // ---------- Extension: UnknownFunctionA / B ----------

    [TestCase(5, 5, 120L)]
    [TestCase(5, 4, 120L)]
    [TestCase(5, 3, 60L)]
    [TestCase(5, 0, 1L)]
    [TestCase(0, 0, 1L)]
    public void UnknownFunctionA_ValidInputs_ReturnsExpected(int n, int r, long expected)
    {
        long result = _calculator.UnknownFunctionA(n, r);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(-4, 5)]
    [TestCase(4, 5)]
    public void UnknownFunctionA_InvalidInputs_ThrowsArgumentOutOfRangeException(int n, int r)
    {
        Assert.That(() => _calculator.UnknownFunctionA(n, r),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [TestCase(5, 5, 1L)]
    [TestCase(5, 4, 5L)]
    [TestCase(5, 3, 10L)]
    [TestCase(5, 0, 1L)]
    [TestCase(0, 0, 1L)]
    public void UnknownFunctionB_ValidInputs_ReturnsExpected(int n, int r, long expected)
    {
        long result = _calculator.UnknownFunctionB(n, r);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(-4, 5)]
    [TestCase(4, 5)]
    public void UnknownFunctionB_InvalidInputs_ThrowsArgumentOutOfRangeException(int n, int r)
    {
        Assert.That(() => _calculator.UnknownFunctionB(n, r),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    // ---------- Mtbf ----------

    [TestCase(900, 10, 90)]
    [TestCase(1, 1, 1)]
    public void Mtbf_ValidInputs_ReturnsAverage(double operatingTime, double numberOfFailures, double expected)
    {
        double result = _calculator.Mtbf(operatingTime, numberOfFailures);
        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(0, 10)]
    [TestCase(-5, 10)]
    [TestCase(900, 0)]
    [TestCase(900, -1)]
    public void Mtbf_NonPositiveInputs_ThrowsArgumentOutOfRangeException(double operatingTime, double numberOfFailures)
    {
        Assert.That(() => _calculator.Mtbf(operatingTime, numberOfFailures),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    // ---------- Availability ----------

    [TestCase(90, 10, 0.9)]
    [TestCase(0, 10, 0)]
    public void Availability_ValidInputs_ReturnsRatio(double mtbf, double mttr, double expected)
    {
        double result = _calculator.Availability(mtbf, mttr);
        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(-1, 10)]
    [TestCase(90, -1)]
    public void Availability_NegativeInputs_ThrowsArgumentOutOfRangeException(double mtbf, double mttr)
    {
        Assert.That(() => _calculator.Availability(mtbf, mttr),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public void Availability_ZeroDenominator_ThrowsArgumentException()
    {
        Assert.That(() => _calculator.Availability(0, 0),
            Throws.TypeOf<ArgumentException>());
    }

    // ---------- Basic Musa: CurrentFailureIntensity ----------

    [Test]
    public void CurrentFailureIntensity_ZeroExecutionTime_ReturnsLambda0()
    {
        double result = _calculator.CurrentFailureIntensity(0.02, 100, 0);
        Assert.That(result, Is.EqualTo(0.02).Within(1e-9));
    }

    [Test]
    public void CurrentFailureIntensity_PositiveExecutionTime_DecaysExponentially()
    {
        double result = _calculator.CurrentFailureIntensity(0.02, 100, 50);
        Assert.That(result, Is.EqualTo(0.019801).Within(1e-6));
    }

    [TestCase(0, 100, 10)]
    [TestCase(0.02, 0, 10)]
    [TestCase(0.02, 100, -1)]
    public void CurrentFailureIntensity_InvalidInputs_ThrowsArgumentOutOfRangeException(double lambda0, double nu0, double tau)
    {
        Assert.That(() => _calculator.CurrentFailureIntensity(lambda0, nu0, tau),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    // ---------- Basic Musa: ExpectedCumulativeFailures ----------

    [Test]
    public void ExpectedCumulativeFailures_ZeroExecutionTime_ReturnsZero()
    {
        double result = _calculator.ExpectedCumulativeFailures(0.02, 100, 0);
        Assert.That(result, Is.EqualTo(0).Within(1e-9));
    }

    [Test]
    public void ExpectedCumulativeFailures_PositiveExecutionTime_ApproachesNu0()
    {
        double result = _calculator.ExpectedCumulativeFailures(0.02, 100, 50);
        Assert.That(result, Is.EqualTo(0.995017).Within(1e-6));
    }

    [TestCase(0, 100, 10)]
    [TestCase(0.02, 0, 10)]
    [TestCase(0.02, 100, -1)]
    public void ExpectedCumulativeFailures_InvalidInputs_ThrowsArgumentOutOfRangeException(double lambda0, double nu0, double tau)
    {
        Assert.That(() => _calculator.ExpectedCumulativeFailures(lambda0, nu0, tau),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }
}