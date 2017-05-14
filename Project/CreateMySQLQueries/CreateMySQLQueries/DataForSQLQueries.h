#pragma once
#include <vector>
#include <string>

using namespace std;

//��������� ��������� �������� ��� ���������� ������� � MySQL
struct RandomValuesOfFields {
	string name;         
	string surname;
	int age;
	string country;
	short sex; // ���: 0 - �������, 1 - �������.
};

class DataForSQLQueries
{
private:
	//������� �������� ����, ������� ( ������� � ������� ) � ����� (��� ������ ������������)
	vector<string> menNames;
	vector<string> menSurnames;

	vector<string> womenNames;
	vector<string> womenSurnames;

	vector<string> countries;
	//���� � ������
	string pathOfMenNames;
	string pathOfWomenNames;
	string pathOfMenSurnames;
	string pathOfWomenSurnames;
	string pathOfCountries;
	
	int generateNumberInTheRange(int, int); //���������� ����� � �������� ���������, ������������ � �������� ��������� ��������� �������� �� ��������
	string INSERT_INTO(string); //��������� ������ ��� ������� � ������� MySQL ��������, ��� ��������� � �������� ��������� ��� ������� MySQL

	int setMenNamesPath(string); //��������� ���� � �����, � ������� ���������� ������� ����� 
	int setMenSurnamesPath(string); //��������� ���� � �����, � ������� ���������� ������� �������
	int setWomenNamesPath(string); //��������� ���� � �����, � ������� ���������� ������� ����� 
	int setWomenSurnamesPath(string); //��������� ���� � �����, � ������� ���������� ������� �������
	int setCountriesPath(string); //��������� ���� � �����, � ������� ���������� ������������ �����

	string getRandomName(); //��������� ���������� �����
	string getRandomSurname(); //��������� ��������� �������
	int getRandomAge(); //��������� ���������� �������� 
	string getRandomCountry(); //��������� ��������� ������
	int getRandomSex(); //��������� ����� ����
public:
	DataForSQLQueries(); //������������� �������� �������� 1 �������, ������������� ��������� � ����������� srand(time(0))
	~DataForSQLQueries();

	RandomValuesOfFields structure; //��������� ������, � ������� ���������� ����� ������ ��� ���������� ������� MySQL 

	bool assignPathWithExistingFiles(); //��������, ��� ��� ����� ������������� ���������� � ����� ���� �������(���������, ����� ����� �� ���� �������)

	void gettingDataFromFiles(); //������ ������ � ������ � �������������� �������(���� ������), ��� ���������� ������ � ����.
	void generateValuesForSQLTable(); //��������� ��������� ��������(����� � �����) � ��������� RandomValuesOfFields ��� ���������� ������ � ������� MySQL
	string getRecordForTable(); //��������� ������ ����������� �������� ��� VALUES
	void recordInstructionForMySqlInFile(int); //��������� �������� ������� ��� MySQL, ������������ ��� ���������� countQueries (����������) ������� ������� 
};

