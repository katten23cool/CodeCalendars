from pathlib import Path
ROOT_DIR = Path(__file__).parent
TEXT_FILE = ROOT_DIR / 'input.txt'

dict = {}
areas = []
Map = []
class Area:
    def __init__(self, letter):
        self.letter = letter
        self.dict = {}

    def letter_in(self, pos):
        if pos in self.dict:
            return True
        return False

    def posindict(self, pos):
        if pos in self.dict:
            return True
        return False
    def addtodict(self, pos):
        if pos in self.dict:
            self.dict[pos] += 1
        else:
            self.dict[pos] = 1


with open(TEXT_FILE) as f:
    for line in f:
        line = line.replace("\n", "")
        templ = []
        for c in line:
            templ.append(c)
        Map.append(templ)

print(Map)
def checkbeside(area, position):
    pos_x = (position[0] + 1, position[1])
    pos_y = (position[0], position[1] + 1)
    if pos_x[0] < len(Map[0]) and pos_x not in dict:
        letterX = Map[pos_x[1]][pos_x[0]]
        if letterX is area.letter:
            dict[pos_x] = 1
            area.addtodict(pos_x)
            checkbeside(area, pos_x)
    if pos_y[1] < len(Map) and pos_y not in dict:
        letterY = Map[pos_y[1]][pos_y[0]]
        if letterY is area.letter:
            dict[pos_y] = 1
            area.addtodict(pos_y)
            checkbeside(area, pos_y)

nb_areas = 0
def findarea(letter, startpos): #then skip all of the same letters till you find another
    area = Area(letter)
    checkbeside(area, startpos)

    return area

x = 0
y = 0
for lst in Map:
    x = 0
    for ltr in lst:
        rea = findarea(ltr, (x, y))
        if len(rea.dict) > 0:
            areas.append(rea)
        x += 1
    y += 1

for are in areas:
    print(are.letter)