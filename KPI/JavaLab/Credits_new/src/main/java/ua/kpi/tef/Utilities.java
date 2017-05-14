package ua.kpi.tef;

import java.io.UnsupportedEncodingException;

/**
 * Created by Укртелеком on 17.04.2017.
 */
public class Utilities {
    public static String convertFrom866To1251(String stringRus) throws UnsupportedEncodingException {

        byte[] convertArray = stringRus.getBytes("ISO-8859-1");
        String win = new String(convertArray,"Cp1251");
        return win;
    }
}
