from pathlib import Path
ROOT_DIR = Path(__file__).parent
TEXT_FILE = ROOT_DIR / 'input.txt'

freshtotal = 0
checkFresh = True
freshIngredients = []

with open(TEXT_FILE) as f:
    for line in f:
        line = line.replace("\n", "")

        if checkFresh:
            if line == "":
                checkFresh = False
                print("damn")

            if checkFresh:
                splits = line.split("-")
                num1 = int(splits[0])
                num2 = int(splits[1])

                freshIngredients.append([num1, num2])
        else:
            num = int(line)
            print(line)
            for ingredient in freshIngredients:
                if ingredient[0] < num < ingredient[1]:
                    freshtotal += 1
                    break

totalsumingredients = 0
somethingchanged = True
changed = 0
while somethingchanged:
    changed = 0
    for i in range(len(freshIngredients)):
        for o in range(len(freshIngredients)):
            if freshIngredients[o][0] < freshIngredients[i][0] < freshIngredients[o][1]:
                freshIngredients[i][0] = freshIngredients[o][1]+1
                changed += 1
    if changed > 0:
        somethingchanged = True
    else:
        somethingchanged = False

for ingredient in freshIngredients:
    if ingredient[1]-ingredient[0] != 0:
        totalsumingredients += ingredient[1]-ingredient[0]+1
        print(ingredient, ingredient[1]-ingredient[0]+1)

print(freshIngredients)
print(freshtotal)
print(totalsumingredients)