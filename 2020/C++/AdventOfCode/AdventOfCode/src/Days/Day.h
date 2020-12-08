#pragma once
#include <string>
#include <vector>
#include <memory>
#include <sstream>
#include <iostream>

class Day {
protected:
	Day();

public:
	virtual void Calculate() = 0;
	virtual void Print();

protected:
	std::vector<std::string>* Split(std::stringstream& text, char splitChar);
	std::vector<std::string>* Split(std::string& text, char splitChar);
	std::vector<std::string>* Split(const std::string& text, const std::string& splitString);

	std::vector<std::string> input;
	std::string resultOne;
	std::string resultTwo;
};
