package ua.kpi.tef.Model.entity;

/**
 * Created by Димон on 20.03.2017.
 */
public class Model {
    private Product product;

    public Model(){
        product = new Product();
    }

    public void setProduct(Product product) {
        this.product = product;
    }

    public Product getProduct() {
        return product;
    }
}
