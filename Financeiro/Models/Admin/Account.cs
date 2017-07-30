using System.Collections.Generic;
using System.Web.Mvc;

namespace Financeiro.Models.Admin
{
    public class Account
    {
        public Account()
        {
        }

        public Account(IList<SelectListItem> owners, IList<SelectListItem> banks) : base()
        {
            Owners = owners;
            Banks = banks;
        }

        public int? AccountId { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public bool AccountActivity { get; set; }

        public IList<SelectListItem> Owners { get; set; }
        public IList<SelectListItem> Banks { get; set; } 
    }
}