using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string input = "x40:4; y40:0; z:userinput; result: x40 * y40 + z;";

        Console.WriteLine("Input string: " + input);

        int x40 = ExtractValueFromString(input, "x40:");
        int y40 = ExtractValueFromString(input, "y40:");

        Console.WriteLine("\nPlease enter value for z:");
        int z = Convert.ToInt32(Console.ReadLine());

        string operation = ExtractOperation(input);
        Console.WriteLine($"\nExtracted operation: {operation}");

        int result = CalculateResult(operation, x40, y40, z);

        Console.WriteLine("\nExtracted and processed values:");
        Console.WriteLine("x40 = " + x40);
        Console.WriteLine("y40 = " + y40);
        Console.WriteLine("z = " + z);
        Console.WriteLine("Result = " + result);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static int ExtractValueFromString(string input, string varIdentifier)
    {
        string pattern = varIdentifier + @"(\d+)";
        Match match = Regex.Match(input, pattern);

        if (match.Success && match.Groups.Count > 1)
        {
            return int.Parse(match.Groups[1].Value);
        }
        Console.WriteLine($"Warning: Could not extract {varIdentifier} value from input string.");
        return 0;
    }

    static string ExtractOperation(string input)
    {
        string pattern = @"result:\s*(.+?);";
        Match match = Regex.Match(input, pattern);

        if (match.Success && match.Groups.Count > 1)
        {
            return match.Groups[1].Value.Trim();
        }

        return string.Empty;
    }

    static int CalculateResult(string operation, int x40, int y40, int z)
    {
        if (operation.Contains("x40") && operation.Contains("y40") && operation.Contains("+"))
        {
            return x40 * y40 + z;
        }

        Console.WriteLine("Warning: Using default operation (x40 * y40 + z)");
        return x40 * y40 + z;
    }
}

