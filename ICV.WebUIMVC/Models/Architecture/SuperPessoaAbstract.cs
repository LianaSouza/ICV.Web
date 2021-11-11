using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public abstract class SuperPessoaAbstract 
    {
        [Required]
        public int id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public Status Status { get; set; }

        public string DataCadastro { get; set; }
    }
}
