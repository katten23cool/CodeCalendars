using System.Diagnostics;
using System.Linq;
using System.Text;

/*Med tomtens släde som just lämnat byn på sin årliga färd runt världen, fylls luften med en blandning av spänning och glädje. Nissarna, som har arbetat outtröttligt för att förbereda alla julklappar och ordna med festligheterna, tar nu en välförtjänt paus.

Men firandet i tomtebyn börjar inte på riktigt förrän tomten är tillbaka från sin resa. För att fördriva tiden medan de väntar på tomtens återkomst från julklappsutdelningen, har nissarna skapat ett speciellt julklappsspel.

Julklappsspelet som nissarna spelar är en unik och rolig tradition i tomtebyn. Nissarna är uppdelade i grupper om 10. I varje grupp är nissarna numrerade 0-9. Varje nisse startar spelet med sin egen present, vilket innebär att nisse 0 har present 0, nisse 1 har present 1, och så vidare upp till nisse 9 som har present 9.

Spelet består av en eller flera omgångar, där varje omgång består av en slumpmässigt genererad sekvens av nummer från 0 till 9. Denna sekvens avgör hur nissarna byter julklappar med varandra.

I varje omgång börjar nisse 0 och byter julklapp med den nisse vars nummer visas först i sekvensen. Sedan fortsätter nissarna, i tur och ordning, enligt sekvensen. Varje nisse byter sin julklapp med den nisse som numret i sekvensen visar. Om en nisse får sitt eget nummer, behåller de sin egen julklapp.

Exempel:
Startsekvens (innan någon byter): 0,1,2,3,4,5,6,7,8,9
Exempel på en omgångssekvens: 2,8,0,3,4,5,6,7,9,1

Förloppet i denna omgång:
- Nisse 0 byter med nisse 2
- Nisse 1 byter med nisse 8
- Nisse 2 byter med nisse 0 (och får tillbaka sin egen present)
- Nisse 3 behåller sin egen present (byter med sig själv)
- Nisse 4 behåller sin egen present (byter med sig själv)
- Nisse 5 behåller sin egen present (byter med sig själv)
- Nisse 6 behåller sin egen present (byter med sig själv)
- Nisse 7 behåller sin egen present (byter med sig själv)
- Nisse 8 byter med nisse 9
- Nisse 9 byter med nisse 1

Efter denna omgång blir sekvensen: 0,1,2,3,4,5,6,7,9,8. Vilket innebär att alla nissar, förutom nisse 8 och 9 har sin egen present i slutet av omgången.

Nissarnas omgångar slumpas. En grupp nissar undrar om det inte vore möjligt att se vems present de kommer få i slutet av spelet med hjälp av ett datorprogram. De ska spela 10 omgångar, och skriver ner sina omgångar i en lista.

Vems present har Nisse 4 i slutet av spelet? (svara med ett heltal)
 *  Svar: 6
*/

Stopwatch sw = Stopwatch.StartNew();
sw.Start();
Dictionary<int, int> nissePresent = new Dictionary<int, int>();

for (int i = 0; i < 10; i++)
{
    nissePresent.Add(i, i);
}
using (var fileStream = File.OpenRead("..\\..\\..\\input.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
{
    string line;
    while ((line = streamReader.ReadLine()) != null)
    {
        int nisseInt = 0;
        foreach (char c in line)
        {
            if (char.IsDigit(c))
            {
                string chaa = c.ToString();
                int cint = Convert.ToInt32(chaa);

                (nissePresent[cint], nissePresent[nisseInt]) = (nissePresent[nisseInt], nissePresent[cint]);
                nisseInt++;
            }
        }
        foreach (var presenter in nissePresent)
        {
            Console.Write(presenter.Value + "\t");
        }
        Console.WriteLine();
    }
}

Console.WriteLine(nissePresent[4] + " " + sw.Elapsed); 