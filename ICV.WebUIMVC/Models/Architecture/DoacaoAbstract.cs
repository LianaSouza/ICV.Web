using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public abstract class DoacaoAbstract
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public CategoriaProduto CategoriaDoacao { get; set; }

        public string DataCadastro { get; set; }

        [Required]
        public int FKIdDoador { get; set; }

    }
}
