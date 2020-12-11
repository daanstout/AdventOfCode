#include "Day11.h"

Day11::Day11(std::vector<std::string>* input) {
	this->input = *input;
}

void Day11::Calculate() {
	rows = input.size();
	columns = input[0].size();

	Seat* state = new Seat[rows];

	for (size_t i = 0; i < rows; i++)
		state[i].current = state[i].next = input[i];

	bool isChanging = true;

	while (isChanging) {
		isChanging = false;

		for (size_t row = 0; row < rows; row++) {
			for (size_t column = 0; column < columns; column++) {
				if (state[row].current[column] == '.')
					continue;

				int numOcc = CountOccupiedNeighbours(state, row, column);

				if (numOcc == 0)
					state[row].next[column] = '#';
				else if (numOcc >= 4)
					state[row].next[column] = 'L';
			}
		}

		for (size_t i = 0; i < rows; i++) {
			for (size_t j = 0; j < columns; j++) {
				isChanging |= state[i].Update();
			}
		}
	}

	int resOne = 0;

	for (size_t i = 0; i < rows; i++)
		for (size_t j = 0; j < columns; j++)
			resOne += state[i].current[j] == '#';

	// Strangely, our result of our actual input is 1 to low. No idea why.
	resultOne = std::to_string(resOne);

	for (size_t i = 0; i < rows; i++)
		state[i].current = state[i].next = input[i];

	isChanging = true;

	while (isChanging) {
		isChanging = false;

		for (size_t row = 0; row < rows; row++) {
			for (size_t column = 0; column < columns; column++) {
				if (state[row].current[column] == '.')
					continue;

				int numOcc = CountOccupiedNeighboursAll(state, row, column);

				if (numOcc == 0)
					state[row].next[column] = '#';
				else if (numOcc >= 5)
					state[row].next[column] = 'L';
			}
		}

		for (size_t i = 0; i < rows; i++) {
			for (size_t j = 0; j < columns; j++) {
				isChanging |= state[i].Update();
			}
		}
	}

	int resTwo = 0;

	for (size_t i = 0; i < rows; i++)
		for (size_t j = 0; j < columns; j++)
			resTwo += state[i].current[j] == '#';

	resultTwo = std::to_string(resTwo);
}

int Day11::CountOccupiedNeighbours(Seat* seats, size_t row, size_t column) {
	int numOcc = 0;

	if (row > 0) {
		numOcc += seats[row - 1].current[column] == '#';

		if (column > 0)
			numOcc += seats[row - 1].current[column - 1] == '#';
		if (column < columns - 1)
			numOcc += seats[row - 1].current[column + 1] == '#';
	}
	if (row < rows - 1) {
		numOcc += seats[row + 1].current[column] == '#';

		if (column > 0)
			numOcc += seats[row + 1].current[column - 1] == '#';
		if (column < rows - 1)
			numOcc += seats[row + 1].current[column + 1] == '#';
	}

	if (column > 0)
		numOcc += seats[row].current[column - 1] == '#';
	if (column < columns - 1)
		numOcc += seats[row].current[column + 1] == '#';

	return numOcc;
}

int Day11::CountOccupiedNeighboursAll(Seat* seats, size_t row, size_t column) {
	int numOcc = 0;

	for (int row1 = row + 1; row1 < rows; row1++) {
		if (seats[row1].current[column] == '.')
			continue;

		if (seats[row1].current[column] == '#')
			numOcc++;

		break;
	}

	for (int row1 = row - 1; row1 >= 0; row1--) {
		if (seats[row1].current[column] == '.')
			continue;

		if (seats[row1].current[column] == '#')
			numOcc++;

		break;
	}

	for (int column1 = column + 1; column1 < columns; column1++) {
		if (seats[row].current[column1] == '.')
			continue;

		if (seats[row].current[column1] == '#')
			numOcc++;

		break;
	}

	for (int column1 = column - 1; column1 >= 0; column1--) {
		if (seats[row].current[column1] == '.')
			continue;

		if (seats[row].current[column1] == '#')
			numOcc++;

		break;
	}

	for (int row1 = row + 1, column1 = column + 1; row1 < rows && column1 < columns; row1++, column1++) {
		if (seats[row1].current[column1] == '.')
			continue;

		if (seats[row1].current[column1] == '#')
			numOcc++;

		break;
	}

	for (int row1 = row - 1, column1 = column + 1; row1 >= 0 && column1 < columns; row1--, column1++) {
		if (seats[row1].current[column1] == '.')
			continue;

		if (seats[row1].current[column1] == '#')
			numOcc++;

		break;
	}

	for (int row1 = row + 1, column1 = column - 1; row1 < rows && column1 >= 0; row1++, column1--) {
		if (seats[row1].current[column1] == '.')
			continue;

		if (seats[row1].current[column1] == '#')
			numOcc++;

		break;
	}

	for (int row1 = row - 1, column1 = column - 1; row1 >= 0 && column1 >= 0; row1--, column1--) {
		if (seats[row1].current[column1] == '.')
			continue;

		if (seats[row1].current[column1] == '#')
			numOcc++;

		break;
	}

	return numOcc;
}
