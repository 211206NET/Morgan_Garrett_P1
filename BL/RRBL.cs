namespace BL;
public class RRBL : IBL
{
    private IRepo _dl;

    public RRBL(IRepo repo)
    {
        _dl = repo;
    }
    /// <summary>
    /// gets all customers
    /// </summary>
    /// <returns></returns>
    public List<Customer> GetAllCustomers()
    {
        return _dl.GetAllCustomers();
    }
    /// <summary>
    /// adds a customer
    /// </summary>
    /// <param name="CustomertoAdd"></param>
    public void AddCustomer(Customer CustomertoAdd)
    {
        _dl.AddCustomer(CustomertoAdd);
    }
    /// <summary>
    /// gets all stores
    /// </summary>
    /// <returns></returns>
     public List<Storefront> GetAllStorefronts()
    {
        return _dl.GetAllStorefronts();
    }
    /// <summary>
    /// adds a store
    /// </summary>
    /// <param name="StorefronttoAdd"></param>
    public void AddStorefront(Storefront StorefronttoAdd)
    {
        _dl.AddStorefront(StorefronttoAdd);
    }
/// <summary>
/// gets all products
/// </summary>
/// <returns></returns>
    public List<Product> GetAllProducts()
    {
        return _dl.GetAllProducts();
    }
    /// <summary>
    /// adds a product
    /// </summary>
    /// <param name="StoreIndex"></param>
    /// <param name="ProducttoAdd"></param>
    public void AddProduct(int StoreIndex, Product ProducttoAdd)
    {
        _dl.AddProduct(StoreIndex, ProducttoAdd);
    }
    /// <summary>
    /// gets all orders
    /// </summary>
    /// <returns></returns>
    public List<Orders> GetAllOrders()
    {
        return _dl.GetAllOrders();
    }
    /// <summary>
    /// adds an order to the list
    /// </summary>
    /// <param name="OrderstoAdd"></param>
     public void AddOrders(Orders OrderstoAdd)
    {
        _dl.AddOrders(OrderstoAdd);
    }
  /*  public void AddOrder(int OrderIndex, Order OrdertoAdd)
    {
        _dl.AddOrder(OrderIndex, OrdertoAdd);
    }*/
    /// <summary>
    /// gets all of the inventories
    /// </summary>
    /// <returns></returns>
    public List<Inventory> GetAllInventories()
    {
        return _dl.GetAllInventories();
    }
    /// <summary>
    /// adds an inventory to the list of a store
    /// </summary>
    /// <param name="StorefrontIndex"></param>
    /// <param name="InventoryToAdd"></param>
    public void AddInventory(int StorefrontIndex, Inventory InventoryToAdd)
    {
        _dl.AddInventory(StorefrontIndex, InventoryToAdd);
    }
    /// <summary>
    /// change the inventory quantity
    /// </summary>
    /// <param name="InventoryIndex"></param>
    /// <param name="qtyToC"></param>
    public void ChangeInventory(int InventoryIndex, int qtyToC)
    {
        _dl.ChangeInventory(InventoryIndex, qtyToC);
    }
    /// <summary>
    /// removes an order form the list
    /// </summary>
    /// <param name="IdToRem"></param>
     public void RemoveOrder(int IdToRem)
     {
         _dl.RemoveOrder(IdToRem);
     }
     /// <summary>
     /// gets all of the line items
     /// </summary>
     /// <returns></returns>
    public List<LineItem> GetAllLineItems()
    {
        return _dl.GetAllLineItems();
    }
    /// <summary>
    /// adds the line items
    /// </summary>
    /// <param name="OrderIndex"></param>
    /// <param name="LineItemToAdd"></param>

     public void AddLineItem(int OrderIndex, LineItem LineItemToAdd)
    {
        _dl.AddLineItem(OrderIndex, LineItemToAdd);
    }

    public Inventory GetInventoriesByStoreId(int StoreId)
    {
        return _dl.GetInventoriesByStoreId(StoreId);
        //throw new NotImplementedException();
    }

    public Orders GetCustomerOrders(int CustomerID)
    {
        return _dl.GetCustomerOrders(CustomerID);
        //throw new NotImplementedException();
    }

    public List<Orders> GetAllOrdersforCustomers(int Cid, int Sid)
    {
        return _dl.GetAllOrdersforCustomers(Cid, Sid);
      //  throw new NotImplementedException();
    }

    public void AddOrders(string Date, Orders OrdersToAdd)
    {
        _dl.AddOrders(Date, OrdersToAdd);
      //  throw new NotImplementedException();
    }

    public Inventory GetInventoriesById(int StoreId)
    {
   //     return _dl.GetInventoriesById(StoreId);
       throw new NotImplementedException();
    }

    List<Inventory> IBL.GetInventoriesById(int StoreId)
    {
        return _dl.GetInventoriesById(StoreId);
     //   throw new NotImplementedException();
    }
}
