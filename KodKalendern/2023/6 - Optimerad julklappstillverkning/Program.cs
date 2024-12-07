using System;
using System.Diagnostics;
using System.Text;

Stopwatch sw = Stopwatch.StartNew();

int julklappartotalt = 0;
int personersomonskar = 0;

using (var fileStream = File.OpenRead("text.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
{
    sw.Start();
    string line;
    while ((line = streamReader.ReadLine()) != null)
    {
        while (line.Contains(" "))
        {
            string tempLine = line;
            tempLine = tempLine.Substring(tempLine.LastIndexOf(" "));
            line = line.Remove(line.LastIndexOf(" "));
            line = line.TrimEnd();
            tempLine = tempLine.Trim();
            julklappartotalt += Convert.ToInt32(tempLine);
        }
        personersomonskar++;
    }
}
Console.WriteLine(julklappartotalt + " : " + sw);