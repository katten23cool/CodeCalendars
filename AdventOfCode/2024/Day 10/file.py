from pathlib import Path
ROOT_DIR = Path(__file__).parent
TEXT_FILE = ROOT_DIR / 'input.txt'

inputList =[]
startPositions = []
scoreValues = {}

def check_around_position(currentPosition, value, start):
    left = [-1 + currentPosition[0],currentPosition[1]]
    right = [1 + currentPosition[0],currentPosition[1]]
    up = [currentPosition[0],-1 + currentPosition[1]]
    down = [currentPosition[0],1 + currentPosition[1]]

    if value == 9:
        print(currentPosition)
        scoreValues[start[0], start[1]] += 1
        return


    moveright = can_move_direction(right, value)
    moveleft = can_move_direction(left, value)
    moveup = can_move_direction(up, value)
    movedown = can_move_direction(down, value)

    print(value)
    if moveleft:
        check_around_position(left, value+1, start)
    if moveright:
        check_around_position(right, value+1, start)
    if moveup:
        check_around_position(up, value+1, start)
    if movedown:
        check_around_position(down, value+1, start)

def can_move_direction(currentPosition, value):
    if  valid_position(currentPosition) and inputList[currentPosition[1]][currentPosition[0]] == value+1:
        return True
    else:
        return False

def valid_position(currentPosition):
    if (currentPosition[1] < len(inputList) and currentPosition[0] < len(inputList[0])) and (currentPosition[0] >= 0 and currentPosition[1] >= 0):
        return True
    else:
        return False


with open(TEXT_FILE) as f:
    y = 0
    for line in f:
        tempList = []
        line = line.replace("\n", "")
        for x,c in enumerate(line):
            c = int(c)
            if c == 0:
                startPositions.append([x,y])
                scoreValues[x, y] = 0
            tempList.append(c)
        inputList.append(tempList)
        y += 1

for x in inputList:
    print(x)



for startposition in startPositions:
    print(startposition)
    check_around_position(startposition, 0, startposition)

print(scoreValues)



