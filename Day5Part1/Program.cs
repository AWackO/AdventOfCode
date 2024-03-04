string filePath = "D:\\acko\\Programiranje\\dotnet_projekti\\AdventOfCode\\Day5Part1\\input.txt";

string[] lines = File.ReadAllLines(filePath);

double[] seeds = lines[0].Split(' ').Skip(1).Select(seed => Convert.ToDouble(seed)).ToArray();


string[] groups = string.Join(Environment.NewLine, lines.Skip(2))
                    .Split(new[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

foreach (var group in groups)
{
    var map = group.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
        .Skip(1)
        .Select(line =>
        {
            var parts = line.Split(' ');
            return new
            {
                destStart = double.Parse(parts[0]),
                sourceStart = double.Parse(parts[1]),
                range = double.Parse(parts[2])
            };
        }).ToArray();

    seeds = seeds.Select(currSeed =>
    {
        var range = map.FirstOrDefault(mappedRange => mappedRange.sourceStart <= currSeed && mappedRange.sourceStart + mappedRange.range > currSeed);
        return range is not null ? (currSeed - range.sourceStart) + range.destStart : currSeed;
    }).ToArray();

}

double min = seeds.Min();
Console.WriteLine(min);