#include "Day4.h"

#include <iostream>
#include <stdint.h>

Day4::Day4(std::vector<std::string>* input) {
	this->input = *input;
}

void Day4::Calculate() {
	std::string required[] = {
		"byr", "iyr", "eyr", "ecl", "pid", "hcl", "hgt"
	};

	int correctOne = 0;
	int correctTwo = 0;

	uint8_t byr = 0x01;
	uint8_t iyr = 0x02;
	uint8_t eyr = 0x04;
	uint8_t ecl = 0x08;
	uint8_t pid = 0x10;
	uint8_t hcl = 0x20;
	uint8_t hgt = 0x40;

	uint8_t containsOne = 0;
	uint8_t containsTwo = 0;

	std::string cur;
	for (int i = 0; i < input.size(); i++) {
		cur = input[i];

		if (cur == "") {
			if (containsOne == 0b01111111)
				correctOne++;
			if (containsTwo == 0b01111111)
				correctTwo++;
			containsOne = 0;
			containsTwo = 0;
			continue;
		}

		std::vector<std::string>* spl1 = Split(cur, ' ');
		for (std::string& splStr : *spl1) {
			std::vector<std::string>* spl2 = Split(splStr, ':');
			if (spl2->at(0) == "byr") {
				containsOne |= byr;
				std::string valS = spl2->at(1);
				if (valS.size() != 4)
					continue;
				int valI = std::stoi(valS);
				if (valI >= 1920 && valI <= 2002)
					containsTwo |= byr;
			} else if (spl2->at(0) == "iyr") {
				containsOne |= iyr;
				std::string valS = spl2->at(1);
				if (valS.size() != 4)
					continue;
				int valI = std::stoi(valS);
				if (valI >= 2010 && valI <= 2020)
					containsTwo |= iyr;
			} else if (spl2->at(0) == "eyr") {
				containsOne |= eyr;
				std::string valS = spl2->at(1);
				if (valS.size() != 4)
					continue;
				int valI = std::stoi(valS);
				if (valI >= 2020 && valI <= 2030)
					containsTwo |= eyr;
			} else if (spl2->at(0) == "hgt") {
				containsOne |= hgt;
				std::string valS = spl2->at(1);
				std::string valStart = valS.substr(0, valS.size() - 2);
				std::string valEnd = valS.substr(valS.size() - 2, 2);
				if (valEnd == "cm") {
					int valI = std::stoi(valStart);
					if (valI >= 150 && valI <= 193)
						containsTwo |= hgt;
				} else if (valEnd == "in") {
					int valI = std::stoi(valStart);
					if (valI >= 59 && valI <= 76)
						containsTwo |= hgt;
				}
			} else if (spl2->at(0) == "hcl") {
				containsOne |= hcl;
				std::string valS = spl2->at(1);
				if (valS.size() != 7)
					continue;
				if (valS[0] != '#')
					continue;
				bool valid = true;
				for (int i = 1; i < 7; i++)
					if (!((valS[i] >= '0' && valS[i] <= '9') || (valS[i] >= 'a' && valS[i] <= 'f')))
						valid = false;
				if (valid)
					containsTwo |= hcl;
			} else if (spl2->at(0) == "ecl") {
				containsOne |= ecl;
				std::string valS = spl2->at(1);
				if (valS == "amb" || valS == "blu" || valS == "brn" || valS == "gry" || valS == "grn" || valS == "hzl" || valS == "oth")
					containsTwo |= ecl;
			} else if (spl2->at(0) == "pid") {
				containsOne |= pid;
				std::string valS = spl2->at(1);
				if (valS.size() != 9)
					continue;
				bool valid = true;
				for (int i = 0; i < 9; i++)
					if (!(valS[i] >= '0' && valS[i] <= '9'))
						valid = false;
				if (valid)
					containsTwo |= pid;
			}
		}
	}

	if (containsOne == 0b01111111)
		correctOne++;
	if (containsTwo == 0b01111111)
		correctTwo++;

	resultOne = std::to_string(correctOne);
	resultTwo = std::to_string(correctTwo);
}
