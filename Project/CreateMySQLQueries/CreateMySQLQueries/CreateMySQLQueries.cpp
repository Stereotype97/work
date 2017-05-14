// CreateMySQLQueries.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <conio.h>
#include <Windows.h>
#include "DataForSQLQueries.h"
#define COUNT_QUERIES 20000

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	DataForSQLQueries *data = new DataForSQLQueries();
	data->gettingDataFromFiles();
	data->recordInstructionForMySqlInFile(COUNT_QUERIES);

	delete data;
	_getch();
    return 0;
}

