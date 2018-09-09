using DAO.Context;
using DAO.Implements;
using DAO.Interfaces;
using Ninject.Modules;
using Services.Implements;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependancyInjection
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

            /* Services */
            //Bind<ICompradorService>().To<CompradorService>();
            //Bind<IVarillaService>().To<VarillaService>();
            //Bind<IMarcoService>().To<MarcoService>();
            //Bind<IPedidoService>().To<PedidoService>();
        }
    }
}
