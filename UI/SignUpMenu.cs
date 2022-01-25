namespace UI;

public class SignUpMenu : IMenu
{
    private IBL _bl;

    public SignUpMenu(IBL bl)
    {
        _bl = bl;
    }
     public void Start()
     {
         List<Customer> allCustomerss = _bl.GetAllCustomers();
                    Console.WriteLine("Create a new Account:");
                    Console.WriteLine("Name: ");
                    string name = Console.ReadLine() ?? "";
                    Console.WriteLine("Username: ");
                    string username = Console.ReadLine() ?? "";
                    Console.WriteLine("Password: ");
                    string password = Console.ReadLine() ?? "";
                Customer newCustomer = new Customer
                    {
                    //    Id = allCustomerss.Count(),
                        Name = name,
                        Username = username,
                        Password = password
                    };

                    _bl.AddCustomer(newCustomer);
     }
}