using Microsoft.Data.SqlClient;
using System.Data;

namespace Models;

public class Orders
{
    public Orders()
    {
  //      this.LineItems = new List<LineItem>();
    }
 /*   public Orders(int id)
    {
        this.ID = id;
        this.StoreId = storeid;
        this.OrderDate = orderdate;
        this.Quantity = quantity;
        //this.Totalprice = totalprice;
        this.LineItems = new List<LineItem>();
    } */
    public Orders(DataRow r)
    {
        ID = (int) r["ID"];                          
        StoreId = (int) r["StoreId"];
        Name = r["Name"].ToString() ?? "";
        CustomerId = (int) r["CustomerId"];
        OrderDate = r["OrderDate"].ToString() ?? "";
        Quantity = (int) r["Quantity"];
        Totalprice = (decimal) r["Totalprice"];                           
    }
    public int ID {get; set; }
    public int StoreId{get; set; }
    public string Name { get; set; }
    public int CustomerId{get; set; }
    public string OrderDate {get; set; }
   // public DateTime OrderDate {get; set; }
    //public List<LineItem> LineItems { get; set; }
    public int Quantity { get; set; }
    public decimal Totalprice { get; set; }
/*
    public decimal CalculateTotal()
    {
    
        decimal total = 0;
        if(this.LineItems?.Count > 0)
        {
            foreach(LineItem lineitem in this.LineItems)
            {
                //multiply the product's price by how many we're buying
                total += lineitem.Item.Price * lineitem.Quantity;
            }
        }
        this.Totalprice = total;
  
        return total;
    }
*/
}
/*
public class Order
{
    public Order()
    {
        this.LineItems = new List<LineItem>();
    }
    public Order(int id)
    {
        this.ID = id;
        this.StoreId = storeid;
        this.OrderDate = orderdate;
        this.Quantity = quantity;
        //this.Totalprice = totalprice;
        this.LineItems = new List<LineItem>();
    }
    public int ID {get; set; }
    public int StoreId{get; set; }
    public int CustomerId{get; set; }
    public DateTime OrderDate {get; set; }
    public List<LineItem> LineItems { get; set; }
    public int Quantity { get; set; }
    public decimal Totalprice { get; set; }
    public decimal CalculateTotal()
    {
    
        decimal total = 0;
        if(this.LineItems?.Count > 0)
        {
            foreach(LineItem lineitem in this.LineItems)
            {
                //multiply the product's price by how many we're buying
                total += lineitem.Item.Price * lineitem.Quantity;
            }
        }
        this.Totalprice = total;
  
        return total;
    }

}*/