from pathlib import Path

ROOT_DIR = Path(__file__).parent
TEXT_FILE = ROOT_DIR / 'input.txt'

fresh_ranges = []
checkFresh = True
freshtotal = 0
totalsumingredients = 0

with open(TEXT_FILE) as f:
    for line in f:
        line = line.strip()
        if checkFresh:
            if line == "":
                checkFresh = False
                continue

            a, b = map(int, line.split("-"))
            fresh_ranges.append((a, b))

        else:
            num = int(line)
            for a, b in fresh_ranges:
                if a <= num <= b:
                    freshtotal += 1
                    break

# --- MERGE RANGES CORRECTLY ---
fresh_ranges.sort()  # sort by start
merged = []

for start, end in fresh_ranges:
    if not merged:
        merged.append([start, end])
    else:
        last = merged[-1]
        if start <= last[1] + 1:  # Overlapping or touching
            last[1] = max(last[1], end)
        else:
            merged.append([start, end])

# compute total unique range length
for a, b in merged:
    totalsumingredients += b - a + 1

print("Merged ranges:", merged)
print("Fresh total:", freshtotal)
print("Total summed range:", totalsumingredients)

#397665529473088