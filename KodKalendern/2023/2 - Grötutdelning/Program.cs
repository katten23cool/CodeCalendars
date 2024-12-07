using System.Text;
/*
    *På den glittrande, snötäckta Nordpolen, vaknar tomtebyn upp den 2:a december. Här är det en älskad tradition för Nissarna att dela ut den årliga julegröten till alla i byn. 
    *I år hade den omtänksamma Nissen Elsa äran att dela ut gröten i 1000 tunnor.

    Allt verkade gå som på räls, tunnorna var redo och köket doftade av kanel. Men när tiden för grötutdelningen närmade sig, upptäckte Nissarna något som skickade en våg av oro genom tomtebyn. 
    Medan de rutinmässigt vägde varje tunna för att säkerställa rättvisa portioner, insåg de att grötmängden i tunnorna var ojämnt fördelad. 
    Vissa tunnor var så fulla att locket knappt gick att stänga, medan andra var så lätta att de kunde bäras med en hand.

    "Det här går inte," utbrast Elsa, "vi kan inte ha så här stor skillnad i portionerna. Alla förtjänar en rättvis mängd julegröt!"

    Nissarna har vägt tunnorna i viktenheten “Uns”, där 1 Uns motsvarar 28 gram. Idealiskt skulle varje tunna innehålla mellan 2000 och 3000 gram julegröt.

    Hur många tunnor innehåller mellan 2000 och 3000 gram julegröt?
    
    Svar: 132
*/
int unsToGram = 28;

int braTunnor = 0;

const Int32 BufferSize = 128;
using (var fileStream = File.OpenRead("text.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
{
    String line;
    while ((line = streamReader.ReadLine()) != null)
    {
        int Uns = Convert.ToInt32(line);

        int GramAmount = Uns * unsToGram;
        if (GramAmount >= 2000 && GramAmount <= 3000)
        {
            braTunnor++;
        }
    }
    Console.WriteLine("Godkända tunnor : " + braTunnor.ToString());
}