using System.Data.Entity;

namespace Financeiro.DAL
{
    public class FinanceiroContext : DbContext
    {
        public FinanceiroContext() : base("FinanceiroDB")
        {
        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
