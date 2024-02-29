using System.Text.RegularExpressions;

string filePath =
    "D:\\acko\\Programiranje\\dotnet_projekti\\AdventOfCode\\Day3Part1\\input.txt";
string[] lines = File.ReadAllLines(filePath);

int result = GetSumOfAdjacentNumbers(lines);
Console.WriteLine(result);

static int GetSumOfAdjacentNumbers(string[] lines)
{
    var symbolRegex = new Regex(@"[^.\d]");
    var symbolAdjacent = new HashSet<(int, int)>();

    for (int i = 0; i < lines.Length; i++)
    {
        foreach (Match match in symbolRegex.Matches(lines[i]))
        {
            int j = match.Index;
            for (int dr = -1; dr <= 1; dr++)
            {
                for (int dc = -1; dc <= 1; dc++)
                {
                    if (dr == 0 && dc == 0) continue;

                    int newRow = i + dr;
                    int newCol = j + dc;

                    symbolAdjacent.Add((newRow, newCol));
                }
            }
        }
    }

    var numberRegex = new Regex(@"\d+");
    int partNumSum = 0;

    for (int i = 0; i < lines.Length; i++)
    {
        foreach (Match match in numberRegex.Matches(lines[i]))
        {
            for (int j = match.Index; j < match.Index + match.Length; j++)
            {
                if (symbolAdjacent.Contains((i, j)))
                {
                    partNumSum += int.Parse(match.Value);
                    break;
                }
            }
        }
    }

    return partNumSum;
}
