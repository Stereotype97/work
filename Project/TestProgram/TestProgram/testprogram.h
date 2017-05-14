#ifndef TESTPROGRAM_H
#define TESTPROGRAM_H
#include <string>
#include <iostream>
#include <fstream>
#include <vector>
#include <iomanip>
#include <time.h>
#define SIZE_TEST 5

void splitStart(std::ostream& = std::cout);
void infoTest(std::string, std::ostream& = std::cout);
void localInfo(std::string);

int **  generateArrays(int, int);
int ** copyFrom(int **, int, int);

void showList (int **, int, int, std::ostream&);

double arrangeTime (std::vector<double>, int = SIZE_TEST);
#endif // TESTPROGRAM_H
