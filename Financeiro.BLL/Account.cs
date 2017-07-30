using System.Linq;
using Financeiro.DAL;
using System.Collections.Generic;

namespace Financeiro.BLL
{
    public class Account
    {
        public void CreateNewAccount(string name)
        {
            using (var context = new FinanceiroContext())
            {
                context.Users.Add(new DAL.User { UserName = name });
            }
        }

        public IList<DAL.Account> GetAccounts()
        {
            using (var context = new FinanceiroContext())
            {
                return (from a in context.Accounts select a).ToList();
            }
        }

        public DAL.Account GetById(int id)
        {
            using (var context = new FinanceiroContext())
            {
                return context.Accounts.Find(id);
            }
        }

        public void Save(int? id, int bankId, int userId)
        {
            using (var context = new FinanceiroContext())
            {
                DAL.Account account;
                var bank = context.Banks.Find(bankId);
                var user = context.Users.Find(userId);

                if (id.HasValue)
                    account = context.Accounts.Find(id);
                else
                {
                    account = new DAL.Account();
                    context.Accounts.Add(account);
                }

                account.Bank = bank;
                account.Owner = user;

                context.SaveChanges();
            }
        }
    }
}
