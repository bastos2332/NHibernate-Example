using Loja.DAO;
using Loja.Entidades;
using Loja.Infra;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja
{
    class Program
    {
        static void Main(string[] args)
        {
            //NHibernateHelper.GeraSchemma();

            ISession session = NHibernateHelper.AbreSESSION();

            UsuarioDAO usuarioDAO = new UsuarioDAO(session);

            Usuario usuario = new Usuario();
            usuario.Nome = "Danilo";

            usuarioDAO.Adiciona(usuario);

            session.Close();

            Console.Read();
        }
    }
}
