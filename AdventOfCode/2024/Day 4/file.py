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

def Tostring(list):
    stri = ""
    for c in list:
        stri += c
    return stri


def LookDown(list, pos, p): # down - up
    temp = ""
    if(p+4 <= len(inputList)):
        for i in range(4):
            temp += Tostring(list[p+i][pos])
        if(temp == text or temp == text[::-1]):
            #print("True - Down", temp)       
            return True
    return False

def LookRight(list, pos): # left - right
    if(Tostring(list[pos:pos+4]) == text or Tostring(list[pos:pos+4]) == text[::-1]):
        #print("True - Right", Tostring(list[pos:pos+4]))
        return True
    return False

def LookDiagonalRightDown(list, pos, p): # digonal right
    temp = ""
    if(p+4 <= len(inputList) and pos+4 <= len(list[p])):
        for i in range(4):
            temp += Tostring(list[p+i][pos+i])
        if(temp == text or temp == text[::-1]):
            #print("True - DiagonalRightDown", temp)       
            return True
    return False

def LookDiagonalLeftDown(list, pos, p): # diagonal left
    temp = ""
    if(p+4 <= len(inputList) and pos-3 >= 0):
        for i in range(4):
            temp += Tostring(list[p+i][pos-i])
        if(temp == text or temp == text[::-1]):
            #print("True - DiagonalLeftDown", temp)       
            return True
    return False




listI = 0

#for list in inputList:
#    for i in range(len(list)):
#        if(LookRight(list, i)):
#            totalXmas += 1
#        if(LookDown(inputList, i, listI)):
#            totalXmas += 1
#        if(LookDiagonalRightDown(inputList, i, listI)):
#            totalXmas += 1
#        if(LookDiagonalLeftDown(inputList, i, listI)):
#            totalXmas += 1
#    listI += 1


print("total xmas:",totalXmas)
totalXMAS = 0

#check from the middle and look if the diagonals that go tru it is mas or sam

def LookDiagonalL(list, midPos, listPos):
    temp = ""
    if(midPos-1 >= 0 and midPos+1 < len(list[listPos]) and listPos-1 >= 0 and listPos+1 < len(list)):
        temp += list[listPos-1][midPos-1]
        temp += list[listPos][midPos]
        temp += list[listPos+1][midPos+1]
        
        if(temp == "MAS" or temp == "SAM"):
            return True
    return False

def LookDiagonalR(list, midPos, listPos):
    temp = ""
    if(midPos-1 >= 0 and midPos+1 < len(list[listPos]) and listPos-1 >= 0 and listPos+1 < len(list)):
        temp += list[listPos-1][midPos+1]
        temp += list[listPos][midPos]
        temp += list[listPos+1][midPos-1]
        
        if(temp == "MAS" or temp == "SAM"):
            return True
    return False



listX = 0

for list in inputList:
    for i in range(len(list)):
        if(LookDiagonalL(inputList, i, listX) and LookDiagonalR(inputList, i, listX)):
            totalXMAS += 1
    listX += 1

print("Total MAS:",totalXMAS)