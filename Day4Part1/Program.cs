string filePath = "D:\\acko\\Programiranje\\dotnet_projekti\\AdventOfCode\\Day4Part1\\input.txt";
string[] lines = File.ReadAllLines(filePath);

int totalPoints = 0;

foreach (string line in lines)
{
    string cleanedLine = line.Substring(line.IndexOf(':') + 1).Trim();

    string[] parts = cleanedLine.Split('|');

    int[] winningNumbers = parts[0]
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    int[] ourNumbers = parts[1]
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    int matches = ourNumbers.Count(number => winningNumbers.Contains(number));

    int points = 0;
    if (matches > 0)
    {
        points += 1;

        for (int i = 1; i < matches; i++)
        {
            points *= 2;
        }
    }

    totalPoints += points;
}

Console.WriteLine($"Total points: {totalPoints}");