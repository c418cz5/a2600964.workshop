List<Employee> employees = new List<Employee>();

employees.Add(new FullTimeEmployee("Bill", 6250m));
employees.Add(new Contractor("Fred", 25m, 100m));

foreach (Employee employee in employees)
{
    decimal pay = employee.CalculatePay();

    Console.WriteLine($"{employee.Name}: Pay ${pay:F2}");
}