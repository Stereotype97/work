package ua.kpi.tef;
/**
 * Created by Димон on 10.04.2017.
 */
public class Book {
    String name;
    String SurnameAuthor;
    String nameAuthor;
    String Publishing;
    int yearPublished;
    Integer price;

    public Book(String name, String surnameAuthor, String nameAuthor, String publishing, int yearPublished, Integer price) {
        this.name = name;
        SurnameAuthor = surnameAuthor;
        this.nameAuthor = nameAuthor;
        Publishing = publishing;
        this.yearPublished = yearPublished;
        this.price = price;
    }

    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }
    public String getSurnameAuthor() {
        return SurnameAuthor;
    }
    public void setSurnameAuthor(String surnameAuthor) {
        SurnameAuthor = surnameAuthor;
    }
    public String getNameAuthor() {
        return nameAuthor;
    }
    public void setNameAuthor(String nameAuthor) {
        this.nameAuthor = nameAuthor;
    }
    public String getPublishing() {
        return Publishing;
    }
    public void setPublishing(String publishing) {
        Publishing = publishing;
    }
    public int getYearPublished() {
        return yearPublished;
    }
    public void setYearPublished(int yearPublished) {
        this.yearPublished = yearPublished;
    }
    public Integer getPrice() {
        return price;
    }
    public void setPrice(Integer price) {
        this.price = price;
    }
}
