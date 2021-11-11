using System;
using System.Collections.Generic;
using System.Text;

namespace ICV.Libary
{
    public class TurmaAbstract : Curso
    {
        public int IdTurma { get; set; }
        public string NomeTurma { get; set; }
        public string DescricaoTurma { get; set; }
        public PeriodoTurma PeriodoTurma { get; set; }
        public Status StatusTurma { get; set; }
        public string DataCadastroTurma { get; set; }
        
    }
}
