#include <conio.h>
#include "sorts.h"
#include "testprogram.h"

using namespace std;

std::clock_t start;
double duration;
vector<double> bubbleTime(0);
vector<double> quickTime(0);

void blockB(int **list, int amount){

    infoTest("Start sort by BubbleMethod.\n");

    string endStr = " is sorting now.";

    for(int i(0); i < SIZE_TEST; i++){

        localInfo("Array#" + to_string(i + 1) + endStr);
        start = clock();
        BubbleSort(list[i], amount);
        duration = double(clock() - start)/CLOCKS_PER_SEC;
        cout << " Finished!\n";
        bubbleTime.push_back(duration);
        printf("time: %.3lf\n", duration);
    }

    duration = arrangeTime(bubbleTime);
    infoTest("Arranged time: " + to_string(duration));
    bubbleTime.clear();
}

void blockQ(int **list2, int amount){

    infoTest("Start sort by QuickMethod.\n");

    string endStr = " is sorting now.";
    for(int i(0); i < SIZE_TEST; i++){
        localInfo("Array#" + to_string(i + 1) + endStr);
        start = clock();
        QSort(list2[i], 0, amount - 1);
        duration = double(clock() - start) / CLOCKS_PER_SEC;
        cout << " Finished!\n";
        quickTime.push_back(duration);
        printf("time: %.3lf\n", duration);
    }
    duration = arrangeTime(quickTime);
    infoTest("Arranged time: " + to_string(duration));
    quickTime.clear();

}

//void freeMemory (int *** p){
//    if (p){
//        for (int i(0); i < SIZE_TEST; i++){
//            delete[] p[i];
//        }
//        delete[] p;
//    }
//}

void attension (){
    system("cls");
    for(int i(5); i >= 0; i--){

        infoTest("You choise automatical work. It begin about " + to_string(i) + " sec");

        start = clock();
        while ((clock() - start) / CLOCKS_PER_SEC < 1.0);

        system("cls");
    }
}

void autoWork(){
    ofstream file;
    string disc;
    infoTest("Enter the name hard disc(d or e) for save result:");
    localInfo("Your disc: ");
    cin >> disc;
    file.open(disc + ":\\ResultTest.txt", ios::out);
    attension();
    infoTest("Automatical work has already begun.");
    int size = 9;
    int setAmount[] = {1000, 2000, 3000, 5000, 10000,
                       500000, 1000000,
                       10000000, 20000000};
    int **list, **list2;
    file << "TestProgram was runned..\n" << endl;

    for (int i(0); i < size - 4; i++){ //прогонка двух сортировок

        infoTest("Generate number for array[" + to_string(setAmount[i]) + "].", cout);
        infoTest("Generate number for array[" + to_string(setAmount[i]) + "].", file);
        list = generateArrays(SIZE_TEST, setAmount[i]);
        list2 = copyFrom(list, SIZE_TEST, setAmount[i]);

        infoTest("Start sort by BubbleMethod.", file);
        blockB(list, setAmount[i]);
        infoTest("Arranged time: " + to_string(duration), file);

        infoTest("Start sort by QuickMethod.", file);
        blockQ(list2, setAmount[i]);
        infoTest("Arranged time: " + to_string(duration) + '\n', file);


        for (int j(0); j < SIZE_TEST; j++){
            delete[] list[j];
            delete[] list2[j];
        }
        delete[] list;
        delete[] list2;
        splitStart(file);
        infoTest("Next test has runned.", file);
    }

    infoTest("Bubble Method is very slow, so next i will run only Quick Sort.", file);
    for (int i(size - 4); i < size; i++){

        infoTest("Generate number for array[" + to_string(setAmount[i]) + "].", file);
        list = generateArrays(SIZE_TEST, setAmount[i]);

        infoTest("Start sort by QuickMethod.", file);
        blockQ(list, setAmount[i]);
        infoTest("Arranged time: " + to_string(duration) + '\n', file);


        for (int j(0); j < SIZE_TEST; j++){
            delete[] list[j];
        }
        delete[] list;

        splitStart(file);
        if (i != size - 1)
            infoTest("Next test has runned.", file);
    }

    infoTest("Automatical work has finished.");
    infoTest("Seek you text file here:\n"
             "C:/Users/ANON/AppData/Local/VirtualStore/ResultTest.txt");
    file.close();
    infoTest("Press any key for close program.\n"
             "Thank You!");
}
////////////////******************************\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


int main()
{
    srand(time(NULL));

    cout << "TestProgram was runned.." << '.' << endl;
    splitStart();
    infoTest("\tProgram can run test automatically or give you possibility "
             "\nenter your data. Choise -a for auto- or -i - for work yourself. \n ");
    localInfo("$ work -");
    char ch;
_work:
    cin >> ch;
    if (ch == 'a'){
        autoWork();
    }
    else if (ch == 'i'){

        int amount, **list, **list2;

        do{

            localInfo("Please, choose amount elements of array for testing: ");
            cin >> amount;

            //////////////////////////////////////////////////////////////////////

            cout << "Enter key for sorting:\n"
                    "\t-b  ->  bubble method\n"
                    "\t-q  ->  quick sort\n"
                    "\t-c  ->  combination\n";
            localInfo("$ sort -");

_sort:
            cin >> ch;
            if (ch == 'b' || ch == 'q' || ch == 'c'){
                infoTest("Generate number for array");
                list = generateArrays(SIZE_TEST, amount);

                if (ch == 'b'){
                    blockB(list, amount);
                }
                else
                    if (ch == 'q'){
                        blockQ(list, amount);
                    }
                    else
                        if (ch == 'c'){
                            list2 = copyFrom(list, SIZE_TEST, amount);
                            blockB(list, amount);
                            blockQ(list2, amount);
                            for (int i(0); i < SIZE_TEST; i++){
                                delete[] list2[i];
                            }
                            delete[] list2;
                        }
                ///Удаление первого массива
                for (int i(0); i < SIZE_TEST; i++){
                    delete[] list[i];
                }
                delete[] list;
                infoTest("All arrays have deleted.\n");
            }
            else {
                infoTest("INCORRECTLY!!! Try again");
                localInfo("$ sort -");
                goto _sort;
            }
            infoTest("Press enter key");
            getch();

            infoTest("Do you want use program again or exit. "
                     "Enter key -u for using or "
                     "\t-e - for exit from program.\n");
            localInfo("$ program -");
            cin >> ch;
        }while(ch != 'e');
    }
    else {
        infoTest("INCORRECTLY!!! Try again");
        localInfo("$ work -");
        goto _work;
    }

    infoTest("Bye!");

    return 0;
}
