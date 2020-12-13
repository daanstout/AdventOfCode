#pragma once

#include "Day.h"

struct Bus {
	long long x;
	long long mx;
};

class Day13 : public Day{
public:
	Day13(std::vector<std::string>* input);

	void Calculate() override;
private:
	long long CRT(std::vector<Bus> busses);
};

