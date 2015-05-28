namespace FsxWeb.WebApiControllers
{
    using System.Web.Http;
    using FsxCommunicator;

    public class PlaneController : ApiController
    {
        private readonly Fsx _fsx = new Fsx();

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