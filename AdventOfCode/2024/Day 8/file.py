from pathlib import Path
ROOT_DIR = Path(__file__).parent
TEXT_FILE = ROOT_DIR / 'input.txt'

dictionaryWithLists = {}
# spara alla positioner för alla olika karaktärer, sedan jämför alla som är
# samma med och ta distansen emellan dem och plussa/minus och kolla om det
# är inom ramen. verkar inte vara allt för svår rn. skulle ju kunna göra en klass i C#
mapX = 0
mapY = 0

with open(TEXT_FILE) as f:
    y = 0
    x = 0
    for line in f:
        line = line.replace("\n", "")
        x = 0
        for c in line:
            if(c != "."):
                if(c in dictionaryWithLists.keys()):
                    posList = dictionaryWithLists[c]
                    pos = f"{x},{y}"
                    posList.append(pos)
                    dictionaryWithLists[c] = posList
                else:
                    tempList = []
                    pos = f"{x},{y}"
                    tempList.append(pos)
                    dictionaryWithLists[c] = tempList
            x += 1
        y += 1
    mapX = x - 1
    mapY = y - 1

#print(mapX,mapY)

antiNodesDictionary = {}

for key in dictionaryWithLists.keys():
    for list in dictionaryWithLists[key]:
        split = list.split(",")
        x1 = int(split[0])
        y1 = int(split[1])
        for list2 in dictionaryWithLists[key]:
            split2 = list2.split(",")
            x2 = int(split2[0])
            y2 = int(split2[1])
            if(list != list2):
                times = 1
                while(True): 
                    mellanX = x1 - x2 
                    mellanY = y1 - y2 

                    antinodeX = x1 + mellanX * times
                    antinodeY = y1 + mellanY * times
                    antiNodePos = f"{antinodeX},{antinodeY}"
                    if(antinodeX >= 0 and antinodeX <= mapX and antinodeY >= 0 and antinodeY <= mapY and antiNodePos):
                        if(antiNodePos in antiNodesDictionary.keys()):
                            antiNodesDictionary[antiNodePos] += 1
                        else:
                            antiNodesDictionary[antiNodePos] = 1
                        #break #remove the # for part 1
                    else:
                        break
                    times += 1

#for part2
for key in dictionaryWithLists:
    for value in dictionaryWithLists[key]:
        if(value not in antiNodesDictionary.keys()):
            antiNodesDictionary[value] = 1


for y in range(mapY +1):
    linee = ""
    for x in range(mapX+1):
        poss = f"{x},{y}"
        if(poss in antiNodesDictionary.keys()):
            linee += "#"
        else:
            linee += "."
    print(linee)


print(len(antiNodesDictionary.keys()))