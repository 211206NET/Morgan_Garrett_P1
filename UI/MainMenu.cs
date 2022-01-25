using DL;

namespace UI;

public class MainMenu : IMenu
{
    private IBL _bl;

    public MainMenu(IBL bl)
    {
        _bl = bl;
    }
     public void Start()
     {
        bool exit = false;
        Console.WriteLine("Welcome to Rev(ature) up your Engines!");

        while(!exit)
        {
            Console.WriteLine("What would you like to do today?");
            Console.WriteLine("[1] Sign up to Website");
            Console.WriteLine("[2] Login to Website");
            Console.WriteLine("[x] Exit");
            string input = Console.ReadLine() ?? "";

            switch (input)
            {
                case "1":
                MenuFactory.GetMenu("signup").Start();
              
                break;
                case "2":
                MenuFactory.GetMenu("login").Start();
               
                break;
                case "x":
                exit = true;
                Console.WriteLine("Thank you for visiting Rev(ature) up your Engines!");
                break;
            }
        }
    }
}