namespace FsxCommunicatorWebApi.Helpers
{
    using Infrastructure;
    using Interfaces;
    using Model;

    internal class FsxManager
    {
        private readonly FsxCommunicator _fsxCommunicator;

        internal FsxManager(ILogger logger)
        {
            _fsxCommunicator = new FsxCommunicator(logger);
        }

        internal PlaneData GetCurrentPlaneData()
        {
            var planeData = _fsxCommunicator.GetPlaneData();

            return planeData;
        }
    }
}
