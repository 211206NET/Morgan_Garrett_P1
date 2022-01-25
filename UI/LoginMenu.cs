namespace UI;

public class LoginMenu : IMenu
{
    private IBL _bl;

    public LoginMenu(IBL bl)
    {
        _bl = bl;
    }
     public void Start()
     {
                    List<Customer> allCustomers = _bl.GetAllCustomers();
                    ManagerMenu managerMenu = new ManagerMenu(_bl); 
                    CustomerMenu customerMenu = new CustomerMenu(_bl);
                    Console.WriteLine("Login to your Account:");
                    Console.WriteLine("Username: ");
                    string username1 = Console.ReadLine() ?? "";
                    Console.WriteLine("Password: ");
                    string password1 = Console.ReadLine() ?? "";
                   
                    if(username1 == "admin" && password1 == "admin")
                    {
                        managerMenu.Start();
                    }
                    else if(allCustomers.Exists(x => x.Username == username1) && allCustomers.Exists(x => x.Password == password1) )
                    {
                        int Id = 0;
                        for(int i = 0; i < allCustomers.Count; i++)
                        {
                         
                            if(allCustomers[i].Username == username1)
                            {
                             //   Console.WriteLine(allCustomers[i].Id); //debug line
                                Id = allCustomers[i].Id;
                            }
                        }
                       customerMenu.Start(Id);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Username or Password\nPlease retype ");
                    }              
     }
}