using System.Linq;
using Financeiro.DAL;
using System.Collections.Generic;

namespace Financeiro.BLL
{
    public class User
    {
        #region -> User specific <-

        public void CreateNewUser(string name)
        {
            using (var context = new FinanceiroContext())
            {
                context.Users.Add(new DAL.User { UserName = name });
            }
        }

        public IList<DAL.User> GetUsers()
        {
            using (var context = new FinanceiroContext())
            {
                return (from a in context.Users select a).ToList();
            }
        }

        public DAL.User GetUserById(int id)
        {
            using (var context = new FinanceiroContext())
            {
                return context.Users.Find(id);
            }
        }

        public void Save(int? id, string name)
        {
            using (var context = new FinanceiroContext())
            {
                DAL.User user;

                if (id.HasValue)
                    user = context.Users.Find(id);
                else
                {
                    user = new DAL.User();
                    context.Users.Add(user);
                }

                user.UserName = name;

                context.SaveChanges();
            }
        }

        #endregion

        #region -> Account specific <-

        public void AddNewAccount(int bankId, int userId)
        {
            using (var context = new FinanceiroContext())
            {
                var owner = (AccountOwner)context.Users.Find(userId);
                owner.AddAccount(context.Banks.Find(bankId));
                context.SaveChanges();
            }
        }

        public void DeleteAccount(Bank bank, User user)
        {

        }

        #endregion
    }
}
