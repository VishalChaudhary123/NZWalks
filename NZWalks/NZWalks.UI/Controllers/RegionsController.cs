using Microsoft.AspNetCore.Mvc;
using NZWalks.UI.Models;
using NZWalks.UI.Models.DTO;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace NZWalks.UI.Controllers
{
    [Route("[Controller]")]
    public class RegionsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegionsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
         // GET ALL Regions
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Index()
        {
            List<RegionDTOResponse> response = new List<RegionDTOResponse>();
            try
            {
                // Get All Regions From Web API

                // Note - We use HttpClient class to consume web api using different type of verb calls e.g GetAsync, PostAsynch, PutAsynch, DeleteAsync

                // To use it, we need to inject it in program.cs file first

                var client = _httpClientFactory.CreateClient();
                var httpResponseMessage = await client.GetAsync("https://localhost:7139/api/regions");
                httpResponseMessage.EnsureSuccessStatusCode(); // ensures that we get a success respnse else throws an exceptions

                // Create the RegionDTOResponse properties as created in API in UI Projects as well

                response.AddRange (await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<RegionDTOResponse>>());
            }
            catch (Exception ex)
            {

               // Log the error
            }

            return View(response);
        }

        // ADD New Regions

        [HttpGet]
        [Route("[action]")]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Add(AddRegionViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7139/api/regions"),
                Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")

            };
            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();
           var response =  await httpResponseMessage.Content.ReadFromJsonAsync<RegionDTOResponse>();

            if (response is not null) 
            {
                return RedirectToAction("Index","Regions");
            }
            return View();

        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var client = _httpClientFactory.CreateClient();
          var response =   await client.GetFromJsonAsync<RegionDTOResponse>($"https://localhost:7139/api/regions/{Id.ToString()}");

            if(response is not null)
            {
                return View(response);
            }
            return View(null);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Edit(RegionDTOResponse request)
        {
            var client = _httpClientFactory.CreateClient();

            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:7139/api/regions/{request.Id}"),
                Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json")
            };
           var httpResponseMessage =  await client.SendAsync(requestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();


            var response = await httpResponseMessage.Content.ReadFromJsonAsync<RegionDTOResponse>();

            if (response is not null)
            {
                return RedirectToAction("Edit", "Regions", new { Id = request.Id });
            }
            return View() ;

        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Delete(RegionDTOResponse request)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var httpResponseMessage = await client.DeleteAsync($"https://localhost:7139/api/regions/{request.Id}");

                httpResponseMessage.EnsureSuccessStatusCode();

                return RedirectToAction("Index", "Regions");
            }
            catch (Exception ex)
            {

                throw;
            }
            return View("Edit");

        }
    }
}
