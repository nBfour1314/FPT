using FPTBookstoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FPTBookstoreApplication.Data_base
{
    public class MyApplicationDbContext : DbContext
    {
        public MyApplicationDbContext() : base("DefaultConnection")
        {

        }

        //define the entity list of database in model

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Orderdetail> Orderdetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}