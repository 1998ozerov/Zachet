using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareAreaBuilder
{

    class DataContext : DbContext
    {
        public DataContext()
            : base("DbConnection")
        { }

        public DbSet<TypeArea> TypeArea { get; set; }

    }
}
