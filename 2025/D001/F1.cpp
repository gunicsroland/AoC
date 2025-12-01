#include <iostream>
#include <fstream>
#include <vector>
#include <string>
#include <cmath>

int main(){
    std::ifstream inputFile("F1_input.txt");
    if (!inputFile) {
        std::cerr << "Error opening file!" << std::endl;
        return 1;
    }

    std::vector<std::string> moves;
    std::string move;
    while (std::getline(inputFile, move)) {
        moves.push_back(move);
    }

    int dial = 50;
    int old = 0;
    int counter1 = 0;
    int counter2 = 0;

    for (const auto& move : moves) {
        old = dial;
        std::string dir = move.substr(0, 1);
        std::string val = move.substr(1);
        int value = std::stoi(val);

        int prefix = dir == "L" ? -1 : 1;
        dial += prefix * value;

        counter2 += std::abs(dial / 100 - old / 100);

        if (dial % 100 == 0){
            counter1++;
        }
    }
    

    std::cout << "Final dial position: " << dial << std::endl;
    std::cout << "Total times dial hit zero: " << counter1 << std::endl;
    std::cout << "Total times dial hit zero during moves: " << counter2 << std::endl;

    return 0;
}