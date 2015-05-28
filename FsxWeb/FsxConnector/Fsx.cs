namespace FsxConnector
{
    using Model;

    public class Fsx
    {
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
