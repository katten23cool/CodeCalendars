instructions = {}

changeFromInstructions = False

CorrectLines = 0
middleNUmbers = 0

wrongLines = []

with open("Day 5/input.txt") as f:
    for line in f:
        
        line = line[:len(line)-1]

        if(line == ""):
            changeFromInstructions = True
            continue
        if(changeFromInstructions == False):
            splitList = line.split("|")
            listOfInstructions = []
            if(int(splitList[0]) in instructions):
                listOfInstructions = instructions[int(splitList[0])]
                listOfInstructions.append(int(splitList[1]))
            else:
                listOfInstructions.append(int(splitList[1]))
            
            instructions[int(splitList[0])] = listOfInstructions
            #print(instructions)
            pass
        else:
            hhh = True
            splitList = line.split(",")
            for i in range(len(splitList)):
                if(int(splitList[i]) in instructions):
                    listOfIns = instructions.get(int(splitList[i]))
                    for j in range(i):
                        if(int(splitList[j]) in listOfIns):
                            #print(splitList)
                            hhh = False
                        
            if(hhh and line != ""):
                CorrectLines += 1
                middleNUmbers += int(splitList[int(len(splitList)/2)])
                #print(int(splitList[int(len(splitList)/2)]))
            elif (hhh == False):
                wrongLines.append(line)
        #print(splitList)

print(CorrectLines, middleNUmbers)
print()
correctedLinesNum = 0
for line in wrongLines:
    #print(line)
    needredo = True
    splitLine = line.split(",")

    while(needredo):
        needredo = False
        for i in range(len(splitLine)):
                    if(int(splitLine[i]) in instructions):
                        listOfIns = instructions.get(int(splitLine[i]))
                        for j in range(i):
                            if(int(splitLine[j]) in listOfIns):
                                num = splitLine.pop(j)
                                splitLine.insert(j+1, num)
                                needredo = True
    #print(splitLine)
    
    correctedLinesNum += int(splitLine[int(len(splitLine)/2)])


print(correctedLinesNum)




#storar alla instruktioner i en dictionary
#vi storar line listan i en lista, sen så går man igenom varje numer och kollar dictionaryn
#och jämför key more value och sedan jämför valuet  med det som var tidigare i listan för 
#att se om det numret finns där innan, om så retunr false