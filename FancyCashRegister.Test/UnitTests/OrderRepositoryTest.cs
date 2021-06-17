using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using FancyCashRegister.Services.Data;
using FancyCashRegister.Domain.Models;

namespace FancyCashRegister.Test.UnitTests
{
    public class OrderRepositoryTest
    {
        [Fact]
        public void AddOrder_WHenCalledTenOrderAddedToDb()
        {
            var subject = new OrderRepository();
            var order = new Order();
            order.DatumAanmaak = new DateTimeOffset(2021, 6, 1, 12, 30, 0, new TimeSpan(2, 0, 0));
            order.Producten.Add(new OrderProduct() { ProductId = 1, Stuksprijs = 12.50M, });

            var result = subject.AddOrder(order);

            result.Should().NotBeNull();
        }
    }
}
