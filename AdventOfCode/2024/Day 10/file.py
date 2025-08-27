from pathlib import Path
ROOT_DIR = Path(__file__).parent
TEXT_FILE = ROOT_DIR / 'input.txt'


inputList =[]
startPositions = []
scoreValues = {}


with open(TEXT_FILE) as f:
    y = 0
    for line in f:
        tempList = []
        line = line.replace("\n", "")
        for x,c in enumerate(line):
            c = int(c)
            if c == 0:
                startPositions.append([x,y])
            elif c == 9:
                scoreValues[x, y] = 0
            tempList.append(c)
        inputList.append(tempList)
        y += 1

for x in inputList:
    print(x)



print(scoreValues)