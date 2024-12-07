using System.Diagnostics;
using System.Linq;
using System.Text;

/*På nordpolen stod tomten och blickade oroligt mot den klarblå himlen. Snön, som brukade falla rikligt under denna tid på året, var märkligt frånvarande. 
 * Tomtebyn var beroende av snö för sin snöenergi, en ren och hållbar kraftkälla som drev allt från julgransljus till KlappMaker3000 i verkstaden.
 * 
 * För att förstå detta klimatiska mysterium, konsulterade tomten nissen Elmira, ledande meteorolog på Nordpolens Meteorologiska och Hydrologiska institut (NMHI). 
 * Elmira plockade fram NMHIs noggrant insamlade data. Denna data innehöll mätningar av antalet snöflingor som samlats i institutets snömätare varje morgon mellan den 1:a och 15:e december under de senaste 250 åren.
 * 
 * Med en djup suck lutade tomten sig över Elmiras skrivbord. Där låg svaren. Men det krävdes en skicklig beräkning för att tolka mönstren och förstå vad som egentligen hände med snön. Var det en naturlig variation, eller något mer oroande?

Tomten menade att det fanns en “regel” som sade att det för varje dag i december skulle falla mer snö än dagen innan. Dessutom skulle ökningen av snöflingor från en dag till nästa alltid vara större än ökningen dagen innan.

Exempelvis: Om det fallit 0 snöflingor dag 1 och 15 snöflingor dag 2, så skulle det falla fler än 30 snöflingor dag 3 (eftersom skillnaden mellan dag 1 och dag 2 var 15 snöflingor, och ökningen till nästkommande dag alltid skulle var större). Om det på dag 3 föll 31 snöflingor så skulle det falla fler än 47 snöflingor på dag 4 (eftersom ökningen mellan dag 2 och 3 var 16).

Elmira menade att det var fullt normalt att snöfallet skiljde sig mellan dagarna i december.

Hur många år skilde sig snöfallet från tomtens “regel”?
 *  Svar: 10
*/

Stopwatch sw = Stopwatch.StartNew();
int years = 0;

using (var fileStream = File.OpenRead("..\\..\\..\\input.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
{
    sw.Start();
    string line;
    while ((line = streamReader.ReadLine()) != null)
    {
        years++;
        List<int> flingor = new List<int>();
        string templine = line;
        while (templine.Contains(","))
        {
            string year = templine.Substring(templine.LastIndexOf(',') + 2);
            templine = templine.Remove(templine.LastIndexOf(','));
            flingor.Add(Convert.ToInt32(year));
        }
        flingor.Add(Convert.ToInt32(templine));
        flingor.Reverse();
        
        int lastflinga = 0;
        int difference = 0;
        foreach (int i in flingor)
        {
            if (i >= lastflinga + difference)
            {
                difference = i - lastflinga;
                lastflinga = i;
                //Console.WriteLine($"{i}\t{lastflinga} \t{difference}");
            }
            else
            {
                //Console.WriteLine($"{i}\t{lastflinga} \t{difference}");
                Console.WriteLine(years);
                break;
            }
        }


    }
}

Console.WriteLine("" + sw.Elapsed);