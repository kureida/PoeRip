using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PoeApp.Models
{
    public class TempestRIPDB
    {
        public int ID { get; set; }
        public string Character { get; set; }
        public int Rank { get; set; }
        public int Level { get; set; }
        public string Class { get; set; }
        public long Experience { get; set; }
        public string Account { get; set; }
    }

    public class TempestRIPDBDBContext : DbContext
    {
        public DbSet<TempestRIPDB> TempestRIPDB { get; set; }
    }
}