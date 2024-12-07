using System.Diagnostics;
using System.Linq;
using System.Text;

/*För att leverera alla julklappar över hela världen på ett enda dygn använde tomten en mycket speciell tidsklocka. Denna klocka, skapad av de äldsta nissarnas förfäder, hade kraften att böja tiden, vilket gjorde det möjligt för tomten att leverera julklappar över hela världen i tid.

Klockan förvarades alltid säkert i tomtens glaciärförråd, ett hemligt förråd ute på nordpolens eviga is. Men efter den senaste snöstormen hade glaciärförrådet blivit helt bortsnöat. Ingen visste längre var ingången låg, då snön hade täckt över alla spår.

Tomten, bekymrad över att inte kunna fullfölja julklappsutdelningen utan klockan, sökte desperat i sina gamla arkiv och hittade slutligen en mycket gammal och sliten karta. Kartan innehöll en serie mystiska instruktioner, skrivna för länge sedan, som skulle leda till platsen där de borde börja gräva i snön för att hitta ingången till glaciärförrådet (och därmed tidsklockan).

Tomten visste att instruktionerna skulle leda honom till den exakta plats där glaciärförrådet fanns om han utgick ifrån sin altan, och vandrade i riktning mot polstjärnan.

Instruktionerna var kodade i en lång sekvens av bokstäver bestående av F och B. Det var gammal nisskod som användes för att skydda hemliga platser.

F står för Framåt: Varje enskilt "F" innebär ett steg framåt.
B står för Bakåt: Varje enskilt "B" innebär ett steg bakåt.

Om det finns två eller fler "F" i rad, tar man alltid ett extra steg. Så "FF" betyder tre steg framåt, och “FFF” betyder fyra steg framåt.

Om det finns två eller fler “B” i rad gäller följande:
Jämnt antal B: Om det finns ett jämnt antal "B" i rad, som i "BB" eller "BBBB", tar du alltid två steg bakåt, oavsett hur många "B" det är.
Ojämnt antal B:
Om det finns ett ojämnt antal "B" i rad, som i "BBB" eller "BBBBB", tar du så många steg bakåt som det finns "B". Så "BBB" innebär tre steg bakåt, och "BBBBB" innebär fem steg bakåt.

Exempel:
"FB" innebär ett steg fram och ett steg bak, vilket resulterar i att du hamnar på samma plats som du startade. Totalt 0 steg.
"FFBF" innebär tre steg fram, ett steg bak och ett steg fram. Totalt 3 steg.
"FFBBBB" innebär tre steg fram och två steg bak. Totalt 1 steg.
"BBBFFFB" innebär tre steg bak, fyra steg fram och ett steg bak. Totalt 0 steg.

Hur många steg ifrån tomtens altan finns tidsklockan?

 *  Svar: 214
*/
Stopwatch sw = Stopwatch.StartNew();
int totalsteg = 0;
List<string> list = new List<string>();
using (var fileStream = File.OpenRead("..\\..\\..\\input.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
{
    sw.Start();
    string line;
    while ((line = streamReader.ReadLine()) != null)
    {
        string chars = "";
        foreach (char c in line)
        {
            if (chars == ""|| c == chars[0])
            {
                chars += c;
            }
            else
            {
                KollaSteg(chars);
                chars = c.ToString();
            }
        }
        KollaSteg(chars);
    }
}
foreach (string c in list)
{
    Console.WriteLine(c);
}

Console.WriteLine(totalsteg + " " + sw.Elapsed);
void KollaSteg(string chars)
{
    if (chars[0] == 'F')
    {
        if (chars.Length > 1)
        {
            totalsteg += chars.Length + 1;
        }
        else
        {
            totalsteg++;
        }
    }
    else if (chars[0] == 'B')
    {
        if (chars.Length % 2 == 0)
        {
            totalsteg -= 2;
        }
        else
        {
            totalsteg -= chars.Length;
        }
    }
    list.Add(chars);
}