using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.ViewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogoRepository
    {
        public List<JogoViewModel> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                var listaJogos = ctx.Jogos.Include(x => x.Estudio).ToList();
                List<JogoViewModel> ViewsModel = new List<JogoViewModel>();

                foreach (var E in listaJogos)
                {
                    var a = new JogoViewModel();

                    a.jogoId = E.JogoId;
                    a.nomeJogo = E.NomeJogo;
                    a.descricao = E.Descricao;
                    a.dataLancamento = E.DataLancamento;
                    a.valor = E.Valor;
                    a.nomeEstudio = ctx.Estudios.Find(E.EstudioId).NomeEstudio;
                    ViewsModel.Add(a);
                }

                return ViewsModel;
            }
        }

        public void Inserir(Jogos jogo)
        {
            using(InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Add(jogo);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Remove(ctx.Jogos.Find(id));
                ctx.SaveChanges();
            }
        }

        public void Alterar(Jogos jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                var a = ctx.Jogos.Find(jogo.JogoId);
                a.NomeJogo = jogo.NomeJogo;
                a.Descricao = jogo.Descricao;
                a.DataLancamento = jogo.DataLancamento;
                a.EstudioId = jogo.EstudioId;
                a.Valor = jogo.Valor;

                ctx.Jogos.Update(a);
                ctx.SaveChanges();
            }
        }
    }
}
