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

        public List<JogoViewModel> Lancamentos()
        {
            using (InLockContext ctx = new InLockContext())
            {
                var listaJogos = ctx.Jogos.Include(x => x.Estudio).OrderByDescending(x => x.DataLancamento).ToList();
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


        public List<JogoViewModel> BuscarPeloNome(string nome)
        {
            using(InLockContext ctx = new InLockContext())
            {
                var listaJogos = ctx.Jogos.Where(x => x.NomeJogo.Contains(nome)).ToList();
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

        public List<JogoViewModel> MaisCaros()
        {

            using (InLockContext ctx = new InLockContext())
            {
                var listaJogos = ctx.Jogos.Include(x => x.Estudio).OrderByDescending(x=> x.Valor).ToList();
                List<JogoViewModel> ViewsModel = new List<JogoViewModel>();

                int contador = 5;
                if (listaJogos.Count < 5) contador = listaJogos.Count;

                for (int i = 0; i < contador; i++)
                {
                    var a = new JogoViewModel();

                    a.jogoId = listaJogos[i].JogoId;
                    a.nomeJogo = listaJogos[i].NomeJogo;
                    a.descricao = listaJogos[i].Descricao;
                    a.dataLancamento = listaJogos[i].DataLancamento;
                    a.valor = listaJogos[i].Valor;
                    a.nomeEstudio = ctx.Estudios.Find(listaJogos[i].EstudioId).NomeEstudio;
                    ViewsModel.Add(a);
                }
                return ViewsModel;
            }
        }

        public List<Lancamentos> Listarr()
        {
            using (InLockContext ctx = new InLockContext())
            {
                var listaJogos = ctx.Jogos.Include(x => x.Estudio).ToList();
                List<Lancamentos> Lancamentos = new List<Lancamentos>();

                foreach (var E in listaJogos)
                {
                    int z = Convert.ToInt16((E.DataLancamento - DateTime.Now).TotalDays);
                    var a = new Lancamentos();

                    a.Titulo = E.NomeJogo;
                    if (z <= 0)
                    {
                        z = 0;
                    }
                    a.DiasFaltando = z;
                    Lancamentos.Add(a);
                }

                return Lancamentos;
            }
        }

    }
}
