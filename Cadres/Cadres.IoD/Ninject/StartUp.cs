using Ninject;

namespace Cadres.IoD.Ninject
{
    public class StartUp
    {
        public static StandardKernel Initialize()
        {
            var kernel = new StandardKernel(new Bindings());
            return kernel;
        }
    }
}
