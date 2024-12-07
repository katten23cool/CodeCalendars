using System.Diagnostics;
using System.Text;
using System.Linq;

Stopwatch sw = Stopwatch.StartNew();

Dictionary<string, int> list = new Dictionary<string, int>();
Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();


using (var fileStream = File.OpenRead("text.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128)) //real answer 1602 D:
{
    sw.Start();
    string line;
    while ((line = streamReader.ReadLine()) != null)
    {
        string word = "";
        foreach (char c in line)
        {
            if (char.IsLetter(c))
            {
                word += c;
            }
        }
        if (!list.ContainsKey(word))
        {
            list.Add(word, 1);
            keyValuePairs.Add(word, line);
        }
        else
        {
            list[word]++;
        }
        


    }
}
foreach (var word in list)
{
    if (word.Value == 1)
    {
        Console.WriteLine(word.Key);
        Console.WriteLine(keyValuePairs[word.Key]);
    }
  
}