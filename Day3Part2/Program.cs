using System.Text.RegularExpressions;

string filePath = "D:\\acko\\Programiranje\\dotnet_projekti\\AdventOfCode\\Day3Part2\\input.txt";
string[] lines = File.ReadAllLines(filePath);

int result = GetSumOfMultipliedAdjacentNumbers(lines);
Console.WriteLine(result);

static int GetSumOfMultipliedAdjacentNumbers(string[] lines)
{
    var gearPositions = new Dictionary<(int, int), List<int>>();

    var gearRegex = new Regex(@"\*");
    for (int i = 0; i < lines.Length; i++)
    {
        foreach (Match match in gearRegex.Matches(lines[i]))
        {
            int j = match.Index;
            gearPositions[(i, j)] = new List<int>();
        }
    }

    var numberRegex = new Regex(@"\d+");
    for (int i = 0; i < lines.Length; i++)
    {
        foreach (Match match in numberRegex.Matches(lines[i]))
        {
            for (int row = i - 1; row <= i + 1; row++)
            {
                for (int col = match.Index - 1; col <= match.Index + match.Length; col++)
                {
                    if (gearPositions.ContainsKey((row, col)))
                    {
                        gearPositions[(row, col)].Add(int.Parse(match.Value));
                    }
                }
            }
        }
    }

    int gearRatioSum = 0;
    foreach (var nums in gearPositions.Values)
    {
        if (nums.Count == 2)
        {
            gearRatioSum += nums[0] * nums[1];
        }
    }

    return gearRatioSum;
}