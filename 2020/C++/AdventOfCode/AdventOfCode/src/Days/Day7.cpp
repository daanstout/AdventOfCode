#include "Day7.h"

#include <queue>

Day7::Day7(std::vector<std::string>* input) {
	this->input = std::make_unique<std::vector<std::string>>(*input);
}

void Day7::Calculate() {
	for (const std::string& line : *input) {
		std::vector<std::string>* spl1 = Split(line, " contain ");
		Bag* bag = new Bag();
		bag->name = spl1->at(0).substr(0, spl1->at(0).size() - 1);
		if (bag->name == "shiny gold bag")
			goldIndex = bagsContainMe.size();
		bagsContainMe.push_back(*bag);
		bagsIContain.push_back(*bag);
	}

	for (int line = 0; line < input->size(); line++) {
		std::vector<std::string>* spl1 = Split(input->at(line).substr(0, input->at(line).size() - 1), " contain ");
		std::vector<std::string>* spl2 = Split(spl1->at(1), ", ");

		for (int sub = 0; sub < spl2->size(); sub++) {
			std::string l;
			if (spl2->at(sub)[spl2->at(sub).size() - 1] == 's')
				l = spl2->at(sub).substr(2, spl2->at(sub).size() - 3);
			else
				l = spl2->at(sub).substr(2, spl2->at(sub).size());

			for (int existing = 0; existing < bagsContainMe.size(); existing++) {
				if (bagsContainMe[existing].name == l) {
					bagsContainMe[existing].bags.push_back(line);
					bagsIContain[line].bags.push_back(existing);
					bagsIContain[line].bagCount.push_back(std::stoi(spl2->at(sub).substr(0, 1)));
					break;
				}
			}
		}
	}

	std::queue<int> q;
	q.push(goldIndex);
	std::vector<int> visited;
	int count = -1;

	while (!q.empty()) {
		int cur = q.front();
		q.pop();

		if (std::count(visited.begin(), visited.end(), cur))
			continue;

		visited.push_back(cur);
		count++;

		Bag curBag = bagsContainMe[cur];

		for (int con : curBag.bags)
			q.push(con);
	}

	resultOne = std::make_unique<std::string>(std::to_string(count));

	resultTwo = std::make_unique<std::string>(std::to_string(CalculateBagCount(goldIndex)));
}

int Day7::CalculateBagCount(int index) {
	if (bagsIContain[index].contains != -1)
		return bagsIContain[index].contains;

	bagsIContain[index].contains = 0;

	for (int i = 0; i < bagsIContain[index].bags.size(); i++) {
		int subBagCount = CalculateBagCount(bagsIContain[index].bags[i]);
		if (subBagCount == 0)
			bagsIContain[index].contains += bagsIContain[index].bagCount[i];
		else
			bagsIContain[index].contains += bagsIContain[index].bagCount[i] * (subBagCount + 1);
	}

	return bagsIContain[index].contains;
}
