using System;
using System.Collections.Generic;

public class SortedSetDemo
{
    public static void Run()
    {
        RunScores();
        RunAccounts();
    }

    static void RunScores()
    {
        var scores = new SortedSet<int>();
        var random = new Random();

        while (scores.Count < 10)
        {
            scores.Add(random.Next(1000, 10000));
        }

        Console.WriteLine("Original scores:");
        DisplayScores(scores);

        scores.Add(15000);

        Console.WriteLine("After adding a new high score:");
        DisplayScores(scores);

        var duplicateScore = scores.Min;
        var duplicateAdded = scores.Add(duplicateScore);

        Console.WriteLine($"Trying to add duplicate score: {duplicateAdded}");
        DisplayScores(scores);
    }

    static void RunAccounts()
    {
        var accounts = new List<BankAccount>
        {
            new BankAccount("Rick", 1000),
            new BankAccount("John", 2500),
            new BankAccount("Jane", 800),
            new BankAccount("Brian", 3200),
            new BankAccount("Lois", 1500),
            new BankAccount("Peter", 4500),
            new BankAccount("Stewie", 100),
            new BankAccount("Meg", 2000),
            new BankAccount("Klaus", 3700),
            new BankAccount("Kobe", 5000)
        };

        var sortedBankSet = new SortedSet<BankAccount>(new BankComparer());

        foreach (var account in accounts)
        {
            sortedBankSet.Add(account);
        }

        Console.WriteLine("Bank accounts sorted by balance:");
        DisplayAccounts(sortedBankSet);

        var highAccount = new BankAccount("New High", 6000);
        sortedBankSet.Add(highAccount); 
        Console.WriteLine("After adding a new high account:");
        DisplayAccounts(sortedBankSet);

        var duplicateAccount = new BankAccount("Rick", 1000);
        var duplicateAdded = sortedBankSet.Add(duplicateAccount);

        Console.WriteLine($"Trying to add duplicate account: {duplicateAdded}");
        DisplayAccounts(sortedBankSet);

        MakePlot(sortedBankSet);
    }

    static void DisplayScores(SortedSet<int> scores)
    {
        Console.WriteLine("Scores:");

        foreach (var score in scores)
        {
            Console.WriteLine(score);
        }

        Console.WriteLine($"Lowest score: {scores.Min}");
        Console.WriteLine($"Highest score: {scores.Max}");
        Console.WriteLine($"Number of scores: {scores.Count}");
        Console.WriteLine();
    }

    static void DisplayAccounts(SortedSet<BankAccount> accounts)
    {
        foreach (var account in accounts)
        {
            Console.WriteLine(account);
        }
    }

    static void MakePlot(SortedSet<BankAccount> accounts)
    {
        var balances = new double[accounts.Count];
        var index = 0;

        foreach (var account in accounts)
        {
            balances[index] = (double)account.Balance;
            index++;
        }

        ScottPlot.Plot myPlot = new();

        myPlot.Add.Bars(balances);

        myPlot.YLabel("Account Balance");
        myPlot.XLabel("Ranking");

        myPlot.Axes.Left.Label.FontSize = 20;
        myPlot.Axes.Bottom.Label.FontSize = 20;

        myPlot.Axes.Margins(bottom: 0, top: .2);

        myPlot.SavePng("Topic7A-Task3.png", 800, 600);

        Console.WriteLine("Graph saved as Topic7A-Task3.png");
    }
}