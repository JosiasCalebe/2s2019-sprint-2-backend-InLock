using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.InLock.WebApi.Domains;

namespace Senai.InLock.WebApi.Repositories
{
    public class UsuarioRepository
    {
        public Usuarios BuscarPorEmailESenha(Usuarios login)
        {
            using (InLockContext ctx = new InLockContext())
            {
                var user = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);

                if (user == null) return null;
                return user;
            }
        }

        public void Cadastrar(Usuarios usuario)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }
    }
}
