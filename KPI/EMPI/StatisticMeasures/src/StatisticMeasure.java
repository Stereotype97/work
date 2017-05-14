/**
 * Created by Димон on 22.03.2017.
 */

import java.util.Random;
import java.util.Scanner;

public class StatisticMeasure {

    int m, k, n;
    int nx[], ny[];
    DataValue[] numbersPairs;
    int[][] corelation;
    boolean isEnough = true;


    private int inputIntValueWithScanner(Scanner sc) {
        while( ! sc.hasNextInt()) {
            System.out.println("Помилка! Спробуйте ще раз");
            sc.next();
        }
        return sc.nextInt();
    }
    private void inputParameters_M_K() {
        Scanner sc = new Scanner(System.in);
        System.out.println("Введiть параметр m(рядки): ");
        while ((m = inputIntValueWithScanner(sc)) <= 0){
            System.out.println("Помилка! Значення не може бути меншим за 0, або дорівнювати 0");
        }
        System.out.println("Введiть параметр k(стовпці): ");
        while((k = inputIntValueWithScanner(sc)) <= 0){
            System.out.println("Помилка! Значення не може бути меншим за 0, або дорівнювати 0");
        }
    }
/*
    public void setCorelationTableMyself(){
        corelation = new int[][]{{15, 10, 12, 37},
            {18, 15, 14, 47},
            {10, 8, 7, 25},
            {43, 33, 33, 109}};
        nx = new int[]{43, 33, 33};
        ny = new int[]{37, 47, 25};
        m = k = 4;
        n = 109;
        isEnough = true;
    }
*/
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
        System.out.print("Введiть кiлькiсть пар значень (у, x): ");
        int amount = inputIntValueWithScanner(sc);
        numbersPairs = new DataValue[amount];

        for (int i = 0; i < amount; i++) {
            int y, x;
            System.out.println(i + 1 + " пара:");
            numbersPairs[i] = new DataValue();
            System.out.print("Введіть y(рядок)(1-" + m + "): ");
            while ((y = inputIntValueWithScanner(sc)) < 1 || y > m)
                System.out.println("Помилка! Число не потрапляє в межі");
            System.out.print("Введіть x(стовпчик)(1-" + k + "): ");
            while((x = inputIntValueWithScanner(sc)) < 1 || x > k)
                System.out.println("Помилка! Число не потрапляє в межі");
            numbersPairs[i].x = x - 1;
            numbersPairs[i].y = y - 1;
        }

    }

    private void randomNumbersPairs(){
        Scanner sc = new Scanner(System.in);
        System.out.print("Введіть кількість пар: ");
        int amount = inputIntValueWithScanner(sc);
        numbersPairs = new DataValue[amount];
        Random random = new Random();
        for (int i = 0; i < amount; i++) {

            numbersPairs[i] = new DataValue();
            numbersPairs[i].x = random.nextInt(k);
            numbersPairs[i].y = random.nextInt(m);
        }
    }

    private void showPairBeforeConfirm(){
        System.out.println("Усі введені пари: ");
        for (int i = 0; i < numbersPairs.length; i++) {
            System.out.print("(" + (numbersPairs[i].y + 1) + "," + (numbersPairs[i].x + 1) + ")| ");
            if (i % 25 == 0 && i != 0)
                System.out.println();
        }
        System.out.println();
    }

    private void buildCorelTable(){
        corelation = new int[m + 1][k + 1];
        countFrequency();
        countMarginFrequency();
        assignCorelationWithMargin();
        System.out.println("Кореляцiйна таблиця:");
        Utilities.showCorelTable(corelation, m + 1, k + 1);

    }

    private void countFrequency(){
        int x_fact, y_fact;

        for (int i = 0; i < numbersPairs.length; i++) {
            x_fact = numbersPairs[i].y;
            y_fact = numbersPairs[i].x;
            corelation[x_fact][y_fact]++;
        }
    }
    private void countMarginFrequency(){
        nx = new int[k];
        ny = new int[m];

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < k; j++) {
                ny[i] += corelation[i][j];
            }
        }

        for (int i = 0; i < k; i++) {
            for (int j = 0; j < m; j++) {
                nx[i] += corelation[j][i];
            }
        }


    }
    private void assignCorelationWithMargin(){
        for (int i = 0; i < m; i++) {
            corelation[i][k] = ny[i];
        }
        for (int i = 0; i < k; i++) {
            corelation[m][i] = nx[i];
        }
        for (int i:nx) {
            n += i;
        }
        corelation[m][k] = n;
    }

    private double P(double xi2){
        return Math.sqrt((xi2/(xi2 + n)));
    }
    private double Xi2(){
        double result = 0;

        for (int i = 0; i < m - 1; i++) {

            for (int j = 0; j < k - 1; j++) {
                if (nTilde(i,j) < 10) {
                    isEnough = false;
                }
                    result += (Math.pow(corelation[i][j] - nTilde(i, j), 2) / nTilde(i, j));

            }
        }
        return result;
    }
    private double nTilde(int i, int j){
        return (double) (nx[j] * ny[i]) / n;
    }

    public void process(){
        inputParameters_M_K();
        setNumbersPairs();
        showPairBeforeConfirm();
        buildCorelTable();
        System.out.println("Коєфіцієнт спряженості Пірсона: " + P(Xi2()));

        if(!isEnough) {
            System.out.println("Вхідних пар даних не вистачає для коректності результатів.");
        }
/*
        //Checked
        System.out.println("Провірені значення");
        setCorelationTableMyself();
        Utilities.showCorelTable(corelation, 4, 4);
        System.out.println(P(Xi2()));
        if(!isEnough) {
            System.out.println("Вхідних пар даних не вистачає для коректності результатів.");
        }
        */
    }

}
