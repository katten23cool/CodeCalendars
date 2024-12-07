
Totalsq = 0
Totalribbon = 0


with open("Day 2/input.txt") as f:
    for line in f:
        line = line.rstrip("\n")
        x = line.split("x")

        l = int(x[0])
        w = int(x[1])
        h = int(x[2])

        lw = 2*l*w
        wh = 2*w*h
        hl = 2*h*l

        spare = int(min(lw/2, wh/2, hl/2))

        values = sorted([l,w,h])
        ribbon = 2 * values[0] + 2 * values[1]
        bow = l*w*h
        Totalribbon += ribbon + bow

        Sq = lw + wh + hl + spare
        Totalsq += Sq

print("Total sq is: ", Totalsq)
print("Total ribbon is:", Totalribbon)