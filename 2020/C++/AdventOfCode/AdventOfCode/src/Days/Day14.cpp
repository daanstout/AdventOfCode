#include "Day14.h"

constexpr unsigned long long memorySize = 99999;

Day14::Day14(std::vector<std::string>* input) {
	this->input = *input;
}

void Day14::Calculate() {
	unsigned long long* memory = new unsigned long long[memorySize];

	for (unsigned long long i = 0ULL; i < memorySize; i++)
		memory[i] = 0ULL;

	unsigned long long orBitmask = 0x0; // Set the bits that need to be 1 (Default: all 0)
	unsigned long long andBitmask = 0x0; // Set the bits that need to be 0 (Default: all 1)

	std::vector<unsigned long long> mems;

	for (const std::string& line : input) {
		std::vector<std::string>* spl1 = Split(line, " = ");
		if (line.substr(0, 3) == "mas") {
			std::string& mask = spl1->at(1);
			size_t maskOppositeEnd = mask.size() - 1;
			orBitmask = 0x0;
			andBitmask = ULLONG_MAX;
			for (size_t i = 0; i < mask.size(); i++) {
				if (mask[maskOppositeEnd - i] == 'X')
					continue;

				if (mask[maskOppositeEnd - i] == '1')
					orBitmask |= (1ULL << i);

				if (mask[maskOppositeEnd - i] == '0')
					andBitmask &= ~(1ULL << i);
			}
		} else if (line.substr(0, 3) == "mem") {
			std::string addressStr = spl1->at(0).substr(4, spl1->at(0).size() - 5);
			unsigned long long address = std::stoull(addressStr);
			unsigned long long value = std::stoull(spl1->at(1));

			value |= orBitmask;
			value &= andBitmask;

			memory[address] = value;

			if (!std::count(mems.begin(), mems.end(), address))
				mems.push_back(address);
		} else {
			std::cout << "Unknown line: " << line << std::endl;
		}
	}

	unsigned long long result = 0ULL;

	for (unsigned long long address : mems) {
		result += memory[address];
	}

	resultOne = std::to_string(result);

	for (unsigned long long i = 0ULL; i < memorySize; i++)
		memory[i] = 0ULL;

	std::vector<unsigned long long> masks;
}
