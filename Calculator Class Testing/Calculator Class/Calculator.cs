using System;

public class Calculator
{

    public class Calc()
    {
        public int Add(int firstnumber, int secondnumber)
        {
            return firstnumber + secondnumber;
        }
        public int Subtract(int firstnumber, int secondnumber)
        {
            return firstnumber - secondnumber;
        }
        public double Divide(double dividend, double divisor)
        {
            if (divisor == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return (double)dividend / divisor;
        }
        public double Multiply(double multiplicand, double multiplier)
        {
            return multiplicand * multiplier;

        }
    }
}
