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
    

    foreach (var game in collectedGames)
    {
        //Console.WriteLine($"Game: {game.Key}");

        var redGems = 0;
        var greenGems = 0;
        var blueGems = 0;
        
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
                    if (int.Parse(gemMatch.Value) > redGems)
                    {
                        redGems = int.Parse(gemMatch.Value);
                    }
                    
                }else if (match.Value == "blue")
                {
                    var gemNumber = new Regex(@"\d+");
                    var gemMatch = gemNumber.Match(colorGem);
                    if (int.Parse(gemMatch.Value) > blueGems)
                    {
                        blueGems = int.Parse(gemMatch.Value);
                    }
                }else if (match.Value == "green")
                {
                    var gemNumber = new Regex(@"\d+");
                    var gemMatch = gemNumber.Match(colorGem);
                    if (int.Parse(gemMatch.Value) > greenGems)
                    {
                        greenGems = int.Parse(gemMatch.Value);
                    }
                }
            }
            
        }

        var gamePower = redGems * blueGems * greenGems;
        gameIdTotal += gamePower;
    }
    
    Console.WriteLine($"Total game id: {gameIdTotal}");
}
catch (IOException e)
{
    Console.WriteLine("The file could not be read:");
    Console.WriteLine(e.Message);
}