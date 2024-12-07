using System.Text;

List<int> nums = new List<int>();

var filestream = File.OpenRead("text.txt");
using (var streamreader = new StreamReader(filestream, Encoding.UTF8, true, 128))
{
    string line;
    while ((line = streamreader.ReadLine()) != null)
    {
        string word = "";
        int total = 0;
        foreach (char c in line)
        {
            if (IsInt(c.ToString()))
            {
                word += c.ToString();
            }
            else
            {
                if (IsInt(word) && word != string.Empty)
                {
                    total += Convert.ToInt32(word);
                }
                word = "";
            }
        }
        if (IsInt(word) && word != string.Empty)
        {
            total += Convert.ToInt32(word);
        }
        nums.Add(total);
    }
}

static bool IsInt(string cha)
{
    bool isnumeric = int.TryParse(cha, out int hell);

    return isnumeric;
}

for (int i = 0; i < nums.Count; i++)
{
    try
    {
        if (nums[i] > nums[i + 1])
        {
            Console.WriteLine(nums[i] + " " + i);
        }
    }
    catch { }
}