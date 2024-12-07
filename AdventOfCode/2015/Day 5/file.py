Allowed = ["a", "e", "i", "o", "u"]
Notallowed = ["ab", "cd", "pq", "xy"]

Nice = 0

with open("Day 5/input.txt") as f:
    for line in f:
        Vowels = 0
        ContainsDoubble = False
        NotContains = True

        Previous = ""
        PrePrevious = ""

        for c in line:
            if(c == PrePrevious and c != Previous):
                ContainsDoubble = True
            if(c in Allowed):
                Vowels += 1
               # print(c)
            Previous = c

        for Nt in Notallowed:
            if(Nt in line):
                NotContains = False
                break

        


        if(Vowels >= 3 and NotContains and ContainsDoubble):
            Nice += 1


print(Nice, "strings are nice")