using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCUnitTesting;
using MVCUnitTesting.Controllers;
using Telerik.JustMock;
using MVCUnitTesting.Models;


namespace MVCUnitTesting.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index_Returns_All_Products_In_DB()
        {
            //Arrange
            var productRepository = Mock.Create<Repository>();
            Mock.Arrange( () => productRepository.GetAll()).
                Returns(new List<Product>()
                {
                    new Product { Genre="Fiction", ID=1, Name="Moby Dick", Price=12.50m},
                    new Product { Genre="History", ID=2, Name="War and Peace", Price=17m},
                    new Product { Genre="Comedy", ID=2, Name="Laught, Love", Price=100m},
                    new Product { Genre="History", ID=2, Name="War ", Price=17m},
                    new Product { Genre="Comedy", ID=2, Name="ha ha ha ", Price=17m}
                }).MustBeCalled();

            //Act
            HomeController controller = new HomeController(productRepository);
            ViewResult viewResult = controller.Index();
            var model = viewResult.Model as IEnumerable<Product>;

            //Assert
            Assert.AreEqual(5, model.Count());

        }

        [TestMethod]
        public void Index_Returns_All_Products_By_Genre()
        {
            //Arrange
            var productRepository = Mock.Create<Repository>();
            Mock.Arrange(() => productRepository.GetAll()).
                Returns(new List<Product>()
                {
                    new Product { Genre="Fiction", ID=1, Name="Moby Dick", Price=12.50m},
                    new Product { Genre="History", ID=2, Name="War and Peace", Price=17m},
                }).MustBeCalled();

            //Act
            HomeController controller = new HomeController(productRepository);
            ViewResult viewResult = controller.Index("History");
            var model = viewResult.Model as IEnumerable<Product>;

            //Assert
            Assert.AreEqual(1, model.Count());

        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index("History") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page!", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
