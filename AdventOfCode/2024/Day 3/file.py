TotalMultiplications = 0

example = "mul(,)"
txt = ""
numbers = ""

example1 = "do()"
example2 = "don't()"
dotext = ""
do = True

with open("Day 3/input.txt") as f:
    for line in f:
        txt = ""
        numbers = ""
        for c in line:
            dotext += c
            if(dotext == example1[:len(dotext)]):
                do = True
            elif(dotext == example2[:len(dotext)]):
                do = False
            else:
                dotext = ""
            #print(dotext)

            if(do):
                txt += c
                if(txt == example[:len(txt)]):
                    if(txt[len(txt) -1] == ","):
                        numbers +=","
                    if(txt == example):
                        nums = numbers.split(",")
                        #print(nums)
                        TotalMultiplications += (int(nums[0]) * int(nums[1]))
                        numbers = ""
                        txt = ""            
            
                elif(txt[len(txt) -1].isdigit()):
                    numbers += txt[len(txt) -1]
                    txt = txt[:len(txt) -1]
                elif(len(txt) >= len(example)):
                    txt = ""
                    numbers = ""
                else:
                    #print("No", txt)
                    txt = ""
                    numbers = ""
            else:
                txt = ""
            # print(txt, example[:len(txt)])




print(TotalMultiplications)