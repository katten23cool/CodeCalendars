using System.Diagnostics;
using System.Text;

//Step 2 answer = 12634632

Stopwatch sw = Stopwatch.StartNew();
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
        sw.Start();
        string rawr = line;
        List<long> temp_list = new(100);
        if (seeds)
        {
            seeds = false;
            List<long> seedstemp = new List<long>();
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
                        seedstemp.Add(Convert.ToInt64(partNumber));
                    }
                    partNumber = "";
                }
            }
            if (IsInt(partNumber))
            {
                seedstemp.Add(Convert.ToInt64(partNumber));
            }
            while (seedstemp.Count > 0)
            {
                long number = seedstemp[0];
                long range = seedstemp[1];
                for (long i = number; i <= range + number; i += 100)
                {
                    Seeds.Add(i);
                }
                Console.WriteLine("Range :/");

                seedstemp.RemoveAt(0);
                seedstemp.RemoveAt(0);
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
        if (line == "water-to-light map:")
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
    /*
    Console.WriteLine("Range\t\tSoil\t\tSeed\t\tSoilRan\t\tSeedRan");
    for (int j = 0; j < fertilizer_water.Count; j++)
    {
        for(int i = 0; i < 3; i++)
        {
            Console.Write(fertilizer_water[j][i] + " \t\t");
        }
        Console.WriteLine();
    }/*
    Console.WriteLine("-------------------------");
    for (int j = 0; j < soil_fertilizer.Count; j++)
    {
        for (int i = 0; i < 3; i++)
        {
            Console.Write(soil_fertilizer[j][i] + " \t\t");
        }
        Console.WriteLine();
    }/*
    for (int j = 0; j < seed_soil_correspond.Count; j++)
    {
        for (int i = 0; i < 3; i++)
        {
            Console.Write(seed_soil_correspond[j][i] + " \t\t");
        }
        Console.WriteLine();
    }
    /*
    foreach(long i in Seeds)
    {
        Console.WriteLine(i);
    }*/
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
        long seed_low = seed_soil_correspond[i][1];
        long seed_hig = seed_soil_correspond[i][0] + seed_soil_correspond[i][1] - 1;
        if (seed <= seed_hig && seed >= seed_low && !seedtaken)
        {
            seedtaken = true;

            Soils.Add(seed + seed_soil_correspond[i][2] - seed_soil_correspond[i][1]);

            //Console.WriteLine($"{seed} -- {seed_low}-- {seed_hig} --- {seedtaken} --{seed_soil_correspond[i][0]}");
        }
    }
    if (!seedtaken)
    {
        Soils.Add(seed);
    }
    //Console.WriteLine(seed);
}
Console.WriteLine("Seeds Done \t" + sw);

List<long> fertilizer = new List<long>();

foreach (long soil in Soils)
{
    //Console.WriteLine(soil);
    bool soiltaken = false;
    for (int i = 0; i < soil_fertilizer.Count; i++)
    {
        long soil_low = soil_fertilizer[i][1];
        long soil_hig = soil_fertilizer[i][0] + soil_fertilizer[i][1] - 1;
        //Console.WriteLine($"{soil} -- {soil_low}-- {soil_hig} --- {soil_fertilizer[i][2] - soil_fertilizer[i][1]} -- {soil_fertilizer[i][0]}");
        if (soil <= soil_hig && soil >= soil_low && !soiltaken)
        {
            if (soil_fertilizer[i][2] - soil_fertilizer[i][1] > 0)
            {
                fertilizer.Add(soil + soil_fertilizer[i][2] - soil_fertilizer[i][1]);
            }
            else
            {
                fertilizer.Add(soil + (soil_fertilizer[i][2] - soil_fertilizer[i][1]));
            }

            soiltaken = true;
        }
    }
    if (!soiltaken)
    {
        fertilizer.Add(soil);
    }
}
Console.WriteLine("Soils Done \t" + sw);
Soils.Clear();
List<long> water = new List<long>();

