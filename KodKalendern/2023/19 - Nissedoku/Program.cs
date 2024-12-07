using System.Diagnostics;
using System.Linq;
using System.Text;

/*En tidig morgon i Tomtebyn, medan snön försiktigt föll utanför fönstren till Tomteverkstadens tryckeri, satt nissen Sigrid, ansvarig för kvalitetskontroll, och bläddrade noggrant igenom facit till veckans utgåva av “Tomtebyns Tankenötter”, en tidning fylld med olika typer av knep och knåp. Sigrid, vars öga för detaljer var lika skarpt som vinterluften utanför, hade en rutin medan tryckpressarna rullade - att noggrant granska varje sida medan hon njöt av sitt morgonkaffe.

Men denna morgon blev annorlunda. Medan tryckpressarna surrade i bakgrunden, och doften av nytryckt papper fyllde rummet, höll Sigrid nästan på att sätta kaffet i halsen. Till hennes förvåning och oro upptäckte hon att något inte stämde med facit till Nissedoku-pusslen. De felaktiga lösningarna var uppenbara, och det stod klart att en av tryckpressarna hade drabbats av ett tekniskt fel.

För att inte försena distributionen av tidningen behövde problemet åtgärdas snabbt. Sigrid behövde veta hur många av Nissedoku-pusslen som hade fått felaktiga facit.

Ett Nissedoku är ett slags pussel som använder 9 bokstäver ordnade i en kvadrat, med tre rader och tre kolumner. För att ett Nissedoku ska vara korrekt löst, måste det uppfylla vissa regler:

- I den första horisontella raden ska bokstäverna antingen vara identiska eller öka i alfabetisk ordning. - I den första vertikala kolumnen ska samma regel tillämpas: bokstäverna ska antingen vara identiska eller öka i alfabetisk ordning. - På diagonalen, som sträcker sig från det övre vänstra hörnet till det nedre högra hörnet, gäller samma regel.

Ett exempel på ett korrekt facit till ett Nissedoku som är ordnat i en lista kan se ut så här: d, p, x, d, h, z, l, l, t. När detta arrangeras i en 3x3 kvadrat ser det ut så här:

d p x
d h z
l l t

- Den första horisontella raden blir: d, p, x
- Den första vertikala kolumnen blir: d, d, l
- Diagonalen blir: d, h, t

Sigrid hade ordnat alla facit till alla Nissedoku i en lång lista. Hur många facit var felaktiga?
 *  Svar: 8
*/
Stopwatch sw = Stopwatch.StartNew();
int totalfaketickets = 0;

using (var fileStream = File.OpenRead("..\\..\\..\\input.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
{
    sw.Start();
    string line;
    while ((line = streamReader.ReadLine()) != null)
    {
        List<List<char>> chars = new List<List<char>>();
        List<char> temp = new List<char>();
        int letterint = 0;
        foreach (char c in line)
        {
            if (char.IsLetter(c))
            {
                letterint++;
                temp.Add(c);

                if (letterint % 3 == 0)
                {
                    chars.Add(temp.ToList());
                    temp.Clear();
                }
            }
        }
        int faketicket = 0;

        for (int i = 0; i < 2; i++)
        {
            if (chars[0][i] > chars[0][i+1])
            {
                faketicket++;
                Console.WriteLine("1 :" +chars[0][i] + " " + chars[0][i + 1]);
            }
        }
        for (int i = 0; i < 2; i++)
        {
            if (chars[i][0] > chars[i + 1][0])
            {
                faketicket++;
                Console.WriteLine("2 :" + chars[i][0] + " " + chars[i+1][0]);

            }
        }
        for (int i = 0; i < 2; i++)
        {
            if (chars[i][i] > chars[i + 1][i + 1])
            {
                faketicket++;
                Console.WriteLine("3 :" + chars[i][i] + " " + chars[i +1][i + 1]);
            }
        }

        if (faketicket > 0)
        {
            totalfaketickets++;
        }/*
        foreach (var c in chars)
        {
            foreach (char ch in c)
            {
                Console.Write(ch + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();*/

    }
}

Console.WriteLine(totalfaketickets + "st " + sw.Elapsed);