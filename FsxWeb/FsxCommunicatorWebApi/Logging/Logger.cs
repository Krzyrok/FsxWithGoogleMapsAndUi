namespace FsxCommunicatorWebApi.Logging
{
    using System;
    using Interfaces;

    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
