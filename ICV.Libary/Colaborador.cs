using System;
using System.Collections.Generic;
using System.Text;

namespace ICV.Libary
{
    public class Colaborador:SuperPessoaAbstract
    {
        public string DataNascimento { get; set; }
        public string CPF { get; set; }
        public TipoColaborador TipoColaborador { get; set; }
        public string Senha { get; set; }

    }
}
