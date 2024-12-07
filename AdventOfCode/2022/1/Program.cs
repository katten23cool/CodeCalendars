using System.Text;

const Int32 BufferSize = 128;
using (var fileStream = File.OpenRead("text.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
{
    String line;
    int elfWithMost = 0;
    int elfSecond = 0;
    int elfthird = 0;
    int elf = 0;
    while ((line = streamReader.ReadLine()) != null)
    {
        int lineInt = 0;
        if (line == string.Empty)
        {
            if(elf > elfWithMost)
            {
                elfthird = elfSecond;
                elfSecond = elfWithMost;
                elfWithMost = elf;

            }
            else if (elf > elfSecond)
            {
                elfthird = elfSecond;

                elfSecond = elf;
            }
            else if (elf > elfthird)
            {
                elfthird = elf;
            }
            Console.WriteLine("elf :" + elf.ToString());
            Console.WriteLine("elf1 :"+elfWithMost.ToString());
            Console.WriteLine("elf2 :" + elfSecond.ToString());
            Console.WriteLine("elf3 :" + elfthird.ToString());
            Console.WriteLine("----");


            elf = 0;
        }
        else
        {
             lineInt = Convert.ToInt32(line);
        }

        elf += lineInt;

    }
    Console.WriteLine(elfWithMost.ToString());
    int totalelfs = elfWithMost + elfSecond + elfthird;
    Console.WriteLine(totalelfs.ToString());
}