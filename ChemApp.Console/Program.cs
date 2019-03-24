using ChemApp.Domain.Concrete;
using Ninject;
using System.Reflection;

namespace ChemApp.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            var supplier = new SupplyingCompany();
            var myStorage = new Storage(supplier);
            var main = new MainMenu();
            main.Run(myStorage, supplier);
        }
    }
}