from pathlib import Path
ROOT_DIR = Path(__file__).parent
TEXT_FILE = ROOT_DIR / 'input.txt'

totalBatery = 0

with open(TEXT_FILE) as f:
    for line in f:
        line = line.replace("\n", "")

        length = len(line)

        startBattery = 0
        startPos = 0

        listOfBatteries = [0,0,0,0,0,0,0,0,0,0,0,0] #Need to find the highest number that is more than 12 from the end

        while startBattery <= 11:
            i = startPos
            while i < length-11+startBattery:
                number = int(line[i])
                if number > listOfBatteries[startBattery]:
                    listOfBatteries[startBattery] = number
                    startPos = i + 1
                i += 1
            startBattery += 1

        batterystring = ""
        for battery in listOfBatteries:
            batterystring += str(battery)
        totalBatery += int(batterystring)
        print(batterystring)


print(totalBatery)