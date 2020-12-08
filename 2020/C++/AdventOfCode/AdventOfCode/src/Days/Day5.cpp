#include "Day5.h"

Day5::Day5(std::vector<std::string>* input) {
	this->input = *input;
}

void Day5::Calculate() {
	int heighestID = 0;

	bool seats[127][7] = { false };
	bool ids[1023] = { false };

	for (const std::string& line : input) {
		int row = 0;
		int column = 0;

		for (int i = 0; i < 7; i++)
			if (line[i] == 'B')
				row |= (1 << (7 - i - 1));


		for (int i = 0; i < 3; i++)
			if (line[i + 7] == 'R')
				column |= (1 << (3 - i - 1));

		seats[row][column] = true;

		int id = row * 8 + column;

		ids[id] = true;

		if (id > heighestID)
			heighestID = id;
	}

	resultOne = std::to_string(heighestID);

	for (int row = 0; row < 127; row++) {
		for (int column = 0; column < 7; column++) {
			if (!seats[row][column]) {
				int id = row * 8 + column;
				if (!ids[id + 1])
					continue;
				if (!ids[id - 1])
					continue;

				resultTwo = std::to_string(id);
				return;
			}
		}
	}
}
