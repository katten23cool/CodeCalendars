from pathlib import Path
ROOT_DIR = Path(__file__).parent
TEXT_FILE = ROOT_DIR / 'input.txt'

totalSum = 0








def DetermineOperations(numberOfNumbers):
    tempList = []
    temp = []
    for j in range(numberOfNumbers -1):
        for i in range(numberOfNumbers):
            if(i % 2 == 0):
                temp.append("*")
            else:
                temp.append("+")
        tempList.append(temp)
        


    print(tempList, numberOfNumbers)
    return tempList



def CanBeCalculated(result, numbersList):
    #numbers of different * and + is the len of the numbers 
    # 2 numbers has 2 different possibilites
    numbersList = [int(item) for item in numbersList]
    listOfOperations = DetermineOperations(len(numbersList))

    for j in range(len(listOfOperations)):
        i = 1
        tempsum = numbersList[0]
        for operation in listOfOperations[j]:
            if(operation == "*"):
                tempsum *= numbersList[i]
            else:
                tempsum += numbersList[i]
            i += 1 
        if(tempsum == result):
            print(tempsum)
            return True  
    return False




with open(TEXT_FILE) as f:
    for line in f:
        line = line.replace("\n", "")
        lineSplit = line.split(":")
        numbers = str.strip(lineSplit[1]).split(" ")

        if(CanBeCalculated(int(lineSplit[0]), numbers)):
            totalSum += int(lineSplit[0])

print(totalSum)
