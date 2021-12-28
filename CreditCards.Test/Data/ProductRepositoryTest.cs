using Moq;
using SampleUnitTestingApp.Data;
using SampleUnitTestingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CreditCards.Test.Data
{
    public class ProductRepositoryTest
    {
        public IProductRepository MockProductRepository { get; private set; }
        public ProductRepositoryTest()
        {
            IList<Product> products = new List<Product>()
            {
                new Product {ProductId = 1,Name="ASP Core Fundamentals",Description="ASP Core Fundamentals",Price=49.99},
                new Product {ProductId = 2,Name="TDD Fundamentals",Description="TDD Fundamentals",Price=60},
                new Product {ProductId = 3,Name="Unit Testing in Action",Description="Unit Testing in Action",Price=50},
            };
            Mock<IProductRepository> mockProductRepo = new Mock<IProductRepository>();
            mockProductRepo.Setup(m => m.FindAll()).Returns(products);
            mockProductRepo.Setup(m => m.FindById(
                It.IsAny<int>())).Returns((int i)=>products.Where(x=>x.ProductId==i).Single());

            mockProductRepo.Setup(m => m.FindByName(It.IsAny<string>()))
                .Returns((string s) => products.Where(x => x.Name == s).Single());

            mockProductRepo.Setup(m => m.Save(It.IsAny<Product>()))
                .Returns((Product target) =>
                {
                    DateTime now = DateTime.Now;
                    if (target.ProductId.Equals(default(int)))
                    {
                        target.DateCreated = now;
                        target.DateModified = now;
                        target.ProductId = products.Count() + 1;
                        products.Add(target);
                    }
                    else
                    {
                        var original = products.Where(
                            q => q.ProductId == target.ProductId).Single();
                        if (original == null) return false;
                        original.Name = target.Name;
                        original.Price = target.Price;
                        original.Description = target.Description;
                        original.DateModified = now;
                    }
                    return true;
                });
            this.MockProductRepository = mockProductRepo.Object;
        }

        [Fact]
        public void CanReturnProductById()
        {
            Product testProduct = this.MockProductRepository.FindById(2);
            Assert.NotNull(testProduct);
            Assert.IsType<Product>(testProduct);
            Assert.Equal("TDD Fundamentals", testProduct.Name);
        }

        [Fact]
        public void CanFindAllProduct()
        {
            IList<Product> testProduct = this.MockProductRepository.FindAll();

            Assert.NotNull(testProduct);
            Assert.Equal(3, testProduct.Count);
        }

        [Fact]
        public void CanReturnProductByName()
        {
            Product testProducts = this.MockProductRepository.FindByName("ASP Core Fundamentals");
            Assert.NotNull(testProducts);
            Assert.IsType<Product>(testProducts);
            Assert.Equal(1, testProducts.ProductId);
        }

        [Fact]
        public void CanInsertProduct()
        {
            Product newProduct = new Product
            {
                Name = "Blazor Fundamentals",
                Description = "Blazor Fundamentals",
                Price = 50
            };

            int productCount = this.MockProductRepository.FindAll().Count;
            Assert.Equal(3, productCount);

            this.MockProductRepository.Save(newProduct);

            productCount = this.MockProductRepository.FindAll().Count;
            Assert.Equal(4,productCount);

            Product testProduct = this.MockProductRepository.FindByName("Blazor Fundamentals");
            Assert.NotNull(testProduct);
            Assert.IsType<Product>(testProduct);
        }
    }
}
