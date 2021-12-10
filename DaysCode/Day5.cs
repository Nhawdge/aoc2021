using System.Numerics;
using Raylib_cs;
public static class Day5
{
    public static void SolvePart1()
    {
        var allLines = File.ReadAllLines("Data/day5.txt");
        var crapGrid = new List<GridCell>();
        var totalIntersections = 0;
        foreach (var line in allLines.Select(x => Line.MakeLineFromString(x)).Where(x => x.IsHorizontal() || x.IsVertical()))
        {
            var startPoint = new Vector2(line.X1, line.Y1);
            var endPoint = new Vector2(line.X2, line.Y2);

            var xDirection = endPoint.X > startPoint.X ? 1 : endPoint.X == startPoint.X ? 0 : -1;
            var yDirection = endPoint.Y > startPoint.Y ? 1 : endPoint.Y == startPoint.Y ? 0 : -1;

            do
            {
                var cell = new GridCell((int)startPoint.X, (int)startPoint.Y, 0);
                var foundCell = crapGrid.Find(x => x.X == cell.X && x.Y == cell.Y);
                if (foundCell != null)
                {
                    foundCell.Intersections++;
                    totalIntersections++;
                }
                else
                {
                    crapGrid.Add(cell);
                }
                startPoint.X += xDirection;
                startPoint.Y += yDirection;
            }
            while (startPoint.X != endPoint.X || startPoint.Y != endPoint.Y);

            var cell2 = new GridCell((int)startPoint.X, (int)startPoint.Y, 0);
            var foundCell2 = crapGrid.Find(x => x.X == cell2.X && x.Y == cell2.Y);
            if (foundCell2 != null)
            {
                foundCell2.Intersections++;
                totalIntersections++;
            }
            else
            {
                crapGrid.Add(cell2);
            }
        }
        var grouped = crapGrid.Where(x => x.Intersections >= 1);
        var answer = grouped.Count();

        Console.WriteLine($"Answer: {totalIntersections}\nAnswer Real:{answer}");

    }

    public static void SolvePart2()
    {
        var allLines = File.ReadAllLines("Data/day5.txt");
        var crapGrid = new List<GridCell>();
        var totalIntersections = 0;
        foreach (var line in allLines.Select(x => Line.MakeLineFromString(x)))
        {
            var startPoint = new Vector2(line.X1, line.Y1);
            var endPoint = new Vector2(line.X2, line.Y2);

            var xDirection = endPoint.X > startPoint.X ? 1 : endPoint.X == startPoint.X ? 0 : -1;
            var yDirection = endPoint.Y > startPoint.Y ? 1 : endPoint.Y == startPoint.Y ? 0 : -1;

            do
            {
                var cell = new GridCell((int)startPoint.X, (int)startPoint.Y, 0);
                var foundCell = crapGrid.Find(x => x.X == cell.X && x.Y == cell.Y);
                if (foundCell != null)
                {
                    foundCell.Intersections++;
                    totalIntersections++;
                }
                else
                {
                    crapGrid.Add(cell);
                }
                startPoint.X += xDirection;
                startPoint.Y += yDirection;
            }
            while (startPoint.X != endPoint.X || startPoint.Y != endPoint.Y);

            var cell2 = new GridCell((int)startPoint.X, (int)startPoint.Y, 0);
            var foundCell2 = crapGrid.Find(x => x.X == cell2.X && x.Y == cell2.Y);
            if (foundCell2 != null)
            {
                foundCell2.Intersections++;
                totalIntersections++;
            }
            else
            {
                crapGrid.Add(cell2);
            }
        }
        var grouped = crapGrid.Where(x => x.Intersections >= 1);
        var answer = grouped.Count();

        Console.WriteLine($"Answer: {totalIntersections}\nAnswer Real:{answer}");

    }


    public record Line(int X1, int Y1, int X2, int Y2)
    {
        public static Line MakeLineFromString(string lineText)
        {
            var pieces = lineText.Split("->", StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries);
            var firstCoords = pieces[0].Split(",", StringSplitOptions.TrimEntries);
            var x1 = int.Parse(firstCoords[0]);
            var y1 = int.Parse(firstCoords[1]);

            var secondCords = pieces[1].Split(",", StringSplitOptions.TrimEntries);
            var x2 = int.Parse(secondCords[0]);
            var y2 = int.Parse(secondCords[1]);

            return new Line(x1, y1, x2, y2);
        }
        public bool IsVertical() => Y1 == Y2;

        public bool IsHorizontal() => X1 == X2;
    }

    public record GridCell(int X, int Y, int Intersections)
    {
        public int Intersections { get; set; } = Intersections;
    }
}