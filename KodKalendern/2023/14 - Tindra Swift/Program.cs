using System.Diagnostics;
using System.Linq;
using System.Text;

/*I tomtebyn hade Tindra Swift, en av nordpolens mest älskade artister, ett storslaget projekt på gång. Med åren hade hon märkt att lyssningarna på hennes julsånger på Spotify alltid minskade efter jul (vilket hon tyckte var mycket märkligt). Tindra hade alltid drömt om att skapa en jullåt som människor aldrig skulle tröttna på, en jullåt som kunde spelas året om.

Tindra hade byggt ett avancerat program som analyserade julfrekvenser från befintliga jullåtar. Programmet tog inte bara hänsyn till melodin och harmonin, utan även sångernas rytm och instrumentens klangfärg. Med programmet till hjälp, började Tindra skapa sin jullåt.

Efter otaliga timmar av analyser och justeringar, var Tindra nära att fullborda sin dröm. Men något var fortfarande inte rätt. En ton i sången som hon skapade lät aningen falsk, och det störde den annars perfekta julharmonin. För att lösa detta problem, omvandlade Tindra musikens toner till numeriska julfrekvenser och listade dem i en lista.

Det var då hon upptäckte det magiska mönstret: summan av de yttersta siffrorna i ett tal var lika med mittensiffran i nästkommande tal. Det var en upptäckt som inte bara skulle kunna korrigera den falska tonen, utan som också kunde vara en stor nog upptäckt för att nominera Tindra till Nobels Julpris!

Denna magiska algoritm var nyckeln till att skapa den ultimata julsången - en sång som inte bara charmade under julen, utan fortsatte att förtrolla lyssnare året runt. Ett kraftfullt verktyg för en artist som Tindra.

Det verkade som att ett tal i listan hade fått en felaktig mittensiffra. Det finns totalt 4147 tal som är placerade på plats 0-4146.

På vilken plats (index) finns det tal som har en felaktig mittensiffra?
 *  Svar: 3553
*/
Stopwatch sw = Stopwatch.StartNew();
int middleNum = 3;
int lineint = 0;
int falsenum = 0;
using (var fileStream = File.OpenRead("..\\..\\..\\input.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
{
    sw.Start();
    string line;
    while ((line = streamReader.ReadLine()) != null)
    {
        int leftside = line[0] - '0';
        int rightside = line[line.Length-1] - '0';
        int middle = (line.Length / 2);
        int middledigit = line[middle] - '0';
        //Console.WriteLine(middleNum + " " + line[middle]);
        if (middleNum != middledigit)
        {
            Console.WriteLine(line + "  " + middleNum + "  " + line[middle]);
            falsenum = Convert.ToInt32(line);
            break;
        }
        middleNum = leftside + rightside;

        lineint++;
    }
}

Console.WriteLine(falsenum + " "+ lineint + " " + sw.Elapsed);