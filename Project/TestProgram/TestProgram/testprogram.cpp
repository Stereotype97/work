#include "testprogram.h"
using namespace std;

void splitStart(ostream & os){

    os << setfill(char(42)) << setw(80) << "" << ends << endl; // отсекает строку запуска
}

void infoTest(string task, ostream& os){
    os << "\nTestProgram -> " << task << endl;

}
void localInfo(string task){
    cout << "\t-> " << task;
}

int **  generateArrays(int cntArr = SIZE_TEST, int cntElem = 1000){

    ////генерация двумерного массива
    ///
    int **list = new int* [cntArr];
    for (int i(0); i < cntArr; i++){
        list[i] = new int[cntElem];
    }

    string tmp = " was generated.\n";
    for(int i(0); i < cntArr; i++){
        for(int j(0); j < cntElem; j++){
            list[i][j] = rand() % 1000 - 500;
        }
        localInfo("Array#" + to_string(i + 1) + tmp);
    }
    infoTest("All arrays was generated");
    return list;
}

int ** copyFrom(int ** tmp, int cntArr, int cntElem){
    int **list = new int* [cntArr];
    for (int i(0); i < cntArr; i++){
        list[i] = new int[cntElem];
    }

    for(int i(0); i < cntArr; i++){
        for(int j(0); j < cntElem; j++){
            list[i][j] = tmp[i][j];
        }

    }
    infoTest("All arrays was copied.\n");

    return list;
}

void showList (int **list, int cntArr, int cntElem, ostream& os){
    os << "List -> on screen\n";
    for(int i(0); i < cntArr; i++){
        for(int j(0); j < cntElem; j++){
            os << setfill(char(32)) << setw(5) << list[i][j];
        }
        os << endl;
    }
    os << endl;
}

double arrangeTime (vector<double> vec, int n){
    double arrange = 0.;
    for (int i(0); i < vec.size(); i++){
        arrange += vec[i];
    }

    return arrange / n;
}
