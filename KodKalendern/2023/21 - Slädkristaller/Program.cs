using System.Diagnostics;
using System.Linq;
using System.Text;

/*Det var dags att förbereda tomtens släde för den magiska julaftonsfärden. I hjärtat av all denna förväntan och spänning fanns nissen Hugo, en mästare i forntida magi och hemliga ritualer, men framför allt, tomtens egen poet.

Varje år, precis innan jul, skrev Hugo en juldikt som speglade julens händelser, känslor och förväntningar. Men det var inte bara för sakens skull. Det fanns en djupare mening med hans ord. Första meningen i dikten var nyckeln till slädens magiska kraft. Varje bokstav spelade en roll i att bestämma antalet magiska kristaller som skulle placeras på släden.

Antalet kristaller bestämdes av det antal unika ord som endast använder samma tecken som finns i första raden i dikten. Eftersom första raden lyder “I en by vid nordpolens rand”, så är det dessa tecken som används för att hitta de unika orden. Ett ord räknas alltså endast en gång. Orden i första raden räknas också.

När Hugo äntligen steg fram för att läsa upp juldikten, kunde man känna en stor förväntan bland nissarna. Hans röst var stark och klar i den kalla luften, och med varje ord vibrerade en osynlig energi runt omkring dem. Hugo läste:

“I en by vid nordpolens rand,
där nissarna bor i ett vinterland.
Snön gnistrar vit på varje tak,
och julens magi finns i varje sak.

Tomtefar i sin röda dräkt,
med ett skägg så vitt som nysnön täckt.
Han styr sin verkstad med varm hand,
och leksaker skapas med julens band.

I månens ljus nissarna lekfullt dansar,
bland julpynt och vackra kransar.
De sjunger och skrattar, sprider glädje och ljus,
i tomtebyn bland sagolika hus.

Renarnas slädar står redo för färd,
för att sprida julmagi över hela vår värld.
För i tomtebyn på nordpolens mark,
startar tomten färden med en lätt spark.

I tomteverkstaden, där maskiner står på rad,
finns en hjälte som gjort alla extra glad.
KlappMaker3000, med kugghjul och band,
har skapat julklappar nästan för hand.

Med ett blinkande ljus och surrande ljud,
har den skapat magi, under nattens stjärnklara bud.
Årets julklapp, JinglePods, uppfunnen av nissen Alberta,
för musikens magi till varje hjärta.

Med ljud av högsta kvalitet, ren och klar,
hörs JinglePods musik från nära och fjärran, så rar.
Nissarna bär dem, dansar och ler,
för i JinglePods klang, finner de julens ande mer.

Och där, mitt på tomtebyns jublande torg,
hörs Tindra Swifts stämma, en röst utan sorg.
Hennes senaste låt flyter genom luften så lätt,
och nissarna dansar, allt känns rätt.

Tacksamhet fyller varje vrå,
för KlappMaker3000, som gjorde julen så skön att förstå.
I tomtebyn, under vinterns kalla natt,
Önskar Kodkalendern God jul så glatt.”

Dikten sparades ner, mening för mening, i en lista (utan punkt- och kommatecken). Hur många kristaller skulle placeras på släden?
 *  Svar: 21
*/
Stopwatch sw = Stopwatch.StartNew();
sw.Start();
int totalSum = 0;
int lineint = 0;
Dictionary<string, int> words = new Dictionary<string, int>();
List<char> chars = new List<char>();

using (var fileStream = File.OpenRead("..\\..\\..\\input.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
{
    string line;
    while ((line = streamReader.ReadLine()) != null)
    {
        if (lineint == 0)
        {
            foreach (char c in line)
            {
                if (c != ' ')
                {
                    chars.Add(char.ToUpper(c));
                    Console.Write(char.ToUpper(c) + " ");
                }
            }
            Console.WriteLine();
            lineint++;
        }
    }

}
using (var fileStream = File.OpenRead("..\\..\\..\\input.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
{
    string rar;
    while ((rar = streamReader.ReadLine()) != null)
    {
        string word = "";
        string word2 = "";
        foreach (char c in rar)
        {
            word2 += char.ToUpper(c);
            if (chars.Contains(char.ToUpper(c)))
            {
                word += char.ToUpper(c);
            }
            else if (c == ' ')
            {
                if (!words.ContainsKey(word) && word == word2.Trim())
                {
                    words.Add(word, 1);
                    Console.WriteLine(word);
                }
                word = "";
                word2 = "";
            }
        }
        if (!words.ContainsKey(word) && word == word2.Trim())
        {
            words.Add(word, 1);
            Console.WriteLine(word);
        }

    }
}

foreach (int word in words.Values)
{
    totalSum += word;
}
Console.WriteLine(totalSum + " " + sw.Elapsed);