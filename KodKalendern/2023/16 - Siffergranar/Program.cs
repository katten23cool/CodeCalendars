using System.Diagnostics;
using System.Linq;
using System.Text;

/*Nissarna brukar varje år dekorera sina hem med siffergranar. Varje gran symboliseras av ett tal med ett ojämnt antal siffror. Den mittersta siffran i granen symboliserar julstjärnan. På vänster och höger sida om julstjärnan skapas ett par grenar. Summan av ett par grenar är alltid lika med julstjärnan. Det första paret av grenar placeras alltid närmast julstjärnan. Granen kan ha flera par grenar som placeras utanför de redan existerande grenarna. Nissarna skrev ner tomtebyns alla siffergranar i en lång lista av tal.

Exempel: en siffergran kan vara 61872, där siffran 8 är granens julstjärna.

    8

  1    7

6        2

Julstjärnan, 8, representerar summan av siffrorna på varje sida om den, steg för steg, med lika summor på båda sidor. I exemplet skulle 1 och 7 utgöra ett par av grenar (nästkommande siffror från mitten) och adderas för att bilda samma summa som julstjärnan (1+7=8). Och på samma sätt skulle 6 och 2 (de yttre siffrorna) också bilda summan 8.

Mitt i all julglädje uppstod ett dilemma. En av nissarna, Nisse Noggrann, hade råkat skapa en siffergran som inte följde reglerna. Hans gran hade fått en felaktig siffra, där summan inte stämde överens med julstjärnans siffra. Detta orsakade en liten uppståndelse bland nissarna, för det var mycket viktigt att alla siffergranar var korrekta för att behålla julens matematiska harmoni.

Vilket tal representerade Nisse Noggranns siffergran?
 *  Svar: 54722
*/

Stopwatch sw = Stopwatch.StartNew();


using (var fileStream = File.OpenRead("..\\..\\..\\input.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
{
    sw.Start();
    string line;
    while ((line = streamReader.ReadLine()) != null)
    {
        List<List<int>> nummer = new List<List<int>>();
        List<int> temp = new List<int>();
        for (int i = 0; i <= (int)line.Length/2;)
        {
            if (i == 0)
            {
                temp.Add(line[(line.Length / 2)] - '0');
            }
            else
            {
                int h = line.Length / 2;
                temp.Add(line[i + h] - '0');
                temp.Add(line[h - i] - '0');
            }
            nummer.Add(temp.ToList());
            temp.Clear();
            i++;
        }

        int bignum = nummer[0][0];
        foreach (var i in nummer)
        {
            int smallnum = 0;
            foreach (var j in i)
            {
                smallnum += j;
            }
            if (smallnum != bignum)
            {
                Console.WriteLine(line);
            }
        }
        nummer.Clear();

    }
}

Console.WriteLine("" + sw.Elapsed);