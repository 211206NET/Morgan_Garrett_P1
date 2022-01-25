//namespace DL;
//public class StaticStorage : IRepo
//{
    
//    private static List<Customer> _allCustomers = new List<Customer>();
//    private static List<Storefront> _allStorefronts = new List<Storefront>();
//    private static List<Product> _allProducts = new List<Product>();
////    private static List<Order> _allOrder = new List<Order>();
//    private static List<Orders> _allOrders = new List<Orders>();
//    private static List<Inventory> _allInventories = new List<Inventory>();
//    private static List<LineItem> _allLineItems = new List<LineItem>();

///// <summary>
///// returns all customers that have signed in
///// </summary>
///// <returns>all customers in the list</returns>
//     public List<Customer> GetAllCustomers()
//    {
//        return StaticStorage._allCustomers;
//    }

///// <summary>
///// Adds a new customer to the online store
///// </summary>
///// <param name="CustomertoAdd">new customer object</param>
//    public void AddCustomer(Customer CustomertoAdd)
//    {
//        StaticStorage._allCustomers.Add(CustomertoAdd);
//    }

//    public List<Storefront> GetAllStorefronts()
//    {
//        return StaticStorage._allStorefronts;
//    }
//    public void AddStorefront(Storefront StorefronttoAdd)
//    {
//        StaticStorage._allStorefronts.Add(StorefronttoAdd);
//    }
//    public List<Product> GetAllProducts()
//    {
//        return StaticStorage._allProducts;
//    }
//    public void AddProduct(int StoreIndex, Product ProducttoAdd)
//    {
// //       StaticStorage._allStorefronts[StoreIndex].Products.Add(ProducttoAdd);
//    }
//     public List<Orders> GetAllOrders()
//    {
//        return StaticStorage._allOrders;
//    }
//      public void AddOrders(Orders OrderstoAdd)
//    {
//       StaticStorage._allOrders.Add(OrderstoAdd);
//    }
//    /*public void AddOrder(int ProductIndex, Order OrdertoAdd)
//    {
//        StaticStorage._allStorefronts[ProductIndex].Orders.Add(OrdertoAdd);
//    }*/
//    public List<Inventory> GetAllInventories()
//    {
//        return StaticStorage._allInventories;
//    }
//    public void AddInventory(int StorefrontIndex, Inventory InventoryToAdd)
//    {
//        StaticStorage._allStorefronts[StorefrontIndex].Inventories.Add(InventoryToAdd);
//    }
//    public void ChangeInventory(int InventoryIndex, int qtyToC)
//    {
//   //      StaticStorage.ChangeInventory(InventoryIndex, qtyToC);
//    }
//     public void RemoveOrder(int IdToRem)
//     {
         
//     }
//     public List<LineItem> GetAllLineItems()
//    {
//        return StaticStorage._allLineItems;
//    }
//     public void AddLineItem(int OrderIndex, LineItem LineItemToAdd)
//    {
//       // StaticStorage._allOrders[OrderIndex].LineItems.Add(LineItemToAdd);
//    }

//}
