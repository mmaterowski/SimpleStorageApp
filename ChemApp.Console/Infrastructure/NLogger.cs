using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChemApp.Console.Infrastructure
{
    public class DefaultLogger
    {
        public static Logger Instance = LogManager.GetCurrentClassLogger();
    }
}