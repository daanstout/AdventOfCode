#pragma once
#include "Day.h"

class Day3 : public Day{
public:
	Day3(std::vector<std::string>* input);

	void Calculate() override;
private:
	long long CountTrees(int slopeR, int slopeD);
};

