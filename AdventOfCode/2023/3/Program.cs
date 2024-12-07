using System.Collections.Specialized;
using System.Numerics;
using System.Text;


string partNumber = "";
int linenum = 0;

int lineposition = 0;

int totalsum = 0;
int x = 0;
int y = 0;

string[,] puzzleInput = new string[1000,1000];

List<Vector2> gearpositi = new List<Vector2>();

List<int> gearvalue1 = new List<int>();

int gearvalue2 = 0;
int geartotal = 0;



var filestream = File.OpenRead("text.txt");
using (var streamreader = new StreamReader(filestream, Encoding.UTF8, true, 128))
{
    string line;
    while ((line = streamreader.ReadLine()) != null)
    {
        x = 0;
        foreach (char c in line)
        {
            puzzleInput[x, y] = c.ToString();
            x++;
        }
        y++;
    }
}
var filestrewam = File.OpenRead("text.txt");

using (var streamreaders = new StreamReader(filestrewam, Encoding.UTF8, true, 128))
{
    string line;
    while ((line = streamreaders.ReadLine()) != null)
    {
        lineposition = -1;
        foreach (char c in line)
        {
            if (IsInt(c) && !HasSpecialChars(c.ToString()))
            {
                partNumber += c.ToString();
            }
            else
            {
                if (HasCaracterBeside(partNumber,linenum, lineposition, puzzleInput) && partNumber != "")
                {
                    int number = Convert.ToInt32(partNumber);
                    totalsum += number; 
                }
                partNumber = "";
            }
            lineposition++;
        }
        if (HasCaracterBeside(partNumber, linenum, lineposition, puzzleInput) && partNumber != string.Empty)
        {
            totalsum += Convert.ToInt32(partNumber);
        }
        linenum++;
    }
    Console.WriteLine(totalsum.ToString());
    Console.WriteLine(geartotal.ToString());
}
static bool IsInt(char cha)
{
    String str = cha.ToString();
    bool isnumeric = int.TryParse(str, out int hell);

    return isnumeric;
}
static bool HasSpecialChars(string yourSring)
{
    if (yourSring.Any(ch => !char.IsLetterOrDigit(ch) && yourSring != "."))
    {
        return true;
    }
    else
    {
        return false;
    }

}

 bool HasCaracterBeside(string yourString, int y, int x, string[,] puzzleInput)
{
    List<(int X, int Y)> neighbors =
    [
        (-1, -1),(0, -1),(1, -1),
        (-1, 0),         (1, 0),
        (-1, 1), (0, 1), (1, 1),
    ];
    for (int i = 0; i < yourString.Length; i++)
    {
        foreach ((int xx, int yy) in neighbors)
        {
            try
            {
                if (puzzleInput[x - i + xx, y + yy] == "*")
                {
                    int num = 0;
                    if (!gearpositi.Contains(new Vector2(x - i + xx, y + yy)))
                    {
                        gearvalue1.Add(Convert.ToInt32(yourString));
                        gearpositi.Add(new Vector2(x - i + xx, y + yy));
                    }
                    else
                    {
                        foreach (Vector2 vector in gearpositi)
                        {
                            if(vector == new Vector2(x - i + xx, y + yy))
                            {
                                break;
                            }
                            num++;
                        }
                        gearvalue2 = Convert.ToInt32(yourString);
                        geartotal += gearvalue1[num] * gearvalue2;
                    }
                    Console.WriteLine(gearvalue1[num] + " " + gearvalue2);
                }
            }
            catch
            {

            }
        }
        foreach ((int xy, int yx) in neighbors)
        {
            int xcord = xy;
            int ycord = yx;
            try
            {
                if (HasSpecialChars(puzzleInput[x - i + xcord, y + ycord]))
                {
                    return true;
                }
            }
            catch (Exception e)
            {
            }
        }
    }
    return false;
}