using Microsoft.Data.SqlClient;
using System.Data;

namespace Models;
public class Product
{
    public Product()
    {   
    }
    public Product( string name, decimal price, string des)
    {
        this.Name = name;
        this.Price = price;
        this.Description = des;
    }
    public Product(int id, string name, decimal price, string des)
    {
        this.ID = id;
        this.Name = name;
        this.Price = price;
        this.Description = des;
    }
      public Product(DataRow row)
    {
        this.ID = (int) row["ID"];
        this.Name = row["Name"].ToString() ?? "";
        this.Price = (decimal) row["Price"];   
        this.Description = row["Description"].ToString() ?? "";

    }
    public int ID {get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
     public List<Orders> Order { get; set; }
}