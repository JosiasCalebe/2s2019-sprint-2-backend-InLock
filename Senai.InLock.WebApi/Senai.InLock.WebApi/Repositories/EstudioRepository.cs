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
    }
}
