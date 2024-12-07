from pathlib import Path
ROOT_DIR = Path(__file__).parent
TEXT_FILE = ROOT_DIR / 'input.txt'

from itertools import product

totalSum = 0

def DetermineOperations(numberOfNumbers):
    return list(product("+*|", repeat=numberOfNumbers - 1))  

def CanBeCalculated(result, numbersList):
    #numbers of different * and + is the len of the numbers 
    # 2 numbers has 2 different possibilites
    numbersList = [int(item) for item in numbersList]
    listOfOperations = DetermineOperations(len(numbersList))
    for operations in listOfOperations:
        tempsum = numbersList[0]
        for i, operation in enumerate(operations):
            if(operation == "*"):
                tempsum *= numbersList[i+1]
            elif(operation == "+"):
                tempsum += numbersList[i+1]
            else:
                tempsum = int(str(tempsum) + str(numbersList[i+1]))
        if(tempsum == result):
            #print(tempsum, operations)
            return True  
    return False

h = 0
with open(TEXT_FILE) as f:
    for line in f:
        print(float((h/850)*100), "%")
        line = line.replace("\n", "")
        lineSplit = line.split(":")
        numbers = str.strip(lineSplit[1]).split(" ")

        if(CanBeCalculated(int(lineSplit[0]), numbers)):
            totalSum += int(lineSplit[0])
        h+=1


print(totalSum)
