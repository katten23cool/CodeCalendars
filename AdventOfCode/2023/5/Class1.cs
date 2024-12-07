
using System.Text;
/*

List<long> Seeds = new List<long>();
bool seeds = true;

//seednum - soilnum - range - seednumu - soilnum+range + range
List<List<long>> seed_soil_correspond = new List<List<long>>();
bool seed_soil_nums = false;
//Soil to feryilizer
List<List<long>> soil_fertilizer = new List<List<long>>();
bool soil_fertilizer_nums = false;
//Soil to feryilizer
List<List<long>> fertilizer_water = new List<List<long>>();
bool fertilizer_water_nums = false;
//Soil to feryilizer
List<List<long>> water_light = new List<List<long>>();
bool water_light_nums = false;
//Soil to feryilizer
List<List<long>> light_temperature = new List<List<long>>();
bool light_temperature_nums = false;
//Soil to feryilizer
List<List<long>> temperature_humidity = new List<List<long>>();
bool temperature_humidity_nums = false;
//Soil to feryilizer
List<List<long>> humidity_location = new List<List<long>>();
bool humidity_location_nums = false;

var filestream = File.OpenRead("text.txt");
using (var streamreader = new StreamReader(filestream, Encoding.UTF8, true, 128))
{
    string line;
    while ((line = streamreader.ReadLine()) != null)
    {
        string rawr = line;
        List<long> temp_list = new(100);
        if (seeds)
        {
            seeds = false;

            string partNumber = "";
            string shortLine = line.Substring(line.LastIndexOf(":") + 1);
            foreach (char c in shortLine)
            {
                if (IsInt(c.ToString()))
                {
                    partNumber += c.ToString();
                }
                else
                {
                    //Console.WriteLine(partNumber);
                    if (partNumber != "")
                    {
                        Seeds.Add(Convert.ToInt64(partNumber));
                    }
                    partNumber = "";
                }
            }
            if (IsInt(partNumber))
            {
                Seeds.Add(Convert.ToInt64(partNumber));
            }

        }
        if (seed_soil_nums)
        {
            for (int i = 0; i < 3; i++)
            {
                string stri = rawr;
                if (rawr.Contains(" "))
                {
                    stri = rawr.Substring(rawr.LastIndexOf(" ") + 1);
                    rawr = rawr.Remove(rawr.LastIndexOf(" "));
                }
                if (IsInt(stri))
                {
                    temp_list.Add(Convert.ToInt64(stri));
                }
            }

            if (temp_list.Count > 0)
            {
                //Console.WriteLine(temp_list[0]);
                temp_list.Add(temp_list[0] + temp_list[2] - 1);
                temp_list.Add(temp_list[0] + temp_list[1] - 1);
                seed_soil_correspond.Add(temp_list);
            }
        }
        if (soil_fertilizer_nums)
        {
            for (int i = 0; i < 3; i++)
            {
                string stri = rawr;
                if (rawr.Contains(" "))
                {
                    stri = rawr.Substring(rawr.LastIndexOf(" ") + 1);
                    rawr = rawr.Remove(rawr.LastIndexOf(" "));
                }
                if (IsInt(stri))
                {
                    temp_list.Add(Convert.ToInt64(stri));
                }
            }
            if (temp_list.Count > 0)
            {
                //Console.WriteLine(temp_list[0]);
                temp_list.Add(temp_list[0] + temp_list[2] - 1);
                temp_list.Add(temp_list[0] + temp_list[1] - 1);
                soil_fertilizer.Add(temp_list);
            }
        }
        if (fertilizer_water_nums)
        {
            for (int i = 0; i < 3; i++)
            {
                string stri = rawr;
                if (rawr.Contains(" "))
                {
                    stri = rawr.Substring(rawr.LastIndexOf(" ") + 1);
                    rawr = rawr.Remove(rawr.LastIndexOf(" "));
                }
                if (IsInt(stri))
                {
                    temp_list.Add(Convert.ToInt64(stri));
                }
            }
            if (temp_list.Count > 0)
            {
                temp_list.Add(temp_list[0] + temp_list[2] - 1);
                temp_list.Add(temp_list[0] + temp_list[1] - 1);
                fertilizer_water.Add(temp_list);
            }
        }
        if (water_light_nums)
        {
            for (int i = 0; i < 3; i++)
            {
                string stri = rawr;
                if (rawr.Contains(" "))
                {
                    stri = rawr.Substring(rawr.LastIndexOf(" ") + 1);
                    rawr = rawr.Remove(rawr.LastIndexOf(" "));
                }
                if (IsInt(stri))
                {
                    temp_list.Add(Convert.ToInt64(stri));
                }
            }
            if (temp_list.Count > 0)
            {
                //Console.WriteLine(temp_list[0]);
                temp_list.Add(temp_list[0] + temp_list[2] - 1);
                temp_list.Add(temp_list[0] + temp_list[1] - 1);
                water_light.Add(temp_list);
            }
        }
        if (light_temperature_nums)
        {
            for (int i = 0; i < 3; i++)
            {
                string stri = rawr;
                if (rawr.Contains(" "))
                {
                    stri = rawr.Substring(rawr.LastIndexOf(" ") + 1);
                    rawr = rawr.Remove(rawr.LastIndexOf(" "));
                }
                if (IsInt(stri))
                {
                    temp_list.Add(Convert.ToInt64(stri));
                }
            }
            if (temp_list.Count > 0)
            {
                //Console.WriteLine(temp_list[0]);
                temp_list.Add(temp_list[0] + temp_list[2] - 1);
                temp_list.Add(temp_list[0] + temp_list[1] - 1);
                light_temperature.Add(temp_list);
            }
        }
        if (temperature_humidity_nums)
        {
            for (int i = 0; i < 3; i++)
            {
                string stri = rawr;
                if (rawr.Contains(" "))
                {
                    stri = rawr.Substring(rawr.LastIndexOf(" ") + 1);
                    rawr = rawr.Remove(rawr.LastIndexOf(" "));
                }
                if (IsInt(stri))
                {
                    temp_list.Add(Convert.ToInt64(stri));
                }
            }
            if (temp_list.Count > 0)
            {
                //Console.WriteLine(temp_list[0]);
                temp_list.Add(temp_list[0] + temp_list[2] - 1);
                temp_list.Add(temp_list[0] + temp_list[1] - 1);
                temperature_humidity.Add(temp_list);
            }
        }
        if (humidity_location_nums)
        {
            for (int i = 0; i < 3; i++)
            {
                string stri = rawr;
                if (rawr.Contains(" "))
                {
                    stri = rawr.Substring(rawr.LastIndexOf(" ") + 1);
                    rawr = rawr.Remove(rawr.LastIndexOf(" "));
                }
                if (IsInt(stri))
                {
                    temp_list.Add(Convert.ToInt64(stri));
                }
            }
            if (temp_list.Count > 0)
            {
                //Console.WriteLine(temp_list[0]);
                temp_list.Add(temp_list[0] + temp_list[2] - 1);
                temp_list.Add(temp_list[0] + temp_list[1] - 1);
                humidity_location.Add(temp_list);
            }
        }

        if (line == "seed-to-soil map:")
        {
            seed_soil_nums = true;
        }
        if (line == "soil-to-fertilizer map:")
        {
            soil_fertilizer_nums = true;
        }
        if (line == "fertilizer-to-water map:")
        {
            fertilizer_water_nums = true;
        }
        if (line == "water-to-light map::")
        {
            water_light_nums = true;
        }
        if (line == "light-to-temperature map:")
        {
            light_temperature_nums = true;
        }
        if (line == "temperature-to-humidity map:")
        {
            temperature_humidity_nums = true;
        }
        if (line == "humidity-to-location map:")
        {
            humidity_location_nums = true;
        }
        if (line == "")
        {
            soil_fertilizer_nums = false;
            seed_soil_nums = false;
            soil_fertilizer_nums = false;
            fertilizer_water_nums = false;
            water_light_nums = false;
            light_temperature_nums = false;
            temperature_humidity_nums = false;
            humidity_location_nums = false;
        }
    }
    
    Console.WriteLine("Range\t\tSoil\t\tSeed\t\tSoilRan\t\tSeedRan");
    for (int j = 0; j < seed_soil_correspond.Count; j++)
    {
        for(int i = 0; i < 5; i++)
        {
            Console.Write(seed_soil_correspond[j][i] + " \t\t");
        }
        Console.WriteLine();
    }/*
    foreach(long i in Seeds)
    {
        Console.WriteLine(i);
    }*//*

}


static bool IsInt(string cha)
{
    String str = cha.ToString();
    bool isnumeric = long.TryParse(str, out long hell);

    return isnumeric;
}

List<long> Soils = new List<long>();

foreach (long seed in Seeds)
{
    bool seedtaken = false;
    for (int i = 0; i < seed_soil_correspond.Count; i++)
    {
        long seed_low = seed_soil_correspond[i][2];
        long seed_hig = seed_soil_correspond[i][4];
        if (seed <= seed_hig && seed >= seed_low && !seedtaken)
        {
            Soils.Add(seed + seed_soil_correspond[i][0]);
            seedtaken = true;
        }
    }
    if (!seedtaken)
    {
        Soils.Add(seed);
    }
    //Console.WriteLine(seed);
}

List<long> fertilizer = new List<long>();

foreach (long soil in Soils)
{

    bool soiltaken = false;
    for (int i = 0; i < soil_fertilizer.Count; i++)
    {
        long soil_low = soil_fertilizer[i][2];
        long soil_hig = soil_fertilizer[i][4];
        Console.WriteLine(soil + " " + soil_low + " " + soil_hig);
        if (soil <= soil_hig && soil >= soil_low && !soiltaken)
        {
            if (soil > soil_fertilizer[i][2])
            {
                fertilizer.Add(soil + soil_fertilizer[i][0]);
            }
            else
            {
                fertilizer.Add(soil - soil_fertilizer[i][0]);
            }
            soiltaken = true;

        }
    }
    if (!soiltaken)
    {
        fertilizer.Add(soil);
    }
}

List<long> water = new List<long>();

foreach (long soil in fertilizer)
{
    bool soiltaken = false;
    for (int i = 0; i < fertilizer_water.Count; i++)
    {
        long soil_low = fertilizer_water[i][2];
        long soil_hig = fertilizer_water[i][4];

        if (soil <= soil_hig && soil >= soil_low && !soiltaken)
        {
            water.Add(soil + fertilizer_water[i][0]);
            soiltaken = true;
        }
    }
    if (!soiltaken)
    {
        water.Add(soil);
    }
}
List<long> light = new List<long>();

foreach (long soil in water)
{
    bool soiltaken = false;
    for (int i = 0; i < water_light.Count; i++)
    {
        long soil_low = water_light[i][2];
        long soil_hig = water_light[i][4];

        if (soil <= soil_hig && soil >= soil_low && !soiltaken)
        {
            light.Add(soil + water_light[i][0]);
            soiltaken = true;
        }
        else
        {

        }
    }
    if (!soiltaken)
    {
        light.Add(soil);
    }
}
List<long> temperature = new List<long>();

foreach (long soil in light)
{
    bool soiltaken = false;
    for (int i = 0; i < light_temperature.Count; i++)
    {
        long soil_low = light_temperature[i][2];
        long soil_hig = light_temperature[i][4];

        if (soil <= soil_hig && soil >= soil_low && !soiltaken)
        {
            temperature.Add(soil + light_temperature[i][0]);
            soiltaken = true;
        }
        else
        {

        }
    }
    if (!soiltaken)
    {
        temperature.Add(soil);
    }
}

List<long> humidity = new List<long>();

foreach (long soil in temperature)
{
    bool soiltaken = false;
    for (int i = 0; i < temperature_humidity.Count; i++)
    {
        long soil_low = temperature_humidity[i][2];
        long soil_hig = temperature_humidity[i][4];

        if (soil <= soil_hig && soil >= soil_low && !soiltaken)
        {
            humidity.Add(soil + temperature_humidity[i][0]);
            soiltaken = true;
        }
        else
        {

        }
    }
    if (!soiltaken)
    {
        humidity.Add(soil);
    }
}
List<long> location = new List<long>();

foreach (long soil in humidity)
{
    bool soiltaken = false;
    for (int i = 0; i < humidity_location.Count; i++)
    {
        long soil_low = humidity_location[i][2];
        long soil_hig = humidity_location[i][4];

        if (soil <= soil_hig && soil >= soil_low && !soiltaken)
        {
            location.Add(soil + humidity_location[i][0]);
            soiltaken = true;
        }
        else
        {

        }
    }
    if (!soiltaken)
    {
        location.Add(soil);
    }
}
foreach (long soil in location)
{
    //Console.WriteLine(soil.ToString());
}*/