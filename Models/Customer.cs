using CustomExceptions;
using System.Text.RegularExpressions;
using System.Data;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Models;
public class Customer
{
    public Customer()
    {
//       this.Orders = new List<Order>();
      
    }
  /*  public Customer(string name)
    {
        this.Orders = new List<Order>();
        this.Name = name;
    }*/
     public Customer(DataRow row)
    {
        this.Id = (int) row["Id"];
        this.Name = row["Name"].ToString() ?? "";
        this.Username = row["Username"].ToString() ?? "";
        this.Password = row["Password"].ToString() ?? "";

    }
    public int Id{ get; set;}
    [Required]
    [RegularExpression("^[a-zA-Z0-9 !?']+$", ErrorMessage = "Restaurant name can only have alphanumeric characters, white space, !, ?, and '.")]
    public string Name{ get; set;}
    //private string _name;
    //public string Name { get => _name;
    //    set
    //    {
    //        Regex pattern = new Regex("^[a-zA-Z0-9 !?']+$");
    //        if(string.IsNullOrWhiteSpace(value))
    //        {
    //            //we're checking whether this string is null or whitespace
    //            throw new InputInvalidException("Name can't be empty");
    //        }
    //        //even if the string is not null or white space,
    //        //we can still check for the name's validity by using RegEx (Regular Expression)
    //        //Regular Expression is a way to pattern match a string for a certain condition
    //        //it has a confusing syntax, so I recommend looking up language specific RegEx reference page to build one
    //        else if(!pattern.IsMatch(value))
    //        {
    //            throw new InputInvalidException("Customer name can only have alphanumeric characters, white space, !, ?, and '.");
    //        }
    //        else
    //        {
    //            this._name = value;
    //        }
    //    }  }
    public string Username { get; set; }
    public string Password { get; set; }
    public List<Orders> Order { get; set; }

    public override string ToString()
    {
        return $"Name: {this.Name} \nUsername: {this.Username} \nPassword: {this.Password}";
    }
}