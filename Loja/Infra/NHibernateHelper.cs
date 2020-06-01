using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Infra
{
    class NHibernateHelper
    {

        private static ISessionFactory Fabrica = CriarSessionFactory();
        private static ISessionFactory CriarSessionFactory()
        {
            Configuration cfg = RecuperarConfiguracao();
            return cfg.BuildSessionFactory();
        }

        public static Configuration RecuperarConfiguracao()
        {
            Configuration cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(Assembly.GetExecutingAssembly());
            return cfg;
        }

        public static void GeraSchemma()
        {
            Configuration cfg = RecuperarConfiguracao();
            new SchemaExport(cfg).Create(true, true);
        }

        public static ISession AbreSESSION()
        {
            return Fabrica.OpenSession();
        }
    }
}
