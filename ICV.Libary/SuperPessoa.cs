using System;
using System.Collections.Generic;
using System.Text;

namespace ICV.Libary
{
    public abstract class SuperPessoaAbstract 
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone{ get; set; }
        public string DataCadastro { get; set; }
        public Status Status { get; set; }

    }
}
