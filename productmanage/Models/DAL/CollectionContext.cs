using BOL;
using Microsoft.EntityFrameworkCore;

public class CollectionContext:DbContext{
    public DbSet<Product1> Products{get;set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        string? constring=@"server=localhost ;port=3306;user=root;password=Reset@123; database=imp";

        optionsBuilder.UseMySQL(constring);
    }

    protected override void OnModelCreating(ModelBuilder builder1){

        base.OnModelCreating(builder1);

        builder1.Entity<Product1>(entity=>{
              
              entity.HasKey(e=>e.ProductId);
              entity.Property(e=>e.Productname);
              entity.Property(e=>e.Price);
              entity.Property(e=>e.Quantity);
            
        });

        builder1.Entity<Product1>().ToTable("product");
    }
}


