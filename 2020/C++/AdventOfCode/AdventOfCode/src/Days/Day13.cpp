#include "Day13.h"

Day13::Day13(std::vector<std::string>* input) {
	this->input = *input;
}

void Day13::Calculate() {
	int timestamp = std::stoi(input[0]);

	std::vector<std::string>* busses = Split(input[1], ',');

	int shortestToArrive = INT_MAX;
	int fastestID = -1;

	for (const std::string& line : *busses) {
		if (line == "x")
			continue;

		int id = std::stoi(line);

		int timeToArrive = id - (timestamp % id);

		if (shortestToArrive > timeToArrive) {
			shortestToArrive = timeToArrive;
			fastestID = id;
		}
	}

	resultOne = std::to_string((long long)shortestToArrive * (long long)fastestID);

	// The solution below was taken from the /r/adventofcode reddit as I wasn't able to figure it out
	long long time = 0L;
	long long inc = std::stoll(busses->at(0));
	for (int i = 1; i < busses->size(); i++) {
		if (busses->at(i) == "x")
			continue;

		int newTime = std::stoi(busses->at(i));

		while (true) {
			time += inc;
			if ((time + i) % newTime == 0) {
				inc *= newTime;
				break;
			}
		}
	}

	resultTwo = std::to_string(time);

	// Holy shit was this second part terrible. If you don't know about stuff like this (like me) this part straight up isn't feasible without simply brute forcing
	// Worst is, I don't even know if this solution i ended up copying brute forces it or not, and I don't care. Normally i enjoy these puzzles and don't mind it
	// if you need some maths with it, but this puzzle can go fuck itself.
}

long long Day13::CRT(std::vector<Bus> busses) {
	long long ans = 0;
	long long mod = 1;
	for (int i = 0; i < busses.size(); i++) {
		while ((ans + i) % busses[i].mx != 0)
			ans += mod;
		mod *= busses[i].mx;
	}

	return ans;
}
