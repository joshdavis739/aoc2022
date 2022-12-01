var input = File.ReadAllLines("C:/Projects/Advent of Code 2022/UI/Day1.txt");
var current = 0;
var largest = 0;
foreach (var line in input)
{
    if (line.Length == 0)
    {
        if (current > largest)
        {
            largest = current;
        }

        current = 0;
    }
    else
    {
        current += int.Parse(line);
    }
}
Console.WriteLine(largest);
