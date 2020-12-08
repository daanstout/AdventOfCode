#include "Day1.h"

#include <iostream>
#include <algorithm>
#include <sstream>

Day1::Day1(std::vector<std::string>* input) {
	std::sort(input->begin(), input->end());

	this->input = *input;
}

void Day1::Calculate() {
	auto begin = input.begin();
	auto end = input.end();
	end--;

	int firstValue;
	int lastValue;

	while (begin != end) {
		firstValue = std::stoi(begin->data());
		lastValue = std::stoi(end->data());

		if (firstValue + lastValue == 2020) {
			std::stringstream ss;
			ss << "Values found: " << begin->data() << " and " << end->data() << ". Multiplied: " << firstValue * lastValue;
			resultOne = ss.str();
		}

		if (firstValue + lastValue > 2020)
			end--;
		else
			begin++;
	}

	int one, two, three;

	for (int i = 0; i < input.size(); i++) {
		one = std::stoi(input[i]);
		for (int j = 1; j < input.size(); j++) {
			two = std::stoi(input[j]);
			for (int k = 2; k < input.size(); k++) {
				if (i == j || i == k || j == k)
					continue;
				three = std::stoi(input[k]);

				if (one + two + three == 2020) {
					std::stringstream ss;
					ss << "Values found: " << one << ", " << two << ", and " << three << ". Multiplied: " << one * two * three;
					resultTwo = ss.str();
				}
			}
		}
	}
}
