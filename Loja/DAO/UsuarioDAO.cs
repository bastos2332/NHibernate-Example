using Loja.Entidades;
using Loja.Infra;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.DAO
{
    public class UsuarioDAO
    {
        private ISession Session { get; set; }

        public UsuarioDAO(ISession session)
        {
            this.Session = session;
        }

        public void Adiciona(Usuario usuario)
        {
            ITransaction transaction = this.Session.BeginTransaction();
            this.Session.Save(usuario);
            transaction.Commit();

        }

        public void Deletar(Usuario usuario)
        {
            ITransaction transaction = this.Session.BeginTransaction();
            this.Session.Delete(usuario);
            transaction.Commit();

        }

        public Usuario BuscaPorId(int id)
        {
            return this.Session.Get<Usuario>(id);
        }
    }
}
