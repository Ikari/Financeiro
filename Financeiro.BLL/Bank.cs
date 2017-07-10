using System.Collections.Generic;
using System.Linq;
using Financeiro.DAL;

namespace Financeiro.BLL
{
    public class Bank
    {
        public void CreateNewBank(string name, string number)
        {
            using (var context = new FinanceiroContext())
            {
                context.Banks.Add(new DAL.Bank { BankName = name, BankNumber = number });
            }
        }

        public IList<DAL.Bank> GetBanks()
        {
            using (var context = new FinanceiroContext())
            {
                return (from a in context.Banks select a).ToList();
            }
        }

        public DAL.Bank GetBankById(int id)
        {
            using (var context = new FinanceiroContext())
            {
                return context.Banks.Find(id);
            }
        }

        public void Save(int? id, string name, string number)
        {
            using (var context = new FinanceiroContext())
            {
                DAL.Bank bank;

                if (id.HasValue)
                    bank = context.Banks.Find(id);
                else
                {
                    bank = new DAL.Bank();
                    context.Banks.Add(bank);
                }

                bank.BankName = name;
                bank.BankNumber = number;

                context.SaveChanges();
            }
        }
    }
}
