#include "Day2.h"

#include <iostream>

Day2::Day2(std::vector<std::string>* input) {
	this->input = *input;
}

void Day2::Calculate() {
	int CorrectOne = 0;
	int CorrectTwo = 0;

	for (const std::string& line : input) {
		size_t minCount, maxCount;

		std::stringstream ss;
		ss << line;

		auto spl1 = Split(ss, ' ');

		{
			ss.clear();
			ss << spl1->at(0);
			auto spl2 = Split(ss, '-');

			minCount = std::stoi(spl2->at(0));
			maxCount = std::stoi(spl2->at(1));
		}

		int occurance = CountChar(spl1->at(2), spl1->at(1)[0]);

		if (occurance >= minCount && occurance <= maxCount)
			CorrectOne++;

		bool isFirst = spl1->at(2)[minCount - 1] == spl1->at(1)[0];
		bool isSecond = spl1->at(2)[maxCount - 1] == spl1->at(1)[0];
		if (isFirst != isSecond)
			CorrectTwo++;
	}

	resultOne = std::to_string(CorrectOne);
	resultTwo = std::to_string(CorrectTwo);
}

int Day2::CountChar(const std::string str, char c) {
	int count = 0;

	for (auto chr : str) {
		if (chr == c)
			count++;
	}

	return count;
}
