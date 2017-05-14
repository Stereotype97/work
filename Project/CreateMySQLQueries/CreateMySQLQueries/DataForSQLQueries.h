#pragma once
#include <vector>
#include <string>

using namespace std;

//Структура случайных значений для заполнения таблицы в MySQL
struct RandomValuesOfFields {
	string name;         
	string surname;
	int age;
	string country;
	short sex; // Пол: 0 - женский, 1 - мужской.
};

class DataForSQLQueries
{
private:
	//Вектора хранимых имен, фамилий ( мужских и женских ) и стран (для любого пользователя)
	vector<string> menNames;
	vector<string> menSurnames;

	vector<string> womenNames;
	vector<string> womenSurnames;

	vector<string> countries;
	//Пути к файлам
	string pathOfMenNames;
	string pathOfWomenNames;
	string pathOfMenSurnames;
	string pathOfWomenSurnames;
	string pathOfCountries;
	
	int generateNumberInTheRange(int, int); //Генерирует число в заданном диапазоне, используется в функциях получения случайных значений из векторов
	string INSERT_INTO(string); //Строковый шаблон для вставки в таблицу MySQL значений, что принимает в качестве аргумента имя таблицы MySQL

	int setMenNamesPath(string); //Установка пути к файлу, в котором содержатся мужские имена 
	int setMenSurnamesPath(string); //Установка пути к файлу, в котором содержатся мужские фамилии
	int setWomenNamesPath(string); //Установка пути к файлу, в котором содержатся женские имена 
	int setWomenSurnamesPath(string); //Установка пути к файлу, в котором содержатся женские фамилии
	int setCountriesPath(string); //Установка пути к файлу, в котором содержатся наименования стран

	string getRandomName(); //Получение случайного имени
	string getRandomSurname(); //Получение случайной фамилии
	int getRandomAge(); //Получение случайного возраста 
	string getRandomCountry(); //Получение случайной страны
	int getRandomSex(); //Случайный выбор пола
public:
	DataForSQLQueries(); //Инициализация векторов размером 1 элемент, инициализация структуры и конструкции srand(time(0))
	~DataForSQLQueries();

	RandomValuesOfFields structure; //Структура данных, в которой содержится новая запись для заполнения таблицы MySQL 

	bool assignPathWithExistingFiles(); //Проверка, что все файлы действительно существуют и могут быть открыты(указывает, какие файлы не были найдены)

	void gettingDataFromFiles(); //Запись данных с файлов в соответсвующие вектора(поля класса), для дальнейшей работы с ними.
	void generateValuesForSQLTable(); //Генерация случайных значений(строк и чисел) в структуре RandomValuesOfFields для заполнения записи в таблице MySQL
	string getRecordForTable(); //Получение строки заполняемых значений для VALUES
	void recordInstructionForMySqlInFile(int); //Получение готового запроса для MySQL, необходимого для заполнения countQueries (количества) записей таблицы 
};

