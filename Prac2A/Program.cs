Payroll payroll = new Payroll(38, 42.5m, 0.2m);

decimal netPay = payroll.CalculateNetPay();

Console.WriteLine($"Net pay: ${netPay:F2}");

payroll.ChangeTaxRate(0.25m);

decimal newNetPay = payroll.CalculateNetPay();

Console.WriteLine($"Net pay after tax rate change: ${newNetPay:F2}");