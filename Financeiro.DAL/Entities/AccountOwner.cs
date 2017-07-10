using System.Linq;
using System.Collections.Generic;

namespace Financeiro.DAL
{
    public class AccountOwner : User
    {
        public AccountOwner()
        {
            Accounts = new List<Account>();
        }

        public IList<Account> Accounts { get; set; }

        public virtual void AddAccount(Bank bank)
        {
            if (Accounts.Any(a => a.BankId == bank.BankId))
                return;

            var newAccount = new Account { AccountActivity = true, Bank = bank, Owner = this };

            this.Accounts.Add(newAccount);
        }
    }
}
