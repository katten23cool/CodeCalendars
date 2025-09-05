from pathlib import Path
ROOT_DIR = Path(__file__).parent
TEXT_FILE = ROOT_DIR / 'input.txt'

with open(TEXT_FILE) as f:
    for line in f:
        line = line.replace("\n", "")
        print()

