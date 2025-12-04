from pathlib import Path
ROOT_DIR = Path(__file__).parent
TEXT_FILE = ROOT_DIR / 'input.txt'

global position

position = 50
startPosition = 50
password = 0
password2 = 0


with open(TEXT_FILE) as f:
    for line in f:
        line = line.replace("\n", "")

        numer = int(line[1:])
        direction = line[0]
        startPosition = position

        if direction == "L":
            position -= numer
            print(f"{startPosition}-{numer} =", end=" ")
        else:
            position += numer
            print(f"{startPosition}+{numer} =", end=" ")

        while position < 0 or position > 99:
            if position < 0:
                position = 100 + position
            if position > 99:
                position = position - 100
                print("---0---", end=" ")

                #yeah it donot eok


        if position == 0:
            password2 += 1

        print(position)
        print(f"Password2: {password2}")


print(f"Password: {password}")
print(f"Password2: {password2}")

#answer: 5892