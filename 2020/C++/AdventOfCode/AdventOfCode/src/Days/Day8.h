#pragma once

#include "Day.h"

class Day8 : public Day {
public:
	Day8(std::vector<std::string>* input);

	void Calculate() override;
private:
	bool IsInfinite(std::vector<std::string> commands, int& acc);
};

