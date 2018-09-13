using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Test.Ninject
{
    public class StartUp
    {
        public static StandardKernel Initialize()
        {
            var kernel = new StandardKernel(new DataModule());
            return kernel;
        }
    }
}
