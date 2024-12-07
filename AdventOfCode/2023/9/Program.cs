using System.Diagnostics;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Stopwatch sw = Stopwatch.StartNew();

        long TotalSum = 0;
        long totalleftsum = 0;

        List<long> numswon = new List<long>();
        int Linera = 0;
        using (var fileStream = File.OpenRead("text.txt"))
        using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
        {
            List<long> lineNumbers = new List<long>();
            sw.Start();
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                List<List<long>> templists = new List<List<long>>();

                while (line.Contains(" "))
                {
                    string tempLine = line;
                    tempLine = tempLine.Substring(tempLine.LastIndexOf(" "));
                    line = line.Remove(line.LastIndexOf(" "));
                    line = line.TrimEnd();
                    tempLine = tempLine.Trim();
                    lineNumbers.Add(Convert.ToInt64(tempLine));
                }
                lineNumbers.Add(Convert.ToInt64(line));
                lineNumbers.Reverse();
                templists.Add(lineNumbers.ToList());

                List<long> temp = new List<long>();
                bool hi = true;
                while (hi)
                {
                    for (int i = 0; i < lineNumbers.Count; i++)
                    {
                        try
                        {
                            long raaawr = lineNumbers[i + 1] - lineNumbers[i];

                            temp.Add(raaawr);
                            //Console.WriteLine(raaawr);
                        }
                        catch (Exception ex)
                        {
                            //Console.WriteLine(ex.Message);
                        }
                    }
                    int j = 0;
                    foreach (long g in temp)
                    {
                        if (g != 0)
                        {
                            j++;
                            //Console.WriteLine(g);
                        }
                    }
                    if (j == 0)
                    {
                        hi = false;
                    }
                    lineNumbers = temp.ToList();
                    templists.Add(temp.ToList());
                    temp.Clear();
                }
                long yoo = 0;
                long yee = 0;
                //part1
                foreach (List<long> templist in templists)
                {
                    try
                    {
                        if (templist[templist.Count - 1] < 0)//remove this if no worki
                        {
                            long ea = templist[templist.Count - 1] - templist[templist.Count - 1] * 2;

                            yoo -= ea;
                        }
                        else
                        {
                            yoo += templist[templist.Count - 1];
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
                //part2
                templists.Reverse();
                foreach (List<long> templist in templists)
                {
                    try
                    {
                        yee = templist[0] - yee;
                        Console.WriteLine(yee);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                int ra = 0;
                Console.WriteLine("Line : " + Linera);
                templists.Reverse();
                foreach (var linee in templists)
                {
                    Console.Write(new string(' ', ra * 2));
                    foreach (var e in linee)
                    {
                        string repeatedString = String.Concat(Enumerable.Repeat("\t", ra));
                        //Console.Write(e + repeatedString);
                        Console.Write(e.ToString().PadLeft(3) + " ");
                    }
                    Console.WriteLine();
                    ra++;
                }
                Console.WriteLine("Sum :" + yoo);
                Console.WriteLine("Sumleft :" + yee);

                TotalSum += yoo;
                totalleftsum += yee;
                lineNumbers.Clear();
                Console.WriteLine();
                Linera++;
            }
        }
        Console.WriteLine($"Left side : {totalleftsum} \tRight side : {TotalSum} \tTime :{sw}");
    }
}