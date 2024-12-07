import hashlib


puzzle = "ckczppom"

number = 0


while(True):
    hel = hashlib.md5((puzzle + str(number)).encode('utf-8')).hexdigest()

    if(hel[:6] == "000000"):
        break
    number += 1



print(hel)
print(number)