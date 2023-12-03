
using System.Text.RegularExpressions;

var fileName = "E:\\work\\c#\\AdventOfCode2023CSharp\\AdventOfCode2023CSharp\\cubes.txt";

char[] delimiters = { ':', ';' };

var collectedGames = new Dictionary<int, List<string>>();

try
{
    string[] text = File.ReadAllLines(fileName);

    foreach (var s in text)
    {
        var parts = s.Split(delimiters).ToList();
        var regex = new Regex(@"\d+");
        var match = regex.Match(parts[0]);
        parts.RemoveAt(0);
        
        collectedGames.Add(int.Parse(match.Value), parts);
    }
    
    var gameIdTotal = 0;

    var gamePossibleTracker = true;
    var gamePossible = true;

    foreach (var game in collectedGames)
    {
        Console.WriteLine($"Game: {game.Key}");
        
        foreach (var part in game.Value)
        {
            var colorGems = part.Split(',').ToList();
            foreach (var colorGem in colorGems)
            {
                var regex = new Regex(@"(red|blue|green)");
                var match = regex.Match(colorGem);
                
                // convert this to a switch statement
                if (match.Value == "red")
                {
                    var gemNumber = new Regex(@"\d+");
                    var gemMatch = gemNumber.Match(colorGem);
                    gamePossibleTracker = IsGamePossible(int.Parse(gemMatch.Value), match.Value);
                }else if (match.Value == "blue")
                {
                    var gemNumber = new Regex(@"\d+");
                    var gemMatch = gemNumber.Match(colorGem);
                    gamePossibleTracker = IsGamePossible(int.Parse(gemMatch.Value), match.Value);
                }else if (match.Value == "green")
                {
                    var gemNumber = new Regex(@"\d+");
                    var gemMatch = gemNumber.Match(colorGem);
                    gamePossibleTracker = IsGamePossible(int.Parse(gemMatch.Value), match.Value);
                }
                
                if (gamePossibleTracker == false)
                {
                    gamePossible = false;
                }
            }
        }

        if (gamePossible)
        {
            Console.WriteLine($"Game {game.Key} is possible");
            gameIdTotal += game.Key;
        }
        
        gamePossible = true;
    }
    
    Console.WriteLine($"Total game id: {gameIdTotal}");
}
catch (IOException e)
{
    Console.WriteLine("The file could not be read:");
    Console.WriteLine(e.Message);
}

static bool IsGamePossible(int gemNumber, string gemColor)
{
    const int redGemsTotal = 12;
    const int blueGemsTotal = 14;
    const int greenGemsTotal = 13;

    if (gemColor == "red")
    {
        if (gemNumber > redGemsTotal)
        {
            return false;
        }
    }
    
    if (gemColor == "green")
    {
        if (gemNumber > greenGemsTotal)
        {
            return false;
        }
    }
    
    if (gemColor == "blue")
    {
        if (gemNumber > blueGemsTotal)
        {
            return false;
        }
    }

    return true;
}