namespace Financeiro.DAL
{
    public class Expense : Transaction
    {
        public Regularity Regularity { get; set; }

        public Expense() {
            Type = TransactionType.DEBIT;
        }

        public Expense(Regularity regularity) : base() {
            Regularity = regularity;
        }
    }
}
