using System;
using System.Diagnostics;
using System.Text;
using System.Linq;

Stopwatch sw = Stopwatch.StartNew();

Dictionary<int,int> popularYears = new Dictionary<int,int>();

using (var fileStream = File.OpenRead("text.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
{
    sw.Start();
    string line;
    while ((line = streamReader.ReadLine()) != null)
    {
        while (line.Contains(","))
        {
            string tempLine = line;
            tempLine = tempLine.Substring(tempLine.LastIndexOf(",")+1);
            line = line.Remove(line.LastIndexOf(","));
            line = line.TrimEnd();
            tempLine = tempLine.Trim();
            if (popularYears.ContainsKey(Convert.ToInt32(tempLine)))
            {
                popularYears[Convert.ToInt32(tempLine)]++;
                
            }
            else
            {
                popularYears.Add(Convert.ToInt32(tempLine), 1);
            }
        }
    }
}
int highest = 0;
int year = 0;
foreach (var popularYear in popularYears)
{
    if (popularYear.Value > highest)
    {
        year = popularYear.Key;
        highest = popularYear.Value;

    }
}
Console.WriteLine(year + " : " + sw);