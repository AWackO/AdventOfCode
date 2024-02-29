

string filePath = "D:\\acko\\Programiranje\\dotnet_projekti\\AdventOfCode\\Day2Part2\\input.txt";

string[] lines = File.ReadAllLines(filePath);

int sum = 0;

foreach (string line in lines)
{
    string[] parts = line.Split(':', StringSplitOptions.TrimEntries);
    string[] sets = parts[1].Split(';', StringSplitOptions.TrimEntries);

    int maxRed = 0;
    int maxGreen = 0;
    int maxBlue = 0;

    foreach (string set in sets)
    {
        string[] cubes = set.Split(',', StringSplitOptions.TrimEntries);

        foreach (string cube in cubes)
        {
            string[] cubeInfo = cube.Split(' ', StringSplitOptions.TrimEntries);
            int currentColorCount = int.Parse(cubeInfo[0]);
            string color = cubeInfo[1];

            switch (color)
            {
                case "red":
                    maxRed = Math.Max(currentColorCount, maxRed);
                    break;
                case "green":
                    maxGreen = Math.Max(currentColorCount, maxGreen);
                    break;
                case "blue":
                    maxBlue = Math.Max(currentColorCount, maxBlue);
                    break;
                default:
                    break;
            }
        }
    }

    sum += (maxRed * maxGreen * maxBlue);
}

Console.WriteLine(sum);
