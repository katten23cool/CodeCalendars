using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_23
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<int> index = new List<int>();
            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead("text.txt"))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String line;
                List<string> list = new List<string>();
                while ((line = streamReader.ReadLine()) != null)
                {
                    int linewidth = line.Length;
                    int linestart = 0;
                    while (linestart < linewidth)
                    {
                        String word = "";
                        int i = 0;
                        while (i < line.Length)
                        {
                            char letter = line[i];
                            word += letter;
                            if (IfInt(letter) && line[0] == letter )
                            {
                                if (list.Count == 0 || list[list.Count - 1] != letter.ToString())
                                {
                                    list.Add(letter.ToString());
                                }
                            }
                            else if (word == "one")
                            {
                                list.Add("1");
                            }
                            else if (word == "two")
                            {
                                list.Add("2");
                            }
                            else if (word == "three")
                            {
                                list.Add("3");
                            }
                            else if (word == "four")
                            {
                                list.Add("4");
                            }
                            else if (word == "five")
                            {
                                list.Add("5");
                            }
                            else if (word == "six")
                            {
                                list.Add("6");
                            }
                            else if (word == "seven")
                            {
                                list.Add("7");
                            }
                            else if (word == "eight")
                            {
                                list.Add("8");
                            }
                            else if (word == "nine")
                            {
                                list.Add("9");
                            }
                            //Console.WriteLine(word);
                            i++;
                        }
                        line = line.Substring(1);
                        linestart++;
                        string wdaw = "";
                        foreach (string c in list)
                        {
                            wdaw += c;
                        }
                        //Console.WriteLine(wdaw);


                    }
                    string strr = $"{Convert.ToInt32(list[0])}{Convert.ToInt32(list[list.Count - 1])}";
                    index.Add(Convert.ToInt32(strr));
                    list.RemoveRange(0, list.Count);
                }
            }
            int total = 0;
            foreach (int str in index)
            {
                total += str;
            }
            Console.WriteLine(total);

            while (true);
        }

        private static bool IfInt(char cha)
        {
            String str = cha.ToString();
            bool isnumeric = int.TryParse(str, out int hell);

            return isnumeric;

        }
    }





    
}
