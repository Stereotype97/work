package ua.kpi.tef;

/**
 * Created by Admin on 17.04.2017.
 */
public class BankWithCreditLine extends Bank implements ICreditable {

    private String creditGoal;
    private int percent;
    private int term;
    private String redemption;

    public BankWithCreditLine(String name, String creditGoal, int percent, int term, String redemption) {
        this.name = name;
        this.creditGoal = creditGoal;
        this.percent = percent;
        this.term = term;
        this.redemption = redemption;
    }
    public int getPercent() {
        return percent;
    }

    public void setPercent(int percent) {
        this.percent = percent;
    }

    public int getTerm() {
        return term;
    }

    public void setTerm(int term) {
        this.term = term;
    }

    public String getRedemption() {
        return redemption;
    }

    public void setRedemption(String redemption) {
        this.redemption = redemption;
    }

    public String getCreditGoal() {
        return creditGoal;
    }

    public void setCreditGoal(String creditGoal) {
        this.creditGoal = creditGoal;
    }


    @java.lang.Override
    public void giveCredit() {

    }
}
