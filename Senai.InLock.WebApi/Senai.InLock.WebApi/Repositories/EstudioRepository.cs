using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.ViewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class EstudioRepository
    {

        public List<EstudioViewModel> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                var listaEstudios = ctx.Estudios.Include(x => x.Pais).ToList();
                List<EstudioViewModel> ViewsModel = new List<EstudioViewModel>();

                foreach (var E in listaEstudios)
                {
                    var a = new EstudioViewModel();

                    a.nomeEstudio = E.NomeEstudio;
                    a.dataCriacao = E.DataCriacao;
                    a.estudioId = E.EstudioId;
                    a.nomePais = ctx.Paises.Find(E.PaisId).NomePais;
                    a.emailUsuario = ctx.Usuarios.Find(E.UsuarioId).Email;

                    ViewsModel.Add(a);
                }
                return ViewsModel;
            }
        }




        public void Inserir(Estudios estudio)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Estudios.Add(estudio);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Estudios.Remove(ctx.Estudios.Find(id));
                ctx.SaveChanges();
            }
        }

        public void Alterar(Estudios estudio)
        {
            using (InLockContext ctx = new InLockContext())
            {
                var a = ctx.Estudios.Find(estudio.EstudioId);
                a.NomeEstudio = estudio.NomeEstudio;
                a.DataCriacao = estudio.DataCriacao;
                a.PaisId = estudio.PaisId;

                ctx.Estudios.Update(a);
                ctx.SaveChanges();
            }
        }

        public List<JogoViewModel> BuscarPeloNome(string nome)
        {
            using(InLockContext ctx = new InLockContext())
            {
                var listaEstudios = ctx.Estudios.Where(x => x.NomeEstudio.Contains(nome)).ToList();

                List<JogoViewModel> JogosRetorno = new List<JogoViewModel>();
                foreach (var item in listaEstudios)
                {
                    var listaJogos = ctx.Jogos.Where(x => x.EstudioId == item.EstudioId);

                    foreach (var E in listaJogos)
                    {
                        var a = new JogoViewModel();

                        a.jogoId = E.JogoId;
                        a.nomeJogo = E.NomeJogo;
                        a.descricao = E.Descricao;
                        a.dataLancamento = E.DataLancamento;
                        a.valor = E.Valor;
                        a.nomeEstudio = ctx.Estudios.Find(E.EstudioId).NomeEstudio;
                        JogosRetorno.Add(a);
                    }
                }
                return JogosRetorno;
            }
        }

        public List<EstudioViewModel> ListarComJogos()
        {
            using (InLockContext ctx = new InLockContext())
            {
                var listaEstudios = ctx.Estudios.Include(x => x.Pais).ToList();
                List<EstudioViewModel> ViewsModel = new List<EstudioViewModel>();

                foreach (var E in listaEstudios)
                {
                    var a = new EstudioViewModel();

                    a.nomeEstudio = E.NomeEstudio;
                    a.dataCriacao = E.DataCriacao;
                    a.estudioId = E.EstudioId;
                    a.nomePais = ctx.Paises.Find(E.PaisId).NomePais;
                    a.emailUsuario = ctx.Usuarios.Find(E.UsuarioId).Email;
                    a.jogos = new List<JogoViewModel>();
                    foreach (var item in ctx.Jogos.Where(x => x.EstudioId == E.EstudioId).ToList())
                    {
                        JogoViewModel jv = new JogoViewModel();
                        jv.jogoId = item.JogoId;
                        jv.nomeJogo = item.NomeJogo;
                        jv.descricao = item.Descricao;
                        jv.dataLancamento = item.DataLancamento;
                        jv.valor = item.Valor;
                        jv.nomeEstudio = ctx.Estudios.Find(item.EstudioId).NomeEstudio;
                        a.jogos.Add(jv);
                    }

                    
                    ViewsModel.Add(a);
                }
                return ViewsModel;
            }
        }


        public List<EstudioViewModel> BuscarPeloIdUsuario(int idUser)
        {
            using (InLockContext ctx = new InLockContext())
            {
                var listaEstudios = ctx.Estudios.Include(x => x.Pais).Where(x=>x.UsuarioId==idUser).ToList();
                List<EstudioViewModel> ViewsModel = new List<EstudioViewModel>();

                foreach (var E in listaEstudios)
                {
                    var a = new EstudioViewModel();

                    a.nomeEstudio = E.NomeEstudio;
                    a.dataCriacao = E.DataCriacao;
                    a.estudioId = E.EstudioId;
                    a.nomePais = ctx.Paises.Find(E.PaisId).NomePais;
                    a.emailUsuario = ctx.Usuarios.Find(E.UsuarioId).Email;

                    ViewsModel.Add(a);
                }
                return ViewsModel;
            }
        }


        public List<EstudioViewModel> Listarr()
        {
            using (InLockContext ctx = new InLockContext())
            {
                var listaEstudios = ctx.Estudios.Include(x => x.Pais).ToList();
                List<EstudioViewModel> ViewsModel = new List<EstudioViewModel>();
                foreach (var E in listaEstudios)
                {
                    var a = new EstudioViewModel();

                    a.nomeEstudio = E.NomeEstudio;
                    a.dataCriacao = E.DataCriacao;
                    a.estudioId = E.EstudioId;
                    a.nomePais = ctx.Paises.Find(E.PaisId).NomePais;

                    if ((DateTime.Now - E.DataCriacao).TotalDays <= 10)
                    {
                        ViewsModel.Add(a);
                    }
                }

                return ViewsModel;

            }

        }

        public List<EstudioViewModel> ListarPorPais(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                var listaEstudios = ctx.Estudios.Include(x => x.Pais).ToList();
                List<EstudioViewModel> ViewsModel = new List<EstudioViewModel>();

                foreach (var E in listaEstudios)
                {
                    var a = new EstudioViewModel();

                    a.nomeEstudio = E.NomeEstudio;
                    a.dataCriacao = E.DataCriacao;
                    a.estudioId = E.EstudioId;
                    a.nomePais = ctx.Paises.Find(E.PaisId).NomePais;
                    if (E.PaisId == id)
                    {
                        ViewsModel.Add(a);
                    }
                }
                return ViewsModel;
            }
        }
       

        public List<EstudioViewModel> ListarJogosPorPais(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                var listaEstudios = ctx.Estudios.Include(x => x.Pais).ToList();
                var listaJogos = ctx.Jogos.Include(x => x.Estudio).ToList();
                List<EstudioViewModel> ViewsModel = new List<EstudioViewModel>();

                foreach (var E in listaEstudios)
                {
                    List<JogoViewModel> Jogos = new List<JogoViewModel>();
                    var a = new EstudioViewModel();

                    a.nomeEstudio = E.NomeEstudio;
                    a.dataCriacao = E.DataCriacao;
                    a.estudioId = E.EstudioId;
                    a.nomePais = ctx.Paises.Find(E.PaisId).NomePais;
                    foreach (var J in listaJogos)
                    {
                        if (J.EstudioId == E.EstudioId)
                        {
                            var j = new JogoViewModel
                            {
                                jogoId = J.JogoId,
                                nomeJogo = J.NomeJogo,
                                dataLancamento = J.DataLancamento,
                                valor = J.Valor
                            };
                            Jogos.Add(j);
                        }
                    }
                    a.jogos = Jogos;

                    if (E.PaisId == id)
                    {
                        ViewsModel.Add(a);
                    }
                }
                return ViewsModel;
            }
        }




    }
}
