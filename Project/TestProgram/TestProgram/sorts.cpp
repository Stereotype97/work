
void swap (int &a, int &b){
    int temp = a;
    a = b;
    b = temp;
}

void BubbleSort(int* arr, int N)
{

    int i = 0, j;
    int temp;
    while(i < N) {
        for (j = i - 1; j >= 0; j--){
            if (arr[j] > arr[i]){
                temp = arr[j];
                arr[j] = arr[i];
                arr[i] = temp;
                i--;
            }
        }
        i++;
    }

}
void QSort(int *mas, int first, int last)
{
    int f = first, ls = last;
    int mid = mas[(f + ls) / 2];
    do
    {
        while (mas[f]<mid)
            f++;
        while (mas[ls]>mid)
            ls--;

        if (f <= ls)
        {
            swap(mas[f], mas[ls]);
            f++;
            ls--;
        }

    } while (f<ls);
    if (first<ls)
        QSort(mas, first, ls);
    if (f<last)
        QSort(mas, f, last);
}
