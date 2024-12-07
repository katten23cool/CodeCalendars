using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Stopwatch sw = Stopwatch.StartNew();
        List<long> raceTime = new List<long>();
        List<long> raceDistance = new List<long>();

        List<long> numswon = new List<long>();

        long LineNum = 0;
        using (var fileStream = File.OpenRead("text.txt"))
        using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
        {
            sw.Start();
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                while (line.Contains(" "))
                {
                    string tempLine = line;
                    tempLine = tempLine.Substring(tempLine.LastIndexOf(" "));
                    line = line.Remove(line.LastIndexOf(" "));
                    line = line.TrimEnd();
                    tempLine = tempLine.Trim();
                    if (LineNum == 0)
                    {
                        raceTime.Add(Convert.ToInt64(tempLine));
                    }
                    else
                    {
                        raceDistance.Add(Convert.ToInt64(tempLine));
                    }
                }
                LineNum++;
            }

        }
        foreach (long e in raceTime)
        {
        }
        for (int j = 0; j < raceTime.Count; j++)
        {
            long amountwon = 0;
            long holdingdown = 0;
            for (long i = 0; i < raceTime[j]; i++)
            {
                if (BoatRaceWin(holdingdown,raceTime[j] - holdingdown, raceDistance[j]))
                {
                    amountwon++;
                }
                holdingdown++;//maybe put this guy all way down under
            }
            numswon.Add(amountwon);
        }
        long totalsum = 1;
        foreach (long wo in numswon)
        {
            totalsum *= wo;
        }
        sw.Stop();
        Console.WriteLine(totalsum + " : " + sw);

        bool BoatRaceWin(long holddown,long millisecondsleft, long distance)
        {
                if (holddown * millisecondsleft > distance)
                {
                    return true;
                }
            return false;
        }
    }
}