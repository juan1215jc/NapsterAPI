using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NapsterAPI.Models;
using Newtonsoft.Json;

namespace NapsterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackByAlbumController : ControllerBase
    {
        [HttpGet]
        public async Task<List<Album>> Get(string album)
        {
            List<Album> lista = new List<Album>();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri("https://api.napster.com/v1/");
            var response = await cliente.GetAsync("albums/" + album + "/tracks?apikey=YTkxZTRhNzAtODdlNy00ZjMzLTg0MWItOTc0NmZmNjU4Yzk4");

            if (response.IsSuccessStatusCode)
            {

                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Album>>(json_respuesta);
                lista = resultado;

            }

            return lista;
        }
    }
}
