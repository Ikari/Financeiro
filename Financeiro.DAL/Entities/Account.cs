using System.Collections.Generic;

namespace Financeiro.DAL
{
    public class Account
    {
        public int AccountId { get; set; }
        public virtual AccountOwner Owner { get; set; }
        public int BankId { get; set; }
        public virtual Bank Bank { get; set; }
        public bool AccountActivity { get; set; }

        public virtual IList<Transaction> Transactions { get; set; }
    }
}
