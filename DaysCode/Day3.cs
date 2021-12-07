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
        var firstLine = allLines[0];
        var index = 0;
        var validO2Values = allLines.ToList();
        var validCO2Values = allLines.ToList();
        foreach (var character in firstLine.ToArray())
        {
            //Console.WriteLine("Loop start ---------------");
            if (validO2Values.Count() > 1)
            {
                var mostCommon = "1";

                var mostCommonList = validO2Values.Select(x => x.Substring(index, 1)).GroupBy(x => x).OrderByDescending(x => x.Count());
                if (mostCommonList.Count() == 1 || mostCommonList.First().Count() != mostCommonList.Last().Count())
                {
                    mostCommon = mostCommonList.First().Key;
                }

                //Console.WriteLine($"{mostCommonList.First().Key}: {mostCommonList.First().Count()} {mostCommonList.Last().Count()}");
                //Console.WriteLine($"Filter: {index}, {mostCommon} Options:\n{string.Join("\n", validO2Values)}");
                validO2Values = validO2Values.Where(x => x.Substring(index, 1) == mostCommon).ToList();
            }
            if (validCO2Values.Count() > 1)
            {
                var leastCommon = "0";
                var leastCommonList = validCO2Values.Select(x => x.Substring(index, 1)).GroupBy(x => x).OrderBy(x => x.Count());
                if (leastCommonList.Count() > 1 && leastCommonList.First().Count() != leastCommonList.Last().Count())
                {
                    leastCommon = leastCommonList.First().Key;
                }
                validCO2Values = validCO2Values.Where(x => x.Substring(index, 1) == leastCommon).ToList();
            }
            //Console.WriteLine($"Counts:\n  O2: {validO2Values.Count}\n  CO2: {validCO2Values.Count}");
            index++;

        }

        var O2Level = Convert.ToInt32(validO2Values.FirstOrDefault(), 2);
        var CO2Level = Convert.ToInt32(validCO2Values.First(), 2);
        Console.WriteLine("------------------");
        Console.WriteLine($"O2 Raw: {validO2Values.First().ToString()}\nCO2 Raw: {validCO2Values.First().ToString()}");
        Console.WriteLine($"O2: {O2Level}\nCO2: {CO2Level}\nAnswer: {O2Level * CO2Level}");
    }

}