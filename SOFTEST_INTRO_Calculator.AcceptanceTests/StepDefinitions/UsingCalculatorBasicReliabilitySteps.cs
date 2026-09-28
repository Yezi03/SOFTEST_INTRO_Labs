using NUnit.Framework;
using Reqnroll;
using SOFTEST_INTRO_Calculator.AcceptanceTests.Support;

namespace SOFTEST_INTRO_Calculator.AcceptanceTests.StepDefinitions;

[Binding]
public sealed class UsingCalculatorBasicReliabilitySteps
{
    private readonly CalculatorContext _context;

    public UsingCalculatorBasicReliabilitySteps(CalculatorContext context)
        => _context = context;

    [When("I have entered {double} and {double} and {double} into the calculator and press current failure intensity")]
    public void WhenIHaveEnteredAndPressCurrentFailureIntensity(double lambda0, double nu0, double tau)
    {
        _context.Result = null;
        _context.Error = null;

        try
        {
            _context.Result = _context.Calculator.CurrentFailureIntensity(lambda0, nu0, tau);
        }
        catch (ArgumentOutOfRangeException error)
        {
            _context.Error = error;
        }
    }

    [When("I have entered {double} and {double} and {double} into the calculator and press expected cumulative failures")]
    public void WhenIHaveEnteredAndPressExpectedCumulativeFailures(double lambda0, double nu0, double tau)
    {
        _context.Result = null;
        _context.Error = null;

        try
        {
            _context.Result = _context.Calculator.ExpectedCumulativeFailures(lambda0, nu0, tau);
        }
        catch (ArgumentOutOfRangeException error)
        {
            _context.Error = error;
        }
    }

    [Then("Basic Musa calculation should be rejected")]
    public void ThenBasicMusaCalculationShouldBeRejected()
    {
        Assert.That(_context.Error, Is.TypeOf<ArgumentOutOfRangeException>());
    }
}