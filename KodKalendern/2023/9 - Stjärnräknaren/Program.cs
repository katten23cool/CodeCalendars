using System;
using System.Diagnostics;
using System.Text;

Stopwatch sw = Stopwatch.StartNew();

int stars = 0;

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
            if (HasSpecialChars(c.ToString()))
            {
                word += c.ToString();
            }
            else
            {
                Console.WriteLine(word);
                int hi = 0;
                foreach (char ch in word) 
                { 
                    if (ch == '*')
                    { 
                        hi++;
                    }
                }
                if (hi == word.Length && word != string.Empty)
                {
                    foreach (char ch in word)
                    {

                        stars++;
                        Console.WriteLine(ch);
                    }

                }

                word = "";
            }
            
        }
        if (word == "*")
        {
            stars++;
        }
    }
}
static bool HasSpecialChars(string yourSring)
{
    if (yourSring.Any(ch => !char.IsLetterOrDigit(ch) && yourSring != "-"))
    {
        return true;
    }
    else
    {
        return false;
    }

}
Console.WriteLine(stars + " : " + sw);