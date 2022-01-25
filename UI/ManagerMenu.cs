using DL;

namespace UI;

public class ManagerMenu
{
    private IBL _bl;

    public ManagerMenu(IBL bl)
    {
        _bl = bl;
    }
     public void Start()
     {
        bool exit = false;
        Console.WriteLine("Welcome Manager!");

        while(!exit)
        {
            Console.WriteLine("What would you like to do today?");
            Console.WriteLine("[1] Add a Store");
            Console.WriteLine("[2] Add Product"); //this is actually gonna be my order function
            Console.WriteLine("[3] View all the Stores");
            Console.WriteLine("[4] View all the Products of a Store");
            Console.WriteLine("[5] View all the Stores and Products");
            Console.WriteLine("[6] Start an Order for a Store");
            Console.WriteLine("[7] View all the Orders of a Store");
            Console.WriteLine("[x] Exit to Main Menu");
            string input = Console.ReadLine() ?? "";

            switch (input)
            {
                case "1":
                    List<Storefront> allStoreffront = _bl.GetAllStorefronts();
                    Console.WriteLine("Add a new Store Location:");
                 //   Console.WriteLine("StoreId: ");
                 //   int id = Int32.Parse(Console.ReadLine() ?? "");
                    Console.WriteLine("Location: ");
                    string location = Console.ReadLine() ?? "";
                    Console.WriteLine("State: ");
                    string state = Console.ReadLine() ?? "";
                    Console.WriteLine("City: ");
                    string city = Console.ReadLine() ?? "";
                
                    Storefront newStorefront = new Storefront
                    {
                        ID = allStoreffront.Count(),
                        Location = location,
                        State = state,
                        City = city
                    };

                    _bl.AddStorefront(newStorefront);
                break;
                case "2":
                // find a storefront then add product
                    Console.WriteLine("Add a new Product:");
                    List<Storefront> allStorefront = _bl.GetAllStorefronts();
                    List<Product> allProduct = _bl.GetAllProducts();
                    List<Inventory> allInventory = _bl.GetAllInventories();
                    Console.WriteLine("Select a Store to add new Products");
                    for(int i = 0; i < allStorefront.Count; i++)
                    {
                        Console.WriteLine($"[{i}]ID: {allStorefront[i].ID} \n Location: {allStorefront[i].Location} \nCity: {allStorefront[i].City} \nState: {allStorefront[i].State}");
                    }
                    int selection = Int32.Parse(Console.ReadLine() ?? "");
                   
                    //Console.WriteLine("Add Product ID: ");
                    int iid = allInventory.Count();
                   // int iid = Int32.Parse(Console.ReadLine() ?? "");
                    Console.WriteLine("Give the Product Name: ");
                    string name = Console.ReadLine() ?? "";
                    Console.WriteLine("Price of the product: ");
                    decimal price = Decimal.Parse(Console.ReadLine() ?? "");
                    Console.WriteLine("Give the Product Description: ");
                    string des = Console.ReadLine() ?? "";
                   // Console.WriteLine("Add Inventory ID: ");
                   // int iidd = Int32.Parse(Console.ReadLine()?? "");
                    Console.WriteLine("Quantity of the product: ");
                    int quantity = Int32.Parse(Console.ReadLine() ?? "");
                    //Console.WriteLine("StoreId: ");
                    int storeid = allStorefront[selection].ID;
                   // int storeid = Int32.Parse(Console.ReadLine() ?? "");

                    Product newProduct = new Product
                    {
                        Name = name, 
                        Price = price, 
                        Description = des
                     };
                    _bl.AddProduct(selection, newProduct);
                    Inventory newInventory = new Inventory{
                      //  ProductId = iid,
                        Quantity = quantity,
                        StoreId = storeid,
                     //   Item = newProduct,
                        Name = name, 
                        Price = price, 
                        Description = des
                        };
                   // Inventory newInventory = new Inventory(iid, iid, quantity, storeid, newProduct);

                    _bl.AddInventory(selection, newInventory);
                    Console.WriteLine("Your Product has been added to the Store!");

                    
                break;
                case "3":
                 List<Storefront> allStorefronts = _bl.GetAllStorefronts();
                    
                    if(allStorefronts.Count == 0)
                    {
                        Console.WriteLine("No Stores have been found :/");
                    }
                    else
                    {
                        Console.WriteLine("Here are all your Stores!");
                        foreach(Storefront storo in allStorefronts)
                        {
                            Console.WriteLine($"Location: {storo.Location} \nState: {storo.State} \nCity: {storo.City}");
                        }
                    }
                break;
                case "4":
                List<Storefront> allStorefronttt = _bl.GetAllStorefronts();

                    Console.WriteLine("Select a Store to Start an Order");
                    for(int i = 0; i < allStorefronttt.Count; i++)
                    {
                        Console.WriteLine($"[{i}] Location: {allStorefronttt[i].Location} \nCity: {allStorefronttt[i].City} \nState: {allStorefronttt[i].State}");                     
                    }
                    int selectionss = Int32.Parse(Console.ReadLine() ?? "");
                
                                 Console.WriteLine($"[{selectionss}] Location: {allStorefronttt[selectionss].Location} \nState: {allStorefronttt[selectionss].State} \nCity: {allStorefronttt[selectionss].City}");
                                 Console.WriteLine("======Products======");
                            
                                foreach(Inventory invent in allStorefronttt[selectionss].Inventories)
                                {

                                    Console.WriteLine($"\tName: {invent.Name}\t Quantity: {invent.Quantity} \t Storeid: {invent.StoreId}\n ProductID: {invent.ID}\tPrice: {invent.Price}\tDescription: {invent.Description}");
                                    
                                }
                break;
                case "5":
                  List<Storefront> allStorefrontss = _bl.GetAllStorefronts();
                    
                    if(allStorefrontss.Count == 0)
                    {
                        Console.WriteLine("No Stores have been found :/");
                    }
                    else
                    {
                        Console.WriteLine("Here are all your Stores!");
                        foreach(Storefront storo in allStorefrontss)
                        {
                            Console.WriteLine($"Location: {storo.Location} \nState: {storo.State} \nCity: {storo.City}");
                       //     Console.WriteLine(storo.Inventories.Count());
                            if(storo.Inventories != null && storo.Inventories.Count > 0)
                            {
                                 Console.WriteLine("======Products======");
                                foreach(Inventory invent in storo.Inventories)
                                {
                                    Console.WriteLine($"\tName: {invent.Name}\t Quantity: {invent.Quantity} \t Storeid: {invent.StoreId}\n ProductID: {invent.ID}\tPrice: {invent.Price}\tDescription: {invent.Description}");
                                }
                            }   
                            else
                            {
                                Console.WriteLine("No Products ");
                            }
                        }
                    }
                break;
                case "6":
                          ShoppingCart();

                break;
                case "7":
                 List<Storefront> allStorefronto = _bl.GetAllStorefronts();
                 List<Orders> allOrderrr = _bl.GetAllOrders();
           
                     for(int i = 0; i < allStorefronto.Count; i++)
                    {
                        Console.WriteLine($"[{i}] Location: {allStorefronto[i].Location} \nCity: {allStorefronto[i].City} \nState: {allStorefronto[i].State}");                     
                    }
                    int p = Int32.Parse(Console.ReadLine() ?? "");
                
                                 Console.WriteLine($"[{p}] Location: {allStorefronto[p].Location} \nState: {allStorefronto[p].State} \nCity: {allStorefronto[p].City}");
                                 Console.WriteLine("======Orders======");              
                        Console.WriteLine("Here are all the Stores Orders!");
                         
                        foreach(Orders Custo in allStorefronto[p].Order)
                        {
                           if(Custo.CustomerId == 4)
                            Console.WriteLine($"ID: {Custo.ID} \nStoreID: {Custo.StoreId} \nName: {Custo.Name} \nCustomerId: {Custo.CustomerId} \nDate: {Custo.OrderDate} \nTotal: {Custo.Totalprice}");                        
                        
                        }

                break;
                case "x":
                exit = true;     
                break;
            }
        }
     }
        public void ShoppingCart()
     {
          List<Storefront> allStorefrontt = _bl.GetAllStorefronts();
                  List<Orders> allOrders = _bl.GetAllOrders();
                decimal totalfa  = 0;
                bool leave = false;
                int cid = 100;
                bool Editted = false;
                List<Orders> CurrentOrder = new List<Orders>();
        while(!leave)
        {

                    Console.WriteLine("Select a Store for your Order");
                    for(int i = 0; i < allStorefrontt.Count; i++)
                    {
                        Console.WriteLine($"[{i}] Location: {allStorefrontt[i].Location} \nCity: {allStorefrontt[i].City} \nState: {allStorefrontt[i].State}");                     
                    }
                    int selections = Int32.Parse(Console.ReadLine() ?? "");
                   
                    Inventor(selections);                   
                      
                    Console.WriteLine("Pick a Product ");
                    int pick = Int32.Parse(Console.ReadLine() ?? "");
                    Random r = new Random();
                    int Rando = r.Next(0,100);
              //      Console.WriteLine(Rando); 
                    int oid = Rando;
                    cid = 4;
                 
                    Console.WriteLine("Get the Quantity of Product you want to buy");
                    int quantityy = Int32.Parse(Console.ReadLine() ?? "");
                    int sidd = allStorefrontt[selections].Inventories[pick].StoreId;
              //      Console.WriteLine(sidd); 
                    DateTime date1 = DateTime.Now;
                    string date2 = date1.ToString();
            //        Console.WriteLine(date1.ToString("F"));
                    int pid = allStorefrontt[selections].Inventories[pick].ID;
                    int totquan = allStorefrontt[selections].Inventories[pick].Quantity;
            //        Console.WriteLine(pid); 
                    string? pname = allStorefrontt[selections].Inventories[pick].Name;
                    decimal pprice = allStorefrontt[selections].Inventories[pick].Price;
                    string? pdes = allStorefrontt[selections].Inventories[pick].Description;

                     int finalq = totquan + quantityy;
                     decimal totalll = quantityy * pprice;
                     totalfa = totalfa + totalll;
                     Orders newOrder = new Orders
                     { 
                      ID = oid,
                      StoreId = sidd, 
                      Name = pname,
                    CustomerId = cid,
                      OrderDate = date2,
                      Quantity = quantityy,
                      Totalprice = totalll
                     };
   
                     CurrentOrder.Add(newOrder);
                     _bl.AddOrders(newOrder);
                     _bl.ChangeInventory(pid,finalq);
                    
                      LineItem newLineItem = new LineItem
                      {
                      };
                      Console.WriteLine("Do you want to keep shopping? yes/no");
                     string answer = Console.ReadLine() ?? "";
                   
                      if(answer == "yes")
                      {
                      }
                      else if(answer == "no")
                      {
                        leave = true;                        
                      }
                      else
                      {}          
        }     
    }
    public void Inventor(int selections)
    {
             List<Storefront> allStorefrontt = _bl.GetAllStorefronts();
                   Console.WriteLine($"[{selections}] Location: {allStorefrontt[selections].Location} \nState: {allStorefrontt[selections].State} \nCity: {allStorefrontt[selections].City}");
                                 Console.WriteLine("======Products======");
                                 int j = 0;
                                foreach(Inventory invent in allStorefrontt[selections].Inventories)
                                {

                                    Console.WriteLine($"[{j}]\tName: {invent.Name} \t Quantity: {invent.Quantity} \t Storeid: {invent.StoreId}\n\tPrice: {invent.Price}\tDescription: {invent.Description}");
                                    j++;
                                }
                    
    }

}