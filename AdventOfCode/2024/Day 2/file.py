
safeReports = 0

def CheckLevels(levs, isincreasing):
    value = True
    for i in range(len(levs) - 1):
                    differ = levs[i] - levs[i + 1]
                    abssol = abs(differ)
                    if(isincreasing and differ < 0 and abssol <= 3):
                        pass
                    elif(isincreasing == False and differ > 0 and abssol <= 3):
                        pass
                    else:
                          value = False
                       
    return value


with open("Day 2/input.txt") as f:
    for line in f:
        isSafe = False

        levels = line.split()
        levels = [int(value) for value in levels]
        
        isincreasin = False
        if(levels[0] < levels[len(levels) - 1]):
            isincreasin = True

        tempLevel = levels[::]

        #print(levels)
        for i in range(len(levels)):
            tempLevel = levels[::]
            tempLevel.pop(i)

            can = CheckLevels(tempLevel, isincreasin)

            if(can):
                isSafe = True
                break
            
            
        if(isSafe):
           # print("can")
            safeReports += 1
        else:
            print(levels, "cannot")


print(safeReports)