using System.Text;

int arrarn = 0;
int[] numbers = new int[1000];

var filestream = File.OpenRead("text.txt");
using (var streamreader = new StreamReader(filestream, Encoding.UTF8, true, 128))
{
    string line;
    while ((line = streamreader.ReadLine()) != null)
    {
        int lineint = Convert.ToInt32(line);
        numbers[arrarn] = lineint;
        arrarn++;
    }
    var nearest = numbers.MinBy(x => Math.Abs((long)x - 106023));

    Console.WriteLine(nearest);

}