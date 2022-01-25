namespace Models;

public class LineItem
{
    public LineItem(){}
   /* public LineItem( int id, int pid, int quantity)
    {
   //     this.ID = iid;
        this.OrderId = id;
        this.ProductId = pid;
        this.Quantity = quantity;
   //     this.Item = item;
    }*/    
    public int ID { get; set; }
    public int OrderId { get; set; }
    public int ProductId{get; set;}
    public int Quantity { get; set; }
    public Product Item { get; set; }
}