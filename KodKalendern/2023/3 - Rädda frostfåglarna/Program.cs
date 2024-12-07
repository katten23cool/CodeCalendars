// See https://var filestream = File.OpenRead("text.txt");
using System.Collections.Generic;
using System.Text;

int average = 0;
int total = 0;
int amount = 0;

var file = File.OpenRead("text.txt");
using (var streamreader = new StreamReader(file, Encoding.UTF8, true, 128))
{
    string line;
    while ((line = streamreader.ReadLine()) != null)
    {
        average++;
        Console.WriteLine(average.ToString());

        total += Convert.ToInt32(line);
    }
}
var filestrewam = File.OpenRead("text.txt");
int divide = total / average;

using (var streamreaders = new StreamReader(filestrewam, Encoding.UTF8, true, 128))
{
    string line;
    while ((line = streamreaders.ReadLine()) != null)
    { 
        if (Convert.ToInt32(line) == divide)
        {
            amount++;
        }
    }
}
Console.WriteLine(amount.ToString());