using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.ViewsModel
{
    public class EstudioViewModel
    {
        public int estudioId { get; set; }
        public string nomeEstudio { get; set; }
        public DateTime dataCriacao { get; set; }
        public string nomePais { get; set; }
        public string emailUsuario { get; set; }
        public List<JogoViewModel> jogos { get; set; }
    }
}
