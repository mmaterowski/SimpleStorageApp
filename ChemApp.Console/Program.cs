using ChemApp.Console.Infrastructure;
using ChemApp.Domain.Concrete;
using Ninject;
using System.Reflection;

namespace ChemApp.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            System.AppDomain.CurrentDomain.UnhandledException += GlobalExceptionHandler.Instance;

            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            var supplier = new SupplyingCompany();
            var myStorage = new Storage(supplier);
            var mainMenu = new MainMenu();
            mainMenu.Run(myStorage, supplier);
        }
    }
}