public static class Day3
{
    public static void SolvePart1()
    {
        var gammaRate = "";
        var epislonRate = "";

        var allLines = File.ReadAllLines("Data/day3.txt").ToList();
        var firstLine = allLines[0];
        for (var i = 0; i < firstLine.Length; i++)
        {
            var columnData = new List<char>();
            foreach (var line in allLines)
            {
                columnData.Add(line[i]);
            }

            gammaRate += columnData.Count(x => x == '1') > columnData.Count(x => x == '0') ? "1" : "0";
            epislonRate += columnData.Count(x => x == '1') > columnData.Count(x => x == '0') ? "0" : "1";
        }
        var gammaAsDecimal = Convert.ToInt32(gammaRate, 2);
        var epsilonAsDecimal = Convert.ToInt32(epislonRate, 2);
        Console.WriteLine($"Gamma: {gammaRate}\nEpsilon: {epislonRate}\nAnswer: {gammaAsDecimal * epsilonAsDecimal}");
    }

    public static void SolvePart2()
    {
        var allLines = File.ReadAllLines("Data/day3.txt");
        var matrix = allLines.Select(x => x.Split("").ToList());
        var firstLine = allLines[0];
        var index = 0;
        var mostCommon = 0 << 0;

        foreach (var character in firstLine.Split(""))
        {
            var commonBits = new List<string>();
            foreach (var line in matrix)
            {
                commonBits.Add(line[index]);
            }

            mostCommon += commonBits.Count(x => x == "1") > commonBits.Count(x => x == "0") ? 1 << index : 0;
            var leastCommon = ~mostCommon;
            index++;
            Console.WriteLine($"{Convert.ToString(mostCommon, 2)} {leastCommon}");
        }

    }
}