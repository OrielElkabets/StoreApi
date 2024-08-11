using Microsoft.EntityFrameworkCore;
using StoreApi.Entities.StoreDb.EOs;

namespace StoreApi.Entities.StoreDb
{
    public class StoreDbContext: DbContext
    {
        public DbSet<ItemsEO> Items { get; set; }
        public StoreDbContext(DbContextOptions<StoreDbContext> option): base(option) {}
    }
}
