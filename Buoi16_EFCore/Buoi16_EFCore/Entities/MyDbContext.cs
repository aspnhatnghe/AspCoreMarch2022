using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi16_EFCore.Entities
{
    public class MyDbContext : DbContext
    {
        #region Properties
        public DbSet<Loai> Loais { get; set; }
        public DbSet<HangHoa> HangHoas { get; set; }
        #endregion

        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
