using System.Diagnostics;
using System.Numerics;
using System.Text;

Stopwatch sw = Stopwatch.StartNew();
List<List<char>> spaceList = new List<List<char>>();
Dictionary<int, Vector2> starcordinates = new Dictionary<int, Vector2>();
Dictionary<string, int> starlengths = new Dictionary<string, int>();
int amountStars = 1;
int totalDistance = 0;
int totalPairs = 0;
int totalGalaxys = 0;
using (var fileStream = File.OpenRead("text.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
{
    sw.Start();
    string line;
    while ((line = streamReader.ReadLine()) != null)
    {
        List<char> tempList = new List<char>();
        int amountX = 0;
        foreach (char c in line)
        {
            if (c == '#')
            {
                amountX++;
                totalGalaxys++;
            }
            tempList.Add(c);
        }
        spaceList.Add(tempList.ToList());
        if (amountX == 0)
        {
            spaceList.Add(tempList.ToList());
        }
    }
}
int x = spaceList[0].Count;
while (x > 0)
{
    x--;
    int amountstars = 0;
    for (int y = 0; y < spaceList.Count; y++)
    {
        if (spaceList[y][x] == '#')
        {
            amountstars++;
        }
    }
    if (amountstars == 0)
    {
        for (int y = 0; y < spaceList.Count; y++)
        {
            spaceList[y].Insert(x, '.');
        }
    }
}


for (int y = 0; y < spaceList.Count; y++)
{
    for (int k = 0; k < spaceList[y].Count; k++)
    {
        if (spaceList[y][k] == '#')
        {
            starcordinates.Add(amountStars++, new Vector2(k, y));
        }
    }
}

// if dictionarey.containts (ab || ba) dictionary check


foreach (var star1 in starcordinates)
{
    foreach (var star2 in starcordinates)
    {
        string starvalue1 = $"{star1.Key}{star2.Key}";
        string starvalue2 = $"{star2.Key}{star1.Key}";

        if (starlengths.ContainsKey(starvalue1) || star1.Key <= star2.Key)
        {
            // Skip if pair has already been processed or if keys are equal
        }
        else
        {
            Vector2 vector1 = star1.Value - star2.Value;
            int distance = (int)(Math.Abs(vector1.X) + Math.Abs(vector1.Y));

            if (distance < 0)
            {
                distance = Math.Abs(distance);
            }

            starlengths.Add(starvalue1, distance);
            totalPairs++;

           // Console.WriteLine($"Pair: ({star1.Key}, {star2.Key}), Distance: {distance}");
        }
    }
   // Console.WriteLine(star1);
}


foreach (var dictioney in starlengths)
{
    totalDistance += dictioney.Value;
  // Console.WriteLine(dictioney.Key);
}




int yj = 0;
foreach (var list in spaceList)
{
    yj++;
    Console.Write(yj + "\t");
    foreach (char c in list)
    {
        Console.Write(c);
    }
    Console.WriteLine();
}
Console.WriteLine("Svar : " + totalDistance + " " + sw);
Console.WriteLine("pairs : " + totalPairs);
Console.WriteLine("Galaxys : " + totalGalaxys);

/*Is not
 * 8612525 - to low
 * 8614057
 * 8614057 - PAirs 82717
 * 9535934 - pairs 91346
 */
