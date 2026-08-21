FullTimeEmployee fullTime = new FullTimeEmployee("Bill", 6250m);
Contractor contractor = new Contractor("Fred", 25m, 100m);

Console.WriteLine(fullTime.GenerateReport());
Console.WriteLine($"Calculated pay: ${fullTime.CalculatePay():F2}");

Console.WriteLine();

Console.WriteLine(contractor.GenerateReport());
Console.WriteLine($"Calculated pay: ${contractor.CalculatePay():F2}");