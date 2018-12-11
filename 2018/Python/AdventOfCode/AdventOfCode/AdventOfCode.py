#path = "C:\\Users\\Daan\\Desktop\\AdventOfCode\\2018\\Input\\"
path = "C:\\Users\\daans\\Desktop\\AdventOfCode\\2018\\Input\\"

def Day1_Question1():
	print("Day 1 - Question 1")

	file = open(path + "Advent of Code Calibration values.txt", "r")
	input = ""
	if file.mode == 'r':
		input = file.read()
	else:
		return

	inputs = input.split('\n')

	frequency = 0

	for change in inputs:
		action = change[0]
		if action == '+':
			frequency += int(change[1:])
		elif action == '-':
			frequency -= int(change[1:])

	print("Answer Q1.1: " + str(frequency) + '\n')

def Day1_Question2():
	print("Day 1 - Question 2")

	file = open(path + "Advent of Code Calibration values.txt", "r")
	input = ""
	if file.mode == 'r':
		input = file.read()
	else:
		return

	inputs = input.split('\n')

	frequency = 0
	usedFrequencies = []
	doubleFound = False

	while not doubleFound:
		for change in inputs:
			action = change[0]
			if action == '+':
				frequency += int(change[1:])
			elif action == '-':
				frequency -= int(change[1:])

			if frequency in usedFrequencies:
				doubleFound = True
				break
			else:
				usedFrequencies.append(frequency)

	print("Answer Q1.2: " + str(frequency) + '\n')

def Day2_Question1():
    print("Day 2 - Question 1")

    file = open(path + "Advent of Code Box Ids.txt", "r")
    input = ""
    if file.mode == 'r':
        input = file.read()
    else:
        return
    
    inputs = input.split('\n')

    twice = 0
    thrice = 0

    for id in inputs:
        existOnce = []
        existTwice = []
        existThrice = []

        for char in id:
            if char in existThrice:
                existThrice.remove(char)
            elif char in existTwice:
                existTwice.remove(char)
                existThrice.append(char)
            elif char in existOnce:
                existOnce.remove(char)
                existTwice.append(char)
            else:
                existOnce.append(char)

        if len(existThrice) >= 1:
            thrice += 1

        if len(existTwice) >= 1:
            twice += 1

    print("Answer Q2.1: " + str(twice * thrice) + "\n")
    print("Day 2 - Question 2:")
    
    for id in inputs:
        for check in inputs:
            differ = False
            next = False
            for index in range(0, len(id)):
                if id[index] != check[index]:
                    if differ:
                        next = True
                        break
                    else:
                        differ = True
            if differ and not next:
                print("Answer Q2.2: The strings are:\n" + id + "\n" + check + "\n")
                return
    return

if(__name__ == "__main__"):
    print("Advent of Code - Year 2018")
	#Day1_Question1()
	#Day1_Question2()
    Day2_Question1()
