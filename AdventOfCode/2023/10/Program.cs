using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Numerics;

Stopwatch sw = Stopwatch.StartNew();

List<string> list = new List<string>();
char[,] chars = new char[150, 150];
char[,] pipes = new char[150, 150];

Vector2 startPosition = new Vector2(0, 0);
Vector2 currentPosition = new Vector2(0, 0);
Vector2 previousPosition = new Vector2(0, 0);

using (var fileStream = File.OpenRead("text.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128)) //real answer 1602 D:
{
    sw.Start();
    string line;
    int y = 0;
    while ((line = streamReader.ReadLine()) != null)
    {
        int x = 0;
        foreach (char c in line)
        {
            if (c == 'S')
            {
                pipes[x, y] = c;
                startPosition = new Vector2(x, y);
                currentPosition = new Vector2(x, y);
            }
            else
            {
                pipes[x, y] = '.';
            }
            chars[x, y] = c;
            x++;
        }
        y++;
    }
}
bool raweda = true;
int steps = 0;
while (raweda)
{
    int x = (int)currentPosition.X;
    int y = (int)currentPosition.Y;

    if (HasCaracterBeside(x, y, chars))
    {
        steps++;
    }
    //Console.WriteLine(currentPosition + "\t" + steps);
    if (currentPosition == startPosition)
    {
        break;
    }
}
/*
for (int i = 0; i < chars.GetLength(1); i++)
{
    for (int j = 0; j < chars.GetLength(0); j++)
    {
        if (pipes[j,i] == 0)
        {
            Console.Write(".");
        }
        else
        {
            Console.Write(pipes[j, i] + "  ");
        }
    }
    Console.WriteLine();
}*/
bool HasCaracterBeside(int x, int y, char[,] puzzleInput)
{
    if (puzzleInput[x, y] == 'S')
    {
        if (x - 1 != previousPosition.X) //is hardkoded to be a J, yee
        {
            previousPosition = currentPosition;

            currentPosition = previousPosition + new Vector2(-1, 0);
        }
        else if (y - 1 != previousPosition.Y)
        {
            previousPosition = currentPosition;

            currentPosition = previousPosition + new Vector2(0, -1);
        }
        
        return true;
    }
    else if (puzzleInput[x, y] == '|')
    {
        if (y - 1 != previousPosition.Y)
        {
            previousPosition = currentPosition;

            currentPosition = previousPosition + new Vector2(0, -1);
        }
        else if (y + 1 != previousPosition.Y)
        {
            previousPosition = currentPosition;

            currentPosition = previousPosition + new Vector2(0, 1);
        }
        return true;
    }
    else if (puzzleInput[x, y] == '-')
    {
        if (x - 1 != previousPosition.X)
        {
            previousPosition = currentPosition;

            currentPosition = previousPosition + new Vector2(-1, 0);
        }
        else if (x + 1 != previousPosition.X)
        {
            previousPosition = currentPosition;

            currentPosition = previousPosition + new Vector2(1, 0);
        }
        return true;
    }
    else if (puzzleInput[x, y] == 'L')
    {
        if (y - 1 != previousPosition.Y)
        {
            previousPosition = currentPosition;

            currentPosition = previousPosition + new Vector2(0, -1);
        }
        else if (x + 1 != previousPosition.X)
        {
            previousPosition = currentPosition;

            currentPosition = previousPosition + new Vector2(1, 0);
        }
        return true;
    }
    else if (puzzleInput[x, y] == 'J')
    {
        if (x - 1 != previousPosition.X)
        {
            previousPosition = currentPosition;

            currentPosition = previousPosition + new Vector2(-1, 0);
        }
        else if (y - 1 != previousPosition.Y)
        {
            previousPosition = currentPosition;

            currentPosition = previousPosition + new Vector2(0, -1);
        }
        return true;
    }
    else if (puzzleInput[x, y] == '7')
    {
        if (y + 1 != previousPosition.Y)
        {
            previousPosition = currentPosition;

            currentPosition = previousPosition + new Vector2(0, 1);
        }
        else if (x - 1 != previousPosition.X)
        {
            previousPosition = currentPosition;

            currentPosition = previousPosition + new Vector2(-1, 0);
        }
        return true;
    }
    else if (puzzleInput[x, y] == 'F')
    {
        if (y + 1 != previousPosition.Y)
        {
            previousPosition = currentPosition;

            currentPosition = previousPosition + new Vector2(0, 1);
        }
        else if (x + 1 != previousPosition.X)
        {
            previousPosition = currentPosition;

            currentPosition = previousPosition + new Vector2(1, 0);
        }
        return true;
    }

    return false;
}

Console.WriteLine((steps / 2).ToString()); //6942

