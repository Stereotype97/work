package ua.kpi.tef;

import java.util.*;

/**
 * Created by Димон on 10.05.2017.
 */
public class Distribution {

    private int amountIntervals;
    private Interval[] intervals;

    private int[] values;
    private int[] frequencies;


    private double averageValue;
    private double averageAbsoluteDeviation;

    public Distribution() {

    }

    public void process(){
        setBuilderIntervals();
        if(values == null) {
            setValues(TypeCreateValues.AFTER_INPUT);
            showValues();
        }
        confirmFrequencies();
        showTable();
        confirmAverageAbsoluteDeviation();
    }

    private int inputIntValueWithScanner(Scanner sc) {
        while(! sc.hasNextInt()) {
            System.out.println("Помилка! Некоректний ввід! Спробуйте ще раз");
            sc.next();
        }
        return sc.nextInt();
    }

    private void setAmountIntervals(){
        Scanner sc = new Scanner(System.in);
        System.out.print("Введiть кiлькiсть інтервалів [Xi, Xi+1) (не менше 2): ");

        while ((amountIntervals = inputIntValueWithScanner(sc)) < 2)
            System.out.println("Помилка! Число не може бути меншим за 2");
        intervals = new Interval[amountIntervals];
        for (int i = 0; i < intervals.length; i++) {
            intervals[i] = new Interval();
        }
    }

    private void setValues(TypeCreateValues type){
        Scanner sc = new Scanner(System.in);
        System.out.println("Оберiть спосіб заповнення масиву вибіркових значень. 1 - власноруч, iнше - автоматично");
        int choice = inputIntValueWithScanner(sc);
        if(choice == 1){
            inputNumbers(type);
        }
        else{
            System.out.println("Значення розраховуватимуться автоматично!");
            randomNumbers(type);
        }
    }

    private void setAmountValues(){
        Scanner sc = new Scanner(System.in);

        System.out.print("Введiть кiлькiсть вибіркових значень (не менше 1): ");
        int amountValues;
        while ((amountValues = inputIntValueWithScanner(sc)) < 1)
            System.out.println("Помилка! Число не може бути меншим за 1");
        values = new int[amountValues];
    }

    private void inputNumbers(TypeCreateValues type) {
        Scanner sc = new Scanner(System.in);
        setAmountValues();
        switch (type){
            case AFTER_INPUT:
                int min = intervals[0].leftBound, max = intervals[amountIntervals - 1].rightBound;
                System.out.println("Вводьте значення, що належать інтервалу[" + min + "; " + max +  "].");
                for (int i = 0; i < values.length; i++) {
                    System.out.print("Введіть " + (i + 1) + "-е значення: ");
                    while ((values[i] = inputIntValueWithScanner(sc)) < min || values[i] > max)/////////////////////////
                        System.out.println("Помилка! Число не може виходити за границі інтервалу[" + min + "; " + max +  "]. Спробуйте ще раз");
                }
                break;
            case AFTER_STERJERS:
                for (int i = 0; i < values.length; i++) {
                    System.out.print("Введіть " + (i + 1) + "-е значення: ");
                    values[i] = inputIntValueWithScanner(sc);
                }
                break;
        }

    }

    private void randomNumbers(TypeCreateValues type) {
        Scanner sc = new Scanner(System.in);
        setAmountValues();
        switch (type){
            case AFTER_INPUT:
                for (int i = 0; i < values.length; i++) {
                    values[i] = getNumberInRange(intervals[0].leftBound, intervals[amountIntervals - 1].rightBound);
                }
                break;
            case AFTER_STERJERS:
                for (int i = 0; i < values.length; i++) {
                    values[i] = getNumberInRange(-25, 50);
                }
                break;
        }

    }

    private int getNumberInRange(int a, int b){
        Random random = new Random();
        return  random.nextInt(b - a) + a;
    }

    private void setBuilderIntervals() {
        Scanner sc = new Scanner(System.in);
        System.out.println("Оберiть спосіб побудови інтервального розподілу. 1 - власноруч, iнше - за ф-лою Стерджерса");
        int choice = inputIntValueWithScanner(sc);
        if(choice == 1){
            inputBounds();
        }
        else{
            confirmBoundsBySterjers();
        }
    }
    private void inputBounds(){//check
        Scanner sc = new Scanner(System.in);
        setAmountIntervals();
        System.out.print("Введіть 1-шу(ліву) границю: ");
        intervals[0].leftBound = inputIntValueWithScanner(sc);

        int bound, prevBound = intervals[0].leftBound;
        for (int i = 0; i < amountIntervals - 1; i++) {
            System.out.print("Введіть праву границю " + (i + 1) + "-го інтервала: ");

            while ((bound = inputIntValueWithScanner(sc)) <= prevBound)
                System.out.println("Помилка! Число не може бути меншим/рівним попередній границі. Спробуйте ще раз");
            intervals[i].rightBound = bound;
            intervals[i + 1].leftBound = bound;
            prevBound = bound;
        }

        System.out.print("Введіть останню границю: ");
        while((intervals[amountIntervals - 1].rightBound = inputIntValueWithScanner(sc)) <= prevBound)
            System.out.println("Помилка! Число не може бути меншим/рівним попередній границі. Спробуйте ще раз");
        showIntervals();
    }

