package ua.kpi.tef;

/**
 * Created by Димон on 10.05.2017.
 */
public class Interval {
    int leftBound;
    int rightBound;

    public Interval() {
        leftBound = 0;
        rightBound = 10;
    }

    public Interval(int leftBound, int rightBound) {
        this.leftBound = leftBound;
        this.rightBound = rightBound;
    }
}
