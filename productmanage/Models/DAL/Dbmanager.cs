namespace DAL;
using System.Collections.Generic;
using BOL;

public class Dbmanager{


    
    public static List<Product1> getallproducts(){
CollectionContext context=new CollectionContext();
        var p=from product in  context.Products select product;

        return p.ToList<Product1>();
    }


    public static Product1 getproductbyid(int id){
        CollectionContext context=new CollectionContext();

        var prod=context.Products.Find(id);

        return prod;
    }


    public static void insertproduct(Product1 prod){
        CollectionContext con=new CollectionContext();
        con.Products.Add(prod);

        con.SaveChanges();
    }


    public static void deleteproduct(int id){
        CollectionContext con=new CollectionContext();
        con.Products.Remove(con.Products.Find(id));
        con.SaveChanges();
    }

    public static void updateproduct(Product1 p){
        CollectionContext con=new CollectionContext();
       var pr= con.Products.Find(p.ProductId);
       pr.Productname=p.Productname;
       pr.Price=p.Price;
       pr.Quantity=p.Quantity;
        con.SaveChanges();
    }
}