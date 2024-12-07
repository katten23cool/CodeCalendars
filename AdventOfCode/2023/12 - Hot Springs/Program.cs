using System.Diagnostics;
using System.Linq;
using System.Text;

/*
 *  Svar: 
*/
Stopwatch sw = Stopwatch.StartNew();
using (var fileStream = File.OpenRead("..\\..\\..\\input.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
{
    sw.Start();
    string line;
    while ((line = streamReader.ReadLine()) != null)
    {

    }
}

Console.WriteLine("" + sw.Elapsed);