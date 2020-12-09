#include "Day9.h"

Day9::Day9(std::vector<std::string>* input) {
	this->input = *input;
}

void Day9::Calculate() {
	std::vector<long long> ints;

	for (int i = 0; i < 25; i++) {
		ints.push_back(std::stoll (input[i]));
	}

	long long invalid = -1;

	for (int i = 25; i < input.size(); i++) {
		long long target = std::stoll(input[i]);

		bool canBeMade = false;

		for (int j = ints.size() - 25; j < ints.size() - 1; j++) {
			for (int k = j + 1; k < ints.size(); k++) {
				if (ints[j] + ints[k] == target) {
					canBeMade = true;
					break;
				}
			}

			if (canBeMade)
				break;
		}

		if (!canBeMade) {
			invalid = target;
			resultOne = std::to_string(target);
			break;
		}

		ints.push_back(target);
	}

	ints.clear();

	for (const std::string& line : input)
		ints.push_back(std::stoll(line));

	bool setFound = false;
	int lookSize = 2;

	while (!setFound) {
		for (int i = 0; i < ints.size() - lookSize; i++) {
			int sum = 0;

			for (int j = i; j < i + lookSize; j++)
				sum += ints[j];

			if (sum == invalid) {
				setFound = true;
				long long largest = -1;
				long long smallest = LLONG_MAX;
				for (int j = i; j < i + lookSize; j++) {
					largest = std::max(largest, ints[j]);
					smallest = std::min(smallest, ints[j]);
				}

				resultTwo = std::to_string(smallest + largest);
			}
		}

		lookSize++;
	}
}
