using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NapsterAPI.Models;
using Newtonsoft.Json;

namespace NapsterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistByGenController : ControllerBase
    {
        [HttpGet]
        public async Task<List<Artista>> Get(string genero)
        {
            List<Artista> lista = new List<Artista>();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri("https://api.napster.com/v1/");
            var response = await cliente.GetAsync("genres/"+ genero + "/artists/top?apikey=YTkxZTRhNzAtODdlNy00ZjMzLTg0MWItOTc0NmZmNjU4Yzk4");

            if (response.IsSuccessStatusCode)
            {

                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Artista>>(json_respuesta);
                lista = resultado;

            }

            return lista;
        }
    }
}
