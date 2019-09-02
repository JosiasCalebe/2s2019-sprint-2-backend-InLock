using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogoRepository
    {
        public List<Jogos> Listar()
        {
            using(InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.Include(x=> x.Estudio).ToList();
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
