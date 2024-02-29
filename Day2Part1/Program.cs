


string filePath = "D:\\acko\\Programiranje\\dotnet_projekti\\AdventOfCode\\Day2Part1\\input.txt";

int maxRed = 12;
int maxGreen = 13;
int maxBlue = 14;

int possibleGamesIDSum = 0;

string[] lines = File.ReadAllLines(filePath);

foreach (string line in lines)
{
    string[] parts = line.Split(':', StringSplitOptions.TrimEntries);
    int gameId = int.Parse(parts[0].Replace("Game ", ""));
    string[] sets = parts[1].Split(';', StringSplitOptions.TrimEntries);

    bool isPossible = true;

    foreach (string set in sets)
    {
        string[] cubes = set.Split(',', StringSplitOptions.TrimEntries);
        int red = 0, green = 0, blue = 0;

        foreach (string cube in cubes)
        {
            string[] cubeInfo = cube.Split(' ', StringSplitOptions.TrimEntries);
            int count = int.Parse(cubeInfo[0]);
            string color = cubeInfo[1];

            switch (color)
            {
                case "red":
                    red += count;
                    break;
                case "green":
                    green += count;
                    break;
                case "blue":
                    blue += count;
                    break;
                default:
                    break;
            }
        }

        if (red > maxRed || green > maxGreen || blue > maxBlue)
        {
            isPossible = false;
            break;
        }
    }

    if (isPossible is true)
    {
        possibleGamesIDSum += gameId;
    }
}

Console.WriteLine(possibleGamesIDSum);
