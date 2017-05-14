package ua.kpi.tef;

import java.io.UnsupportedEncodingException;
import java.net.URL;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Locale;
import java.util.ResourceBundle;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.*;

public class Controller implements Initializable{


    View view;
    private ResourceBundle bundle;
    private int sizeList;
    private int indexPage;
    private ArrayList<BankWithCreditLine> creditList;


    public static final int SIZE_OF_COLLECTION = InitializingList.AMOUNT_ALL_CREDITS;


    @FXML private Button previous, next, showAllVariants, choiceThisCredit, addFilterGoal, addFilterBank, addFilterPercent;
    @FXML private ComboBox<String> comboBoxGoalCredit, comboBoxBank, comboBoxPercent, comboBoxTerm;
    @FXML private Label choiceCreditGoal, creditGoal, numberSuitableCredits, index, bank, percent, term, redemption,
            choiceBank, choicePercent, choiceTerm;
    @FXML private TextField indexField, bankField, goalField, percentField, termField, redemptionField;

    @Override
    public void initialize(URL location, ResourceBundle resources){
        view = new View();
        bundle = resources;
    }

    public void setBundle(Locale locale){
        bundle = ResourceBundle.getBundle(view.NAME_OF_BUNDLE, locale);
    }
    public void setRuLocale(){
        setBundle(new Locale("ru", "RU"));
        changeNamesAllFields();
    }
    public void setEnLocale(){
        setBundle(new Locale("en", "En"));
        changeNamesAllFields();
    }

    private String processByBundleAndConvertToCp1251(String keyBundle){
        String result = "";
        try {
            result = Utilities.convertFrom866To1251(bundle.getString(keyBundle));
        }catch (UnsupportedEncodingException e){
            result = "Data is not exist!";
        }
        return result;
    }
    private void changeNamesAllFields(){
        choiceCreditGoal.setText(processByBundleAndConvertToCp1251(view.NAME_OF_PROJECT));
        creditGoal.setText(processByBundleAndConvertToCp1251(view.CREDITS_GOAL));
        comboBoxGoalCredit.setPromptText(processByBundleAndConvertToCp1251(view.NOT_INDICATED));
        comboBoxGoalCredit.getItems().set(0, processByBundleAndConvertToCp1251(view.BUYING_CAR));
        comboBoxGoalCredit.getItems().set(1, processByBundleAndConvertToCp1251(view.BUYING_APARTMENT));
        comboBoxGoalCredit.getItems().set(2, processByBundleAndConvertToCp1251(view.BEGIN_BUSINESS));
        showAllVariants.setText(processByBundleAndConvertToCp1251(view.SHOW_ALL_VARIANTS));
        numberSuitableCredits.setText(processByBundleAndConvertToCp1251(view.NUMBER_OF_SUITABLE_CREDITS));
        index.setText(processByBundleAndConvertToCp1251(view.INDEX));
        bank.setText(processByBundleAndConvertToCp1251(view.BANK));
        bankField.setPromptText(processByBundleAndConvertToCp1251(view.PROMPT_BANK));
        percent.setText(processByBundleAndConvertToCp1251(view.PERCENT));
        term.setText(processByBundleAndConvertToCp1251(view.TERM));
        redemption.setText(processByBundleAndConvertToCp1251(view.REDEMPTION));
        redemptionField.setPromptText(processByBundleAndConvertToCp1251(view.PROMPT_REDEPMPTION));
        choiceThisCredit.setText(processByBundleAndConvertToCp1251(view.CHOICE_THIS_CREDIT));
        choiceBank.setText(processByBundleAndConvertToCp1251(view.CHOICE_BANK));
        comboBoxBank.setPromptText(processByBundleAndConvertToCp1251(view.NOT_CHOSEN));
        comboBoxBank.getItems().set(0, processByBundleAndConvertToCp1251(view.NOT_CHOSEN));
        comboBoxBank.getItems().set(1, processByBundleAndConvertToCp1251(view.PRIVATBANK));
        comboBoxBank.getItems().set(2, processByBundleAndConvertToCp1251(view.OSHADBANK));
        comboBoxBank.getItems().set(3, processByBundleAndConvertToCp1251(view.TINKOFF));
        choicePercent.setText(processByBundleAndConvertToCp1251(view.CHOICE_PERCENT));
        choiceTerm.setText(processByBundleAndConvertToCp1251(view.CHOICE_TERN_REDEMPTION ));

    }

