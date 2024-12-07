using System.Diagnostics;
using System.Linq;
using System.Text;

/*Under natten hade starka solstormar orsakat ett fantastiskt norrsken över nordpolens natthimmel. Nissarna, vanligtvis tidiga i säng, hade stannat uppe för att njuta av det spektakulära skådespelet.

Men när morgonen kom och de trötta nissarna anlände till tomteverkstaden, möttes de av en oväntad överraskning. Ett strömavbrott under natten hade återställt den älskade julmustautomaten (källan till deras mycket älskade juldryck). För att återaktivera automaten behövdes nu ett lösenord, något som ingen nisse hade stött på tidigare.

Nissen Nora, verkstadens problemlösare, kallades snabbt till platsen. Hon upptäckte att lösenordet var kopplat till en lista av tal, en kod som skapades genom att analysera sekvenser av ökande och minskande tal.

I listan av tal så kan nästkommande tal antingen vara högre eller lägre än det aktuella talet. Ökande respektive minskande tal i följd bildar sekvenser. För att återskapa lösenordet, behövde längden av sekvenserna summeras.

Exempel: Listan 1, 6, 8, 4, 3, 2, 55 bildar sekvenserna:
1, 6, 8 av ökande tal (med längden 3)
8, 4, 3, 2 av minskande tal (med längden 4)
2, 55 av ökande tal (med längden 2)

Denna exempellista skulle bilda lösenordet 9, eftersom 3+4+2=9.

Vad är lösenordet till julmustautomaten?
 *  Svar: 1019
*/
Stopwatch sw = Stopwatch.StartNew();
int totalSum = 0;
using (var fileStream = File.OpenRead("..\\..\\..\\input.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
{
    sw.Start();
    string line;
    int tempInt = 0;
    int tempInt2 = 0;

    bool high = true;
    bool low = true;
    while ((line = streamReader.ReadLine()) != null)
    {
        int lineInt = Convert.ToInt32(line);
        if (lineInt > tempInt && high)
        {
            tempInt = lineInt;
            tempInt2++;
            //Console.WriteLine("H\t" + line);
        }
        else
        {
            high = false;
        }

        if (lineInt < tempInt && low)
        {
            tempInt = lineInt;
            tempInt2++;
            //Console.WriteLine("L\t" + line);
        }
        else
        {
            low = false;
        }

        if (!low && !high)
        {
            Console.WriteLine(tempInt2);
            high = true;
            low = true;
            tempInt = lineInt;
            totalSum += tempInt2; 
            tempInt2 = 1;
        }
    }
}

Console.WriteLine(totalSum+" " + sw.Elapsed);