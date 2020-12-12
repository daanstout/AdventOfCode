#pragma once

#include "Day.h"

struct Vec2 {
	int x;
	int y;
	int rot;

	inline void MoveLeft(int val) {
		x -= val;
	}

	inline void MoveRight(int val) {
		x += val;
	}

	inline void MoveUp(int val) {
		y += val;
	}

	inline void MoveDown(int val) {
		y -= val;
	}

	inline void RotateRight(int val) {
		rot += val;
		rot %= 360;
	}

	inline void RotateLeft(int val) {
		rot -= val;
		rot %= 360;

		if (rot < 0)
			rot += 360;
	}

	inline void MoveForward(int val) {
		switch (rot) {
			case 0:
				MoveUp(val);
				break;
			case 90:
				MoveRight(val);
				break;
			case 180:
				MoveDown(val);
				break;
			case 270:
				MoveLeft(val);
				break;
			default:
				std::cout << "Error: Rotation of: " << rot << " degrees is not divisible by 90!" << std::endl;
				break;
		}
	}

	inline void SetLeft() {
		*this = Vec2{ -y, x, rot };
	}

	inline void SetRight() {
		*this = Vec2{ y, -x, rot };
	}

	inline void SetReverse() {
		*this = Vec2{ -x, -y, rot };
	}

	inline void AddMultiple(Vec2 vec, int times) {
		x += vec.x * times;
		y += vec.y * times;
	}
};

class Day12 : public Day {
public:
	Day12(std::vector<std::string>* input);

	void Calculate() override;
};

