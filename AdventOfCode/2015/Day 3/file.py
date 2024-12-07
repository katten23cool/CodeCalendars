housegrid = {}

# Starting coordinates
x = 0
y = 0

x1 = 0
y1 = 0

real = True

with open("Day 3/input.txt") as f:
    for line in f:
        for c in line:
            if(real): 
                if (x, y) not in housegrid:
                    housegrid[(x, y)] = 0
                if c == ">":
                    x += 1
                elif c == "<":
                    x -= 1
                elif c == "^":
                    y -= 1
                elif c == "v":
                    y += 1
                if (x, y) not in housegrid:
                    housegrid[(x, y)] = 1
                housegrid[(x, y)] += 1

                real = False
            else:
                if (x1, y1) not in housegrid:
                    housegrid[(x1, y1)] = 0
                if c == ">":
                    x1 += 1
                elif c == "<":
                    x1 -= 1
                elif c == "^":
                    y1 -= 1
                elif c == "v":
                    y1+= 1
                if (x1, y1) not in housegrid:
                    housegrid[(x1, y1)] = 1
                housegrid[(x1, y1)] += 1
                real = True


print(len(housegrid))
