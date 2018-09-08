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

            /* DAO */
            Bind<ICompradorDAO>().To<CompradorDAO>();
            Bind<IVarillaDAO>().To<VarillaDAO>();
            Bind<IMarcoDAO>().To<MarcoDAO>();
            Bind<IPedidoDAO>().To<PedidoDAO>();

            /* Services */
            Bind<ICompradorService>().To<CompradorService>();
            Bind<IVarillaService>().To<VarillaService>();
            Bind<IMarcoService>().To<MarcoService>();
            Bind<IPedidoService>().To<PedidoService>();
        }
    }
}
