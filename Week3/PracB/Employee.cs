public abstract class Employee
{
       public string Name { get; set; }

    public const decimal TaxRate = 0.2m;
    public Employee(string name)
    {
        Name = name;
    }    public abstract decimal CalculatePay();
}