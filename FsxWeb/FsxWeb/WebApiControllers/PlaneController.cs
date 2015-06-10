namespace FsxWeb.WebApiControllers
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Web.Http;
    using FsxCommunicator;
    using FsxCommunicator.Model;
    using Logging;

    public class PlaneController : ApiController
    {
        private readonly Fsx _fsx;

        public PlaneController()
        {
            _fsx = new Fsx(new Logger());
        }

        // GET: api/Plane
        public async Task<IHttpActionResult> Get()
        {
            //var planeData = new PlaneData {Location = new Location {Latitude = 50.0, Longitude = 50.0}};
            PlaneData planeData = null;
            try
            {
                //planeData = _fsx.GetCurrentPlaneData();
                planeData = await GetFromWebApi();
            }
            catch (Exception)
            {
                // some error
            }

            if (planeData == null)
            {
                return BadRequest("cannot connect to the FSX");
            }
            return Ok(planeData);
        }

        private async Task<PlaneData> GetFromWebApi()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8045/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/plane");
                if (response.IsSuccessStatusCode)
                {
                    PlaneData product = await response.Content.ReadAsAsync<PlaneData>();
                    return product;
                }

                return null;
            }
        }
    }
}