using System.Text;

int totalSum = 0;
int totalSum2 = 0;
int lineint = 0;

int maxred = 12;
int maxgreen = 13;
int maxblue = 14;

const Int32 BufferSize = 128;
using (var fileStream = File.OpenRead("text.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
{
    String line;
    while ((line = streamReader.ReadLine()) != null)
    {
        lineint++;
        int amountred = 0;
        int amountgreen = 0;
        int amountblue = 0;
        while (true)
        {
            int amountred1 = 0;
            int amountgreen1 = 0;
            int amountblue1 = 0;
            string game;
            if (line.Contains(";"))
            {
                game = line.Substring(line.LastIndexOf(";") + 2);
            }
            else
            {
                game = line.Substring(line.LastIndexOf(":") + 2);
            }

            string word = "";
            string amount = "";
            bool startword = false;
            foreach (char c in game)
            {
                if (IfInt(c))
                {
                    amount += c;
                }
                if (startword)
                {
                    word += c;
                }
                if (c.ToString() == " " && c.ToString() != ",")
                {
                    word = "";
                    startword = true;
                    continue;
                }
                if (word == "blue")
                {
                    amountblue1 += Convert.ToInt32(amount);
                    startword = false;
                    amount = "";
                    word = "";
                }
                if (word == "red")
                {
                    amountred1 += Convert.ToInt32(amount);
                    startword = false;
                    amount = "";
                    word = "";
                }
                if (word == "green")
                {
                    amountgreen1 += Convert.ToInt32(amount);
                    startword = false;
                    amount = "";
                    word = "";
                }
            }

            if (amountblue1 > amountblue)
            {
                amountblue = amountblue1;
            }
            if (amountred1 > amountred)
            {
                amountred = amountred1;
            }
            if (amountgreen1 > amountgreen)
            {
                amountgreen = amountgreen1;
            }
            if (line.Contains(";"))
            {
                line = line.Remove(line.LastIndexOf(";"));
            }
            else
            {
                break;
            }
        }
        //part 1
        if (amountred <= maxred && amountblue <= maxblue && amountgreen <= maxgreen)
        {
            totalSum += lineint;
        }
        //part 2
        totalSum2 += amountred * amountgreen * amountblue;
    }
    Console.WriteLine("Del 1 : " + totalSum);
    Console.WriteLine("Del 2 : " + totalSum2);
}
static bool IfInt(char cha)
{
    String str = cha.ToString();
    bool isnumeric = int.TryParse(str, out int hell);

    return isnumeric;
}