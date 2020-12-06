#include "Day6.h"

Day6::Day6(std::vector<std::string>* input) {
	this->input = std::make_unique<std::vector<std::string>>(*input);
}

void Day6::Calculate() {
	int results[26] = { 0 };
	int groupSize = 0;
	int sumOne = 0;
	int sumTwo = 0;

	for (const std::string& line : *input) {
		if (line == "" && groupSize) {
			for (int i = 0; i < 26; i++) {
				sumOne += results[i] != 0;
				sumTwo += (results[i] == groupSize);
				results[i] = 0;
			}

			groupSize = 0;
		} else
			groupSize++;

		for (int i = 0; i < line.size(); i++) {
			results[line[i] - 'a']++;
		}
	}

	if (groupSize) {
		for (int i = 0; i < 26; i++) {
			sumOne += results[i] != 0;
			sumTwo += (results[i] == groupSize);
		}
	}

	resultOne = std::make_unique<std::string>(std::to_string(sumOne));
	resultTwo = std::make_unique<std::string>(std::to_string(sumTwo));
}
