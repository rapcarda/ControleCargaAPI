using System;
using System.Collections.Generic;

namespace API.ViewModel
{
    public class MovimentoViewModel
    {
        public int UsuarioCodigo { get; set; }
        public string UsuarioNome { get; set; }
        public string FrotaPlaca { get; set; }
        public DateTime? DataHoraInicial { get; set; }
        public DateTime? DataHoraFinal { get; set; }
        public IEnumerable<ItemMovimentoViewModel> ItemMovimento { get; set; }
    }
}
