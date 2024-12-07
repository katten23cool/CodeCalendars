using System.Diagnostics;
using System.Text;

Stopwatch sw = Stopwatch.StartNew();

List<string> list = new List<string>();

using (var fileStream = File.OpenRead("text.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128)) //real answer 1602 D:
{
    sw.Start();
    string line;
    while ((line = streamReader.ReadLine()) != null)
    {
        int x = 0;
        foreach (char c in line)
        {
          
        }
    }
}