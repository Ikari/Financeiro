using System;

namespace Financeiro.DAL
{
    public abstract class Transaction
    {
        public int TransactionId { get; set; }
        public TransactionType Type { get; set; }
        public decimal Ammount { get; set; }
        public DateTime Date { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
