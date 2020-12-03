#pragma once
#include <string>
#include <vector>
#include <memory>
#include <sstream>

class Day {
protected:
	Day();

public:
	virtual void Calculate() = 0;
	virtual void Print();

protected:
	std::vector<std::string>* Split(std::stringstream& text, char splitChar);

	std::unique_ptr<std::vector<std::string>> input;
	std::unique_ptr<std::string> resultOne;
	std::unique_ptr<std::string> resultTwo;
};
