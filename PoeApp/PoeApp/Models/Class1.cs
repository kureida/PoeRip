using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PoeApp.Models
{
    public class Class1
    {
        public int ID { get; set;}
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
    public class Class1DBContext : DbContext
    {
        public DbSet<Class1> Class1s { get; set; }
    }
}