using DAO.Context;
using DAO.Implements;
using DAO.Interfaces;
using Ninject;
using Ninject.Modules;
using Services.Implements;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Test.Ninject
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            /* Context */
            Bind<DbContext>().To<CadresContext>();

            /* DAO */
            Bind<IVarillaDAO>().To<VarillaDAO>();
            Bind<ICompradorDAO>().To<CompradorDAO>();
            Bind<IMarcoDAO>().To<MarcoDAO>();
            Bind<IPedidoDAO>().To<PedidoDAO>();

            /* Service */
            Bind<IVarillaService>().To<VarillaService>();
            Bind<ICompradorService>().To<CompradorService>();
            Bind<IMarcoService>().To<MarcoService>();
            Bind<IPedidoService>().To<PedidoService>();
        }
    }
}
