using System.Text.RegularExpressions;

//Thanks https://regex101.com

var filePath = "../../../data/input.txt";
string[] corruptedMemory = File.ReadAllLines(filePath);

long partOneSum = ExtractMul(corruptedMemory);
Console.WriteLine($"part one: {partOneSum}");

long partTwoSum = ExtractConditions(string.Join("",corruptedMemory));

Console.WriteLine($"part two: {partTwoSum}");

static long ExtractConditions(string corruptedMemory)
{
    string pattern = @"do\(\)(.*?)(don't\(\)|$)|(^.*?)(don't\(\)|$)";

    var matchCollection = Regex.Matches(corruptedMemory, pattern);
    string[] conditionalMuls = matchCollection.Select(m => m.Value).ToArray();
    var sum = ExtractMul(conditionalMuls);
    
    return sum;
}

static long ExtractMul(string[] corruptedMemory)
{
    var totalSum = 0L;
    string pattern = @"mul\(\d+,\d+\)";
    foreach (var line in corruptedMemory)
    {
        var matchCollection = Regex.Matches(line, pattern);
        foreach (var match in matchCollection.ToList())
        {
            var value = match.Value;
            //nice feature [] Range
            var numbers = value.TrimEnd(')')[4..(value.Length-1)]
                .Split(",")
                .Select(int.Parse)
                .ToArray();
            var sum = Math.BigMul(numbers[0], numbers[1]);
            totalSum += sum;
        }
    }
    return totalSum;
}
