namespace FsxWeb.Infrastructure
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using FsxCommunicatorWebApi.Application;
    using FsxCommunicatorWebApi.Model;

    public class FsxWebApi
    {
        public async Task<PlaneData> GetPlaneData()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.Uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(Constants.ApiUri);
                if (response.IsSuccessStatusCode)
                {
                    var product = await response.Content.ReadAsAsync<PlaneData>();
                    return product;
                }

                return null;
            }
        }
    }
}