package ua.kpi.tef;

import ua.kpi.tef.Model.entity.Model;
import ua.kpi.tef.Model.entity.Product;

public class Main {

    public static void main(String[] args) {
	// write your code here
        Product product = new Product();
        product.checkOverride();

        Model model = new Model();
        View view = new View();

        Controller controller = new Controller(model, view);
        controller.processUserRecord();
    }
}
