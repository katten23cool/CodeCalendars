using System.Diagnostics;
using System.Linq;
using System.Text;

/*I den östra delen av Småland, ligger en liten, pittoresk by som kallas Figeholm. Denna by är inte som någon annan; den är känd bland nissarna som en trendskapare för julklappar. Här, på denna förtrollade plats, föds trender som senare sprider sig till resten av Sverige.

Varje år, när decembernätterna blir längre och stjärnorna lyser klarare, samlas nissarna i tomtebyn för att genomföra en mycket viktig analys. De ska räkna alla julklappar som ska skickas till Figeholm. För i Figeholm avslöjas hemligheterna om vad barn i hela Sverige kommer att önska sig nästa år.

Ett gammalt ordspråk som vandrat mellan generationer av nissar lyder: "Som Figeholm önskar, önskar Sverige." Detta år är inget undantag. Ordspråket innebär att önskningarna i Figeholm ett år, brukar återspegla önskningarna för Sverige kommande år. Genom att räkna paketen som ska skickas till Figeholm i år, så kan nissarna få en fingervisning över vad de behöver tillverka nästa år. Nissarna har plockat fram de färdigpackade säckarna som tomten ska plocka med sig till Figeholm, och skrivit ner alla julklapparna.

Nissarna har skrivit ner varje julklapp så många gånger som det förekommer i säckarna, i en lång lista. Om t.ex. “fotboll” förekommer tre gånger, så har de skrivit ner “fotbollfotbollfotboll”.

Hur många julklappar ska totalt skickas till Figeholm?
 *  Svar: 535
*/
Stopwatch sw = Stopwatch.StartNew();
int totalklappar = 0;
using (var fileStream = File.OpenRead("..\\..\\..\\input.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
{
    sw.Start();
    string line;
    while ((line = streamReader.ReadLine()) != null)
    {
        string word = "";
        int length = 0;
        foreach (char c in line)
        {
            word += c;
            if (word.Length * 2 < line.Length)
            {
                length = word.Length;
            }
            else
            {
                length = 0;
            }
            if (line.Substring(length, word.Length) == word)
            {
                Console.Write(word + " ");
                break;
            }
        }
        int tempint = 0;
        while (line.Contains(word))
        {
            totalklappar++;
            tempint++;
            line = line.Remove(line.LastIndexOf(word));
        }
        Console.WriteLine(tempint.ToString());
    }
}

Console.WriteLine(totalklappar + " " + sw.Elapsed);