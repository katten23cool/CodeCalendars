from pathlib import Path
ROOT_DIR = Path(__file__).parent
TEXT_FILE = ROOT_DIR / 'input.txt'

dict = {}
areas = []
map = []
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
        map.append(templ)

print(map)
def checkbeside(area, position):
    posX = [position[0] + 1, position[1]]
    posY = [position[0], position[1]+ 1]
    letterX = map[posX[0]][posX[1]]
    letterY = map[posY[0]][posY[1]]
    if letterX is area.letter:
        area.addtodict(posX)
        checkbeside(area, letterX)
    if letterY is area.letter:
        area.addtodict(posY)
        checkbeside(area, letterY)

nb_areas = 0
def findarea(letter, startpos):
    area = Area(letter)
    checkbeside(area, startpos)

    return area

print(findarea("A", [0,0]).dict)

print(dict)