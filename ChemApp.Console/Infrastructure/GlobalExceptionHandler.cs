namespace ChemApp.Console.Infrastructure
{
    using System;

    internal static class GlobalExceptionHandler
    {
        internal static void Instance(object sender, UnhandledExceptionEventArgs e)
        {
            DefaultLogger.Instance.Error("ExceptionOccured:");
            DefaultLogger.Instance.Error(e.ExceptionObject.ToString());
        }
    }
}