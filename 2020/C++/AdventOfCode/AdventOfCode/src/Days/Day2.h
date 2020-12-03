#pragma once

#include "Day.h"

class Day2 : public Day {
public:
	Day2(std::vector<std::string>* input);

	void Calculate() override;
private:
	int CountChar(const std::string str, char c);
};

