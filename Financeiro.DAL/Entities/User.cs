using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financeiro.DAL
{
    //public abstract class User
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int UserId { get; set; }
        public virtual string UserName { get; set; }
        public virtual bool UserActivity { get; set; }
    }
}
