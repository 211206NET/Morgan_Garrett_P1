using Xunit;
using Models;
using Moq;
using BL;
using Models;
using DL;
using WebApi;
using WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using CustomExceptions;
using System.Collections.Generic;
using System;

namespace Tests;

public class ControllerTest
{
    [Fact]
    public void ProductControllerGetShouldGetAllProducts()
    {
        //Arrange, Act, Assert pattern
        //Arrange step, we need to set up our mocks, so when BL.GetReviewsByRestoId
        //Gets called, we instead return a stubbed data
        var mockBL = new Mock<IBL>();
        int i = 1;
        mockBL.Setup(x => x.GetAllInventories()).Returns(
                new List<Inventory>
                {
                     new Inventory
                     {
                         ID = 1,
                         Quantity = 5,
                         StoreId = 1,
                         Name = "2003 Tesla Monstr Truck",
                         Price = 3000,
                         Description = "Its an electric monster truck"
                     },
                     new Inventory
                     {
                         ID = 2,
                         Quantity = 10,
                         StoreId = 1,
                         Name = "3010 Ford Boat car",
                         Price = 4000,
                         Description = "Its a boat Car"
                     },
                 }
             );

        var reviewCtrllr = new ProductController(mockBL.Object);

        //Act
        var result = reviewCtrllr.Get();

        //Assert
        Assert.NotNull(result);
        Assert.IsType<List<Inventory>>(result);
        //Assert.Equal(2, result.Count);
    }
    [Fact]
    public void ProductControllersGetShouldGetAllProducts()
    {
        //Arrange, Act, Assert pattern
        //Arrange step, we need to set up our mocks, so when BL.GetReviewsByRestoId
        //Gets called, we instead return a stubbed data
        var mockBL = new Mock<IBL>();
        int i = 1;
        mockBL.Setup(x => x.GetAllInventories()).Returns(
                new List<Inventory>
                {
                     new Inventory
                     {
                         ID = 1,
                         Quantity = 5,
                         StoreId = 1,
                         Name = "2003 % Monstr Truck",
                         Price = 3000,
                         Description = "Its an elect^ric monster truck"
                     },
                     new Inventory
                     {
                         ID = 2,
                         Quantity = 10,
                         StoreId = 1,
                         Name = "3010## Ford Boat car",
                         Price = 40060,
                         Description = "&Its a boat Car"
                     },
                 }
             );

        var reviewCtrllr = new ProductController(mockBL.Object);

        //Act
        var result = reviewCtrllr.Get();

        //Assert
        Assert.NotNull(result);
        Assert.IsType<List<Inventory>>(result);
        //Assert.Equal(2, result.Count);
    }
    [Fact]
    public void ProductControllerGetShouldGetAllProductsByStoreId()
    {
        //Arrange, Act, Assert pattern
        //Arrange step, we need to set up our mocks, so when BL.GetReviewsByRestoId
        //Gets called, we instead return a stubbed data
        var mockBL = new Mock<IBL>();
        int i = 1;
        mockBL.Setup(x => x.GetInventoriesById(i)).Returns(
                new List<Inventory>
                {
                     new Inventory
                     {
                         ID = 1,
                         Quantity = 5,
                         StoreId = 1,
                         Name = "2003 Tesla Monstr Truck",
                         Price = 3000,
                         Description = "Its an electric monster truck"
                     },
                     new Inventory
                     {
                         ID = 2,
                         Quantity = 10,
                         StoreId = 1,
                         Name = "3010 Ford Boat car",
                         Price = 4000,
                         Description = "Its a boat Car"
                     },
                 }
             );

            var reviewCtrllr = new ProductController(mockBL.Object);

            //Act
        var result = reviewCtrllr.GetSpecific(1);

        //Assert
        Assert.NotNull(result);
        Assert.IsType<ActionResult<List<Inventory>>>(result);
        //Assert.Equal(2, result.Count);
     }
    [Fact]
    public void ProductControllersGetShouldGetAllProductsByStoreId()
    {
        //Arrange, Act, Assert pattern
        //Arrange step, we need to set up our mocks, so when BL.GetReviewsByRestoId
        //Gets called, we instead return a stubbed data
        var mockBL = new Mock<IBL>();
        int i = 1;
        mockBL.Setup(x => x.GetInventoriesById(i)).Returns(
                new List<Inventory>
                {
                     new Inventory
                     {
                         ID = 1,
                         Quantity = 5,
                         StoreId = 1,
                         Name = "2003 Tesla Monster",
                         Price = 30000,
                         Description = "Its an electric monster"
                     },
                     new Inventory
                     {
                         ID = 2,
                         Quantity = 10,
                         StoreId = 1,
                         Name = "3010 dFord Boat car",
                         Price = 40000,
                         Description = "Its a boat"
                     },
                 }
             );

        var reviewCtrllr = new ProductController(mockBL.Object);

        //Act
        var result = reviewCtrllr.GetSpecific(1);

        //Assert
        Assert.NotNull(result);
        Assert.IsType<ActionResult<List<Inventory>>>(result);

    }
    [Fact]
    public void CustomerControllerShouldGetAllCustomers()
    {
        //Arrange
        var mockBL = new Mock<IBL>();
        mockBL.Setup(x => x.GetAllCustomers()).Returns(
            new List<Customer>
                {
                     new Customer
                     {
                         Id = 1,
                         Name = "Garrett",
                         Username = "Tracy",
                         Password = "1234"
                     },
                     new Customer
                     {
                         Id = 2,
                         Name = "Brad",
                         Username = "fgf",
                         Password = "3525"
                     },

                }
            );
        var userCtrllr = new CustomerController(mockBL.Object);
        //Act
        var result = userCtrllr.Get();

        //Assert
        Assert.NotNull(result);
        Assert.IsType<List<Customer>>(result);
    }
    [Fact]
    public void CustomersControllerShouldGetAllCustomers()
    {
        //Arrange
        var mockBL = new Mock<IBL>();
        mockBL.Setup(x => x.GetAllCustomers()).Returns(
            new List<Customer>
                {
                     new Customer
                     {
                         Id = 1,
                         Name = "Gaett",
                         Username = "Tracy",
                         Password = "123@3&4"
                     },
                     new Customer
                     {
                         Id = 2,
                         Name = "Brad",
                         Username = "fgf",
                         Password = "35*&325"
                     },

                }
            );
        var userCtrllr = new CustomerController(mockBL.Object);
        //Act
        var result = userCtrllr.Get();

        //Assert
        Assert.NotNull(result);
        Assert.IsType<List<Customer>>(result);
    }
    [Fact]
    public void StorefrontControllerShouldGetAlloftheStorefront()
    {
        //Arrange
        var mockBL = new Mock<IBL>();
        mockBL.Setup(x => x.GetAllStorefronts()).Returns(
            new List<Storefront>
                {
                     new Storefront
                     {
                         ID = 1,
                         Location = "1234 Garrett Ave",
                         State = "TX",
                         City = "Dallas"
                     },
                     new Storefront
                     {
                         ID = 2,
                         Location = "5466 Batman Street",
                         State = "NY",
                         City = "New York City"
                     },

                }
            );
        var storeController = new StorefrontController(mockBL.Object);
        //Act
        var result = storeController.Get();

        //Assert
        Assert.NotNull(result);
        Assert.IsType<List<Storefront>>(result);
    }
    [Fact]
    public void StorefrontControllersShouldGetAlloftheStorefront()
    {
        //Arrange
        var mockBL = new Mock<IBL>();
        mockBL.Setup(x => x.GetAllStorefronts()).Returns(
            new List<Storefront>
                {
                     new Storefront
                     {
                         ID = 1,
                         Location = "123@4 Garrett Ave",
                         State = "TX@",
                         City = "Dall@%as"
                     },
                     new Storefront
                     {
                         ID = 2,
                         Location = "54%66 Batman Street",
                         State = "N#Y",
                         City = "New# York City"
                     },

                }
            );
        var storeController = new StorefrontController(mockBL.Object);
        //Act
        var result = storeController.Get();

        //Assert
        Assert.NotNull(result);
        Assert.IsType<List<Storefront>>(result);
    }
    
}