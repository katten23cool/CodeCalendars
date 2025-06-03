from pathlib import Path
ROOT_DIR = Path(__file__).parent
TEXT_FILE = ROOT_DIR / 'input.txt'


inputList =[]
startPositions = []


with open(TEXT_FILE) as f:
    y = 0
    for line in f:
        tempList = []
        line = line.replace("\n", "")
        for x,c in enumerate(line):
            c = int(c)
            if(c == 0):
                startPositions.append([x,y])
            tempList.append(c)
        inputList.append(tempList)
        y += 1






def start(check, startP):
    nlist = []
    st1 = startP[1]
    st0 = startP[0]
    xlen = len(inputList[0])
    ylen = len(inputList)

    #print(st0,st1,xlen,ylen)
    if(st0 + 1 < xlen and inputList[st1][st0+1] == check):
        nlist.append([st1,st0+1])

    if(st0 - 1 > 0 and inputList[st1][st0-1] == check):
        nlist.append([st1,st0-1])

    if(st1 - 1 > 0 and inputList[st1-1][st0] == check):
        nlist.append([st1-1,st0]) 

    if(st1 + 1< ylen and inputList[st1+1][st0] == check):
        nlist.append([st1+1,st0])

    #print(nlist)
    return nlist


def CheckAround(lst, startPos, checkFor):
    newList =[]
    if(lst == []):
        newList = start(checkFor, startPos)
    else:
        for list in lst:
            newList = start(checkFor, list)

    return newList


def CheckHikingTrail(zeroPos):
    tmpLst = []
    endReached = 0

    for i in range(10):
        tmpLst = CheckAround(tmpLst, zeroPos, i)
        print(CheckAround(tmpLst, zeroPos, i))

    for c in tmpLst:
        endReached += len(c)

    return endReached

numbs = 0
for star in startPositions:
    pass
    numbs += CheckHikingTrail(star)
    print(star)

print(numbs)

