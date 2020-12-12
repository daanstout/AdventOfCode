#include "Day12.h"

Day12::Day12(std::vector<std::string>* input) {
	this->input = *input;
}

void Day12::Calculate() {
	Vec2 pos = { 0, 0, 90 };

	for (const std::string& line : input) {
		const char dir = line[0];
		const int val = std::stoi(line.substr(1));

		switch (dir) {
			case 'N':
				pos.MoveUp(val);
				break;
			case 'S':
				pos.MoveDown(val);
				break;
			case 'E':
				pos.MoveRight(val);
				break;
			case 'W':
				pos.MoveLeft(val);
				break;
			case 'L':
				pos.RotateLeft(val);
				break;
			case 'R':
				pos.RotateRight(val);
				break;
			case 'F':
				pos.MoveForward(val);
				break;
			default:
				std::cout << "Error! Direction of: " << dir << " (With value of: " << val << ") is not a valid direction" << std::endl;
				break;
		}
	}

	int manhattan = std::abs(pos.x) + std::abs(pos.y);

	resultOne = std::to_string(manhattan);

	pos = { 0, 0, 90 };
	Vec2 wayPoint = { 10, 1, 0 };

	for (const std::string& line : input) {
		const char dir = line[0];
		const int val = std::stoi(line.substr(1));

		switch (dir) {
			case 'N':
				wayPoint.MoveUp(val);
				break;
			case 'S':
				wayPoint.MoveDown(val);
				break;
			case 'E':
				wayPoint.MoveRight(val);
				break;
			case 'W':
				wayPoint.MoveLeft(val);
				break;
			case 'L':
				if (val == 90)
					wayPoint.SetLeft();
				else if (val == 180)
					wayPoint.SetReverse();
				else if (val == 270)
					wayPoint.SetRight();
				else
					std::cout << "Warning! Was told to turn left " << val << " degrees" << std::endl;
				break;
			case 'R':
				if (val == 90)
					wayPoint.SetRight();
				else if (val == 180)
					wayPoint.SetReverse();
				else if (val == 270)
					wayPoint.SetLeft();
				else
					std::cout << "Warning! Was told to turn right " << val << " degrees" << std::endl;
				break;
			case 'F':
				pos.AddMultiple(wayPoint, val);
			default:
				break;
		}
	}

	manhattan = std::abs(pos.x) + std::abs(pos.y);

	resultTwo = std::to_string(manhattan);
}
