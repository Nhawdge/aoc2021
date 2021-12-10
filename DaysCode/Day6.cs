using System.Diagnostics;

public static class Day6
{
    public static void SolvePart1()
    {
        var fishList = File.ReadLines("Data/day6.txt").First();

        Console.WriteLine(fishList);
        var endDay = 80;
        for (var day = 0; day < endDay; day++)
        {
            var newList = new List<string>();
            foreach (var fish in fishList.Split(",", StringSplitOptions.RemoveEmptyEntries))
            {
                var fishTimer = int.Parse(fish);

                if (fishTimer == 0)
                {
                    newList.Add("6");
                    newList.Add("8");
                }
                else
                {
                    newList.Add((fishTimer - 1).ToString());
                }
            }
            // Console.WriteLine($"Day: {day}\n\t{fishList}");
            fishList = string.Join(",", newList);
        }
        var totalFish = fishList.Split(",").Count();
        Console.WriteLine($"Total fish after {endDay} days: {totalFish}");
    }

    public static void SolvePart2(Stopwatch timer)
    {
        var fishList = File.ReadLines("Data/day6.txt").First();

        var fishesAndTimers = new Dictionary<int, double>();

        var groupedFish = fishList.Split(",", StringSplitOptions.RemoveEmptyEntries).GroupBy(x => x);

        foreach (var fishGroup in groupedFish)
        {
            fishesAndTimers.Add(int.Parse(fishGroup.Key), fishGroup.Count());
        }

        var endDay = 256;
        long lastTime = 0;

        for (var day = 0; day < endDay; day++)
        {
            var time = timer.ElapsedMilliseconds - lastTime;
            lastTime = timer.ElapsedMilliseconds;
            Console.WriteLine($"Day: {day} ({time}ms) - {string.Join("\n", fishesAndTimers.Select(x => $"{x.Key}: {x.Value}"))}");

            var newFishTimers = fishesAndTimers.Select(x => new KeyValuePair<int, double>((x.Key - 1), x.Value)).ToList();

            var underZero = newFishTimers.FirstOrDefault(x => x.Key < 0);

            var rowSix = newFishTimers.Find(x => x.Key == 6);
            if (rowSix.Key != 0)
            {
                var newSix = new KeyValuePair<int, double>(6, rowSix.Value + underZero.Value);
                newFishTimers.Remove(rowSix);
                newFishTimers.Add(newSix);
            }
            else
            {
                newFishTimers.Add(new KeyValuePair<int, double>(6, underZero.Value));
            }
            newFishTimers.Add(new KeyValuePair<int, double>(8, underZero.Value));

            newFishTimers.Remove(underZero);
            fishesAndTimers = newFishTimers.ToDictionary(x => x.Key, x => x.Value);
        }

        var total = fishesAndTimers.Sum(x => x.Value);

        Console.WriteLine($"Total fish after {endDay} days: {total}");
    }
}