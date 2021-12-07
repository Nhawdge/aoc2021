public static class Day4
{
    public static void SolvePart1()
    {
        var allLines = File.ReadAllLines("Data/day4.txt");
        var bingoNumbersCalled = allLines.First();

        var allBingoSheets = MakeSheets(allLines);

        foreach (var numberCalled in bingoNumbersCalled.Split(",").Select(x => int.Parse(x)))
        {
            foreach (var sheet in allBingoSheets)
            {
                var hit = sheet.Numbers.Find(x => x.Number == numberCalled);
                if (hit != null)
                {
                    hit.Mark();
                    Console.Write(sheet.ToString());

                    if (CheckForBingo(sheet))
                    {
                        Console.WriteLine($"Bingo! {numberCalled}");
                        var totalUnMarked = sheet.Numbers.Where(x => x.IsMarked == false).Sum(x => x.Number);
                        Console.WriteLine($"Sum of unmarked: {totalUnMarked}\nAnswer: {totalUnMarked * numberCalled}");
                        return;
                    }
                }
            }
        }
    }

    public static void SolvePart2()
    {

        var allLines = File.ReadAllLines("Data/day4.txt");
        var bingoNumbersCalled = allLines.First();

        var allBingoSheets = MakeSheets(allLines);

        foreach (var numberCalled in bingoNumbersCalled.Split(",").Select(x => int.Parse(x)))
        {
            foreach (var sheet in allBingoSheets)
            {
                if (sheet.HasBingo)
                {
                    continue;
                }
                var hit = sheet.Numbers.Find(x => x.Number == numberCalled);
                if (hit != null)
                {
                    hit.Mark();
                    Console.Write(sheet.ToString());

                    if (CheckForBingo(sheet))
                    {
                        sheet.HasBingo = true;
                        Console.WriteLine($"Bingo! {numberCalled}");
                        var totalUnMarked = sheet.Numbers.Where(x => x.IsMarked == false).Sum(x => x.Number);
                        Console.WriteLine($"Sum of unmarked: {totalUnMarked}\nAnswer: {totalUnMarked * numberCalled}");
                    }
                }
            }
        }
    }


    private static IEnumerable<BingoSheet> MakeSheets(string[] allLines)
    {
        var allSheets = new List<BingoSheet>();

        var row = 0;
        var column = 0;
        var holder = new List<BingoNumber>();
        foreach (var line in allLines.Skip(1))
        {
            if (string.IsNullOrEmpty(line))
            {
                row = 0;
                var sheet = new BingoSheet(holder, false);
                allSheets.Add(sheet);
                holder = new List<BingoNumber>();
                continue;
            }

            var splitLine = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            column = 0;
            foreach (var number in splitLine)
            {
                var bingoNum = new BingoNumber(int.Parse(number), row, column, false);
                holder.Add(bingoNum);
                column++;
            }
            row++;
        }

        return allSheets;
    }

    public record BingoSheet(List<BingoNumber> Numbers, bool HasBingo)
    {
        public bool HasBingo { get; set; } = HasBingo;
        public override string ToString()
        {
            var rows = Numbers.Select(x => x.Row).Distinct().OrderBy(x => x);
            var output = string.Empty;
            foreach (var row in rows)
            {
                output += string.Join(" ", Numbers.Where(x => x.Row == row).OrderBy(x => x.Column).Select(x => x.IsMarked ? x.Number + " " : x.Number + "*")) + "\n";
            }
            return output + "\n";
        }
    };

    public record BingoNumber(int Number, int Row, int Column, bool IsMarked)
    {
        public bool IsMarked { get; set; } = IsMarked;
        public void Mark()
        {
            IsMarked = true;
        }

    };
    public static bool CheckForBingo(BingoSheet sheet)
    {
        var rowBingo = sheet.Numbers.Where(x => x.IsMarked)
            .GroupBy(x => x.Row)
            .FirstOrDefault(x => x.Count() == 5);

        if (rowBingo != null)
            return true;

        var columnBingo = sheet.Numbers.Where(x => x.IsMarked).GroupBy(x => x.Column).FirstOrDefault(x => x.Count() == 5);
        if (columnBingo != null)
            return true;


        return false;
    }

}