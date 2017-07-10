using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financeiro.DAL
{
    public class Bank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? BankId { get; set; }
        public string BankNumber { get; set; }
        public string BankName { get; set; }
        public bool BankActivity { get; set; }
    }
}