foreach (long soil in fertilizer)
{
    //Console.WriteLine(soil);

    bool soiltaken = false;
    for (int i = 0; i < fertilizer_water.Count; i++)
    {
        long soil_low = fertilizer_water[i][1];
        long soil_hig = fertilizer_water[i][0] + fertilizer_water[i][1] - 1;
        if (soil <= soil_hig && soil >= soil_low && !soiltaken)
        {
            water.Add(soil + fertilizer_water[i][2] - fertilizer_water[i][1]);
            //Console.WriteLine($"{soil} \t {soil_low}\t {soil_hig} \t {fertilizer_water[i][2] - fertilizer_water[i][1]} \t {fertilizer_water[i][0]}");
            soiltaken = true;
        }
    }
    if (!soiltaken)
    {
        water.Add(soil);
    }
}
List<long> light = new List<long>();
Console.WriteLine("Fertilizer Done\t" + sw);

foreach (long soil in water)
{
    //Console.WriteLine(soil);
    bool soiltaken = false;
    for (int i = 0; i < water_light.Count; i++)
    {
        long soil_low = water_light[i][1];
        long soil_hig = water_light[i][0] + water_light[i][1] - 1;
        //Console.WriteLine($"{soil} \t {soil_low}\t {soil_hig} \t {water_light[i][2] - water_light[i][1]} \t {water_light[i][0]}");
        if (soil <= soil_hig && soil >= soil_low && !soiltaken)
        {
            light.Add(soil + water_light[i][2] - water_light[i][1]);
            soiltaken = true;
        }
    }
    if (!soiltaken)
    {
        light.Add(soil);
    }
}
List<long> temperature = new List<long>();
Console.WriteLine("Water Done \t" + sw);

foreach (long soil in light)
{    //Console.WriteLine(soil);
    bool soiltaken = false;
    for (int i = 0; i < light_temperature.Count; i++)
    {
        long soil_low = light_temperature[i][1];
        long soil_hig = light_temperature[i][0] + light_temperature[i][1] - 1;
        //Console.WriteLine($"{soil} \t {soil_low}\t {soil_hig} \t {water_light[i][2] - water_light[i][1]} \t {water_light[i][0]}");
        if (soil <= soil_hig && soil >= soil_low && !soiltaken)
        {
            temperature.Add(soil + light_temperature[i][2] - light_temperature[i][1]);
            soiltaken = true;
        }
    }
    if (!soiltaken)
    {
        temperature.Add(soil);
    }
}
Console.WriteLine("Light Done \t" + sw);

List<long> humidity = new List<long>();

foreach (long soil in temperature)
{
    // Console.WriteLine(soil);
    bool soiltaken = false;
    for (int i = 0; i < temperature_humidity.Count; i++)
    {
        long soil_low = temperature_humidity[i][1];
        long soil_hig = temperature_humidity[i][0] + temperature_humidity[i][1] - 1;
        //Console.WriteLine($"{soil} \t {soil_low}\t {soil_hig} \t {water_light[i][2] - water_light[i][1]} \t {water_light[i][0]}");
        if (soil <= soil_hig && soil >= soil_low && !soiltaken)
        {
            humidity.Add(soil + temperature_humidity[i][2] - temperature_humidity[i][1]);
            soiltaken = true;
        }
    }
    if (!soiltaken)
    {
        humidity.Add(soil);
    }
}
List<long> location = new List<long>();
Console.WriteLine("Temperature Done \t" + sw);

foreach (long soil in humidity)
{
    //Console.WriteLine(soil);
    bool soiltaken = false;
    for (int i = 0; i < humidity_location.Count; i++)
    {
        long soil_low = humidity_location[i][1];
        long soil_hig = humidity_location[i][0] + humidity_location[i][1] - 1;
        //Console.WriteLine($"{soil} \t {soil_low}\t {soil_hig} \t {water_light[i][2] - water_light[i][1]} \t {water_light[i][0]}");
        if (soil <= soil_hig && soil >= soil_low && !soiltaken)
        {
            location.Add(soil + humidity_location[i][2] - humidity_location[i][1]);
            soiltaken = true;
        }
    }
    if (!soiltaken)
    {
        location.Add(soil);
    }
    sw.Stop();
}
Console.WriteLine("Humidity Done \t" + sw);

location.Sort();
int braj = 0;
foreach (long soil in location)
{
    if (braj < 5)
    {
        Console.WriteLine(soil.ToString());
    }
    braj++;
}
Console.WriteLine(sw.ToString());