#include "Day8.h"

Day8::Day8(std::vector<std::string>* input) {
	this->input = *input;
}

void Day8::Calculate() {
	int acc;
	IsInfinite(input, acc);

	resultOne = std::to_string(acc);

	int curRow = 0;

	for (int i = 0; i < input.size(); i++) {
		std::vector<std::string> commands;
		for (std::string& l : input)
			commands.push_back(l);

		for (; curRow < input.size(); curRow++) {
			std::string command = commands[curRow].substr(0, 3);
			if (command == "nop") {
				if (commands[curRow][5] == '0')
					continue;

				commands[curRow] = "jmp" + commands[curRow].substr(3);
				curRow++;
				break;
			} else if (command == "jmp") {
				commands[curRow] = "nop" + commands[curRow].substr(3);
				curRow++;
				break;
			}
		}

		if (!IsInfinite(commands, acc))
			break;
	}

	resultTwo = std::to_string(acc);
}

bool Day8::IsInfinite(std::vector<std::string> commands, int& acc) {
	acc = 0;
	int pc = 0;

	std::vector<int> visited;

	bool running = true;

	while (running) {
		if (pc == commands.size())
			return false;

		if (std::count(visited.begin(), visited.end(), pc))
			return true;

		visited.push_back(pc);

		std::string& line = commands[pc];

		if (line.substr(0, 3) == "nop") {
			pc++;
			continue;
		} else if (line.substr(0, 3) == "acc") {
			int sign = line[4] == '+' ? 1 : -1;
			int val = std::stoi(line.substr(5)) * sign;
			acc += val;
			pc++;
			continue;
		} else if (line.substr(0, 3) == "jmp") {
			int sign = line[4] == '+' ? 1 : -1;
			int val = std::stoi(line.substr(5)) * sign;
			pc += val;
			continue;
		} else {
			std::cout << "Unknown command: " << line << std::endl;
		}
	}
}
