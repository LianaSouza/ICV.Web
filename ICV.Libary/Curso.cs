using System;
using System.Collections.Generic;
using System.Text;

namespace ICV.Libary
{
    public abstract class Curso
    {
        public int IdCurso { get; set; }
        public string NomeCurso { get; set; }
        public string DescricaoCurso { get; set; }
        public Status StatusCurso { get; set; }
        public string DataCadastroCurso { get; set; }
    }
}
