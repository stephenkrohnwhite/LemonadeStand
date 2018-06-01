namespace LemonadeStand
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model15")
        {
        }

        public virtual DbSet<HighScore> HighScores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HighScore>()
                .Property(e => e.NAME)
                .IsUnicode(false);
        }
    }
}
