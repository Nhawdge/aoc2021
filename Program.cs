using System.Diagnostics;

var timer = new Stopwatch();

timer.Start();

//Day1.SolvePart1();
//Day1.SolvePart2();
//Day2.SolvePart1();
//Day2.SolvePart2();
//Day3.SolvePart1();
Day3.SolvePart2();

// var number = 1 << 2;
// number += 1 << 5;
// Console.WriteLine(Convert.ToString(number, 2));

timer.Stop();
Console.WriteLine($"RunTime:  {timer.ElapsedMilliseconds}ms");