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
            0 + 444

        i = 0
        while position < 0 or position > 99:
            if position < 0:
                position = 100 + position
            if position > 99:
                position = position - 100

            if (startPosition != 0) and (position != 0) or abs(numer)> 100:
                password2 += 1
                print("---0---", end=" ")
            i+=1



        if position == 0 and abs(numer) < 100:
            password += 1
            password2 += 1

        print(position)
        print(f"Password2: {password2}")  # Too high 6924, 5895. Close 4790, 5886


print(f"Password: {password}")
print(f"Password2: {password2}") #Too high 6924, 5895. Close 4790, 5886

#to test: 6072