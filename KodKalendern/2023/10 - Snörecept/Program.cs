using System.Diagnostics;
using System.Text;
using System.Linq;

Stopwatch sw = Stopwatch.StartNew();

List<string> list = new List<string>();

using (var fileStream = File.OpenRead("text.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128)) //real answer 1602 D:
{
    sw.Start();
    string line;
    while ((line = streamReader.ReadLine()) != null)
    {
        string word = "";
        string shorterline = line.Substring(0,line.Length-1);
        foreach (char c in shorterline)
        {
            if (char.IsLetter(c))
            {
                word += c;
            }
        }
       if (word.Length == 8)
        {
            list.Add(line);
        }

     
    }
}
foreach (string line in list)
{
    Console.WriteLine(line);
}