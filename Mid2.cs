using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter code in your mini-language (e.g., var a1 = 12@; float b2 = 3.14$$;):");
        string? inputCode = Console.ReadLine();
        inputCode = inputCode ?? string.Empty;
        string pattern = @"(?<type>\w+)\s+(?<name>[abc]\w*\d+)\s*=\s*(?<value>[^;]*?[^\w\s.][^;]*);";
        var matches = Regex.Matches(inputCode, pattern);
        Console.WriteLine("\n{0,-15} {1,-15} {2,-15}", "VarName", "SpecialSymbol", "Token Type");
        Console.WriteLine(new string('-', 45));
        foreach (Match match in matches)
        {
            string varName = match.Groups["name"].Value;
            string valueStr = match.Groups["value"].Value;
            string varType = match.Groups["type"].Value;
            string specialChar = ExtractFirstSpecialChar(valueStr);
            if (!string.IsNullOrEmpty(specialChar))
            {
                Console.WriteLine("{0,-15} {1,-15} {2,-15}", varName, specialChar, varType);
            }
        }
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
    static string ExtractFirstSpecialChar(string value)
    {
        foreach (char c in value)
        {
            if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c) && c != '.')
            {
                return c.ToString();
            }
        }
        return string.Empty;
    }
}
