#include "Day.h"

#include<iostream>

Day::Day() : input(), resultOne("not yet calculated"), resultTwo("not yet calculated") { }

void Day::Print() {
	std::cout << resultOne << std::endl << resultTwo << std::endl;
}

std::vector<std::string>* Day::Split(std::stringstream& text, char splitChar) {
	std::vector<std::string>* vec = new std::vector<std::string>();
	std::string segment;

	while (std::getline(text, segment, splitChar)) {
		vec->push_back(segment);
	}

	return vec;
}

std::vector<std::string>* Day::Split(std::string& text, char splitChar) {
	std::stringstream ss;
	ss << text;
	std::vector<std::string>* vec = new std::vector<std::string>();
	std::string segment;

	while (std::getline(ss, segment, splitChar)) {
		vec->push_back(segment);
	}

	return vec;
}

std::vector<std::string>* Day::Split(const std::string& text, const std::string& splitString) {
	auto start = 0U;
	auto end = text.find(splitString);

	std::vector<std::string>* vec = new std::vector<std::string>();

	while (end != std::string::npos) {
		vec->push_back(text.substr(start, end - start));
		start = end + splitString.length();
		end = text.find(splitString, start);
	}
	vec->push_back(text.substr(start, end - start));
	return vec;
}
