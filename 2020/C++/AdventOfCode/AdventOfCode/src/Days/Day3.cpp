#include "Day3.h"

#include <iostream>

Day3::Day3(std::vector<std::string>* input) {
	this->input = std::make_unique<std::vector<std::string>>(*input);
}

void Day3::Calculate() {
	long long num11 = CountTrees(1, 1);
	long long num31 = CountTrees(3, 1);
	long long num51 = CountTrees(5, 1);
	long long num71 = CountTrees(7, 1);
	long long num12 = CountTrees(1, 2);

	resultOne = std::make_unique<std::string>(std::to_string(num31));

	resultTwo = std::make_unique<std::string>(std::to_string(num11 * num31 * num51 * num71 * num12));
}

long long Day3::CountTrees(int slopeR, int slopeD) {
	int numRows = input->size();
	int numColumns = input->at(0).size();

	int currentRow = 0, currentColumn = 0;

	long long numTrees = 0;

	while (currentRow < numRows) {
		if (input->at(currentRow)[currentColumn] == '#')
			numTrees++;

		currentRow += slopeD;
		currentColumn += slopeR;

		currentColumn %= numColumns;
	}

	return numTrees;
}
