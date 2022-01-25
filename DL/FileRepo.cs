//using System.Text.Json;

//namespace DL;

////This class reads and writes to the file
//public class FileRepo : IRepo
//{
//    public FileRepo()
//    { }

//    private string filePath = "../DL/Customers.json";
//    private string filePath1 = "../DL/Storefronts.json";
//    private string filePath2 = "../DL/Orders.json";

//    /// <summary>
//    /// 
//    /// </summary>
//    /// <returns></returns>
//    public List<Customer> GetAllCustomers()
//    {
//        string jsonString = File.ReadAllText(filePath);

//        return JsonSerializer.Deserialize<List<Customer>>(jsonString);
//    }

//    /// <summary>
//    /// 
//    /// </summary>
//    /// <param name="index"></param>
//    /// <returns></returns>
//    public Customer GetCustomerByIndex(int index)
//    {
//        List<Customer> allCustomers = GetAllCustomers();
        
//        return allCustomers[index];
//    }

//    /// <summary>
//    /// 
//    /// </summary>
//    /// <param name="custToAdd"></param>
//    public void AddCustomer(Customer custToAdd)
//    {
//        //First, we're going to grab all the restaurants from the file
//        //Second, we'll deserialize as List<Restaurant>
//        //Third, we'll use List's Add method to add our new restaurant
//        //Lastly, we'll serialize that List<Restaurant> and then write it to the file

//        List<Customer> allCustomers = GetAllCustomers();
//        allCustomers.Add(custToAdd);

//        string jsonString = JsonSerializer.Serialize(allCustomers);
//        File.WriteAllText(filePath, jsonString);
//    }
//    public List<Storefront> GetAllStorefronts()
//    {
//        string jsonString = File.ReadAllText(filePath1);

//        return JsonSerializer.Deserialize<List<Storefront>>(jsonString);
//    }
//     public Storefront GetStorefrontByIndex(int index)
//    {
//        List<Storefront> allStorefronts= GetAllStorefronts();
        
//        return allStorefronts[index];
//    }
//     public void AddStorefront(Storefront storeToAdd)
//    {
//        List<Storefront> allStorefronts= GetAllStorefronts();
//        allStorefronts.Add(storeToAdd);

//        string jsonString = JsonSerializer.Serialize(allStorefronts);
//        File.WriteAllText(filePath1, jsonString);
//    }
//    public List<Product> GetAllProducts()
//    {
//        string jsonString = File.ReadAllText(filePath1);

//        return JsonSerializer.Deserialize<List<Product>>(jsonString);
//    }
//    public Product GetProductByIndex(int index)
//    {
//        List<Product> allProducts= GetAllProducts();
        
//        return allProducts[index];
//    }
//    public void AddProduct(int StoreIndex, Product productToAdd)
//    {
// /*       List<Storefront> allStorefronts = GetAllStorefronts();
//        Storefront selectedStorefront = allStorefronts[StoreIndex];
        
//      if(selectedStorefront.Products == null)
//        {
//           selectedStorefront.Products = new List<Product>();
//        }
//        selectedStorefront.Products.Add(productToAdd);

//        string jsonString = JsonSerializer.Serialize(allStorefronts);
//        File.WriteAllText(filePath1, jsonString);*/
//    }
//    public List<Orders> GetAllOrders()
//    {
//        string jsonString = File.ReadAllText(filePath2);

//        return JsonSerializer.Deserialize<List<Orders>>(jsonString);
//    }
//    public Orders GetOrderByIndex(int index)
//    {
//        List<Orders> allOrders= GetAllOrders();
        
//        return allOrders[index];
//    }
//    public void AddOrders(Orders OrdersToAdd)
//    {
//        //First, we're going to grab all the restaurants from the file
//        //Second, we'll deserialize as List<Restaurant>
//        //Third, we'll use List's Add method to add our new restaurant
//        //Lastly, we'll serialize that List<Restaurant> and then write it to the file

//        List<Orders> allOrders = GetAllOrders();
//        allOrders.Add(OrdersToAdd);

//        string jsonString = JsonSerializer.Serialize(allOrders);
//        File.WriteAllText(filePath2, jsonString);
//    }

//   /*  public void AddOrder(int ProductIndex, Order OrderToAdd)
//    {
//        //1. Grab all restaurants
//        //2. Find the restaurant by its index
//        //3. Append review
//        //4. Write to file

//        List<Storefront> allCustomers = GetAllStorefronts();
        

//        Storefront selectedCustomer = allCustomers[ProductIndex];
        
//        if(selectedCustomer.Orders == null)
//        {
//            selectedCustomer.Orders = new List<Order>();
//        }
//        selectedCustomer.Orders.Add(OrderToAdd);

//        string jsonString = JsonSerializer.Serialize(allCustomers);
//        File.WriteAllText(filePath1, jsonString);
//    }*/
//    public List<Inventory> GetAllInventories()
//    {
//        string jsonString = File.ReadAllText(filePath1);

//        return JsonSerializer.Deserialize<List<Inventory>>(jsonString);
//    }
//     public void AddInventory(int StorefrontIndex, Inventory InventoryToAdd)
//    {
//        //1. Grab all restaurants
//        //2. Find the restaurant by its index
//        //3. Append review
//        //4. Write to file

//        List<Storefront> allStorefronts = GetAllStorefronts();

//        Storefront selectedStorefront = allStorefronts[StorefrontIndex];
        
//        if(selectedStorefront.Inventories == null)
//        {
//            selectedStorefront.Inventories = new List<Inventory>();
//        }
//        selectedStorefront.Inventories.Add(InventoryToAdd);

//        string jsonString = JsonSerializer.Serialize(allStorefronts);
//        File.WriteAllText(filePath1, jsonString);
//    }
//    public void ChangeInventory(int InventoryIndex, int qtyToC)
//    {
//   //      StaticStorage.ChangeInventory(InventoryIndex, qtyToC);
//    }
//     public void RemoveOrder(int IdToRem){}
//     public List<LineItem> GetAllLineItems()
//    {
//        string jsonString = File.ReadAllText(filePath1);

//        return JsonSerializer.Deserialize<List<LineItem>>(jsonString);
//    }
//    public void AddLineItem(int OrderIndex, LineItem LineItemToAdd)
//    {
//        //1. Grab all restaurants
//        //2. Find the restaurant by its index
//        //3. Append review
//        //4. Write to file

//        /*      List<Orders> allOrders = GetAllOrders();

//              Orders selectedOrder = allOrders[OrderIndex];

//              if(selectedOrder.LineItems == null)
//              {
//                  selectedOrder.LineItems = new List<LineItem>();
//              }
//              selectedOrder.LineItems.Add(LineItemToAdd);

//              string jsonString = JsonSerializer.Serialize(allOrders);
//              File.WriteAllText(filePath2, jsonString);
          
//        */
//    }
//}