path = "C:\\Users\\Daan\\Desktop\\AdventOfCode\\2018\\Input\\"

def Day1_Question1():
	print("Day 1 - Question 1")

	file = open(path + "Advent of Code Calibration values.txt", "r")
	input = ""
	if(file.mode == 'r'):
		input = file.read()
	else:
		return

	inputs = input.split('\n')

	frequency = 0

	for change in inputs:
		action = change[0]
		if(action == '+'):
			frequency += int(change[1:])
		elif(action == '-'):
			frequency -= int(change[1:])

	print("Answer Q1.1: " + str(frequency) + '\n')


def Day1_Question2():
	print("Day 1 - Question 2")

	file = open(path + "Advent of Code Calibration values.txt", "r")
	input = ""
	if(file.mode == 'r'):
		input = file.read()
	else:
		return

	inputs = input.split('\n')

	frequency = 0
	usedFrequencies = []
	doubleFound = False

	while(not doubleFound):
		for change in inputs:
			action = change[0]
			if(action == '+'):
				frequency += int(change[1:])
			elif(action == '-'):
				frequency -= int(change[1:])

			if(frequency in usedFrequencies):
				doubleFound = True;
				break;
			else:
				usedFrequencies.append(frequency)

	print("Answer Q1.2: " + str(frequency) + '\n')


if(__name__ == "__main__"):
	print("Advent of Code - Year 2018")
	Day1_Question1()
	Day1_Question2()



