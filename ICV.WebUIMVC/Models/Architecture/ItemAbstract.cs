using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public abstract class ItemAbstract
    {
        [Required]
        public int IdItem { get; set; }

        [Required]
        public string QuantidadeItem { get; set; }
        public string DataCadastroItem { get; set; }

        [Required]
        public string IdProduto { get; set; }

        [Required]
        public string IdDoacao { get; set; }

    }
}
