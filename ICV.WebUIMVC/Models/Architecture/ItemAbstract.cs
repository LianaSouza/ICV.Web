﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebUIMVC.Models
{
    public abstract class ItemAbstract<T> : ICrud<T>
    {
        [Required]
        public int IdItem { get; set; }

        [Required]
        public string QuantidadeItem { get; set; }

        public string DataCadastroItem { get; set; }

        public CategoriaProduto categoriaProduto { get; set; }

        [Required]
        public string IdProduto { get; set; }

        [Required]
        public string IdDoacao { get; set; }

        public abstract T Buscar(int id);

        public abstract List<T> Buscar();

        public abstract void Cadastrar(T objeto);

        public abstract void Editar(T objeto, int id);

        public abstract void Remover(int id);
    }
}
