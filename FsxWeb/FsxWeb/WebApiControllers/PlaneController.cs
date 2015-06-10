namespace FsxWeb.WebApiControllers
{
    using System.Threading.Tasks;
    using System.Web.Http;
    using FsxCommunicator;
    using Infrastructure;
    using Logging;

    public class PlaneController : ApiController
    {
        private readonly Fsx _fsx;
        private readonly FsxWebApi _fsxWebApi;

        public PlaneController()
        {
            _fsx = new Fsx(new Logger());
            _fsxWebApi = new FsxWebApi();
        }

        // GET: api/Plane
        public async Task<IHttpActionResult> Get()
        {
            //var planeData = new PlaneData {Location = new Location {Latitude = 50.0, Longitude = 50.0}};
            var planeData = await _fsxWebApi.GetPlaneData();

            if (planeData == null)
            {
                return BadRequest("cannot connect to the FSX");
            }
            return Ok(planeData);
        }
    }
}