#include <string>
#include <fstream>
#include <iostream>

#include "Days/Day1.h"
#include "Days/Day2.h"
#include "Days/Day3.h"
#include "Days/Day4.h"
#include "Days/Day5.h"
#include "Days/Day6.h"
#include "Days/Day7.h"
#include "Days/Day8.h"
#include "Days/Day9.h"
#include "Days/Day10.h"
#include "Days/Day11.h"
#include "Days/Day12.h"
#include "Days/Day13.h"

std::vector<std::string>* ImportFile(const std::string& path);

template<typename T>
void day(int d, const std::string& file);

int main() {
	day<Day1>(1, "Day 1.txt");
	day<Day2>(2, "Day 2.txt");
	day<Day3>(3, "Day 3.txt");
	day<Day4>(4, "Day 4.txt");
	day<Day5>(5, "Day 5.txt");
	day<Day6>(6, "Day 6.txt");
	day<Day7>(7, "Day 7.txt");
	day<Day8>(8, "Day 8.txt");
	day<Day9>(9, "Day 9.txt");
	day<Day10>(10, "Day 10.txt");
	day<Day11>(11, "Day 11.txt");
	day<Day12>(12, "Day 12.txt");
	day<Day13>(13, "Day 13.txt");

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

template<typename T>
void day(const int d, const std::string& file) {
	std::cout << "Day " << d << std::endl;
	std::vector<std::string>* input = ImportFile("src/Input/" + file);
	T day(input);
	day.Calculate();
	day.Print();
	std::cout << std::endl;
}