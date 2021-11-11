using System;
using System.Collections.Generic;
using System.Text;

namespace ICV.Libary
{
    public interface ICrud<T>
    {
        void Cadastrar(T objeto);
        T Buscar(int id);
        List<T> Buscar();
        void Editar(T objeto, int id);
        void Remover(int id);
    }
}
