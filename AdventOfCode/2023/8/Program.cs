using System.Diagnostics;
using System.Text;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

Stopwatch sw = Stopwatch.StartNew();

List<List<String>> cordinates = new List<List<String>>();
List<char> instructions = new List<char>();
bool getinstructions = true;

using (var fileStream = File.OpenRead("text.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
{
    sw.Start();
    string line;
    while ((line = streamReader.ReadLine()) != null)
    {
        if (getinstructions)
        {
            foreach (char c in line)
            {
                instructions.Add(c);
            }
            getinstructions = false;
        }
        else
        {
            List<string> tempList = new List<string>();
            string word = "";
            foreach (char c in line)
            {
                if (char.IsLetterOrDigit(c))
                {
                    word += c.ToString();
                }
                else
                {
                    if (word != string.Empty)
                    {
                        tempList.Add(word);
                    }
                    word = string.Empty;
                }
            }
            if (word != string.Empty)
            {
                tempList.Add(word);
            }
            cordinates.Add(tempList);
        }
    }
}
Console.WriteLine("Reading Lines Done :" + sw);
cordinates.RemoveAt(0);//hmmmmmmmmm

int totalthing = 0;

string helluu = "AAA";
List<string> strings = new List<string>();
List<string> temporary = new List<string>();
List<int> numbers = new List<int>();

bool foundAnswer = false;
foreach (List<string> str in cordinates)
{
    char cha = Convert.ToChar(str[0].Substring(2));

    if (cha == 'A')
    {
        //Console.WriteLine(cha + "\t" + str[0] + "\t");

        strings.Add(str[0]);
        //Console.WriteLine(str[0] + $" {0} \t");
    }
}
while (!foundAnswer)
{
    for (int c = 0; c < instructions.Count; c++)
    {
        if (1 == 2)
        {
            int first = 1;
            if (instructions[c] != 'L')
            {
                first = 2;
            }
            string hello = FindCordinates(helluu, first);
            if (hello == "ZZZ")
            {
                foundAnswer = true;
            }
            else
            {
                helluu = hello;
            }
        }
        else
        {
            int first = 1;
            if (instructions[c] != 'L')
            {
                first = 2;
            }
            string hello = FindCordinatesList(first);

            long raa = 0;
            for (int s = 0; s < strings.Count; s++)
            {
                if (Convert.ToChar(strings[s][2]) == 'Z')
                {
                    Console.Write(strings[s] + "\t");
                    numbers.Add(totalthing);
                    strings.RemoveAt(s);
                }
            }
            if (raa == strings.Count)
            {
                Console.WriteLine();
                foundAnswer = true;
            }
        }
    }
}

string FindCordinates(string strs, int i) //part 1
{
    foreach (List<string> str in cordinates)
    {
        if (str[0] == strs) // AAA == AAA
        {
            totalthing++;
            string brah = str[i]; // AAA - BBB - CCC
            //Console.WriteLine(brah);
            return brah;
        }
    }
    return "";
}

string FindCordinatesList(int lf)
{
    if (strings.Count > 0)
    {
        foreach (string str in strings)
        {
            for (int i = 0; i < cordinates.Count; i++)
            {
                if (cordinates[i][0] == str)
                {
                    temporary.Add(cordinates[i][lf]);
                    //Console.WriteLine(str + $"\t{cordinates[i][1]}\t{cordinates[i][2]}\t{lf}");
                    break;
                }
            }
        }
        /*Console.WriteLine();
    foreach (var i in temporary)
    {
        Console.WriteLine(i);
    }*/
        strings = temporary.ToList();
        temporary.Clear(); 
        totalthing++;
       
    }
    else
    {
    }
    return "";
}

foreach (long i in numbers)
{
    Console.WriteLine(i + "\t");
}/*
List<long> numbers2 = numbers.ToList();
bool iDidIt = false;
int ntaa = 0;
while (!iDidIt)
{
    for (int i = 0;i < numbers.Count; i++)
    {
        long maxValue = GetMaxValue(numbers2);
        if (AllElemetsSame(numbers2))
        {
            iDidIt = true;
            break;
        }
        else
        {
            if (numbers2[i] < maxValue)
            {
                numbers2[i] += numbers[i];
            }
        }
    }
    ntaa++;
    if (ntaa % 10000000 == 0)
    {
        foreach (long i in numbers2)
        {
            Console.Write(i + "\t");
        }
        Console.WriteLine(ntaa + " " + sw);
        Console.WriteLine();
    }
    
}
*/


bool AllElemetsSame(List<long> list)
{
    long same = list[0];
    long amount = 0;
    foreach (long i in list)
    {
        if(i == same)
        {
            amount++;
        }
    }
    if (amount == list.Count)
    {
        return true;
    }
    else
    {
        return false;
    }
}

long GetMaxValue(List<long> list)
{
    long max = 0;
    foreach (long i in list)
    {
         if (max < i)
        {
            max = i;
        }
    }
    return max;
}

//Console.WriteLine(totalthing + " " + sw);
Console.WriteLine(FindMeetingPosition(numbers) + " " + sw);


 int FindMeetingPosition(List<int> numbers)
{
    // Ensure the list is not empty
    if (numbers.Count == 0)
    {
        return 0; // or handle as appropriate for your case
    }

    int lcm = LCM(numbers);

    return lcm;
}

static int GCD(int a, int b)
{
    while (b != 0)
    {
        int temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}

 int LCMI(int a, int b)
{
    return (a * b) / GCD(a, b);
}

 int LCM(List<int> numbers)
{
    // Calculate the LCM of all numbers in the list
    return numbers.Aggregate(1, (currentLCM, number) => LCMI(currentLCM, number));
}