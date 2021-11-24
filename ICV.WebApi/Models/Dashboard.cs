using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebApi.Models
{
    public class Dashboard
    {
        public string DataInicio { get; set; }

        public string DataFim { get; set; }

        public List<int> QtdEntradaDoacao { get; set; }

        public List<int> QtdSaidaDoacao { get; set; }
    }
}
