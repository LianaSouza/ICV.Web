using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public class CursoModel: ICrud<CursoModel>
    {
        [Required]
        public int IdCurso { get; set; }

        [Required]
        public string NomeCurso { get; set; }

        [Required]
        public string DescricaoCurso { get; set; }

        [Required]
        public Status StatusCurso { get; set; }

        public string DataCadastroCurso { get; set; }

        public CursoModel Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public List<CursoModel> Buscar()
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(CursoModel objeto)
        {
            throw new NotImplementedException();
        }

        public void Editar(CursoModel objeto, int id)
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
