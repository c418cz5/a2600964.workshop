using System.Collections.Generic;
using Xunit;

public class EmployeeTests
{
    [Fact]
    public void FullTimeEmployee_CalculatePay_ReturnsCorrectPay()
    {
        FullTimeEmployee employee = new FullTimeEmployee("Bill", 6250m);

        decimal result = employee.CalculatePay();

        Assert.Equal(5000m, result);
    }

    [Fact]
    public void Contractor_CalculatePay_ReturnsCorrectPay()
    {
        Contractor employee = new Contractor("Fred", 25m, 100m);

        decimal result = employee.CalculatePay();

        Assert.Equal(2000m, result);
    }

    [Fact]
    public void FullTimeEmployee_GeneratesCorrectReport()
    {
        FullTimeEmployee employee = new FullTimeEmployee("Bill", 6250m);

        string result = employee.GenerateReport();

        Assert.Equal("Bill: Pay $5000.00. Tax $1250.00.", result);
    }

    [Fact]
    public void Contractor_GeneratesCorrectReport()
    {
        Contractor employee = new Contractor("Fred", 25m, 100m);

        string result = employee.GenerateReport();

        Assert.Equal("Fred: Pay $2000.00. Tax $500.00.", result);
    }

    [Fact]
    public void Employees_CanBeStoredAsEmployeeObjects()
    {
        List<Employee> employees = new List<Employee>();

        employees.Add(new FullTimeEmployee("Bill", 6250m));
        employees.Add(new Contractor("Fred", 25m, 100m));

        Assert.Equal(5000m, employees[0].CalculatePay());
        Assert.Equal(2000m, employees[1].CalculatePay());
    }

    [Fact]
    public void FullTimeEmployee_StoresNameAndSalary()
    {
        FullTimeEmployee employee = new FullTimeEmployee("Bill", 6250m);

        Assert.Equal("Bill", employee.Name);
        Assert.Equal(6250m, employee.AnnualSalary);
    }

    [Fact]
    public void Contractor_StoresNameRateAndHours()
    {
        Contractor employee = new Contractor("Fred", 25m, 100m);

        Assert.Equal("Fred", employee.Name);
        Assert.Equal(25m, employee.Rate);
        Assert.Equal(100m, employee.Hours);
    }

    [Fact]
    public void InterfaceCanGenerateReport()
    {
        IReportable employee = new FullTimeEmployee("Bill", 6250m);

        string result = employee.GenerateReport();

        Assert.Contains("Bill", result);
        Assert.Contains("5000.00", result);
    }
}