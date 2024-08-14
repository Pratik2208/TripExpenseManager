using Microsoft.EntityFrameworkCore;
using TripExpenseManager.Data.Data.Models;

namespace TripExpenseManager.Data.Data
{
    public class CosmosDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<LocationCategory> LocationCategories { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public CosmosDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasNoDiscriminator()
                .ToContainer("Users")
                .HasPartitionKey(u => u.UserName)
                .HasKey(u => u.UserName);

            modelBuilder.Entity<Trip>()
                .HasNoDiscriminator()
                .ToContainer("Trips")
                .HasPartitionKey(t => t.UserName)
                .HasKey(t => t.Id);

            modelBuilder.Entity<Trip>()
                .Property(t => t.Id)
                .ToJsonProperty("id");

            modelBuilder.Entity<LocationCategory>()
                .ToContainer("Locations")
                .HasNoDiscriminator()
                .HasPartitionKey(lc => lc.Name)
                .HasKey(lc => lc.Name);

            modelBuilder.Entity<LocationCategory>()
                .Property(lc => lc.Id)
                .ToJsonProperty("id");

            modelBuilder.Entity<LocationCategory>()
                .HasData((new List<LocationCategory>
                {
                    new LocationCategory("Beach","/images/beach.png"),
                    new LocationCategory("WildLife and Nature","/images/wildlife.png"),
                    new LocationCategory("Hills","/images/hill.png"),
                    new LocationCategory("Island","/images/island.png"),
                    new LocationCategory("Mountain","/images/mountain.png"),
                    new LocationCategory("Religious","/images/religious.png"),
                    new LocationCategory("Other","/images/tourism.png")
                }));

            modelBuilder.Entity<ExpenseCategory>()
                .ToContainer("ExpenseCategories")
                .HasNoDiscriminator()
                .HasPartitionKey(ec => ec.Name)
                .HasKey(ec => ec.Name);

            modelBuilder.Entity<ExpenseCategory>()
                .Property(ec => ec.Id)
                .ToJsonProperty("id");

            modelBuilder.Entity<ExpenseCategory>()
                .HasData(new List<ExpenseCategory>
                {
                    new("Food"),new("Fuel"),new("Entertainment"),new("Shopping"),new("Other")
                });

            modelBuilder.Entity<Expense>()
                .ToContainer("Expenses")
                .HasNoDiscriminator()
                .HasPartitionKey(e => e.TripId)
                .HasKey(e => e.Id);

            modelBuilder.Entity<Expense>()
                .Property(t => t.Id)
                .ToJsonProperty("id");
        }
    }
}
