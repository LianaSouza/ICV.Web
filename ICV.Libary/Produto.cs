using System;
using System.Collections.Generic;
using System.Text;

namespace ICV.Libary
{
    class Produto
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public CategoriaProduto CategoriaProduto { get; set; }
        public string QuantidadeProduto { get; set; }
        public string DataCadastro { get; set; }

    }
}
