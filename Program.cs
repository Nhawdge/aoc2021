using System.Diagnostics;

var timer = new Stopwatch();

timer.Start();

//Day1.SolvePart1();
//Day1.SolvePart2();
//Day2.SolvePart1();
//Day2.SolvePart2();
//Day3.SolvePart1();
//Day3.SolvePart2();
//Day4.SolvePart1();
//Day4.SolvePart2();
//Day5.SolvePart1(); 
//Day5.SolvePart2(); 
//Day6.SolvePart1();
//Day6.SolvePart2(timer);
//Day7.SolvePart1();
//Day7.SolvePart2();

Day8.SolvePart1();

timer.Stop();
Console.WriteLine($"RunTime:  {timer.ElapsedMilliseconds}ms");