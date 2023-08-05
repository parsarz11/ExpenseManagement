using ExpensesManagment.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManagment.Web.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Income> Incomes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }


    }
}
