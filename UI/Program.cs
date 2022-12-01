var input = File.ReadAllLines("C:/Projects/Advent of Code 2022/UI/Day1.txt");
var current = 0;
var numberOfItemsToTrack = 3;
var largestItems = Array.Empty<int>();

foreach (var line in input)
{
    if (line.Length == 0)
    {
        if (largestItems.Length < numberOfItemsToTrack)
        {
            largestItems = largestItems.Append(current).OrderBy(x => x).ToArray();
        }
        else if (current > largestItems[0])
        {
            var newLargestItems = largestItems.Skip(1).Append(current).OrderBy(x => x).ToArray();
            largestItems = newLargestItems;
        }

        current = 0;
    }
    else
    {
        current += int.Parse(line);
    }
}

if (current > largestItems[0])
{
    var newLargestItems = largestItems.Skip(1).Append(current).OrderBy(x => x).ToArray();
    largestItems = newLargestItems;
}

Console.WriteLine(largestItems.Sum());