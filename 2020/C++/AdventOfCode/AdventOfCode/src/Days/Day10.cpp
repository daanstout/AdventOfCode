#include "Day10.h"

#include <algorithm>

Day10::Day10(std::vector<std::string>* input) {
	this->input = *input;
}

void Day10::Calculate() {
	std::vector<int> jolts;

	jolts.push_back(0);

	for (const std::string& line : input)
		jolts.push_back(std::stoi(line));

	std::sort(jolts.begin(), jolts.end());

	int sizeDiff[3] = { 0 };

	for (size_t i = 0; i < jolts.size() - 1; i++) {
		sizeDiff[jolts[i + 1] - jolts[i] - 1]++;
	}

	sizeDiff[2]++;

	resultOne = std::to_string(sizeDiff[0] * sizeDiff[2]);

	// The solution below was taken from the /r/adventofcode reddit as I wasn't able to figure it out
	long long* arrangements = new long long[jolts.size()];

	for (size_t i = 0; i < jolts.size(); i++)
		arrangements[i] = 0;

	arrangements[0] = 1;

	for (size_t i = 0; i < jolts.size(); i++) {
		for (size_t j = i + 1; j < jolts.size(); j++) {
			if (jolts[j] - jolts[i] > 3)
				break;
			arrangements[j] += arrangements[i];
		}
	}

	resultTwo = std::to_string(arrangements[jolts.size() - 1]);
}
