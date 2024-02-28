
string filePath = "D:\\acko\\Programiranje\\dotnet_projekti\\AdventOfCode\\AdventOfCode\\input.txt"; 
int totalSum = 0;

foreach (string line in File.ReadAllLines(filePath))
{
    int sum = GetNumbers(line);
    totalSum += sum;
}

Console.WriteLine(totalSum);

static int GetNumbers(string input)
{
    string numbers = "";

    foreach (char c in input)
    {
        if (char.IsDigit(c))
        {
            numbers += c;
        }
    }

    int numberToAdd = 0;
    if (numbers.Length > 0)
    {
        numberToAdd += int.Parse(numbers[0].ToString() + numbers[numbers.Length - 1].ToString());
    }

    return numberToAdd;
}