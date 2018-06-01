namespace LemonadeStand
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class PlayerInfoDbContext : DbContext
    {
        public DbSet PlayerName { get; set; }
        public DbSet Score { get; set; }
    }
    
}
