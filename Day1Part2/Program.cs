using System.Text.RegularExpressions;

var numbers = new Dictionary<string, int>()
{
    {"one", 1 },
    {"two", 2},
    {"three", 3 },
    {"four", 4 },
    {"five", 5 },
    {"six", 6 },
    {"seven", 7 },
    {"eight", 8 },
    {"nine", 9 },
    {"1", 1 },
    {"2", 2},
    {"3", 3},
    {"4", 4},
    {"5", 5},
    {"6", 6},
    {"7", 7 },
    {"8", 8 },
    {"9", 9 },

};
string filePath = "D:\\acko\\Programiranje\\dotnet_projekti\\AdventOfCode\\Day1Part2\\input.txt"; 

string[] lines = File.ReadAllLines(filePath);

List<string> combinedNumber = new();

foreach (var item in lines)
{
    KeyValuePair<string, int> firstMatch = FindFirstMatch(item, numbers);
    KeyValuePair<string, int> lastMatch = FindLastMatch(item, numbers);

    string firstNumber = firstMatch.Value.ToString();
    string lastNumber = lastMatch.Value.ToString();

    combinedNumber.Add(firstNumber + lastNumber);

}

int sum = 0;

foreach (string str in combinedNumber)
{
    if (int.TryParse(str, out int number))
    {
        sum += number;
    }
}

static KeyValuePair<string, int> FindFirstMatch(string item, Dictionary<string, int> numbers)
{
    KeyValuePair<string, int> longestMatch = new KeyValuePair<string, int>();
    foreach (var entry in numbers)
    {
        if (item.Contains(entry.Key))
        {
            if (longestMatch.Key is null || item.IndexOf(entry.Key) < item.IndexOf(longestMatch.Key))
            {
                longestMatch = entry;
            }
        }
    }
    return longestMatch;
}

static KeyValuePair<string, int> FindLastMatch(string item, Dictionary<string, int> numbers)
{
    KeyValuePair<string, int> longestMatch = new KeyValuePair<string, int>();
    foreach (var entry in numbers)
    {
        if (item.Contains(entry.Key))
        {
            if (longestMatch.Key is null || item.LastIndexOf(entry.Key) > item.LastIndexOf(longestMatch.Key))
            {
                longestMatch = entry;
            }
        }
    }
    return longestMatch;
}
