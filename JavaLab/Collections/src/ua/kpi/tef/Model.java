package ua.kpi.tef;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;
import java.util.Set;

/**
 * Created by Димон on 10.04.2017.
 */
public class Model {
    public static final int SIZE_OF_COLLECTION = 5;


    private Map<String, Book> catalog = new HashMap<>();
    private ArrayList<String> keyCatalog = new ArrayList<>();

    public Map<String, Book> getCatalog() {
        return catalog;
    }
    public ArrayList<String> getKeyCatalog() {
        return keyCatalog;
    }

    public Model(){
        catalog.put("978-5-496-00487-9", new Book("Чистый код", "Мартин", "Роберт",
                "Питер", 2016, 334));
        catalog.put("978-5-9775-3346-1", new Book("Qt 5.3 C++", "Шлее", "Макс",
                "БХВ-Петербург", 2016, 475));
        catalog.put("978-5-8459-1839-0", new Book("Язык программирования С++", "Липпман, Лажойе",
                "Стенли, Жози","Вильямс", 2014, 670));
        catalog.put("978-5-9922-2054-4", new Book("Возвращение Шерлока Холмса", "Дойль", "Артур",
                "Альфа-книга", 2015, 190));
        catalog.put("978-5-9922-2369-9", new Book("Таинственный остров", "Верн", "Жуль",
                "Альфа-книга", 2017, 216));

        makeKeyCatalog();
        }

        private void makeKeyCatalog(){
            Set<Map.Entry<String, Book>> set = catalog.entrySet();
            for (Map.Entry<String, Book> i :set) {
                keyCatalog.add(i.getKey());
            }

    }

}
