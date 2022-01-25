using Microsoft.Data.SqlClient;
using System.Data;
namespace DL;

public class DBRepo : IRepo
{
    //    Log.Logger = new LoggerConfiguration().WriteTo.File("logger.txt").CreateLogger(); add later
    private string _connectionString;
    public DBRepo(string connectionString)
    {
        _connectionString = connectionString;
    }
    /// <summary>
    /// Used to get all customers
    /// </summary>
    /// <returns> Returns All Customers in the Customer List</returns>
    public List<Customer> GetAllCustomers()
    {
        List<Customer> allCustomers = new List<Customer>();
        using SqlConnection connection = new SqlConnection(_connectionString);
        string custoSelect = "Select * From Customer";
        string inventSelect = "Select * From Orders";

        DataSet RRSet = new DataSet();

        //Two different adapters for different tables
        using SqlDataAdapter custoAdapter = new SqlDataAdapter(custoSelect, connection);
        using SqlDataAdapter ordoAdapter = new SqlDataAdapter(inventSelect, connection);

        custoAdapter.Fill(RRSet, "Customer");
        ordoAdapter.Fill(RRSet, "Orders");

        DataTable? CustomerTable = RRSet.Tables["Customer"];
        DataTable? OrderTable = RRSet.Tables["Orders"];

        if (CustomerTable != null) // && OrderTable != null)
        {
            foreach (DataRow row in CustomerTable.Rows)
            {
                Customer custo = new Customer(row);
                if (OrderTable != null)
                {
                    custo.Order = OrderTable.AsEnumerable().Where(r => (int)r["CustomerId"] == custo.Id).Select(
                        r =>
                            new Orders {
                                ID = (int)r["ID"],
                                StoreId = (int)r["StoreId"],
                                Name = r["Name"].ToString() ?? "",
                                CustomerId = (int)r["CustomerId"],
                                OrderDate = r["OrderDate"].ToString() ?? "",
                                Quantity = (int)r["Quantity"],
                                Totalprice = (decimal)r["Totalprice"]

                            }
                    ).ToList();
                }
                allCustomers.Add(custo);
            }
        }
        return allCustomers;
    }
    /// <summary>
    /// Gets all of the Stores
    /// </summary>
    /// <returns>Returns all of the stores in the list</returns>
    public List<Storefront> GetAllStorefronts()
    {
        List<Storefront> allCustomers = new List<Storefront>();
        using SqlConnection connection = new SqlConnection(_connectionString);
        string custoSelect = "Select * From Storefront";
        string ordoSelect = "Select * From Inventory";
        string inventSelect = "Select * From Orders";

        DataSet RRSet = new DataSet();

        //Two different adapters for different tables
        using SqlDataAdapter custoAdapter = new SqlDataAdapter(custoSelect, connection);
        using SqlDataAdapter ordoAdapter = new SqlDataAdapter(ordoSelect, connection);
        using SqlDataAdapter inventAdapter = new SqlDataAdapter(inventSelect, connection);

        custoAdapter.Fill(RRSet, "Storefront");
        ordoAdapter.Fill(RRSet, "Inventory");
        inventAdapter.Fill(RRSet, "Orders");

        DataTable? CustomerTable = RRSet.Tables["Storefront"];
        DataTable? OrderTable = RRSet.Tables["Inventory"];
        DataTable? InventTable = RRSet.Tables["Orders"];

        if (CustomerTable != null) // && OrderTable != null)
        {
            foreach (DataRow row in CustomerTable.Rows)
            {
                Storefront custo = new Storefront(row);
                if (OrderTable != null)
                {
                    custo.Inventories = OrderTable.AsEnumerable().Where(r => (int)r["StoreId"] == custo.ID).Select(
                        r =>
                            new Inventory {
                                ID = (int)r["ID"],
                                Quantity = (int)r["Quantity"],
                                StoreId = (int)r["StoreId"],
                                Name = r["Name"].ToString() ?? "",
                                Price = (decimal)r["Price"],
                                Description = r["Description"].ToString() ?? ""
                            }
                    ).ToList();
                }
                if (InventTable != null)
                {
                    custo.Order = InventTable.AsEnumerable().Where(r => (int)r["StoreId"] == custo.ID).Select(
                        r =>
                            new Orders {
                                ID = (int)r["ID"],
                                StoreId = (int)r["StoreId"],
                                Name = r["Name"].ToString() ?? "",
                                CustomerId = (int)r["CustomerId"],
                                OrderDate = r["OrderDate"].ToString() ?? "",
                                Quantity = (int)r["Quantity"],
                                Totalprice = (decimal)r["Totalprice"]

                            }
                    ).ToList();
                }
                allCustomers.Add(custo);
            }
        }
        return allCustomers;
    }
    /// <summary>
    /// Gets all of the products
    /// </summary>
    /// <returns>returns all of the products in the list</returns>
    public List<Product> GetAllProducts()
    {
        List<Product> allProducts = new List<Product>();
        using SqlConnection connection = new SqlConnection(_connectionString);
        string ProdoSelect = "Select * From Product";
        //       string inventSelect = "Select * From Orders";

        DataSet RRSet = new DataSet();

        //Two different adapters for different tables
        using SqlDataAdapter ProdoAdapter = new SqlDataAdapter(ProdoSelect, connection);
        //        using SqlDataAdapter ordoAdapter = new SqlDataAdapter(inventSelect, connection);

        ProdoAdapter.Fill(RRSet, "Product");
        //        ordoAdapter.Fill(RRSet, "Orders");

        DataTable? CustomerTable = RRSet.Tables["Product"];
        //        DataTable? OrderTable = RRSet.Tables["Orders"];

        if (CustomerTable != null) // && OrderTable != null)
        {
            foreach (DataRow row in CustomerTable.Rows)
            {
                Product custo = new Product(row);
            }
        }
        return allProducts;

    }
    /// <summary>
    /// Gets all of the orders
    /// </summary>
    /// <returns>Returns all of the orders</returns>
    public List<Orders> GetAllOrders()
    {
        List<Orders> allOrders = new List<Orders>();
        using SqlConnection connection = new SqlConnection(_connectionString);

        string ordoSelect = "Select * From Orders";
        //  string custoSelect = "Select * From LineItem";

        DataSet RRSet = new DataSet();

        //Two different adapters for different tables
        using SqlDataAdapter ordoAdapter = new SqlDataAdapter(ordoSelect, connection);
        //       using SqlDataAdapter custoAdapter = new SqlDataAdapter(custoSelect, connection);

        ordoAdapter.Fill(RRSet, "Orders");
        //   custoAdapter.Fill(RRSet, "LineItem");

        DataTable? OrderTable = RRSet.Tables["Orders"];
        //    DataTable? CustomerTable = RRSet.Tables["LineItem"];


        if (OrderTable != null) // && OrderTable != null)
        {
            foreach (DataRow row in OrderTable.Rows)
            {
                Orders custo = new Orders(row);
                /*  if (CustomerTable != null)
                  {
                   custo.LineItems = CustomerTable.AsEnumerable().Where(r => (int) r["OrderId"] == custo.ID).Select(
                       r =>
                           new LineItem {
                               ID = (int) r["ID"],   
                               OrderId = (int) r["OrderId"],
                               ProductId = (int) r["ProductId"],            
                               Quantity = (int) r["Quantity"]
                           }
                   ).ToList();
                   }*/

                allOrders.Add(custo);
            }
        }
        return allOrders;
    }
    /// <summary>
    /// returns all the inventories
    /// </summary>
    /// <returns></returns>
    public List<Inventory> GetAllInventories()
    {
        List<Inventory> allInventories = new List<Inventory>();
        using SqlConnection connection = new SqlConnection(_connectionString);

        string ordoSelect = "Select * From Inventory";
        string custoSelect = "Select * From LineItem";

        DataSet RRSet = new DataSet();

        //Two different adapters for different tables
        using SqlDataAdapter ordoAdapter = new SqlDataAdapter(ordoSelect, connection);
        using SqlDataAdapter custoAdapter = new SqlDataAdapter(custoSelect, connection);

        ordoAdapter.Fill(RRSet, "Inventory");
        custoAdapter.Fill(RRSet, "LineItem");

        DataTable? OrderTable = RRSet.Tables["Inventory"];
        DataTable? CustomerTable = RRSet.Tables["LineItem"];


        if (OrderTable != null) // && OrderTable != null)
        {
            foreach (DataRow row in OrderTable.Rows)
            {
                Inventory custo = new Inventory(row);
                /*   if (CustomerTable != null)
                   {
                    custo.LineItems = CustomerTable.AsEnumerable().Where(r => (int) r["ProductId"] == custo.ID).Select(
                        r =>
                            new LineItem {
                                ID = (int) r["ID"],   
                                OrderId = (int) r["OrderId"],
                                ProductId = (int) r["ProductId"],            
                                Quantity = (int) r["Quantity"]
                            }
                    ).ToList();
                    }*/

                allInventories.Add(custo);
            }
        }
        return allInventories;
    }
    /// <summary>
    /// gets all of the LineItems
    /// </summary>
    /// <returns>Returns the lineItem</returns>
    public List<LineItem> GetAllLineItems()
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// Adds a customers to the customer list
    /// </summary>
    /// <param name="CustomerToAdd"></param>
    public void AddCustomer(Customer CustomerToAdd)
    {
        DataSet restoSet = new DataSet();

        string selectCmd = "SELECT * FROM Customer Where Id = -1";
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd, connection))
            {

                dataAdapter.Fill(restoSet, "Customer");

                DataTable restoTable = restoSet.Tables["Customer"];

                DataRow newRow = restoTable.NewRow();

                newRow["Name"] = CustomerToAdd.Name;
                newRow["Username"] = CustomerToAdd.Username ?? "";
                newRow["Password"] = CustomerToAdd.Password ?? "";

                restoTable.Rows.Add(newRow);

                string insertCmd = $"INSERT INTO Customer (Name, Username, Password) VALUES (@Name, @Username, @Password)";
                //      string insertCmd = $"INSERT INTO Customer (Name, Username, Password) VALUES ('{CustomerToAdd.Name}', '{CustomerToAdd.Username}', '{CustomerToAdd.Password}')";

                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(dataAdapter);

                dataAdapter.InsertCommand = cmdBuilder.GetInsertCommand();

                dataAdapter.Update(restoTable);
                Log.Information("A new Customer has been added with Name: {Name}, Username: {Username}, Password: {Password}", CustomerToAdd.Name, CustomerToAdd.Username, CustomerToAdd.Password);
            }
        }
    }
    /// <summary>
    /// Adds a storefront to the store list
    /// </summary>
    /// <param name="StorefrontToAdd"></param>
    public void AddStorefront(Storefront StorefrontToAdd)
    {
        DataSet restoSet = new DataSet();

        string selectCmd = "SELECT * FROM Storefront Where Id = -1";
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd, connection))
            {

                dataAdapter.Fill(restoSet, "Storefront");

                DataTable restoTable = restoSet.Tables["Storefront"];

                DataRow newRow = restoTable.NewRow();


                newRow["Location"] = StorefrontToAdd.Location ?? "";
                newRow["State"] = StorefrontToAdd.State ?? "";
                newRow["City"] = StorefrontToAdd.City ?? "";

                restoTable.Rows.Add(newRow);
                string insertCmd = $"INSERT INTO Customer (Location, State, City) VALUES (@Location, @State, @City)";
                //string insertCmd = $"INSERT INTO Customer (Location, State, City) VALUES ('{StorefrontToAdd.Location}', '{StorefrontToAdd.State}', '{StorefrontToAdd.City}')";

                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(dataAdapter);

                dataAdapter.InsertCommand = cmdBuilder.GetInsertCommand();

                dataAdapter.Update(restoTable);
                Log.Information("A new Storefront has been added with Location: {Location}, State: {State}, City: {City}", StorefrontToAdd.Location, StorefrontToAdd.State, StorefrontToAdd.City);
            }
        }
    }
    /// <summary>
    /// Adds an order to the Order list
    /// </summary>
    /// <param name="OrdersToAdd"></param>
    public void AddOrders(Orders OrdersToAdd)
    {
        DataSet restoSet = new DataSet();

        string selectCmd = "SELECT * FROM Orders Where Id = -1";
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd, connection))
            {

                dataAdapter.Fill(restoSet, "Orders");

                DataTable restoTable = restoSet.Tables["Orders"];

                DataRow newRow = restoTable.NewRow();


                newRow["StoreId"] = OrdersToAdd.StoreId;
                newRow["Name"] = OrdersToAdd.Name;
                newRow["CustomerId"] = OrdersToAdd.CustomerId;
                newRow["OrderDate"] = OrdersToAdd.OrderDate;
                newRow["Quantity"] = OrdersToAdd.Quantity;
                newRow["Totalprice"] = OrdersToAdd.Totalprice;


                restoTable.Rows.Add(newRow);
                string insertCmd = $"INSERT INTO Orders (StoreId, Name, CustomerId, OrderDate, Quantity, Totalprice) VALUES (@StoreId, @Name, @CustomerId, @OrderDate, @Quantity, @Totalprice)";
                //string insertCmd = $"INSERT INTO Customer (Location, State, City) VALUES ('{StorefrontToAdd.Location}', '{StorefrontToAdd.State}', '{StorefrontToAdd.City}')";

                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(dataAdapter);

                dataAdapter.InsertCommand = cmdBuilder.GetInsertCommand();

                dataAdapter.Update(restoTable);
                Log.Information("A new Order has been added with StoreId: {StoreId},Name: {Name},CustomerId {CustomerId}, OrderDate: {OrderDate},Quantity {Quantity},Price: {Totalprice}", OrdersToAdd.StoreId, OrdersToAdd.Name, OrdersToAdd.CustomerId, OrdersToAdd.OrderDate, OrdersToAdd.Quantity, OrdersToAdd.Totalprice);
            }
        }
        //  throw new NotImplementedException();
    }
    public void AddOrders(string Date, Orders OrdersToAdd)
    {
        DataSet restoSet = new DataSet();

        string selectCmd = "SELECT * FROM Orders Where Id = -1";
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd, connection))
            {

                dataAdapter.Fill(restoSet, "Orders");

                DataTable restoTable = restoSet.Tables["Orders"];

                DataRow newRow = restoTable.NewRow();


                newRow["StoreId"] = OrdersToAdd.StoreId;
                newRow["Name"] = OrdersToAdd.Name;
                newRow["CustomerId"] = OrdersToAdd.CustomerId;
                newRow["OrderDate"] = Date; // OrdersToAdd.OrderDate;
                newRow["Quantity"] = OrdersToAdd.Quantity;
                newRow["Totalprice"] = OrdersToAdd.Totalprice;


                restoTable.Rows.Add(newRow);
                string insertCmd = $"INSERT INTO Orders (StoreId, Name, CustomerId, OrderDate, Quantity, Totalprice) VALUES (@StoreId, @Name, @CustomerId, @OrderDate, @Quantity, @Totalprice)";
                //string insertCmd = $"INSERT INTO Customer (Location, State, City) VALUES ('{StorefrontToAdd.Location}', '{StorefrontToAdd.State}', '{StorefrontToAdd.City}')";

                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(dataAdapter);

                dataAdapter.InsertCommand = cmdBuilder.GetInsertCommand();

                dataAdapter.Update(restoTable);
                Log.Information("A new Order has been added with StoreId: {StoreId},Name: {Name},CustomerId {CustomerId}, OrderDate: {OrderDate},Quantity {Quantity},Price: {Totalprice}", OrdersToAdd.StoreId, OrdersToAdd.Name, OrdersToAdd.CustomerId, OrdersToAdd.OrderDate, OrdersToAdd.Quantity, OrdersToAdd.Totalprice);
            }
        }
        //  throw new NotImplementedException();
    }
    /// <summary>
    /// Adds a product to the the store list
    /// </summary>
    /// <param name="StoreIndex"></param>
    /// <param name="ProducttoAdd"></param>
    public void AddProduct(int StoreIndex, Product ProducttoAdd)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string sqlCmd = "INSERT INTO Product (Name, Price, Description) VALUES (@Name, @Price, @Description)";

            using (SqlCommand cmd = new SqlCommand(sqlCmd, connection))
            {
                SqlParameter param = new SqlParameter("@Name", ProducttoAdd.Name);
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Price", ProducttoAdd.Price);
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Description", ProducttoAdd.Description);
                cmd.Parameters.Add(param);


                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }

        //  throw new NotImplementedException();
    }
    /// <summary>
    /// Adds an inventory to the store list
    /// </summary>
    /// <param name="StorefrontIndex"></param>
    /// <param name="InventoryToAdd"></param>
    public void AddInventory(int StorefrontIndex, Inventory InventoryToAdd)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            //string sqlCmd = "INSERT INTO Inventory (ProductId, Quantity, StoreId) VALUES (@ProductId, @Quantity, @StoreId)";
            string sqlCmd = "INSERT INTO Inventory ( Quantity, StoreId, Name, Price, Description) VALUES ( @Quantity, @StoreId, @Name, @Price, @Description)";
            using (SqlCommand cmd = new SqlCommand(sqlCmd, connection))
            {
                //   SqlParameter param = new SqlParameter("@ProductId", StorefrontIndex);
                //cmd.Parameters.Add(param);

                SqlParameter param = new SqlParameter("@Quantity", InventoryToAdd.Quantity);
                cmd.Parameters.Add(param);

                param = new SqlParameter("@StoreId", InventoryToAdd.StoreId);
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Name", InventoryToAdd.Name);
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Price", InventoryToAdd.Price);
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Description", InventoryToAdd.Description);
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
            }
            connection.Close();
            Log.Information("A new Inventory has been added with Quantity {Quantity}, StoreId: {StoreId},Name: {Name},Price: {Price},Description: {Description}", InventoryToAdd.Quantity, InventoryToAdd.StoreId, InventoryToAdd.Name, InventoryToAdd.Price, InventoryToAdd.Description);
        }

        //throw new NotImplementedException();
    }
    public List<Orders> GetAllOrdersforCustomers(int Cid, int Sid)
    {
        List<Orders> CustOrders = new List<Orders>();
        string selectProdCmd = "SELECT * FROM Orders WHERE CustomerId = @CID AND StoreId = @SID";
        SqlConnection connection = new SqlConnection(_connectionString);
        SqlCommand cmd = new SqlCommand(selectProdCmd, connection);
        //Gets the current user's id from the username
        //  SqlParameter param = new SqlParameter("@CID", CiD);
        //cmd.Parameters.Add(param)

        cmd.Parameters.AddWithValue("@CID", Cid);
        cmd.Parameters.AddWithValue("@SID", Sid);

        DataSet productOrderSet = new DataSet();

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        adapter.Fill(productOrderSet, "Orders");

        DataTable productOrderTable = productOrderSet.Tables["Orders"]!;
        if (productOrderTable != null)
        {
            //Adds each of the product orders we find to the cart to return
            foreach (DataRow row in productOrderTable.Rows)
            {
                Orders pOrder = new Orders(row);
                CustOrders.Add(pOrder);
            }
        }

        return CustOrders;
    }

    public Orders GetCustomerOrders(int CustomerID)
    {
        string query = "SELECT * From Orders WHERE CustomerId = @CustomerId";
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        using SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("CustomerId", CustomerID);

        using SqlDataReader reader = cmd.ExecuteReader();
        Orders selectedProduct = new Orders();
        if (reader.Read())
        {
            selectedProduct.StoreId = reader.GetInt32(0);
            selectedProduct.Name = reader.GetString(1);
            selectedProduct.CustomerId = reader.GetInt32(2);
            selectedProduct.OrderDate = reader.GetString(3);
            selectedProduct.Quantity = reader.GetInt32(4);
            selectedProduct.Totalprice = reader.GetDecimal(5);

        }
        connection.Close();
        return selectedProduct;
    }
    /// <summary>
    /// Changes the inventory Quantity
    /// </summary>
    /// <param name="InventoryIndex"></param>
    /// <param name="qtyToC"></param>
    public void ChangeInventory(int InventoryIndex, int qtyToC)
    {

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string sqlCmd = "UPDATE Inventory SET Quantity = @p0 WHERE Id = @p1";
            using (SqlCommand cmd = new SqlCommand(sqlCmd, connection))
            {
                //SqlParameter param = (new SqlParameter("@p1", qtyToChange));
                cmd.Parameters.AddWithValue("@p0", qtyToC);
                cmd.Parameters.AddWithValue("@p1", InventoryIndex);


                int changed = cmd.ExecuteNonQuery();
                //Console.WriteLine($"changed: {changed}, invIndex: {invIndex}");
            }
            connection.Close();
        }
    }
    /// <summary>
    /// Removes an order from the order list
    /// </summary>
    /// <param name="IdToRem"></param>
    public void RemoveOrder(int IdToRem)
    {
        //throw new NotImplementedException();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string sqlCmd = "DELETE FROM Orders WHERE ID = @p0";
            using (SqlCommand cmd = new SqlCommand(sqlCmd, connection))
            {
                cmd.Parameters.AddWithValue("@p0", IdToRem);

                int changed = cmd.ExecuteNonQuery();
                Console.WriteLine($"Removed item: changed: {changed}, invIndex: {IdToRem}");
            }
            connection.Close();
        }
    }
    /// <summary>
    /// Addsa a line item to the list
    /// </summary>
    /// <param name="OrderIndex"></param>
    /// <param name="LineItemToAdd"></param>
    public void AddLineItem(int OrderIndex, LineItem LineItemToAdd)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string sqlCmd = "INSERT INTO LineItem (OrderId, ProductId, Quantity) VALUES (@OrderId, @ProductId, @Quantity)";

            using (SqlCommand cmd = new SqlCommand(sqlCmd, connection))
            {
                SqlParameter param = new SqlParameter("@OrderId", LineItemToAdd.OrderId);
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ProductId", LineItemToAdd.ProductId);
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Quantity", LineItemToAdd.Quantity);
                cmd.Parameters.Add(param);


                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }

        //throw new NotImplementedException();
    }
    public List<Inventory> GetInventoriesById(int StoreId)
    //public Inventory GetInventoriesById(int StoreId)
    {
       /* string selectcmd = "Select * From Inventory Where ID = @storoId";
        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        // using SqlCommand cmd = new SqlCommand(query, connection);
        SqlCommand cmd = new SqlCommand(selectcmd, connection);
        //  SqlParameter param = new SqlParameter("@storoId", StoreId);
        //cmd.Parameters.Add(param);
        cmd.Parameters.AddWithValue("@storoId", StoreId);

        using SqlDataReader reader = cmd.ExecuteReader();
        Inventory selectedProduct = new Inventory();
        if (reader.Read())
        {
            selectedProduct.ID = reader.GetInt32(0);
            selectedProduct.Quantity = reader.GetInt32(1);
            selectedProduct.StoreId = reader.GetInt32(2);
            selectedProduct.Name = reader.GetString(3);
            selectedProduct.Price = reader.GetDecimal(4);
            selectedProduct.Description = reader.GetString(5);


        }
        connection.Close();
        return selectedProduct;*/
         string selectcmd = "Select * From Inventory Where StoreId = @storoId";
        SqlConnection connection = new SqlConnection(_connectionString);
         SqlCommand cmd = new SqlCommand(selectcmd, connection);
          SqlParameter param = new SqlParameter("@storoId", StoreId);
        cmd.Parameters.Add(param);
      //  cmd.Parameters.AddWithValue("@storoId", StoreId);
        DataSet inventorySet = new DataSet();

          SqlDataAdapter adapter = new SqlDataAdapter(cmd);

          adapter.Fill(inventorySet, "Inventory");

          DataTable inventoryTable = inventorySet.Tables["Inventory"];

          List<Inventory> inventories = new List<Inventory>();
          foreach (DataRow dr in inventoryTable.Rows)
          {
              inventories.Add(new Inventory
              {
              ID = (int)dr["ID"],
              Quantity = (int)dr["Quantity"],
              StoreId = (int)dr["StoreId"],
              Name =(string) dr["Name"] ?? "",
              Price = (decimal)dr["Price"],
              Description =(string) dr["Description"]?? "",
              });
          }
          return inventories;
        // throw new NotImplementedException();
    }
    public Inventory GetInventoriesByStoreId(int StoreId)
    {
        string selectcmd = "Select * From Inventory Where StoreId = @storoId";
        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        // using SqlCommand cmd = new SqlCommand(query, connection);
        SqlCommand cmd = new SqlCommand(selectcmd, connection);
        //  SqlParameter param = new SqlParameter("@storoId", StoreId);
        //cmd.Parameters.Add(param);
        cmd.Parameters.AddWithValue("@storoId", StoreId);

        using SqlDataReader reader = cmd.ExecuteReader();
        Inventory selectedProduct = new Inventory();
        if (reader.Read())
        {
            selectedProduct.ID = reader.GetInt32(0);
            selectedProduct.Quantity = reader.GetInt32(1);
            selectedProduct.StoreId = reader.GetInt32(2);
            selectedProduct.Name = reader.GetString(3);
            selectedProduct.Price = reader.GetDecimal(4);
            selectedProduct.Description = reader.GetString(5);


        }
        connection.Close();
        return selectedProduct;
    }
}

