namespace FsxCommunicator
{
    using Interfaces;
    using Model;

    public class Fsx
    {
        private readonly ILogger _logger;

        public Fsx(ILogger logger)
        {
            _logger = logger;
        }

        public PlaneData GetCurrentPlaneData()
        {
            var planeData = new PlaneData
            {
                Location = new Location
                {
                    Altitude = 1.0
                }
            };

            return planeData;
        }
    }
}
