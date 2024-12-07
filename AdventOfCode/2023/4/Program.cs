using System.Text;

int totalSum = 0;

string number = "";
int cardNum = 0;
int cardTotalSum = 0;

List<int> cardList = new List<int>();

for (int i = 0; i < 203; i++)
{
    cardList.Add(0);
}

var filestream = File.OpenRead("text.txt");
using (var streamreader = new StreamReader(filestream, Encoding.UTF8, true, 128))
{
    string line;
    while ((line = streamreader.ReadLine()) != null)
    {
        List<string> winningNums = new List<string>();
        List<string> Nums = new List<string>();
        bool numbs = false;
        cardNum++;
        string lines = line.Substring(line.IndexOf(":"));
        foreach (char c in lines)
        {
            if (!numbs)
            {
                if (c != '|')
                {
                    if (IsInt(c))
                    {
                        number += c.ToString();
                    }
                    else
                    {
                        if (number.Length > 0 && number != " ")
                        {
                            winningNums.Add(number);
                        }
                        number = "";
                    }
                }
                else
                {
                    numbs = true;
                }
                
            }
            else
            {
                if (IsInt(c))
                {
                    number += c.ToString();
                }
                else
                {
                    if (number.Length > 0 && number != " ")
                    {
                        Nums.Add(number);
                    }
                    number = "";
                }
            }
        }
        if (number.Length > 0 && number != " ")
        {
            Nums.Add(number);
        }
        number = "";
        int local = 0;
        int timesWon = 0;
        foreach (string wins in winningNums)
        {
            foreach (string num in Nums)
            {
                if (wins == num)
                {
                    if (local == 0)
                    {
                        local = 1;
                    }
                    else
                    {
                        local *= 2;
                    }
                    timesWon++;
                }
            }
        }
        cardList[cardNum - 1] += 1;
        for (int l = 0; l < cardList[cardNum - 1]; l++)
        {
            for (int i = cardNum; i < timesWon + cardNum; i++)
            { 
                cardList[i] += 1;
            }
        }
        totalSum += local;
    }
    int j = 0;
    foreach(int i in cardList)
    {
        cardTotalSum += Convert.ToInt32(i);
        Console.WriteLine(j+": "+i);
        j++;
        
    }

    Console.WriteLine(totalSum); 
    Console.WriteLine(cardTotalSum);

}

bool IsInt(char cha)
{
    String str = cha.ToString();
    bool isnumeric = int.TryParse(str, out int hell);

    return isnumeric;
}
