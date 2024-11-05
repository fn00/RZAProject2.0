using RZAProject2.Components;
using RZAProject2.Services;
using RZAProject2.Models;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;


namespace RZAProject2UnitTest
{
    public class Tests
    {
        private TlS2302452RzaContext _context;
        private CustomerService _customerService;


        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<TlS2302452RzaContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new TlS2302452RzaContext(options);
            _customerService = new CustomerService(_context);
        }

        [Test]
        public async Task Test1()
        {
            Customer tempCustomer = new Customer()
            {
                Username = "admin",
                Password = "admin"
            };
            await _customerService.AddCustomerAsync(tempCustomer);
            var result = await _context.Customers.FirstOrDefaultAsync(c => c.Username == tempCustomer.Username);
            Assert.NotNull(result);
        }
        [Test]
        public async Task Test2()
        {
            Customer tempCustomer = new Customer();
            tempCustomer.Username = "admin";
            tempCustomer.Password = "admin";
            await _customerService.AddCustomerAsync(tempCustomer);
            var result = await _context.Customers.FirstOrDefaultAsync(c => c.Username == "not admin");
            Assert.Null(result);
        }
        [Test]
        public async Task Test3()
        {
            Customer tempCustomer = new Customer();
            tempCustomer.Username = "admin";
            tempCustomer.Password = "admin";
            await _customerService.AddCustomerAsync(tempCustomer);
            var result = await _customerService.LogIn(tempCustomer);
            Assert.NotNull(result);
        }
        [Test]
        public async Task Test4()
        {
            Customer tempCustomer = new Customer();
            tempCustomer.Username = "admin";
            tempCustomer.Password = "admin";
            await _customerService.AddCustomerAsync(tempCustomer);
            tempCustomer.Username = "not admin";
            var result = await _customerService.LogIn(tempCustomer);
            Assert.Null(result);
        }
        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }
    }
}