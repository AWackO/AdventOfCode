string inputString = "D:\\acko\\Programiranje\\dotnet_projekti\\AdventOfCode\\Day7Part1\\input.txt";
var lines = File.ReadLines(inputString)
    .Select(line =>
    {
        var parts = line.Split(' ');
        return new Hand(parts[0], int.Parse(parts[1]));
    })
    .ToList();

var cardOrder = "23456789TJQKA";
var jokers = "";

var checkHands = new HandChecker(cardOrder, jokers);
var part1result = checkHands.GetOrderedHandResult(lines);
Console.WriteLine($"Result1 = {part1result}");

jokers = "J";
cardOrder = "J23456789TQKA";

var checkHandsJokers = new HandChecker(cardOrder, jokers);
var part2result = checkHandsJokers.GetOrderedHandResult(lines);
Console.WriteLine($"Result2 = {part2result}");