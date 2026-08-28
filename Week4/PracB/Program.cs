namespace AdventDay7;

using System.IO.Pipelines;
using System.Text;

/// <summary>
/// Class <c>Program</c> contains the magical tachyon manifold.
/// </summary>
public static class Program
{
    // This is a single line comment.
    // TODO: Change hardcoded string for the input file to one on your PC.
    public static string FileToRead { get; set; } =
        @"E:\SODP\a2600964.workshop\Week4\PracB\Example.txt";

    /// <summary>
    /// Processes the starting point of the tachyon manifold.
    /// It sends the first tachyon beam to the position below the S symbol.
    /// </summary>
    /// <param name="posX">The horizontal position of the start symbol.</param>
    /// <param name="posY">The vertical position of the start symbol.</param>
    /// <param name="tachyonGrid">
    /// The grid containing the tachyon manifold.
    /// </param>
    public static void processStart(
        int posX,
        int posY,
        List<string> tachyonGrid)
    {
        string line = tachyonGrid[posY + 1];
        StringBuilder sb = new StringBuilder(line);

        sb[posX] = '|';

        line = sb.ToString();
        tachyonGrid[posY + 1] = line;
    }

    /// <summary>
    /// Processes a splitter in the tachyon manifold.
    /// When a beam reaches the splitter, two beams are created,
    /// one on the left and one on the right.
    /// </summary>
    /// <param name="posX">The horizontal position of the splitter.</param>
    /// <param name="posY">The vertical position of the splitter.</param>
    /// <param name="tachyonGrid">
    /// The grid containing the tachyon manifold.
    /// </param>
    public static void processSplitter(
        int posX,
        int posY,
        List<string> tachyonGrid)
    {
        string line = tachyonGrid[posY];
        StringBuilder sb = new StringBuilder(line);

        if (tachyonGrid[posY - 1][posX] == '|')
        {
            sb[posX - 1] = '|';
            sb[posX + 1] = '|';

            line = sb.ToString();
            tachyonGrid[posY] = line;
        }
    }

    /// <summary>
    /// Processes an empty space in the tachyon manifold.
    /// If a beam is directly above the empty space,
    /// the space is changed to a beam.
    /// </summary>
    /// <param name="posX">The horizontal position of the empty space.</param>
    /// <param name="posY">The vertical position of the empty space.</param>
    /// <param name="tachyonGrid">
    /// The grid containing the tachyon manifold.
    /// </param>
    public static void processEmpty(
        int posX,
        int posY,
        List<string> tachyonGrid)
    {
        string line = tachyonGrid[posY];
        StringBuilder sb = new StringBuilder(line);

        if (tachyonGrid[posY - 1][posX] == '|')
        {
            sb[posX] = '|';

            line = sb.ToString();
            tachyonGrid[posY] = line;
        }
    }

    /// <summary>
    /// Reads the tachyon manifold from the input file,
    /// processes each position in the grid, and prints the final result.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    public static void Main(string[] args)
    {
        var sr = new StreamReader(FileToRead);
        string srText = sr.ReadToEnd();
        int totalCount = 0;

        List<string> symbols = [.. srText.Split("\n")];
        List<string> tachyonGrid = symbols[..^1];

        Console.WriteLine("Begin Tachyon Manifold start state");

        foreach (var item in tachyonGrid)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("End Tachyon Manifold start state");

        for (int posY = 0; posY < tachyonGrid.Count; posY++)
        {
            var item = tachyonGrid[posY];

            foreach (var (posX, character) in item.Index())
            {
                if (character == 'S')
                {
                    processStart(posX, posY, tachyonGrid);
                }
                else if (character == '^')
                {
                    processSplitter(posX, posY, tachyonGrid);
                }
                else if (posY != 0)
                {
                    processEmpty(posX, posY, tachyonGrid);
                }
            }
        }

        Console.WriteLine("Begin Tachyon Manifold end state");

        foreach (var item in tachyonGrid)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("End Tachyon Manifold end state");
        Console.WriteLine($"Total Tachyon Manifold splits were: {totalCount}");
        Console.WriteLine("If using Example.txt, your total should be 21");
        Console.WriteLine(
            $"If using Example.txt, your total is {(totalCount == 21 ? "RIGHT" : "WRONG")}");
    }
}