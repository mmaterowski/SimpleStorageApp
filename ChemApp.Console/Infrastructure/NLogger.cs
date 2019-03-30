using NLog;

namespace ChemApp.Console.Infrastructure
{
    public class DefaultLogger
    {
        public static Logger Instance = LogManager.GetCurrentClassLogger();
    }
}