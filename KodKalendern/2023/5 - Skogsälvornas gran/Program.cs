using System.Text;

int mark = 0;
int ore = 0;
int ortug = 0;
int penning = 0;

int plangbocker = 0;


var filestream = File.OpenRead("text.txt");
using (var streamreader = new StreamReader(filestream, Encoding.UTF8, true, 128))
{
    string line;
    while ((line = streamreader.ReadLine()) != null)
    {
        int totalline = 0;
        string rawr = line;
        for (int i = 0; i < 4; i++)
        {
            string stri = rawr;
            if (rawr.Contains(","))
            {
                stri = rawr.Substring(rawr.LastIndexOf(",") +2);
                rawr = rawr.Remove(rawr.LastIndexOf(","));
            }
            if (i == 0)
            {
                penning = Convert.ToInt32(stri);
            }
            else if (i == 1)
            {
                ortug = Convert.ToInt32(stri);

            }
            else if (i == 2)
            {
                ore = Convert.ToInt32(stri);

            }
            else if (i == 3)
            {
                mark = Convert.ToInt32(stri);
            }
        }
        totalline += mark * 192;
        totalline += ore * 24;
        totalline += ortug * 8;
        totalline += penning;

        if (totalline >= 1000)
        {
            plangbocker++;
        }
    }
    Console.WriteLine(plangbocker);
}