#make 2 lists, then sort them low to high, then match them and get the abs value of them and add them togheter

totalSum = 0

leftList = []
rightList = []

with open("Day 1/input.txt") as f:
    for line in f:
        valuelist = line.split()
        leftList.append(int(valuelist[0]))
        rightList.append(int(valuelist[1]))

leftList.sort()
rightList.sort()

for i in range(len(leftList)):
    totalSum += abs(leftList[i] - rightList[i])

print("Part 1:",totalSum)

totalLocations = 0

for i in leftList:
    timesinlist = 0
    for f in rightList:
        if(f == i):
            timesinlist += 1
    totalLocations += i * timesinlist

print("Part 2:", totalLocations)
