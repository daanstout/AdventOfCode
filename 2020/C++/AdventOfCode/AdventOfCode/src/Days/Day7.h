#pragma once

#include "Day.h"

struct Bag {
	std::string name;
	std::vector<int> bags;
	std::vector<int> bagCount;
	int contains = -1;
};

class Day7 : public Day {
public:
	Day7(std::vector<std::string>* input);

	void Calculate() override;
private:
	int CalculateBagCount(int index);

	std::vector<Bag> bagsContainMe;
	std::vector<Bag> bagsIContain;
	int goldIndex;
};

