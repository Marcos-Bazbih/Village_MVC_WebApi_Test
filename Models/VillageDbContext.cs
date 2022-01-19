using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Village_MVC_WebApi_Test.Models
{
    public partial class VillageDbContext : DbContext
    {
        public VillageDbContext()
            : base("name=VillageDbContext")
        {
        }

        DbSet<Citizen> citizens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<Village_MVC_WebApi_Test.Models.Citizen> Citizens { get; set; }
    }
}
