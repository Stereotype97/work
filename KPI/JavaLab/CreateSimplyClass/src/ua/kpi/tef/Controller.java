package ua.kpi.tef;

import ua.kpi.tef.Model.entity.Model;
import ua.kpi.tef.Model.entity.Product;

import java.util.regex.*;
import java.util.Scanner;

/**
 * Created by Димон on 20.03.2017.
 */
public class Controller {
    public static final String REGEX_ONLY_NUMBERS = "[0-9]+";
    public static final String REGEX_ONLY_LETTERS = "[A-ZА-Я][a-zа-я]+";
    public static final String REGEX_MOBILE_PHONE = "\\+\\d{2}\\(\\d{3}\\)\\d{3}-\\d{2}-\\d{2}";
    public static final String REGEX_DATE = "\\d{1,2}\\.\\d{1,2}\\.?\\d{0,4}";
    public static final String REGEX_MONEY_FORMAT = "[0-9]+[.,]?[0-9]{0,2}";

    Model model;
    View view;
    Product product = new Product();

    Pattern pattern;
    Scanner scanner = new Scanner(System.in);

    public Controller(Model model, View view){
        this.model = model;
        this.view = view;
    }

    public void processUserRecord(){
        processName();
        processFabricator();
        processAmount();
        processDateOfManufacture();
        processDateOfExpiration();
        processProvider();
        processNumberOfProvider();
        processNumberOfFabricator();
        processPrice();

        model.setProduct(product.clone());
    }

    /**This function check data getting from console while not get correctly string and return it*/
    private String checkBySpecifiedRegex(String patternString, String wrongInput){
        pattern = Pattern.compile(patternString);
        while(!scanner.hasNext(pattern)){
            view.printMessage(wrongInput);
            scanner.next();
        }
        return scanner.next();
    }

    private String checkByNumbersPattern(){
        return checkBySpecifiedRegex(REGEX_ONLY_NUMBERS, view.WRONG_INPUT_ONLY_NUMBERS);
    }
    private String checkByLettersPattern(){
        return checkBySpecifiedRegex(REGEX_ONLY_LETTERS, view.WRONG_INPUT_ONLY_LETTERS);
    }
    private String checkByRegexOnMobilePhone(){
        return checkBySpecifiedRegex(REGEX_MOBILE_PHONE, view.WRONG_INPUT_MOBILE_PHONE_NUMBER);
    }
    private String checkByRegexOnDate(){
        return checkBySpecifiedRegex(REGEX_DATE, view.WRONG_INPUT_DATE);
    }
    private String checkByRegexOnMoneyFormat(){
        return checkBySpecifiedRegex(REGEX_MONEY_FORMAT, view.WRONG_INPUT_NOT_MONEY_FORMAT);
    }

    private void processName(){
        view.printMessage(view.INPUT + "наименование товара:\n");
        product.setName(checkByLettersPattern());
    }
    private void processFabricator(){
        view.printMessage(view.INPUT + "производителя:\n");
        product.setFabricator(checkByLettersPattern());
    }
    private void processAmount(){
        view.printMessage(view.INPUT + "количество указанного товара:\n");
        product.setAmount(checkByNumbersPattern());
    }
    private void processDateOfManufacture(){
        view.printMessage(view.INPUT + "дату изготовления:\n" + view.SСHEDULE_DATE);
        product.setDateOfManufacture(checkByRegexOnDate());
    }
    private void processDateOfExpiration(){
        view.printMessage(view.INPUT + "срок годности:\n" + view.SСHEDULE_DATE);
        product.setDateOfExpiration(checkByRegexOnDate());
    }
    private void processProvider(){
        view.printMessage(view.INPUT + "поставщика:\n");
        product.setProvider(checkByLettersPattern());

    }
    private void processNumberOfProvider(){
        view.printMessage(view.INPUT + "номер телефона поставщика:\n" + view.SСHEDULE_MOBILE_PHONE_NUMBER);
        product.setNumberOfProvider(checkByRegexOnMobilePhone());
    }
    private void processNumberOfFabricator(){
        view.printMessage(view.INPUT + "номер телефона изготовителя:\n" + view.SСHEDULE_MOBILE_PHONE_NUMBER);
        product.setNumberOfFabricator(checkByRegexOnMobilePhone());
    }
    private void processPrice(){
        view.printMessage(view.INPUT + "цену за единицу товара:\n");
        product.setPrice(checkByRegexOnMoneyFormat());
    }

}
