from pathlib import Path
ROOT_DIR = Path(__file__).parent
TEXT_FILE = ROOT_DIR / 'input.txt'


totalID1 = 0
totalID2 = 0

with open(TEXT_FILE) as f:
    for line in f:
        line = line.replace("\n", "")
        ranges = line.split(",")
        for range in ranges:
            ids = range.split("-")
            startRange = int(ids[0])
            endRange = int(ids[1])
            while startRange <= endRange:
                startString = f"{startRange}"
                length = len(startString)

                i = 2
                while i <= length:
                    x = 0
                    listOfStrings = []
                    if length % i == 0:
                        amount = int(length/i)
                        start = 0
                        end = amount
                        while x < i:
                            listOfStrings.append(startString[start:end])
                            x += 1
                            start += amount
                            end += amount

                        theSame = True
                        for item in listOfStrings:
                            if item != listOfStrings[0]:
                                theSame = False
                                break
                        if theSame:
                            totalID2 += startRange
                            #print(startRange)
                            i = length*2
                    i += 1


                if startString[:int(length/2)] == startString[int(length/2):]:
                    #print("THIS ONE", end=": ")
                    totalID1 += startRange

              #  print(startRange)
               #print(length)

                startRange += 1

            #print(ids)

print(totalID1)
print(totalID2)

#we check amount depending on how long it is so if it has a lenght of 10 we need to check upto 10 simillar but if want efficient then check not in ordning