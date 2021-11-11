using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public class DoadorModel : ICrud<DoadorModel>
    {
        [Required]
        public int IdDoador { get; set; }

        [Required]
        public string NomeDoador { get; set; }

        [Required]
        public string DocumentoDoador { get; set; }

        [Required]
        public string StatusDoador { get; set; }

        public string DataCadatro { get; set; }

        public DoadorModel Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public List<DoadorModel> Buscar()
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(DoadorModel objeto)
        {
            throw new NotImplementedException();
        }

        public void Editar(DoadorModel objeto, int id)
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
