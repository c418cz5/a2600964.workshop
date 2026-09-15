using System;
using System.Collections.Generic;

public class BankComparer : IComparer<BankAccount>
{
    public int Compare(BankAccount? x, BankAccount? y)
    {
        if (x == null && y == null)
        {
            return 0;
        }

        if (x == null)
        {
            return -1;
        }

        if (y == null)
        {
            return 1;
        }

        var balanceResult = x.Balance.CompareTo(y.Balance);

        if (balanceResult != 0)
        {
            return balanceResult;
        }

        return x.Owner.CompareTo(y.Owner);
    }
}