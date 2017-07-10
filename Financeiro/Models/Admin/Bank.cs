using System;
using System.ComponentModel.DataAnnotations;

namespace Financeiro.Models.Admin
{
    public class Bank
    {
        public int BankId { get; set; }
        [Display(Description ="Nome do Banco")]
        [Required(ErrorMessage = "O nome do banco é obrigatório.")]
        public string BankName { get; set; }
        [Display(Description ="Número do Banco")]
        [Required(ErrorMessage = "O número do banco é obrigatório")]
        public string BankNumber { get; set; }
    }
}