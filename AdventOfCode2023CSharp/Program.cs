using System.Text.RegularExpressions;

static Dictionary<int, int> FindCalibrationValuesInString(string str)
{
        
    var alphaNumericToMatch = new Dictionary<string, int>()
    {
        {"one", 1}, {"two", 2}, {"three", 3}, {"four", 4}, {"five", 5}, {"six", 6}, {"seven", 7}, {"eight", 8}, {"nine", 9}, {"1", 1}, {"2", 2},
        {"3", 3}, {"4", 4}, {"5", 5}, {"6", 6}, {"7", 7}, {"8", 8}, {"9", 9}
    };
        
    var matchedWords = new Dictionary<int, int>();
        
    foreach (var word in alphaNumericToMatch)
    {
        Regex rx = new Regex(word.Key);
        foreach (Match match in rx.Matches(str))
        {
            matchedWords.Add(match.Index, word.Value);
        }
    }
        
    var sortedWords = matchedWords.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

    // foreach (var word in sortedWords)
    // {
    //     Console.WriteLine($"{word.Key} and {word.Value}");
    // }

    return sortedWords;

}

static int ConcatenateIntegers(int first, int second)
{
    var firstAsString = first.ToString();
    var secondAsString = second.ToString();

    var concatenated = firstAsString + secondAsString;

    return int.Parse(concatenated);
}

string fileName = "E:\\work\\c#\\AdventOfCode2023CSharp\\AdventOfCode2023CSharp\\calibrationvalues.txt";

try
{
    var calibrationValues = File.ReadAllLines(fileName);
            
    var sum = 0;
            
    foreach (var cv in calibrationValues)
    {
        var calibValues = FindCalibrationValuesInString(cv);
                
        var first = calibValues.Values.First();
        var last = calibValues.Values.Last();
        Console.WriteLine(cv);
        Console.WriteLine($"{first} and {last}");
                
        var concatenated = ConcatenateIntegers(first, last);
        Console.WriteLine(concatenated);

        sum += concatenated;
    }
            
    Console.WriteLine($"Sum: {sum}");
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}