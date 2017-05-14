package ua.kpi.tef;

import javafx.fxml.FXML;

import javafx.scene.control.Alert;
import javafx.scene.control.ComboBox;
import javafx.scene.control.TextField;
import javafx.scene.control.Button;
//import javafx.scene.input.MouseEvent;
//import javafx.event.EventHandler;
import java.util.*;


public class Controller {

    Model model = new Model();

    private int indexPage = 1;
    private String key = new String();
    @FXML
    private Button look, left, right, changePrice, sort;
    @FXML
    private TextField textIndex, textISBN, textName, textSurnameAuthor, textNameAuthor, textPublishing, textYearPublished, textPrice, textNewPrice;
    @FXML
    private ComboBox<String> comboBox;



    private void fillFields(int indexOfKeyCatalog){

        Map<String, Book> localCatalog = model.getCatalog();
        key = model.getKeyCatalog().get(indexOfKeyCatalog - 1);

        textIndex.setText("   " + indexPage + "/" + model.SIZE_OF_COLLECTION);
        textISBN.setText(key);
        textName.setText(localCatalog.get(key).getName());
        textSurnameAuthor.setText(localCatalog.get(key).getSurnameAuthor());
        textNameAuthor.setText(localCatalog.get(key).getNameAuthor());
        textPublishing.setText(localCatalog.get(key).getPublishing());
        textYearPublished.setText(String.valueOf(localCatalog.get(key).getYearPublished()));
        textPrice.setText(String.valueOf(localCatalog.get(key).getPrice()));
    }

    public void onLookClick() {

        indexPage = 1;
        fillFields(indexPage);
        right.setDisable(false);
        left.setDisable(true);
    }

    public void onRightClick() {

        if(indexPage == 1){
            left.setDisable(false);
        }
        indexPage++;
        if(indexPage == model.SIZE_OF_COLLECTION){
            right.setDisable(true);
        }

        fillFields(indexPage);

    }
    public void onLeftClick() {
        if(indexPage == model.SIZE_OF_COLLECTION){
            right.setDisable(false);
        }
        indexPage--;
        if(indexPage == 1){
            left.setDisable(true);
        }

        fillFields(indexPage);
    }
    public void onChangePriceClick() {
        if(!textNewPrice.getText().equals("")) {

            key = model.getKeyCatalog().get(indexPage - 1);
            Book book = model.getCatalog().get(key);
            book.setPrice(Integer.parseInt(textNewPrice.getText()));
            model.getCatalog().replace(key, book);

            textPrice.setText(String.valueOf(model.getCatalog().get(key).getPrice()));

            textNewPrice.setText("");
        }
        else{
            textNewPrice.setText("Введите новую цену!");
        }
    }
    @FXML
    public void onSortClick() {
        Alert alert;
        if(comboBox.getSelectionModel().isEmpty()){
            alert = new Alert(Alert.AlertType.ERROR);
            alert.setTitle("Ошибка");
            alert.setHeaderText(null);
            alert.setContentText("Вы не выбрали критерий!");
            alert.showAndWait();
        }
        else {
            String selectedItem = comboBox.getSelectionModel().getSelectedItem().toString();

            if (selectedItem.equals("ISBN"))
                Collections.sort(model.getKeyCatalog());

            else if (selectedItem.equals("фамилии автора")) {
                sortBySurname();
            } else if (selectedItem.equals("цене книги")) {
                sortByPrice();
            }

            alert = new Alert(Alert.AlertType.INFORMATION);
            alert.setTitle("Информация");
            alert.setHeaderText(null);
            alert.setContentText("Нажмите кнопку \"Просмотр\"!");
            alert.show();
        }
    }

    private void sortBySurname(){
        final Map<String, Book> sortedMap = new TreeMap<>(new Comparator<String>() {
            @Override
            public int compare(String lhs, String rhs) {
                return model.getCatalog().get(lhs).getSurnameAuthor().compareTo(model.getCatalog().get(rhs).getSurnameAuthor());
            }
        });
        sortedMap.putAll(model.getCatalog());
        int i = 0;
        for (final Map.Entry<String, Book> entry: sortedMap.entrySet())  {
            model.getKeyCatalog().set(i, entry.getKey());
            i++;
        }
    }
    private void sortByPrice(){
        final Map<String, Book> sortedMap = new TreeMap<String, Book>(new Comparator<String>() {
            @Override
            public int compare(String lhs, String rhs) {
                return model.getCatalog().get(lhs).getPrice() - model.getCatalog().get(rhs).getPrice();
            }
        });
        sortedMap.putAll(model.getCatalog());
        int i = 0;
        for (final Map.Entry<String, Book> entry: sortedMap.entrySet())  {
            model.getKeyCatalog().set(i, entry.getKey());
            i++;
        }
    }

    public void clearAllFields(){
        textIndex.setText("   " + 1 + "/" + model.SIZE_OF_COLLECTION);

        textISBN.setText("");
        textName.setText("");
        textSurnameAuthor.setText("");
        textNameAuthor.setText("");
        textPublishing.setText("");
        textYearPublished.setText("");
        textPrice.setText("");
        textNewPrice.setText("");
    }
/*
    @FXML
    public void initialize() {
        look.addEventHandler(MouseEvent.MOUSE_CLICKED, new EventHandler<MouseEvent>() {
            @Override
            public void handle(MouseEvent event) {
                //action
            }
        });
    }
*/
    }


