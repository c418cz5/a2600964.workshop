Console.WriteLine("Hello, World!");
const double TAX_RATE = 0.2;
static double CalculatePay(double hours, double rate)
{
    if (hours < 0 || rate < 0)
    {
        throw new ArgumentException("Hours and rate must be positive.");
    }

    double gross = hours * rate;
    double tax = gross * TAX_RATE;
    double net = gross - tax;

    return net;
}