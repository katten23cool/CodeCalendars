using System.Text;

char oRock = 'A';
char oPaper = 'B';
char oScissors = 'C';

string oMove = "";

char Rock = 'X';
char Paper = 'Y';
char Scissors = 'Z';

int IRock = 1;
int IPaper = 2;
int IScissors = 3;

int Points = 0;

string move = "";

const Int32 BufferSize = 128;
using (var fileStream = File.OpenRead("text.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
{
    String line;
    while ((line = streamReader.ReadLine()) != null)
    { 
        foreach (char c in line)
        {
            if (c == oRock || c == Rock)
            {
                if (c == oRock)
                {
                    oMove = "Rock";
                }
                else
                {
                    move = "Rock";
                }
            }
            else if (c == Paper || c == oPaper)
            {
                if (c == oPaper)
                {
                    oMove = "Paper";
                }
                else
                {
                    move = "Paper";
                }
            }
            else if (c == Scissors || c == oScissors)
            {
                if (c == oScissors)
                {
                    oMove = "Scissors";
                }
                else
                {
                    move = "Scissors";
                }
            }

        }
        if (oMove != move)
        {
            if(oMove == "Scissors" && move == "Rock")
            {
                Points += 6 + IRock;
            }
            else if (move == "Rock" && oMove == "Paper")
            {
                Points += 0 + IRock;
            }

            if (oMove == "Rock" && move == "Paper")
            {
                Points += 6 + IPaper;
            }
            else if (move == "Paper" && oMove == "Scissors")
            {
                Points += 0 + IPaper;
            }

            if (oMove == "Paper" && move == "Scissors")
            {
                Points += 6 + IScissors;
            }
            else if (move == "Scissors" && oMove == "Rock")
            {
                Points += 0 + IScissors;
            } 
        }
        else
        {
            if (move == "Paper")
            {
                Points += 3 + IPaper;
            }
            if (move == "Rock")
            {
                Points += 3 + IRock;
            }
            if (move == "Scissors")
            {
                Points += 3 + IScissors;
            }

        }
    }
    Console.WriteLine(Points.ToString());
}