    public void onNextClick() {

        if (indexPage == 1) {
            previous.setDisable(false);
        }
        indexPage++;
        if (indexPage == creditList.size()) {
            next.setDisable(true);
        }

        fillFields(indexPage);

    }

    public void onPrevClick() {
        if (indexPage == creditList.size()) {
            next.setDisable(false);
        }
        indexPage--;
        if (indexPage == 1) {
            previous.setDisable(true);
        }

        fillFields(indexPage);
    }

    public void showAllVariant() throws SQLException, ClassNotFoundException {
        creditList = new InitializingList().getCreditLines();
        indexPage = 1;
        sizeList = creditList.size();
        next.setDisable(false);
        previous.setDisable(true);
            fillFields(indexPage);
        choiceThisCredit.setDisable(false);
    }

    private void fillFields(int indexOfKeyCatalog) {
        indexField.setText("   " + indexPage + "/" + sizeList);
            bankField.setText(creditList.get(indexOfKeyCatalog - 1).getName());
        goalField.setText(creditList.get(indexOfKeyCatalog - 1).getCreditGoal());
        percentField.setText(String.valueOf(creditList.get(indexOfKeyCatalog - 1).getPercent()));
        termField.setText(String.valueOf(creditList.get(indexOfKeyCatalog - 1).getTerm()));
        redemptionField.setText(creditList.get(indexOfKeyCatalog - 1).getRedemption());
    }

    public void sortByBank(){
        for (int i = creditList.size() - 1; i >= 0; i--) {
            if(!creditList.get(i).getName().equals(comboBoxBank.getSelectionModel().getSelectedItem().toString())){
                creditList.remove(i);
            }

        }
        sizeList = creditList.size();
        indexPage = 1;
        if (sizeList != 0)
            fillFields(indexPage);
        blockButtonTransition();
    }

    public void sortByPercent(){
        for (int i = creditList.size() - 1; i >= 0; i--) {
            if(creditList.get(i).getPercent() != Integer.parseInt(comboBoxPercent.getSelectionModel().getSelectedItem().toString())){
                creditList.remove(i);
            }

        }
        sizeList = creditList.size();
        indexPage = 1;
        if (sizeList != 0)
            fillFields(indexPage);
        blockButtonTransition();
    }

    public void sortByGoal(){
        for (int i = creditList.size() - 1; i >= 0; i--) {
            if(!creditList.get(i).getCreditGoal().equals(comboBoxGoalCredit.getSelectionModel().getSelectedItem().toString())){
                creditList.remove(i);
            }

        }
        sizeList = creditList.size();
        indexPage = 1;
        if (sizeList != 0)
            fillFields(indexPage);
        blockButtonTransition();
    }
    public void finish(){
        Alert alert;
        alert = new Alert(Alert.AlertType.INFORMATION);
        alert.setTitle("Информация");
        alert.setHeaderText(null);
        alert.setContentText("Кредит успешно выбран");
        alert.show();
        disableAllFields();
    }

    private void disableAllFields(){
        comboBoxGoalCredit.setDisable(true);
        showAllVariants.setDisable(true);
        bankField.setDisable(true);
        goalField.setDisable(true);
        percentField.setDisable(true);
        termField.setDisable(true);
        redemptionField.setDisable(true);
        comboBoxBank.setDisable(true);
        comboBoxPercent.setDisable(true);
        comboBoxTerm.setDisable(true);
        next.setDisable(true);
        previous.setDisable(true);
        addFilterGoal.setDisable(true);
        addFilterBank.setDisable(true);
        addFilterPercent.setDisable(true);
        choiceThisCredit.setDisable(true);
    }
    private void blockButtonTransition(){
        if (sizeList <= 1){
            next.setDisable(true);
            previous.setDisable(true);
        }
    }


}
