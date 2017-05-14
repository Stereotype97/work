package ua.kpi.tef;

import java.sql.*;
import java.util.ArrayList;

/**
 * Created by Admin on 17.04.2017.
 */

public class InitializingList {
    public static final int AMOUNT_ALL_CREDITS = 10;
    public static final String SELECT_FROM_TABLE_CREDIT =
            "SELECT `name`, `goal`, `percent`, `term`, `redemption` " +
                    "from credit;";
    Connection connection = null;
    Statement statement = null;

    public ArrayList<BankWithCreditLine> getCreditLines() {
        return creditLines;
    }

    public ArrayList<BankWithCreditLine> creditLines = new ArrayList<BankWithCreditLine>();

    public  InitializingList() throws SQLException, ClassNotFoundException {
        connectToDatabase();

        statement = connection.createStatement();
        ResultSet resultSet = statement.executeQuery(SELECT_FROM_TABLE_CREDIT);

        while (resultSet.next()){
            String name = resultSet.getString("name");
            String goal = resultSet.getString("goal");
            int percent = resultSet.getInt("percent");
            int term = resultSet.getInt("term");
            String redemption = resultSet.getString("redemption");
            creditLines.add(new BankWithCreditLine(name, goal, percent, term, redemption));
            //System.out.println(name + " " + goal + " " + percent + " " + term + " " + redemption);
        }
        connection.close();
    }

    public void connectToDatabase() throws SQLException, ClassNotFoundException {
        try {
            Class.forName("com.mysql.jdbc.Driver");
        } catch (ClassNotFoundException e) {
            System.out.println("Where is your MySQL JDBC Driver?");
            e.printStackTrace();
            return;
        }
        connection = DriverManager.getConnection("jdbc:mysql://localhost:3306/credits","root", "LEAD1");

    }
}
