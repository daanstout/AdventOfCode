#pragma once

#include "Day.h"

struct Seat {
	std::string current;
	std::string next;

	bool Update() {
		bool change = current != next;
		current = next;
		return change;
	}
};

class Day11 : public Day {
public:
	Day11(std::vector<std::string>* input);

	void Calculate() override;
private:
	int CountOccupiedNeighbours(Seat* seats, size_t row, size_t column);
	int CountOccupiedNeighboursAll(Seat* seats, size_t row, size_t column);

	size_t rows;
	size_t columns;
};

