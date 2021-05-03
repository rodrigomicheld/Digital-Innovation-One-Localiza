using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Models.ViewModels
{
    public class ValidarCampoViewModel
    {
        public IEnumerable<string> Erros { get; private set; }

        public ValidarCampoViewModel(IEnumerable<string> erros)
        {
            Erros = erros;
        }
    }
}
