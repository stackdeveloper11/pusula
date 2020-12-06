using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pusula.Data
{
    public class PusulaDB:DbContext
    {
        public PusulaDB() : base("PusulaDB")
        {
            Configuration.LazyLoadingEnabled = false;
        }
        public static PusulaDB Create()
        {
            return new PusulaDB();
        }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
