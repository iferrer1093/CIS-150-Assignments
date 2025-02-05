using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator_Class_Testing;
using static Calculator;
namespace Calculator_Class_Testing;

[TestClass]
public class CalculatorTest
{

    [TestMethod]
    public void Add_AddsTwoWholeNumbers_TakesSumOfNumbers()
    {
        var calculator = new Calc();

        var result = calculator.Add(1, 2);

        Assert.AreEqual(3, result);
    }

    [TestMethod]
    public void Add_AddsOneNegativeWholeNumber_TakesSumOfNumbers()
    {
        var calculator = new Calc();

        var result = calculator.Add(-1, 2);

        Assert.AreEqual(1, result);
    }
    [TestMethod]
    public void Subtract_SubtractsTwoWholePositiveNumbers()
    {
        var calculator = new Calc();

        var result = calculator.Subtract(1, 2);


        Assert.AreEqual(-1, result);
    }
    [TestMethod]
    public void Subtract_SubtractsOneWholeNegativeNumber()
    {
        var calculator = new Calc();

        var result = calculator.Subtract(-1, 2);

        Assert.AreEqual(-3, result);
    }

    [TestMethod]
    public void Multiply_MultiplyTwoWholeNumbers()
    {
        var calculator = new Calc();

        var result = calculator.Multiply(2, 3);

        Assert.AreEqual(6, result);
    }

    [TestMethod]
    public void Multiply_MultiplyTwoNegativeWholeNumbers()
    {
        var calculator = new Calc();

        var result = calculator.Multiply(-2, -5);

        Assert.AreEqual(10, result);
    }

    [TestMethod]
    public void Divide_DivideTwoWholeNumbers()
    {
        var calculator = new Calc();

        var result = calculator.Divide(10, 5);

        Assert.AreEqual(2, result);
    }

    [TestMethod]
    public void Divide_DividebyZero_ReturnError()
    {
        var calculator = new Calc();

        Assert.ThrowsException<DivideByZeroException>(() => calculator.Divide(10, 0));
    }




}