using System.Linq;
using DL;

namespace UI;

public class CustomerMenu
{
    private IBL _bl;

    public CustomerMenu(IBL bl)
    {
        _bl = bl;
    }
     public void Start(int Id)
     {
        bool exit = false;
       
        Console.WriteLine("Welcome User!");

        while(!exit)
        {
            Console.WriteLine("What would you like to do today?");
            Console.WriteLine("[1] Start an Order");
            Console.WriteLine("[2] View all your Customers Orders");
            Console.WriteLine("[3] View all the Orders");
            Console.WriteLine("[4] Sort all of my Orders");
            Console.WriteLine("[x] Exit to Main Menu");
            string input = Console.ReadLine() ?? "";

            switch (input)
            {
                case "1":
                 ShoppingCart(Id);
                break;
                case "2":
                 List<Customer> allCustomers = _bl.GetAllCustomers();
                 List<Orders> allOrderrr = _bl.GetAllOrders();
                    int p = 0;
                    for(int i = 0; i < allCustomers.Count; i++)
                    {
                     //   Console.WriteLine($"[{i}]ID: {allCustomers[i].Id}\n Location: {allCustomers[i].Location} \nCity: {allCustomers[i].City} \nState: {allStorefronttt[i].State}");                     
                            if(allCustomers[i].Id == Id)
                            {
                            p = i;
                            }
                    }
                    {
                        Console.WriteLine("Here are all the Customers Orders!");
                        foreach(Orders Custo in allCustomers[p].Order)
                        {
                            Console.WriteLine($"ID: {Custo.ID} \nStoreID: {Custo.StoreId} \nName: {Custo.Name} \nCustomerId: {Custo.CustomerId} \nDate: {Custo.OrderDate} \nTotal: {Custo.Totalprice}");                        
                        }
                    }
                
                break;
                case "3":
                    List<Orders> allOrder = _bl.GetAllOrders();

       //             Console.WriteLine(allOrder.Count()); 
                    
                    if(allOrder.Count == 0)
                    {
                        Console.WriteLine("No Stores have been found :/");
                    }
                    else
                    {
                        
                        Console.WriteLine("Here are all your Stores!");
                        foreach(Orders ordo in allOrder)
                        {
                           
                            Console.WriteLine($"ID: {ordo.ID} \nStoreID: {ordo.StoreId} \nName: {ordo.Name} \nCustomerId: {ordo.CustomerId} \nDate: {ordo.OrderDate} \nTotal: {ordo.Totalprice}");
                            
                        }
                        
                    }
                break;
                case "4":
                Sort(Id);
                break;
                case "x":
                exit = true;
                
                break;
            }
        }
     }
     public void ShoppingCart(int Id)
     {
          List<Storefront> allStorefrontt = _bl.GetAllStorefronts();
                  List<Orders> allOrders = _bl.GetAllOrders();
                decimal totalfa  = 0;
                int cid = Id;
                bool leave = false;
                bool Editted = false;
                List<Orders> CurrentOrder = new List<Orders>();
        while(!leave)
        {
             Console.WriteLine("Welcome to the Shopping Cart!");
            Console.WriteLine("[1] Add another Order");
            Console.WriteLine("[2] Edit the Order");
            Console.WriteLine("[3] Delete an Order");
            Console.WriteLine("[x] Exit and checkout");
            string input = Console.ReadLine() ?? "";

            switch (input)
            {
                case "1":

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

                     int finalq = totquan - quantityy;
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
                    
                   /*  Console.WriteLine("Do you want to keep shopping? yes/no");
                     string answer = Console.ReadLine() ?? "";
                   
                      if(answer == "yes")
                      {
                      }
                      else if(answer == "no")
                      {
              
                        leave = true;                        
                      }
                      else
                      {}*/
                          //   Product newProd = new Product(pid, pname, pprice, pdes); 
                   //  LineItem newLineItem = new LineItem( oid, pid, quantityy);
                      LineItem newLineItem = new LineItem
                      {
                      };
                    // _bl.AddLineItem(oid, newLineItem);
                        break;
                 case "2":
 
                         Console.WriteLine("Pick what Order you want to edit");
                         int j = 0;
                         foreach(Orders Custo in CurrentOrder)
                        {
                            Console.WriteLine($"[{j}]\t ID: {Custo.ID} \nStoreID: {Custo.StoreId} \nName: {Custo.Name} \nCustomerId: {Custo.CustomerId} \nDate: {Custo.OrderDate} \nTotal: {Custo.Totalprice}");                        
                         j++;
                        }
                        int picky = Int32.Parse(Console.ReadLine() ?? "");
                    break;
                case "3":
                        Console.WriteLine("Pick what Order you want to Delete");
                         int z = 0;

                        foreach(Orders Custo in CurrentOrder)
                        {
                            Console.WriteLine($"[{z}]\t ID: {Custo.ID} \nStoreID: {Custo.StoreId} \nName: {Custo.Name} \nCustomerId: {Custo.CustomerId} \nDate: {Custo.OrderDate} \nTotal: {Custo.Totalprice}");                        
                         z++;
                        }
                        int deleto = Int32.Parse(Console.ReadLine() ?? "");
                        int deleteid = CurrentOrder[deleto].ID;
                        _bl.RemoveOrder(deleteid);
                        totalfa = totalfa - CurrentOrder[deleto].Totalprice;
                        CurrentOrder.RemoveAt(deleto);
                        CurrentOrder.TrimExcess();
                break;
                case "x":
                  foreach(Orders Custo in CurrentOrder)
                        {
                            Console.WriteLine($"ID: {Custo.ID} \nStoreID: {Custo.StoreId} \nName: {Custo.Name} \nCustomerId: {Custo.CustomerId} \nDate: {Custo.OrderDate} \nTotal: {Custo.Totalprice}");                        
                        }
                        Console.WriteLine($"Your Final Total after everything you bought this time is {totalfa}");
                                      
                        CurrentOrder.Clear();
                                
                leave = true;
                break;                   
            }
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
    public void Sort(int Id) 
    {
        //internal Customer CurrentCustomer { get; set; }
         //Customer currStore = _bl.GetCustomerByID(storeID!);
        //List<Customer> allOrders = CurrentCustomer.Orders!;
        //use for sorting. also maybe look into putting this in shopping cart menu
   
    }
}