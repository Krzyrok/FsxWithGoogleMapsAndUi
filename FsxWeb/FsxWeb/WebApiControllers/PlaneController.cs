namespace FsxWeb.WebApiControllers
{
    using System.Web.Http;
    using FsxCommunicator;
    using Logging;

    public class PlaneController : ApiController
    {
        private readonly Fsx _fsx;

        public PlaneController()
        {
            _fsx = new Fsx(new Logger());
        }

        // GET: api/Plane
        public IHttpActionResult Get()
        {
            var planeData = _fsx.GetCurrentPlaneData();

            if (planeData == null)
            {
                return NotFound();
            }
            return Ok(planeData);
        }
    }
}