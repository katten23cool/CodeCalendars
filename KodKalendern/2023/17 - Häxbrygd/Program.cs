using System.Diagnostics;
using System.Linq;
using System.Text;

/*I tomtebyn rådde det vanligtvis glädje och feststämning under december månad. Men en morgon förändrades allt när nissen Alva, känd för att vara den mest energiska nissen i byn, vaknade upp med en konstig och sällsynt sjukdom. 
 * Hon var täckt av gröna prickar och kunde inte sluta nysa! Paniken spreds snabbt bland nissarna, och de insåg att de behövde hjälp.

Tomten, som var bekymrad över sin vän, samlade ihop en grupp modiga nissar för att söka hjälp. De visste precis vart de skulle vända sig – till skogens häxa, känd för sina magiska botemedel. Med en karta i handen och hopp i hjärtat begav de sig ut på en farlig resa genom snötäckta skogar och över frusna floder.

Till sist nådde de häxans stuga, en mystisk byggnad täckt av snirkliga sniderier och glimmande kristaller. Häxan, en gammal och vis kvinna, lyssnade tålmodigt på deras berättelse. Efter att ha tänkt en stund, tog hon fram en gammal, dammig bok och började bläddra i den. Hon läste högt ur boken:

“I skogens dunkel bland trädens snår,
en åkomma lurar, sällsynt och svår.
Grönsotssnuvan, listig och spröd,
endast en dryck kan rädda dig ur nöd.

På ett tangentbord, där bokstäver står i rad,
Väljs ingredienser för denna lemonad,
Den som dricker av elixiret klart,
från sjukdomens grepp, befrias snart.”

Hon förklarade att botemedlet till Alvas sjukdom krävde särskilda ingredienser. För att skapa botemedlet får endast ingredienser vars namn kan skrivas med en rad på tangentbordet användas.

Exempelvis skulle “ägg” kunna vara en tänkbar ingrediens eftersom Ä och G finns på samma rad på tangentbordet. Likaså skulle “rep” kunna vara en tänkbar ingrediens, eftersom bokstäverna R, E och P alla befinner sig på samma rad på tangentbordet.

Häxan ledde nissarna till sitt stora skafferi. Hon förklarade att alla ingredienser fanns där, men utmaningen var att identifiera dem bland hundratals burkar, flaskor och påsar. Häxan hade en lista på alla ingredienser i skafferiet.

Hur många ingredienser kan skrivas med en rad på tangentbordet?
 *  Svar: 5
*/

Stopwatch sw = Stopwatch.StartNew();

List<char> topRow = ['Q','W','E','R','T','Y','U','I','O','P','Å'];

List<char> middleRow = ['A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Ö', 'Ä'];

List<char> bottomRow = ['Z', 'X', 'C', 'V', 'B', 'N', 'M'];

int totalSum = 0;

using (var fileStream = File.OpenRead("..\\..\\..\\input.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
{
    sw.Start();
    string line;
    while ((line = streamReader.ReadLine()) != null)
    {
        List<char> temp = new List<char>();
        foreach (char c in line)
        {
            temp.Add(c);
        }
        int top = 0;
        int middle = 0;
        int bottom = 0;
        foreach (char c in temp)
        {
            char ca = char.ToUpper(c);
            if (topRow.Contains(ca))
            {
                top++;
            }
            else if (middleRow.Contains(ca))
            {
                middle++;
            }
            else if (bottomRow.Contains(ca))
            {
                bottom++;
            }
        }
        if (top == temp.Count)
        {
            totalSum++;
            Console.WriteLine(line);
        }
        else if (middle == temp.Count)
        {
            totalSum++;
            Console.WriteLine(line);
        }
        else if (bottom == temp.Count)
        {
            totalSum++;
            Console.WriteLine(line);
        }
    }
}

Console.WriteLine(totalSum + " " + sw.Elapsed); //its suppose to be 11