﻿using RZAProject2.Models;
using Microsoft.EntityFrameworkCore;

namespace RZAProject2.Services
{
    public class CustomerService
    {
        private readonly TlS2302452RzaContext _context;

        public CustomerService(TlS2302452RzaContext context)
        {
            _context = context;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer?> LogIn(Customer customer)
        {
            return await _context.Customers.FirstOrDefaultAsync(
                c => c.Username == customer.Username &&
                c.Password == customer.Password);
        }
        public async Task ChangePassword(int customerId, string hashedOldPassword, string hashedNewPassword)
        {
            Customer? customer = await _context.Customers.SingleOrDefaultAsync(
                c => c.CustomerId == customerId &&
                c.Password == hashedOldPassword);
            if (customer != null)
            {
                customer.Password = hashedNewPassword;
                await _context.SaveChangesAsync();
            }
        }
        #region hidden
        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }
        public async Task<Customer> GetCustomerFromIdAsync(int id)
        {
            return await _context.Customers.FirstAsync(c => c.CustomerId == id);
        }
        public async Task<bool> CheckUsernameExistsAsync(string username)
        {
            var result = await _context.Customers.FirstOrDefaultAsync(c => c.Username == username);
            return result != null;
        }
        #endregion
    }
}
