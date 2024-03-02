
string filePath = "D:\\acko\\Programiranje\\dotnet_projekti\\AdventOfCode\\Day4Part2\\input.txt";
string[] lines = File.ReadAllLines(filePath);

int totalCards = 0;
List<int> cardInstances = Enumerable.Repeat(0, lines.Length).ToList();

for (int i = 0; i < lines.Length; i++)
{
    totalCards += CountCardInstances(lines[i], i, cardInstances);
}

Console.WriteLine(totalCards);

static int CountCardInstances(string line, int cardNumber, List<int> cardInstances)
{
    string cleanedLine = line.Split(':')[1].Trim();
    string[] parts = cleanedLine.Split('|');

    List<int> winningNumbers = parts[0]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

    List<int> ourNumbers = parts[1]
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToList();

    List<int> commonNumbers = ourNumbers.Where(number => winningNumbers.Contains(number)).ToList();

    cardInstances[cardNumber]++;

    int cardInstanceCount = cardInstances[cardNumber];

    for (int i = 1; i <= cardInstanceCount && commonNumbers.Count > 0; i++)
    {
        for (int j = 1; j <= commonNumbers.Count && cardNumber + j < cardInstances.Count; j++)
        {
            cardInstances[cardNumber + j]++;
        }
    }

    return cardInstances[cardNumber];
}
