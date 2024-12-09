from pathlib import Path
ROOT_DIR = Path(__file__).parent
TEXT_FILE = ROOT_DIR / 'input.txt'

import time
inputList = []
checkSum = 0
with open(TEXT_FILE) as f:
    for line in f:
        x = 0
        id = 0
        boolin = True
        line = line.replace("\n", "")
        for c in line:
            if(boolin):
                for i in range(int(c)):
                    inputList.append(id)
                id +=1
                boolin = False
            else:
                for i in range(int(c)):
                    inputList.append(".")
                boolin = True
            x += 1


#deleted p1

listOfValues = []

tempStr = ""
leng = 0
start = 0
val = ""
for i, val in enumerate(inputList):
    if val == "." or val == "": 
        continue

    if tempStr == "":  # Start a new segment
        tempStr = str(val)
        start = i
    elif int(tempStr.split(",")[-1]) == val: 
        tempStr += f",{val}"
    else:
        leng = tempStr.count(f"{val-1}")
        print(leng, tempStr, val-1)
        listOfValues.append([False, leng, start, int(val) - 1])
        tempStr = str(val)
        start = i

if tempStr:
    leng = tempStr.count(f"{val}")
    listOfValues.append([False, leng, start, int(val)])

print(listOfValues)



listOfValues = listOfValues[::-1]

start = 0
startPos = 0
tru = True
while(tru):
    dots = ""
    templist = []
    for i in range(len(inputList)):
        if(dots == "" and str(inputList[i]) == "."):
            dots = "."
            start = i
        elif(str(inputList[i]) == "."):
            dots += "."
        elif(dots != ""):
            templist.append([dots,start])
            dots = ""
    for list in listOfValues:
        if(list[0] == False):
            for tList in templist:
                #print(list[1],tList[0])
                if(list[1] <= len(tList[0]) and list[2] > tList[1]):
                    for i in range(list[1]):
                        inputList.pop(list[2])
                    for i in range(list[1]):
                        inputList.insert(list[2],".")
                    
                    for i in range(list[1]):
                        inputList.pop(tList[1])
                    for i in range(list[1]):
                        inputList.insert(tList[1],list[3])
                    break
            list[0] = True
            break

    for i, list in enumerate(listOfValues):

        if(list[0] == False):
            tru = True
            print(f"{i/100}%")#orkar inte greja med denna mer så den får bruteforcas
            break
        else:
            tru = False




for i in range(len(inputList)):
    if(inputList[i] != "."):
        checkSum += (i* int(inputList[i]))

#print(inputList)

print(checkSum)