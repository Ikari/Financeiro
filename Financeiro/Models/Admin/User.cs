using System;
using System.ComponentModel.DataAnnotations;

namespace Financeiro.Models.Admin
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
        public string UserName { get; set; }
    }
}