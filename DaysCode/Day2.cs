public static class Day2
{
    public static void SolvePart1()
    {
        var allLines = File.ReadAllLines("data/day2.txt").ToList();
        var verticalChanges = allLines.Where(x => x.StartsWith("up") || x.StartsWith("down"));
        var horizontalChanges = allLines.Where(x => x.StartsWith("forward"));
        var finalVertical = 0;
        var finalHorizontal = 0;

        foreach (var vertChange in verticalChanges)
        {
            var splitVars = vertChange.Split(" ");
            string direction = splitVars[0];
            int distance = int.Parse(splitVars[1]);
            if (direction == "down")
            {
                finalVertical += distance;
            }
            else
            {
                finalVertical -= distance;
            }
        }

        foreach (var horChange in horizontalChanges)
        {
            var splitVars = horChange.Split(" ");
            string direction = splitVars[0];
            int distance = int.Parse(splitVars[1]);
            if (direction == "forward")
            {
                finalHorizontal += distance;
            }
        }
        Console.WriteLine($"Final Vertical: {finalVertical}\nFinal Horizontal: {finalHorizontal}");
        Console.WriteLine($"Final Change {finalHorizontal * finalVertical}");
    }

    public static void SolvePart2()
    {
        var allLines = File.ReadAllLines("data/day2.txt").ToList();
        var currentDepth = 0;
        var currentDistance = 0;
        var currentAim = 0;

        foreach (var line in allLines)
        {
            var splitVars = line.Split(" ");
            var change = splitVars[0];
            var amount = int.Parse(splitVars[1]);

            switch (change)
            {
                case "up":
                    currentAim -= amount;
                    break;
                case "down":
                    currentAim += amount;
                    break;
                case "forward":
                    currentDistance += amount;
                    currentDepth += currentAim * amount;
                    break;
            }
        }

        Console.WriteLine($"Depth: {currentDepth}\nDistance: {currentDistance}\nAnswer: {currentDepth * currentDistance}");
    }
}
