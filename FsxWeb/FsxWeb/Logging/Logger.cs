namespace FsxWeb.Logging
{
    using System;
    using FsxCommunicator.Interfaces;

    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
