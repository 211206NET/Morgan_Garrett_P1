namespace DL;
public interface IRepo
{
    //Notice, how we're lacking access modifiers
    //interface members are implicitely public
    //they also lack method body
    List<Customer> GetAllCustomers();
    List<Storefront> GetAllStorefronts();
    List<Product> GetAllProducts();
  //  List<Order> GetAllOrder();
    List<Orders> GetAllOrders();
    List<Inventory> GetAllInventories();
    List<LineItem> GetAllLineItems();

    void AddCustomer(Customer CustomerToAdd);
    void AddStorefront(Storefront StorefrontToAdd);
    void AddOrders(Orders OrdersToAdd);
    void AddOrders(string Date, Orders OrdersToAdd);
    void AddProduct(int StoreIndex, Product ProducttoAdd);
   // void AddOrder(int OrderIndex, Order OrderToAdd);
    void AddInventory(int StorefrontIndex, Inventory InventoryToAdd);
    void ChangeInventory(int InventoryIndex, int qtyToC);
    void RemoveOrder(int IdToRem);
    void AddLineItem(int OrderIndex, LineItem LineItemToAdd);
    Inventory GetInventoriesByStoreId(int StoreId);
    List<Inventory> GetInventoriesById(int StoreId);
    //  Inventory GetInventoriesById(int StoreId);
    Orders GetCustomerOrders(int CustomerID);
    List<Orders> GetAllOrdersforCustomers(int Cid, int Sid);

}