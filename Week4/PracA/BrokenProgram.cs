using System.Globalization;

namespace Topic4A
{
    internal static class BrokenProgram
    {
        private const int ExpectedTotal = 1120;
        private const string ExpectedTotalMessage = "Expected total was: 1120";
        private const string RightMessage = "Your answer was RIGHT!";
        private const string WrongMessage = "Your answer was WRONG!\nGo and fix it.";

        private static void Main()
        {
            const string input = """
       23
       +  
       77
       +  
        3
       +  
      457
       *  
        2
          
      """;

            int total = 0;
            List<int> items = [];
            List<string> symbols = [];

            string[] lines = input.Split('\n');

            for (int i = 0; i < lines.Length; i += 2)
            {
                string numberText = lines[i].Trim();

                if (!string.IsNullOrEmpty(numberText))
                {
                    items.Add(int.Parse(numberText, CultureInfo.InvariantCulture));
                }

                if (i != 0)
                {
                    string symbol = lines[i - 1].Trim();

                    if (!string.IsNullOrEmpty(symbol))
                    {
                        symbols.Add(symbol);
                    }
                }
            }

            foreach ((int i, int value) in items.Index())
            {
                if (i == 0)
                {
                    total = value;
                }
                else if (symbols[i - 1] == "*")
                {
                    total *= value;
                }
                else
                {
                    total += value;
                }
            }

            Console.WriteLine("Total was: " + total);
            Console.WriteLine(ExpectedTotalMessage);
            Console.WriteLine(
                total == ExpectedTotal
                    ? RightMessage
                    : WrongMessage);
        }
    }
}