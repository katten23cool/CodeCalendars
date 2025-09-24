from pathlib import Path
ROOT_DIR = Path(__file__).parent
TEXT_FILE = ROOT_DIR / 'input.txt'

dict = {}
areas = []
class Area:
    def __init__(self, letter):
        self.letter = letter
        self.dict = {}

    def letter_in(self, pos):
        if pos in self.dict:
            return True
        return False


with open(TEXT_FILE) as f:
    for line in f:
        line = line.replace("\n", "")
        for c in line:
            if c in dict:
                dict[c] += 1
            else:
                dict[c] = 1


nb_areas = 0
def findarea():
    pass
print(dict)