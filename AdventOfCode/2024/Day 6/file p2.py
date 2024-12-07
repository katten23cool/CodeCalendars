import time
import copy

map = []
orginalMap = []
originalPos = ","
guardPos = ","
guardLeft = False

j = 0
with open("Day 6/input.txt") as f:
    for line in f:
        line = line[:-1]
        templist = []
        for i in range(len(line)):
            templist.append(line[i])
            if(line[i] == "^"):
                guardPos = f"{i},{j}"
                originalPos = f"{i},{j}"

        map.append(templist[:])
        j += 1
                
print(guardPos)
orginalMap = copy.deepcopy(map)

def MoveGuard(map):
    guardDirection = GetGuardDirection()

    if(guardDirection == "^"):
        guardDirection = CheckIfObstacle("0,-1", "^")
        pass
    elif(guardDirection == ">"):
        guardDirection = CheckIfObstacle("1,0", ">")
        pass
    elif(guardDirection == "<"):
        guardDirection = CheckIfObstacle("-1,0", "<")
        pass
    else:
        guardDirection = CheckIfObstacle("0,1", "v")
        pass
    pass


def CheckIfObstacle(direction, guard):
    global guardPos
    global map
    global guardLeft
    splitdir = direction.split(",")
    splitguar = guardPos.split(",")
    x = int(splitdir[0]) + int(splitguar[0])
    y = int(splitdir[1]) + int(splitguar[1])

    if(y >= len(map) or x >= len(map[0]) or y <= -1 or x <= -1):
        guardLeft = True
        map[int(splitguar[1])][int(splitguar[0])] = "X"
        return False

    if(map[y][x] != "#"):
        map[int(splitguar[1])][int(splitguar[0])] = "X"
        guardPos = f"{x},{y}"
        map[y][x] = guard
    else:
        Rotate90Deg(guard)

def Rotate90Deg(dir):
    global guardPos
    global map
    split = guardPos.split(",")

    newdir = ""

    if(dir == "^"):
        newdir = ">"
    elif(dir == ">"):
        newdir = "v"
    elif(dir == "<"):
        newdir = "^"        
    else:
        newdir = "<"

    map[int(split[1])][int(split[0])] = newdir

def GetGuardDirection():
    global guardPos
    global map
    split = guardPos.split(",")
    #print(split)
    return map[int(split[1])][int(split[0])]

def Reset():
    global map
    global originalPos
    global originalPos
    global guardPos

    guardPos = originalPos
    map = copy.deepcopy(orginalMap)

obstacles = 0
k = 0
for d in range(len(map)):
    for t in range(len(map[0])):
        char = map[d][t]
        Reset()      
        if(char != "#"):
            map[d][t] = "#"
            while(guardLeft == False and k < 10000):
                MoveGuard(map)
                k += 1
            if(guardLeft):
                guardLeft = False
            else:
                obstacles +=1 
            #print(k)
            k = 0

for c in orginalMap:
    print(c)
print(obstacles)