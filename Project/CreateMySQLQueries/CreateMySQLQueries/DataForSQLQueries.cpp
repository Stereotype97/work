#include "stdafx.h"
#include "DataForSQLQueries.h"
#include <time.h>
#include <fstream>
#include <iostream>


int DataForSQLQueries::generateNumberInTheRange(int begin, int end)
{
	return rand() % (end - begin + 1) + begin;
}

string DataForSQLQueries::INSERT_INTO(string table)
{
	return "INSERT IGNORE INTO " + table 
		  + "\n(name, surname, age, country, sex)\n"
		  + "VALUES ";
}

DataForSQLQueries::DataForSQLQueries()
{
	srand(time(NULL));
}

DataForSQLQueries::~DataForSQLQueries()
{
}

int DataForSQLQueries::setMenNamesPath(string path)
{
	ifstream input(path, ios::in);
	if (!input.is_open()) {
		std::cout << "Error! File with men's names don't find!\n";
		return 1;
	}
	else {
		pathOfMenNames = path;
		input.close();
	}
	return 0;
}

int DataForSQLQueries::setMenSurnamesPath(string path)
{
	ifstream input(path, ios::in);
	if (!input.is_open()) {
		std::cout << "Error! File with men's surnames don't find!\n";
		return 1;
	}
	else {
		pathOfMenSurnames = path;
		input.close();
	}
	return 0;
}

int DataForSQLQueries::setWomenNamesPath(string path)
{
	ifstream input(path, ios::in);
	if (!input.is_open()) {
		std::cout << "Error! File with women's names don't find!\n";
		return 1;
	}
	else {
		pathOfWomenNames = path;
		input.close();
	}
	return 0;
}

int DataForSQLQueries::setWomenSurnamesPath(string path)
{
	ifstream input(path, ios::in);
	if (!input.is_open()) {
		std::cout << "Error! File with women's surnames don't find!\n";
		return 1;
	}
	else {
		pathOfWomenSurnames = path;
		input.close();
	}
	return 0;
}

int DataForSQLQueries::setCountriesPath(string path)
{
	ifstream input(path, ios::in);
	if (!input.is_open()) {
		std::cout << "Error! File with countries don't find!\n";
		return 1;
	}
	else {
		pathOfCountries = path;
		input.close();
	}
	return 0;
}

string DataForSQLQueries::getRandomName()
{
	if (structure.sex)
		return menNames[generateNumberInTheRange(0, menNames.size() - 1)];
	else
		return womenNames[generateNumberInTheRange(0, womenNames.size() - 1)];
}

string DataForSQLQueries::getRandomSurname()
{
	if (structure.sex)
		return menSurnames[generateNumberInTheRange(0, menSurnames.size() - 1)];
	else
		return womenSurnames[generateNumberInTheRange(0, womenSurnames.size() - 1)];
}

int DataForSQLQueries::getRandomAge()
{
	int firstRangeOfAge = 18;
	int secondRangeOfAge = 52;
	return generateNumberInTheRange(firstRangeOfAge, secondRangeOfAge);
}

string DataForSQLQueries::getRandomCountry()
{
	return countries[generateNumberInTheRange(0, countries.size() - 1)];
}

int DataForSQLQueries::getRandomSex()
{
	return generateNumberInTheRange(0, 1);
}

bool DataForSQLQueries::assignPathWithExistingFiles()
{
	if(
	setMenNamesPath("E:\\PEOPLE_DB\\nameMen.txt") |
	setMenSurnamesPath("E:\\PEOPLE_DB\\surnameMen.txt") |
	setWomenNamesPath("E:\\PEOPLE_DB\\nameWomen.txt") |
	setWomenSurnamesPath("E:\\PEOPLE_DB\\surnameWomen.txt") |
	setCountriesPath("E:\\PEOPLE_DB\\country.txt") )  return false;
	
	return true;
}

void DataForSQLQueries::gettingDataFromFiles()
{
	if (assignPathWithExistingFiles())
		cout << "Successfull! All files exist! Updating data from it..." << endl;

	string temp;

	//Заполнение вектора мужских имен
	ifstream file(pathOfMenNames);
	while (file >> temp) {
		menNames.push_back(temp);
	}
	file.close();
	
	//Заполнение вектора мужских фамилий
	file.open(pathOfMenSurnames);
	while (file >> temp) {
		menSurnames.push_back(temp);
	}
	file.close();

	//Заполнение вектора женских имен
	file.open(pathOfWomenNames);
	while (file >> temp) {
		womenNames.push_back(temp);
	}
	file.close();

	//Заполнение вектора женских имен
	file.open(pathOfWomenSurnames);
	while (file >> temp) {
		womenSurnames.push_back(temp);
	}
	file.close();

	//Заполнение вектора названий стран
	file.open(pathOfCountries);
	while (file >> temp) {
		countries.push_back(temp);
	}
	file.close();

	cout << "OK! Started generate instruction!.." << endl;
}

void DataForSQLQueries::generateValuesForSQLTable()
{	
	structure.sex = getRandomSex();
	structure.name = getRandomName();
	structure.surname = getRandomSurname();
	structure.age = getRandomAge();
	structure.country = getRandomCountry();	
}

string DataForSQLQueries::getRecordForTable()
{
	return "('" + structure.name + "', '" + structure.surname + "', " + std::to_string(structure.age)
			+ ", '" + structure.country + "', " + std::to_string(structure.sex) + ")";
}

void DataForSQLQueries::recordInstructionForMySqlInFile(int countQueries)
{
	ofstream file("e:\\PEOPLE_DB\\QUERY.txt", ios::trunc);
		
	file << INSERT_INTO("People");
	for (int i(0); i < countQueries; i++) {
		generateValuesForSQLTable();
		file << getRecordForTable();
		if (i != countQueries - 1) {
			file << ",\n";
		}
		else
			file << ";";
	}
	file.close();
	cout << "All queries has formed!";
}
