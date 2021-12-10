public static class Day7
{
    public static void SolvePart1()
    {
        var crabPositions = File.ReadLines("Data/day7.txt").First();
        var fuelUsed = new Dictionary<int, int>();

        var crabPosList = crabPositions.Split(",", StringSplitOptions.RemoveEmptyEntries);

        var min = crabPosList.Min(x => int.Parse(x));
        var max = crabPosList.Max(x => int.Parse(x));

        var currentIndex = min;
        while (currentIndex <= max)
        {
            var groupedCrabs = crabPosList.GroupBy(x => x);
            var fuelNeeded = 0;
            foreach (var group in groupedCrabs)
            {
                var distance = Math.Abs(int.Parse(group.Key) - currentIndex);
                fuelNeeded += distance * group.Count();
            }
            fuelUsed.Add(currentIndex, fuelNeeded);
            currentIndex++;
        }

        var orderedList = fuelUsed.OrderBy(x => x.Value);
        var leastFuel = orderedList.First();
        Console.WriteLine($"Least fuel needed: {leastFuel.Key}, {leastFuel.Value}");

    }
    public static void SolvePart2()
    {
        var crabPositions = File.ReadLines("Data/day7.txt").First();
        var fuelUsed = new Dictionary<int, int>();

        var crabPosList = crabPositions.Split(",", StringSplitOptions.RemoveEmptyEntries);

        var min = crabPosList.Min(x => int.Parse(x));
        var max = crabPosList.Max(x => int.Parse(x));

        var currentIndex = min;
        while (currentIndex <= max)
        {
            var groupedCrabs = crabPosList.GroupBy(x => x);
            var fuelNeeded = 0;
            foreach (var group in groupedCrabs)
            {
                var distance = DoTheMath(Math.Abs(int.Parse(group.Key) - currentIndex));


                fuelNeeded += distance * group.Count();
            }
            fuelUsed.Add(currentIndex, fuelNeeded);
            currentIndex++;
        }

        var orderedList = fuelUsed.OrderBy(x => x.Value);
        var leastFuel = orderedList.First();
        Console.WriteLine($"Least fuel needed: {leastFuel.Key}, {leastFuel.Value}");

    }
    private static int DoTheMath(int start)
    {
        var end = 0;
        for (var index = start; index >= 0; index--)
        {
            end += index;
        }
        return end;
    }
}
