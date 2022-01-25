using Xunit;
using Models;
using CustomExceptions;
using System.Collections.Generic;

namespace Tests;

public class ModelsTest
{
    [Fact]
    public void StoreShouldCreate()
    {
            //Arrange
            //Act
            Storefront testStorefront = new Storefront();
            //Assert
            Assert.NotNull(testStorefront);
    }
    [Fact]
    public void CustomerShouldCreate()
    {
            //Arrange
            //Act
           Customer testCustomer = new Customer();
            //Assert
            Assert.NotNull(testCustomer);
    }

[Fact]
public void CustomerShouldcreateData()
{
        Customer testCustomer = new Customer();
        string name = "Test Name";
        string username = "Test Username";
        string password = "Test Password";

        //Act
        testCustomer.Name = name;
        testCustomer.Username = username;
        testCustomer.Password = password;

        //Assert
        Assert.Equal(name, testCustomer.Name);
        Assert.Equal(username, testCustomer.Username);
        Assert.Equal(password, testCustomer.Password);
}
[Fact]
public void OrderShouldcreateData()
{
        Storefront testCustomer = new Storefront();
        string location = "Test Location";
        string city = "Test City";
        string state = "Test State";

        //Act 
        testCustomer.Location = location;
        testCustomer.City = city;
        testCustomer.State = state;
 
        //Assert    
        Assert.Equal(location, testCustomer.Location );
        Assert.Equal(city, testCustomer.City);
        Assert.Equal(state,testCustomer.State );
}
//[Theory]
//[InlineData("#$%grgfhd@")]
//[InlineData("     ")]
//[InlineData(null)]
//[InlineData("")]
//public void CustomerShouldnotcreatedata(string input)
//{
//        Customer testCustomer = new Customer();

//        Assert.Throws<InputInvalidException>(() => testCustomer.Name = input);

//}

[Fact]
    public void CustomerShouldHaveCustomToStringMethod()
    {
        //Arrange: the restaurant with its properties, and the expected ToString output
        Customer testCustomer = new Customer{
            Name = "Test Name",
            Username = "Test Username",
            Password = "Test Password"
        };
        string expectedOutput = "Name: Test Name \nUsername: Test Username \nPassword: Test Password";

        //Act: call ToString Method
        //Assert: the output of ToString Method is equal to the expected output
        Assert.Equal(expectedOutput, testCustomer.ToString());
    }

    [Fact]
    public void StorefrontReviewsShouldBeAbleToBeSet()
    {
        //Arrange: my test restaurant, and my list of reviews
        Storefront testStorefront = new Storefront();
        List<Inventory> testInventories = new List<Inventory>();
        int testInventCount = 0;
        
        //Act: setting my reviews list to the restaurant
        testStorefront.Inventories = testInventories;

        //Assert: that my Reviews property of the test restaurant is not null and has the the number of items that i expect it to contain
        Assert.NotNull(testStorefront.Inventories);
        Assert.Equal(testInventCount, testStorefront.Inventories.Count);
    }
}