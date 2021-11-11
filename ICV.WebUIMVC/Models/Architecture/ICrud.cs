using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    interface ICrud<T>
    {
        void Cadastrar(T objeto);
        T Buscar(int id);
        List<T> Buscar();
        void Editar(T objeto, int id);
        void Remover(int id);
    }
}
