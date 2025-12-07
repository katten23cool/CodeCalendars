from pathlib import Path
ROOT_DIR = Path(__file__).parent
TEXT_FILE = ROOT_DIR / 'input.txt'

iL = []
totalmath = 0


with open(TEXT_FILE) as f:
    for line in f:
        line = line.replace("\n", "")
        tplst = line.split(" ")

        iL.append(tplst)


for lin in iL:
    print(lin)
    print(len(lin))

for i in range(len(iL[0])):
    num1 = int(iL[0][i])
    num2 = int(iL[1][i])
    num3 = int(iL[2][i])
    num4 = int(iL[3][i])
    symbol = iL[4][i].strip()

    num = 0
    if symbol == "*":
        num += (num1*num2*num3*num4)
    elif symbol == "+":
        num += (num1+num2+num3+num4)
    print(num)
    totalmath += num
    print(i)


print(totalmath)

totalmath2 = 0

for i in range(len(iL[0])):
    nums = []
    symbol = iL[4][i].strip()
    for n in range(4):
        tempnum = ""
        for l in range(4):
            if len(iL[l][i]) > n:
                tempnum += iL[l][i][-1-n]
        if tempnum == "":
            if symbol == "*":
                tempnum = 1
            else:
                tempnum = 0
        nums.append(int(tempnum))

    print(nums)

    num = 0
    if symbol == "*":
        num += (nums[0]*nums[1]*nums[2]*nums[3])
    elif symbol == "+":
        num += (nums[0]+nums[1]+nums[2]+nums[3])
    print(num)
    totalmath2 += num

print(totalmath2)