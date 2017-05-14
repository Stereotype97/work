package ua.kpi.tef;

/**
 * Created by Димон on 20.03.2017.
 */
public class View {
    public static final String WRONG_INPUT_ONLY_NUMBERS = "Некорректный ввод, должны быть только цифры!";
    public static final String WRONG_INPUT_ONLY_LETTERS = "Некорректный ввод, должны быть только буквы"
           + " русского или английского алфавита!\n Возможно, первая буква должна быть большой?\n";
    public static final String WRONG_INPUT_DATE = "Некорректный ввод, следуйте указаниям!";
    public static final String WRONG_INPUT_MOBILE_PHONE_NUMBER = "Некорректный ввод, введите номер телефона, как указано";
    public static final String WRONG_INPUT_NOT_MONEY_FORMAT = "Некорректный ввод, должны быть только цифры и разделяющий знак!(две цифры после него)";

    public static final String INPUT = "Введите ";
    public static final String SСHEDULE_DATE = "Шаблон: 12.9.2000";
    public static final String SСHEDULE_MOBILE_PHONE_NUMBER = "Шаблон: +38(050)123-45-67";

    public void printMessage(String message){
        System.out.println(message);
    }
}
