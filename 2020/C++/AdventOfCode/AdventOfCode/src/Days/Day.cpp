#include "Day.h"

#include<iostream>

Day::Day() : input(nullptr), resultOne(std::make_unique<std::string>("not yet calculated")), resultTwo(std::make_unique<std::string>("not yet calculated")) { }

void Day::Print() {
	std::cout << *resultOne << std::endl << *resultTwo << std::endl;
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
