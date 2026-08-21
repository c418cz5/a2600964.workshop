public class Contractor : Employee, IReportable
{

    public decimal Rate { get; set; }

    public decimal Hours { get; set; }

    public Contractor(string name, decimal rate, decimal hours)
        : base(name)
    {
        Rate = rate;
        Hours = hours;
    }

    public override decimal CalculatePay()
    {
        decimal grossPay = Rate * Hours;
        decimal tax = grossPay * TaxRate;

        return grossPay - tax;
    }

    public string GenerateReport()
    {
        decimal grossPay = Rate * Hours;
        decimal tax = grossPay * TaxRate;

        return $"{Name}: Pay ${CalculatePay():F2}. Tax ${tax:F2}.";
    }
}