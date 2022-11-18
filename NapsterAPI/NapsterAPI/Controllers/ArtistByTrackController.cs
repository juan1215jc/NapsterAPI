using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NapsterAPI.Models;
using Newtonsoft.Json;

namespace NapsterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistByTrackController : ControllerBase
    {
        [HttpGet]
        public async Task<Track> Get(string track)
        {
            Track lista = new Track();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri("https://api.napster.com/v1/");
            var response = await cliente.GetAsync("tracks/" + track + "?apikey=YTkxZTRhNzAtODdlNy00ZjMzLTg0MWItOTc0NmZmNjU4Yzk4");

            if (response.IsSuccessStatusCode)
            {

                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Track>(json_respuesta);
                lista = resultado;

            }

            return lista;
        }
    }
}
