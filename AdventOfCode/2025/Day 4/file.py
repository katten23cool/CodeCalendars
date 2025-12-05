from pathlib import Path
ROOT_DIR = Path(__file__).parent
TEXT_FILE = ROOT_DIR / 'input.txt'

map = []
totalRolls = 0

with open(TEXT_FILE) as f:
    for line in f:
        line = line.replace("\n", "")
        lists = []
        for c in line:
            lists.append(c)
        map.append(lists)

def amountofpaperaround(posx, posy):
    amount = 0

    for x in range(posx-1, posx+2):
        if x < 0 or x >= len(map[0]):
            continue

        for y in range(posy-1, posy+2):
            if y < 0 or y >= len(map):
                continue

            if map[y][x] != "." and not (x is posx and y is posy):
                amount += 1

    return amount



removed = True
while removed:
    changed = []
    y = 0
    for yLine in map:
        x = 0
        for xLine in yLine:
            if amountofpaperaround(x, y) < 4 and map[y][x] == "@":
                totalRolls += 1
                changed.append([[y],[x]])
                # print(x, y)
            x += 1
            #print(xLine, end="")
        y += 1
        #print()

    if len(changed) <= 0:
        removed = False

    for place in changed:
        map[place[0][0]][place[1][0]] = "."


print(totalRolls)