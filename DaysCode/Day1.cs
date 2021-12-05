using System.Diagnostics;

public static class Day1
{
    public static void SolvePart1()
    {
        var path = "data/day1.txt";
        var lastLine = string.Empty;
        var increases = 0;

        var timer = new Stopwatch();

        timer.Start();
        foreach (var line in File.ReadLines(path))
        {
            if (lastLine == string.Empty)
            {
                lastLine = line;
                continue;
            }
            
            var lineAsInt = int.Parse(line);
            var lastLineAsInt = int.Parse(lastLine);
            if (lineAsInt > lastLineAsInt)
                increases++;

            lastLine = line;
        }
        var time = timer.ElapsedMilliseconds;
        Console.WriteLine($"Run Duration: {time}ms");
        Console.WriteLine($"Increases: {increases}");

    }

    public static void SolvePart2()
    {
        var path = "data/day1.txt";
        var increases = 0;

        var timer = new Stopwatch();
        var allLines = File.ReadAllLines(path).ToList();
        var allSums = new List<int>();

        timer.Start();
        for (var index = 0; index < allLines.Count; index++)
        {
            var rangeEnd = index + 3;
            if (rangeEnd > allLines.Count)
                break;

            var lineGroup = allLines.GetRange(index, 3);
            var sum = lineGroup.Sum(x => int.Parse(x));
            if (index < 10)
            {
                Console.WriteLine($"{index} {sum}");
            }
            allSums.Add(sum);
        }
        int lastLine = 0;
        foreach (var line in allSums)
        {
            if (lastLine == 0)
            {
                lastLine = line;
                continue;
            }
            if (line > lastLine)
                increases++;

            lastLine = line;
        }
        var time = timer.ElapsedMilliseconds;
        Console.WriteLine($"Run Duration: {time}ms");
        Console.WriteLine($"Increases: {increases}");
    }
}