    private void confirmBoundsBySterjers(){
        setValues(TypeCreateValues.AFTER_STERJERS);
        showValues();
        amountIntervals = 1 + (int)Math.round(log2(values.length));
        //Виділення пам'яті під масив інтервалів
        intervals = new Interval[amountIntervals];
        for (int i = 0; i < intervals.length; i++) {
            intervals[i] = new Interval();
        }

        System.out.println("Кількість інтервалів розрахованих за формулою: " + amountIntervals);
        int xMin = findMin(values), xMax = findMax(values);
        System.out.println("Xmin = " + xMin);
        System.out.println("Xmax = " + xMax);

        int h = (int) Math.ceil((double)(xMax - xMin) / amountIntervals);
        System.out.println("h = " + h);
        int delta = amountIntervals * h - (xMax - xMin), delta1 = delta / 2;
        System.out.println("Delta = " + delta);
        System.out.println("Delta1 = " + delta1);
        //Встановлення інтервалів
        int xBegin = xMin - delta1, xCurrent = xBegin + h;
        intervals[0].leftBound = xBegin;

        for (int i = 0; i < intervals.length - 1; i++) {
            intervals[i].rightBound = xCurrent;
            intervals[i + 1].leftBound = xCurrent;
            xCurrent += h;
        }
        intervals[amountIntervals - 1].rightBound = xCurrent;
        //showIntervals();
    }

    private void confirmFrequencies(){
        //int maxBound = intervals[intervals.length - 1].rightBound;
        //System.out.println(maxBound);
        intervals[intervals.length - 1].rightBound++;
        frequencies = new int[amountIntervals];
        for (int i = 0; i < values.length; i++) {
            for (int j = 0; j < intervals.length; j++) {
                int leftLimit = intervals[j].leftBound, rightLimit = intervals[j].rightBound;
//                if(values[i] == maxBound){
//                    frequencies[frequencies.length - 1]++;
//                    break;
//                }
//                else
                if (values[i] >= leftLimit && values[i] < rightLimit){
                    frequencies[j]++;
                    break;
                }
            }
        }
        intervals[intervals.length - 1].rightBound--;
    }

    private void confirmAverageValue(){
        double sum = 0;
        for(int i = 0; i < intervals.length; i++){
            sum += ((double)(intervals[i].leftBound + intervals[i].rightBound) / 2) * frequencies[i];
        }
        averageValue = sum / values.length;
    }
    private void confirmAverageAbsoluteDeviation(){
        confirmAverageValue();
        System.out.println("Середнє значення елементів вибірки = " + averageValue);
        Map<Integer, Integer> map = new HashMap<Integer, Integer>();
        for (int i = 0; i < values.length; i++) {
            map.put(values[i], map.containsKey(values[i]) ? map.get(values[i]) + 1 : 1);
        }
        Integer[] uniqueValues = new Integer[map.size()];
        Integer[] countValues = new Integer[map.size()];
        map.keySet().toArray(uniqueValues);
        int i = 0;
        for (Integer obj:map.values()) {
            countValues[i] = obj;
            //System.out.println(uniqueValues[i] + " " + countValues[i]);
            i++;
        }

        double sum = 0;
        for (int j = 0; j < intervals.length; j++) {
            double x = (double)(intervals[j].leftBound + intervals[j].rightBound) / 2;
            //System.out.println(x);
            sum += Math.abs(x - averageValue);
        }
        averageAbsoluteDeviation = sum / values.length;
        System.out.format("Середнє абсолютне відхилення = %.2f", averageAbsoluteDeviation);
    }

    double log2(double x)
    {
        return (Math.log(x) / Math.log(2));
    }

    public void showIntervals() {
        System.out.println("Інтервали:");
        for (int i = 0; i < intervals.length; i++) {
            System.out.println("[" + intervals[i].leftBound + ";" + intervals[i].rightBound + ")");
        }
    }
    public void showValues(){
        System.out.println("Значення:");
        for (int i = 0; i < values.length; i++) {
            System.out.print(values[i] + " ");
        }
        System.out.println();
    }
//    public void showFrequencies(){
//        System.out.println("Частоти:");
//        for (int i = 0; i < frequencies.length; i++) {
//            System.out.print(frequencies[i] + " ");
//        }
//        System.out.println();
//    }
    public void showTable(){
        System.out.print("| №|Інтервали|Довжина|Частоти|\n|");
        for (int i = 0; i < 29; i++) {
            System.out.print("-");
        }
        System.out.println('|');
        for (int i = 0; i < intervals.length; i++) {
            int left = intervals[i].leftBound, right = intervals[i].rightBound;
            System.out.format("|%3d|[%3d;%3d)| %3d   | %3d   |%n",
                    i + 1, left, right, right - left, frequencies[i]);
        }
        for (int i = 0; i < 31; i++) {
            System.out.print("-");
        }
        System.out.println();
    }
    private int findMin(int[] array){
        int min = array[0];
        for (int i = 1; i < array.length; i++) {
            if (min > array[i])
                min = array[i];
        }
        return min;
    }
    private int findMax(int[] array){
        int max = array[0];
        for (int i = 1; i < array.length; i++) {
            if (max < array[i])
                max = array[i];
        }
        return max;
    }
}
