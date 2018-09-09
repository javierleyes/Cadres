using DAO.Context;
using DAO.Implements;
using DAO.Interfaces;
using Ninject;
using Ninject.Modules;
using Services.Implements;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Test.IoD
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            /* Context */
            CadresContext Context = new CadresContext();

            /* DAO */
            Bind<IVarillaDAO>().To<VarillaDAO>().WithConstructorArgument("dbContext", Context);
            Bind<ICompradorDAO>().To<CompradorDAO>().WithConstructorArgument("dbContext", Context);
            Bind<IMarcoDAO>().To<MarcoDAO>().WithConstructorArgument("dbContext", Context);
            Bind<IPedidoDAO>().To<PedidoDAO>().WithConstructorArgument("dbContext", Context);

            /* Provisorio ver con lsoro y jluna jaja */
            IVarillaDAO VarillaDAO = new VarillaDAO(Context);
            ICompradorDAO CompradorDAO = new CompradorDAO(Context);
            IMarcoDAO MarcoDAO = new MarcoDAO(Context);
            IPedidoDAO PedidoDAO = new PedidoDAO(Context);

            MarcoService marcoService = new MarcoService(new MarcoDAO(Context));

            /* Services */
            Bind<IVarillaService>().To<VarillaService>().WithConstructorArgument("entityDAO", VarillaDAO);
            Bind<ICompradorService>().To<CompradorService>().WithConstructorArgument("entityDAO", CompradorDAO);
            Bind<IMarcoService>().To<MarcoService>().WithConstructorArgument("entityDAO", MarcoDAO);
            Bind<IPedidoService>().To<PedidoService>().WithConstructorArgument("entityDAO", PedidoDAO).WithPropertyValue("MarcoService", marcoService);
        }

        public static StandardKernel LoadDependancy()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            return kernel;
        }
    }
}
