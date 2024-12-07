using System.Diagnostics;
using System.Linq;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

/*I tomteverkstaden arbetade nissarna på sin senaste produkt: "JinglePods" - trådlösa hörlurar med ett jultema, vackert designade i röda och gröna färger, med en unik glänsande snöflinga graverad på varje hörlur.

Denna morgon inträffade en mindre katastrof. Nissen Norbert (vars klumpighet var välkänd bland de andra nissarna) satt med en stor låda av alla hörlurar framför sig och parade ihop vänster och höger hörlur.

Plötsligt, när han plockade upp en av hörlurarna, så råkade han tappa den. Det började som en liten studs på det blankpolerade golvet, men snart tog oturen över.

Hörluren studsade från golvet, upp på bänken där nisse Elvira arbetade på en gnistrande leksaksrobot, och innan någon hann reagera, råkade roboten skjuta hörluren rätt upp i luften, studsandes på kristallkronan i taket, flög den sedan rakt in i smältugnen där de gjuter leksakernas metalldelar. Ett litet "hiss" hördes, och hörluren var borta, smält ner till ingenting i ugnens hetta.

Alla nissar i verkstaden stannade upp och stirrade på Norbert, vars öron rodnade mer än den röda mössan på hans huvud. "Åh nej, vad har jag gjort?" utbrast han med en hand över munnen.

Elsa, chefen för hörlursavdelningen, suckade djupt och skakade på huvudet. "Nu har vi ett par JinglePods mindre, och varje par är unikt. Det här kommer bli ett problem," sa hon bekymrat.

Norbert, kände sig djupt ansvarig för misstaget, erbjöd sig att hitta en lösning. "Jag ska fixa det här," sa han bestämt. Norbert hade en lång lista på alla hörlurars serienummer.

Varje JinglePod-hörlur har ett unikt serienummer bestående av en kombination av bokstäver. För varje par av JinglePods är serienumren spegelbilder av varandra när det gäller vokaler och konsonanter. Det innebär att om en hörlur har en vokal på en specifik position i sitt serienummer, kommer dess partnerhörlur att ha en konsonant på exakt samma position i sitt serienummer, och vice versa.

Till exempel, om en hörlur har serienumret "AATT", där 'A' och 'T' är vokaler respektive konsonanter, så skulle dess partnerhörlur t.ex. kunna ha serienumret "RROO", där 'R' och 'O' är motsatta konsonanter respektive vokaler på motsvarande positioner. Detta system garanterar att varje par av JinglePods är unikt matchade genom sina serienummer.

På detta sätt kan nissarna enkelt identifiera vilka två hörlurar som hör ihop genom att jämföra serienumrens struktur av vokaler och konsonanter.

Vilket serienummer har den hörlur som saknar sin partner?
 *  Svar: byaueojiadoiyioleyxs
*/
Stopwatch sw = Stopwatch.StartNew();
string vokal = "AEIOUYÅÄÖ";
string consonant = "BCDFGHJKLMNPQRSTVWXZ";

Dictionary<string, CustomData> pairs = new Dictionary<string, CustomData>();


using (var fileStream = File.OpenRead("..\\..\\..\\input.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
{
    sw.Start();
    string line;
    while ((line = streamReader.ReadLine()) != null)
    {
        string tempstring= "";
        string reversestring = "";
        foreach (char c in line.ToUpper())
        {
            if (vokal.Contains(c))
            {
                tempstring += 1;
                reversestring += 0;
            }
            else if (consonant.Contains(c))
            {
                tempstring += 0; 
                reversestring += 1;
            }
        }
        if (pairs.ContainsKey(tempstring))
        {
            pairs[tempstring].Number += 1;
        }
        else if (pairs.ContainsKey(reversestring))
        {
            pairs[reversestring].Number += 1;
        }
        else
        {
            pairs.Add(tempstring, new CustomData { String1 = line, Number = 1 });
        }
    }
}
foreach (var pair in pairs)
{
    if (pair.Value.Number == 1)
    {
        Console.WriteLine($"Serienummer: {pair.Value.String1}");
    }
}

Console.WriteLine("" + sw.Elapsed);
class CustomData
{
   public string String1 { get; set; }
  public  int Number { get; set; }
}