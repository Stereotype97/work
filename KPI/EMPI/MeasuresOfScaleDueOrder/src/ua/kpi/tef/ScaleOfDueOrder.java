package ua.kpi.tef;

/**
 * Created by Димон on 13.04.2017.
 */
import java.util.ArrayList;
import java.util.Collections;
import java.util.Random;
import java.util.Scanner;

public class ScaleOfDueOrder {
    int n;
    double y0 = 0, y1 = 0;
    double biserialCoef;
    DataValue[] valuePairs;
    boolean isCorrectly = true;

    private int inputIntValueWithScanner(Scanner sc) {
        while(! sc.hasNextInt()) {
            System.out.println("Помилка! Спробуйте ще раз");
            sc.next();
        }
        return sc.nextInt();
    }

    private void setNumbersPairs() {
        Scanner sc = new Scanner(System.in);
        System.out.println("Оберiть шлях створення пар значень. 1 - власноруч, iнше - автоматично");
        int choice = inputIntValueWithScanner(sc);
        if(choice == 1){
            inputNumbersPairs();
        }
        else{
            System.out.println("Пари значень розраховуватиметься автоматично!");
            randomNumbersPairs();
        }
    }

    private void inputNumbersPairs(){
        Scanner sc = new Scanner(System.in);
        System.out.print("Введiть кiлькiсть пар значень (x, y) (не менше 5, для коректності розрахунків): ");

        while ((n = inputIntValueWithScanner(sc)) < 5)
            System.out.println("Помилка! Число не може бути меншим за 5");
        valuePairs = new DataValue[n];

        for (int i = 0; i < n; i++) {
            int x, y;
            System.out.println(i + 1 + " пара:");
            valuePairs[i] = new DataValue();
            System.out.print("Вкажіть стать(0 - ч; 1 - ж): ");
            while ((x = inputIntValueWithScanner(sc)) < 0 || x > 1)
                System.out.println("Помилка! Число не потрапляє в межі. Спробуйте ще раз");
            System.out.print("Вкажіть вік(від 1 до 50): ");
            while((y = inputIntValueWithScanner(sc)) < 1 || y > 50)
                System.out.println("Помилка! Число не потрапляє в межі. Спробуйте ще раз");

            valuePairs[i].xDichotomy = x;
            valuePairs[i].yQuantitative = y;
        }

    }
    private void randomNumbersPairs(){
        Scanner sc = new Scanner(System.in);
        Random random = new Random();

        System.out.print("Введіть кількість пар(від 5 до 30, щоб дослідити залежність статі у діапазоні 1-50 років,\n" +
                "і одержати коректні результати): ");

        while ((n = inputIntValueWithScanner(sc)) < 5 || n > 30)
            System.out.println("Помилка! Число не може бути меншим за 5 або бути більше 30");


        int ageAdult = 18, boundAge = 50;
        int amount = boundAge - ageAdult + 1;
        valuePairs = new DataValue[n];

        ArrayList<DataValue> localArray = new ArrayList<>();

        for (int i = 0; i < amount; i++) {

            localArray.add(new DataValue(random.nextInt(2), ageAdult++));
        }

        Collections.shuffle(localArray, random);
        for (int i = 0; i < n; i++) {
            valuePairs[i] = localArray.get(i);
        }
    }

    private void printTable(){
        System.out.print("| №|Стать| Вік |Ранги|\n|");
        for (int i = 0; i < 21; i++) {
            System.out.print("-");
        }
        System.out.println('|');
        for (int i = 0; i < n; i++) {
            System.out.format("|%3d|  %d  |%5d|%5.1f|%n",
                    i + 1, valuePairs[i].xDichotomy, valuePairs[i].yQuantitative, valuePairs[i].yRanged);
        }
        for (int i = 0; i < 23; i++) {
            System.out.print("-");
        }
        System.out.println();
    }
/*
    private int indexOfFirstMinElementOfValuePairs(){
        int min = valuePairs[0].yQuantitative, index = 0;
        for (int i = 1; i < valuePairs.length; i++)
        {
            if (valuePairs[i].yQuantitative < min) {
                min = valuePairs[i].yQuantitative;
                index = i;
            }

        }
        return index;
    }
    private int indexOfNextMinElementOfValuePairs(int currentMin){
        int min = 100, index = 0;
        for (int i = 0; i < valuePairs.length; i++)
        {
            if (valuePairs[i].yQuantitative < min && valuePairs[i].yQuantitative > currentMin) {
                min = valuePairs[i].yQuantitative;
                index = i;
            }
        }
        return index;
    }
    private void rangeQuantitative(){
        int range = 1;
        int indexMinElement = indexOfFirstMinElementOfValuePairs(),
                minElement = valuePairs[indexMinElement].yQuantitative;
        valuePairs[indexMinElement].yRanged = range++;

        for (int i = 0; i < valuePairs.length - 2; i++) {
            indexMinElement = indexOfNextMinElementOfValuePairs(minElement);
            valuePairs[indexMinElement].yRanged = range++;
            minElement = valuePairs[indexMinElement].yQuantitative;
        }
        for (int i = 0; i < valuePairs.length; i++) {
            if (valuePairs[i].yRanged == 0)
                valuePairs[i].yRanged = range;
        }

    }
*/

