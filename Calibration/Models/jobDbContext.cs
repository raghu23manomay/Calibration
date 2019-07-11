using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Calibration.Models;

namespace Calibration.Models
{
    public class jobDbContext : DbContext
    { 
        static jobDbContext()
        {
            Database.SetInitializer<jobDbContext>(null);
        }
        public jobDbContext()
            : base("Name=jobDbContext")
        {
        } 
        public DbSet<CustomerList> CList { get; set; }
        public DbSet<Login> LoginDetail { get; set; }
        
    }
    
}