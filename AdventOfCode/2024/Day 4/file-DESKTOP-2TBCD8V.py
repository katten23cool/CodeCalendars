inputList = []
totalXmas = 0
with open("Day 4/input.txt") as f:
    for line in f:
        tempList = []
        for c in line:
            tempList.append(c)
        if("\n" in tempList):
            tempList.remove("\n")
        inputList.append(tempList)

text = "XMAS"

def LookUp(list):
    pass

def LookDown(list):
    pass

def LookDiagonal(list):
    pass

def LookRight(list, pos):
    if(pos+3 <= len(list)):
        if(list[pos:pos+3] == text or list[pos:pos +3] == text[::-1]):
            print(list[pos:pos +3])
            return True

    return False

def LookLeft(list):
    pass


for list in inputList:
    for i in range(len(list)):
        if(LookRight(list, i)):
            totalXmas += 1
        else:
            list[i] == "."
            print(list)


print(totalXmas)