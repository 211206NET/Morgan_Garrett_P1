using Microsoft.Data.SqlClient;
using System.Data;

namespace Models;
public class Inventory
{
    public Inventory()
    {
    }
   /* public Inventory( int quantity, int storeid, string name, decimal price, string des)
    {
      //  this.ID = id;
      //  this.ProductId = pid;
        this.Quantity = quantity;
        this.StoreId = storeid;
        this.Name = name;
        this.Price = price;
        this.Description = des;
      //  this.Item = item;
    }*/
 /*   public Inventory(int id,int pid, int quantity, int storeid, Product item)
    {
        this.ID = id;
        this.ProductId = pid;
        this.Quantity = quantity;
        this.StoreId = storeid;
        this.Item = item;
    }*/
     public Inventory(DataRow r)
    {
        ID = (int) r["ID"];  
        Quantity = (int) r["Quantity"];                        
        StoreId = (int) r["StoreId"];
        Name = r["Name"].ToString() ?? "";   
        Price = (decimal) r["Price"];   
        Description = r["Description"].ToString() ?? "";                        
    }
    public int ID{get; set;}
  //  public int ProductId{get; set;}
    public int Quantity { get; set; }
    public int StoreId{get; set;}
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
  //  public List<LineItem> LineItems { get; set; }
  //  public Product Item {get; set;}
    
}