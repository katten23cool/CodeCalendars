using System;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Timers;

Stopwatch sw = Stopwatch.StartNew();

int totalwinnings = 0;

List<int> winningnums = new List<int>();
List<List<int>> cards_five = new List<List<int>>();
List<List<int>> cards_four = new List<List<int>>();
List<List<int>> cards_house = new List<List<int>>();
List<List<int>> cards_three = new List<List<int>>();
List<List<int>> cards_two = new List<List<int>>();
List<List<int>> cards_one = new List<List<int>>();
List<List<int>> cards_high = new List<List<int>>();


using (var fileStream = File.OpenRead("text.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
{
    sw.Start();
    string line;
    while ((line = streamReader.ReadLine()) != null)
    {
        List<int> tempList = new List<int>();
        string tempWinnings = "";
        bool winnings = false;
        foreach (char c in line)
        {
            if (c == ' ' || winnings)
            {
                if (IsInt(c) && winnings)
                {
                    tempWinnings += c.ToString();
                }
                winnings = true;
            }
            else
            {
                if (IsInt(c))
                {
                    tempList.Add(Convert.ToInt32(c.ToString()));
                }
                else if (c == 'A')
                {
                    tempList.Add(14);
                }
                else if (c == 'K')
                {
                    tempList.Add(13);
                }
                else if (c == 'Q')
                {
                    tempList.Add(12);
                }
                else if (c == 'J') //should be 11 if part1 
                {
                    tempList.Add(1);
                }
                else if (c == 'T')
                {
                    tempList.Add(10);
                }
            }
        }
        Dictionary<int, int> tempValues = new Dictionary<int, int>();
        for (int i = 0; i < tempList.Count; i++)
        {
            if (tempValues.ContainsKey(tempList[i]))
            {
                tempValues[tempList[i]]++;
            }
            else
            {
                tempValues.Add(tempList[i], 1);
            }
        }
        int jokers = 0;
        int temp_two = 0;
        int temp_three = 0;
        int temp_four = 0;
        int temp_five = 0;
        foreach (var values in tempValues)
        {
           
            if (values.Value == 2)
            {
                temp_two++;
            }
            else if (values.Value == 3) //one problem might be that the jokers that it no 2parts
            {
                temp_three++;
            }
            else if (values.Value == 4)
            {
                temp_four++;
            }
            else if (values.Value == 5)
            {
                temp_five++;
            }
            if (values.Key == 1)
            {
                jokers = values.Value;
            }
        }
        tempList.Add(Convert.ToInt32(tempWinnings));
        if (temp_five == 1 || jokers == 5)
        {
            cards_five.Add(tempList);
        }
        else if (temp_four == 1)
        {
            if (jokers == 1)
            {
                cards_five.Add(tempList);
            }
            else
            {
                cards_four.Add(tempList);
            }
        }
        else if (temp_two == 1 && temp_three == 1)
        {
            if (jokers == 2 || jokers == 3)
            {
                cards_five.Add(tempList);
            }
            else
            {
                cards_house.Add(tempList);
            }
        }
        else if (temp_three == 1)
        {
            if (jokers == 2)
            {
                cards_five.Add(tempList);
            }
            else if (jokers == 1)
            {
                cards_four.Add(tempList);
            }
            else
            {
                cards_three.Add(tempList);
            }
        }
        else if (temp_two == 2)
        {
            if (jokers == 1)
            {
                cards_five.Add(tempList);
            }
            else
            {
                cards_two.Add(tempList);
            }
        }
        else if (temp_two == 1)
        {
            if (jokers == 3)
            {
                cards_five.Add(tempList);
            }
            else if (jokers == 2)
            {
                cards_four.Add(tempList);
            }
            else if (jokers == 1)
            {
                cards_three.Add(tempList);
            }
            else
            {
                cards_one.Add(tempList);
            }
        }
        else
        {
            if (jokers == 4)
            {
                cards_five.Add(tempList);
            }
            else if (jokers == 3)
            {
                cards_four.Add(tempList);
            }
            else if (jokers == 2)
            {
                cards_three.Add(tempList);
            }
            else if (jokers == 1)
            {
                cards_one.Add(tempList);
            }
            else
            {
                cards_high.Add(tempList);
            }
        }
    }
}
Console.WriteLine("Reading Lines Done :" + sw);
bool IsInt(char cha)
{
    String str = cha.ToString();
    bool isnumeric = int.TryParse(str, out int hell);

    return isnumeric;
}

Console.WriteLine("Sorting Done :" + sw);

cards_one.Sort(SortList);
cards_two.Sort(SortList);
cards_three.Sort(SortList);
cards_four.Sort(SortList);
cards_five.Sort(SortList);
cards_high.Sort(SortList);
cards_house.Sort(SortList);

int SortList(List<int> list1, List<int> list2)
{
    int result = list1[0].CompareTo(list2[0]);
    if (result == 0)
    {
        result = list1[1].CompareTo(list2[1]);
    }
    if (result == 0)
    {
        result = list1[2].CompareTo(list2[2]);
    }
    if (result == 0)
    {
        result = list1[3].CompareTo(list2[3]);
    }
    if (result == 0)
    {
        result = list1[4].CompareTo(list2[4]);
    }
    return result;
}

Console.WriteLine("Highest");
foreach (List<int> i in cards_high)
{
    winningnums.Add(i[5]);
    foreach (int j in i)
    {
        Console.Write(j + "\t");
    }
    Console.WriteLine();
}
Console.WriteLine("One pair");
foreach (List<int> i in cards_one)
{
    winningnums.Add(i[5]);
    foreach (int j in i)
    {
        Console.Write(j + "\t");
    }
    Console.WriteLine();
}
Console.WriteLine("Two pair");

foreach (List<int> i in cards_two)
{
    winningnums.Add(i[5]);
    foreach (int j in i)
    {
        Console.Write(j + "\t");
    }
    Console.WriteLine();
}
Console.WriteLine("three pair");

foreach (List<int> i in cards_three)
{
    winningnums.Add(i[5]);
    foreach (int j in i)
    {
        Console.Write(j + "\t");
    }
    Console.WriteLine();
}
Console.WriteLine("House");

foreach (List<int> i in cards_house)
{
    winningnums.Add(i[5]);
    foreach (int j in i)
    {
        Console.Write(j + "\t");
    }
    Console.WriteLine();
}
Console.WriteLine("Four ");

foreach (List<int> i in cards_four)
{
    winningnums.Add(i[5]);
    foreach (int j in i)
    {
        Console.Write(j + "\t");
    }
    Console.WriteLine();
}
Console.WriteLine("Five");

foreach (List<int> i in cards_five)
{
    winningnums.Add(i[5]);
    foreach (int j in i)
    {
        Console.Write(j + "\t");
    }
    Console.WriteLine();
}

int lineh = 0;
foreach (int i in winningnums)
{
    lineh++;
    totalwinnings += i * lineh;
}
Console.WriteLine(totalwinnings); //!250014315 249511785