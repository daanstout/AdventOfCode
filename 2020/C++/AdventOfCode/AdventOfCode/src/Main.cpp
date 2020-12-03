#include <string>
#include <fstream>
#include <iostream>

#include "Days/Day1.h"
#include "Days/Day2.h"
#include "Days/Day3.h"

std::vector<std::string>* ImportFile(const std::string& path);

void day1();
void day2();
void day3();

int main() {
	day1();
	day2();
	day3();

	std::getchar();
}

std::vector<std::string>* ImportFile(const std::string& path) {
	std::vector<std::string>* input = new std::vector<std::string>();
	std::ifstream stream(path);
	std::string line;

	while (getline(stream, line)) {
		input->push_back(line);
	}

	return input;
}

void day1() {
	std::cout << "Day 1" << std::endl;
	std::vector<std::string>* input = ImportFile("src/Input/Day 1.txt");
	Day1 day(input);
	day.Calculate();
	day.Print();
	std::cout << std::endl;
}

void day2() {
	std::cout << "Day 2" << std::endl;
	std::vector<std::string>* input = ImportFile("src/Input/Day 2.txt");
	Day2 day(input);
	day.Calculate();
	day.Print();
	std::cout << std::endl;
}

void day3() {
	std::cout << "Day 3" << std::endl;
	std::vector<std::string>* input = ImportFile("src/Input/Day 3.txt");
	Day3 day(input);
	day.Calculate();
	day.Print();
	std::cout << std::endl;
}