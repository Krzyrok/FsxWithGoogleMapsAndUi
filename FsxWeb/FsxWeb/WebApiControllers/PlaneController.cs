namespace FsxWeb.WebApiControllers
{
    using System.Web.Http;

    public class PlaneController : ApiController
    {
        //private readonly FsxManager _fsxManager = new FsxManager();

        // GET: api/Plane
        public IHttpActionResult Get()
        {
            //var planeData = _fsxManager.GetCurrentPlaneData();
            var planeData = "Data";

            if (planeData == null)
            {
                return NotFound();
            }
            return Ok(planeData);
        }
    }
}