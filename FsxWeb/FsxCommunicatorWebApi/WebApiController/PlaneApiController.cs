namespace FsxCommunicatorWebApi.WebApiController
{
    using System.Web.Http;
    using System.Web.Http.Cors;
    using Application;
    using Helpers;
    using Logging;

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PlaneApiController : ApiController
    {
        private readonly FsxManager _fsxManager = new FsxManager(new Logger());

        [Route(Constants.ApiUri)]
        // GET: api/Plane
        public IHttpActionResult Get()
        {
            var planeData = _fsxManager.GetCurrentPlaneData();

            if (planeData == null)
            {
                return NotFound();
            }
            return Ok(planeData);
        }
    }
}
