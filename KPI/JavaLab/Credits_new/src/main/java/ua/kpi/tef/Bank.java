package ua.kpi.tef;

/**
 * Created by Укртелеком on 16.04.2017.
 */
public class Bank {
    protected String name;
    protected double capital;
    protected int amountClients;

    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }
    public double getCapital() {
        return capital;
    }
    public void setCapital(double capital) {
        this.capital = capital;
    }
    public int getAmountClients() {
        return amountClients;
    }
    public void setAmountClients(int amountClients) {
        this.amountClients = amountClients;
    }
}