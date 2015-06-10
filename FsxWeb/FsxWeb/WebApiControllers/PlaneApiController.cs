namespace FsxWeb.WebApiControllers
{
    using System.Threading.Tasks;
    using System.Web.Http;
    using FsxCommunicator;
    using Infrastructure;
    using Logging;

    public class PlaneApiController : ApiController
    {
        private readonly Fsx _fsx;
        private readonly FsxWebApi _fsxWebApi;

        public PlaneApiController()
        {
            _fsx = new Fsx(new Logger());
            _fsxWebApi = new FsxWebApi();
        }

        [Route("api/plane")]
        public async Task<IHttpActionResult> Get()
        {
            var planeData = await _fsxWebApi.GetPlaneData();

            if (planeData == null)
            {
                return BadRequest("cannot connect to the FSX");
            }
            return Ok(planeData);
        }
    }
}