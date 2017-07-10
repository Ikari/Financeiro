namespace Financeiro.DAL
{
    public class Income : Transaction
    {
        public Regularity Regularity { get; set; }

        public Income() {
            Type = TransactionType.CREDIT;
        }

        public Income(Regularity regularity) : base() {
            Regularity = regularity;
        }
    }
}
