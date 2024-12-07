using System.Diagnostics;
using System.Linq;
using System.Text;

/*I tomtebyn, på den pittoreska Russinvägen, där husen var prydda med snirklig snickarglädje och färggranna fönsterluckor, var Lucia en dag fylld av en lång och magisk tradition. 
 * Nissarna på Russinvägen hade i generationer ägnat sig åt att torka russin.
 * Varje år, på Lucia-morgonen, tog varje nisse sina noggrant torkade russin till den stora bakstugan. 
 * I bakstugan pågick det årliga luciabaket. I bakstugan skulle russinen användas för att pryda lussekatter.
 * 
 * Men denna Lucia-morgon uppstod ett mysterium. När alla nissar hade lämnat in sina russinaskar, märkte de att det saknades russin. En av nissarna hade inte lämnat in sina russin. Men vem?
 * Traditionen sade att varje nisse på Russinvägen torkade lika många russin som deras gatunummer (100-499). Det var en del av den magi som knöt samman hantverket med deras hem.
 * Varje nisse hade lämnat in olika många askar, men varje nisses totala antal russin var alltid lika med dess gatunummer. 
 * Nissarna skrev ner antalet russin som varje nisses askar innehöll i en lista. Dessa listor samlade nissarna i en lista av listor.
 * På vilket gatunummer bor den nisse som inte hade lämnat några russin?
 *  Svar: 
*/
Stopwatch sw = Stopwatch.StartNew();
int totalSumRussin = 0;
int totalhusnummer = 0;
int husnummer = 100;
using (var fileStream = File.OpenRead("..\\..\\..\\input.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
{
    sw.Start();
    string line;
    while ((line = streamReader.ReadLine()) != null)
    {
        string stri = line;
        while (line.Contains(","))
        {
            stri = line.Substring(line.LastIndexOf(",") + 2);
            line = line.Remove(line.LastIndexOf(","));
            totalSumRussin += Convert.ToInt32(stri);
           // Console.Write(stri + " ");
        }
       // Console.WriteLine(line);
        totalSumRussin += Convert.ToInt32(line);
        totalhusnummer += husnummer;
        husnummer++;
    }
    totalhusnummer += husnummer;

}

Console.WriteLine($"Totala summan russin: {totalSumRussin} \tTid tagen:" + sw.Elapsed);
Console.WriteLine($"Totala summan hus: {totalhusnummer} : {husnummer}");
Console.WriteLine($"Den nissen som inte har lämnat russin är: {totalhusnummer - totalSumRussin}");
