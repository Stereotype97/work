package ua.kpi.tef;

/**
 * Created by Димон on 13.04.2017.
 */
public class DataValue {

    public int xDichotomy;
    public int yQuantitative;
    public double yRanged;
    public DataValue(){
        xDichotomy = 0;
        yQuantitative = 0;
        yRanged = 0.0;
    }

    public DataValue(int xDichotomy, int yQuantitative) {
        this.xDichotomy = xDichotomy;
        this.yQuantitative = yQuantitative;
        yRanged = 0.0;
    }
}