    private void bubbleSortIntInt(int arr[], int index[], int n) {

        for (int i = 0; i < n; i++) {
            for (int j = n - 1; j > i; j--) {
                if (arr[j - 1] > arr[j]) {
                    int copy = arr[j - 1];
                    arr[j - 1] = arr[j];
                    arr[j] = copy;

                    int copy1 = index[j - 1];
                    index[j - 1] = index[j];
                    index[j] = copy1;
                }
            }
        }
    }
    private void bubbleSortIntDouble(int arr[], double index[], int n) {

        for (int i = 0; i < n; i++) {
            for (int j = n - 1; j > i; j--) {
                if (arr[j - 1] > arr[j]) {
                    int copy = arr[j - 1];
                    arr[j - 1] = arr[j];
                    arr[j] = copy;

                    double copy1 = index[j - 1];
                    index[j - 1] = index[j];
                    index[j] = copy1;
                }
            }
        }
    }

    private double[] rangeUnion(int[] arr, int n) {

        boolean oneTime = false;
	    double[] res = new double[n];
        for (int i = 0; i < n; i++) {
            res[i] = i + 1;
        }
        int i = 1, indexFirstRepeat = 0, count = 1, sum = 0;
        while (i < n) {
            sum = (int) res[i - 1];
            if (arr[i - 1] == arr[i]) {
                if (!oneTime) {
                    indexFirstRepeat = i - 1;
                    oneTime = true;
                }
                while (i < n && arr[i - 1] == arr[i]) {
                    isCorrectly = false;
                    count++;
                    sum += res[i];
                    i++;
                }

            }
            if (count > 1) {

                double average = (double)sum / count;

                for (int j = indexFirstRepeat; j < i; j++) {
                    res[j] = average;
                }
                i--;
            }

            count = 1;
            sum = 0;
            oneTime = false;

            i++;
        }
        return res;
    }

    private void rangeQuantitative(){
        int size = valuePairs.length;
        int[] arrayForRange = new int[size];
        for (int i = 0; i < size; i++) {
            arrayForRange[i] = valuePairs[i].yQuantitative;
        }

        int[] indexes = new int[size];
        for (int i = 0; i < n; i++) {
            indexes[i] = i + 1;
        }

        bubbleSortIntInt(arrayForRange, indexes, size);
        double[] rangedArray = rangeUnion(arrayForRange, size);
        bubbleSortIntDouble(indexes, rangedArray, size);

        for (int i = 0; i < size; i++) {
            valuePairs[i].yRanged = rangedArray[i];
        }

    }
    private void confirmY0_Y1(){
        int amountY0 = 0, amountY1 = 0;
        for (int i = 0; i < valuePairs.length; i++) {
            if (valuePairs[i].xDichotomy == 0){
                y0 += valuePairs[i].yRanged;
                amountY0++;
            }
            else if (valuePairs[i].xDichotomy == 1){
                y1 += valuePairs[i].yRanged;
                amountY1++;
            }
        }
            if (amountY0 != 0)
                y0 /= amountY0;
            if (amountY1 != 0)
                y1 /= amountY1;

    }
    private void confirmBiserialCoef(){
        confirmY0_Y1();
        //System.out.println(y0 + " " + y1);
        biserialCoef = ((double)2 / (double)n) * (y0 - y1);
    }

    private String makePowerOfRelations(double coefficient){
        coefficient = Math.abs(coefficient);
        if (coefficient >= 0.7)
            return new String("сильний");
        else if (coefficient < 0.7 && coefficient >= 0.5)
            return new String("середній");
        else if (coefficient < 0.5 && coefficient >= 0.3)
            return new String("помірний");
        else if (coefficient < 0.3 && coefficient >= 0.2)
            return new String("слабкий");
        else if (coefficient < 0.2 && coefficient > 0)
            return new String("дуже слабкий");
        return new String("відсутній");
    }
    private void showCharacteristicOfCoefficient(double coefficient){
        if(!isCorrectly){
            System.out.println("Значення коефіцієнта не може бути достовірним.\n" +
                    "Присутні об'єднані ранги");
            System.out.println( "(Розрахунок бісерального рангового коефіцієнта не допускає об'єднаних рангів)");
        }
        System.out.println("Бісеріальний ранговий коефіцієнт = " + coefficient);
        //Розрахунок напрямку
        String direction = new String();
        if (coefficient > 0)
            direction = new String("прямий");
        else
            if (coefficient < 0)
                direction = new String("зворотній");

        System.out.println("Напрямок зв'язку: " + direction);
        //Формування сили зв'язку
        System.out.println("Сила зв'язку: " + makePowerOfRelations(coefficient));
    }

    public void process(){
        setNumbersPairs();
        rangeQuantitative();
        printTable();
        confirmBiserialCoef();
        showCharacteristicOfCoefficient(biserialCoef);
    }

}
