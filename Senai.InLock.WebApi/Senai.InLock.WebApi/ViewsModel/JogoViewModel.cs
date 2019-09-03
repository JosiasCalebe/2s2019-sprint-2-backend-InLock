using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.ViewsModel
{
    public class JogoViewModel
    {
        public int jogoId { get; set; }
        public string nomeJogo { get; set; }
        public string descricao { get; set; }
        public DateTime dataLancamento { get; set; }
        public double valor { get; set; }
        public string nomeEstudio { get; set; }
    }
}
