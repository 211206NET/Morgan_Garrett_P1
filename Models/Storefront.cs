using Microsoft.Data.SqlClient;
using System.Data;

namespace Models;

public class Storefront
{

    //Example of constructor overloading
    public Storefront()
    {
        this.Inventories = new List<Inventory>();
        //this.Orders = new List<Order>();
    }
    public Storefront(DataRow row)
    {
        this.ID = (int) row["ID"];
        this.Location = row["Location"].ToString() ?? "";
        this.State = row["State"].ToString() ?? "";
        this.City = row["City"].ToString() ?? "";

    }
  /*  public Storefront(string location)
    {
        this.Inventories = new List<Inventory>();
        //this.Orders = new List<Order>();
        this.Location = location;
    }*/
     public int ID { get; set; }
    public string Location { get; set; }
    public string State { get; set; }
    public string City { get; set; }
  //  public List<Product> Products {get; set; } //  delete this and stuff in file
    public List<Inventory> Inventories { get; set; }
    public List<Orders> Order { get; set; }
}