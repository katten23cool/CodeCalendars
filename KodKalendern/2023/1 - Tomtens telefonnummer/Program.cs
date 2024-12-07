using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    /*
     *  Lucka 1 - Tomtens telefonnummer
        Det var en krispig vintermorgon den första december. Snön låg som ett tjockt, fluffigt täcke över hela Nordpolen, och stjärnorna glittrade som små diamanter på den mörka himlen. 
        Nissarna, klädda i sina färgglada kläder och med rosiga kinder från den kyliga luften, skuttade glatt mot tomteverkstaden. 
        Det var äntligen dags att börja förberedelserna inför julen, den mest spännande tiden på året!

        Nissarna hade sett fram emot denna dag i månader. De hade planerat, drömt och pratat om alla leksaker och presenter de skulle skapa. 
        Men när de nådde fram till verkstaden, möttes de av något mycket oväntat – dörren till verkstaden var låst! Detta hade aldrig hänt förut. 
        Verkstaden, ett ställe fullt av glädje och skratt, stod nu tyst och otillgänglig framför dem.

        "Låt oss ringa Tomten" föreslog ena nissen. Men nissar sparar inte sina telefonnummer i sin telefon som vi vanliga människor gör. 
        Istället minns de telefonnummer med hjälp av enkla minnesregler.

        Minnesregeln för tomtens telefonnummer är följande:

        Beräkna summan av alla tal mellan 127 och 267 (inklusive både 127 och 267) adderat med summan av alla tal mellan 1110 och 1378 (inklusive både 1110 och 1378) 
        adderat med summan av alla tal mellan 3239293 och 3239330 (inklusive både 3239293 och 3239330).

        Vad är tomtens telefonnummer?
        Svar: 123456250
     */
    internal class Program
    {
        
        static void Main(string[] args)
        {
            int TotalNum = 0;
            for (int startNum = 127; startNum <= 267; startNum++)
            {
                TotalNum += startNum;
            }
            for (int startNum = 1110; startNum <= 1378; startNum++)
            {
                TotalNum += startNum;
            }
            for (int startNum = 3239293; startNum <= 3239330; startNum++)
            {
                TotalNum += startNum;
            }

            Console.WriteLine(TotalNum.ToString());
            while (true) ;
        }
    }
}
