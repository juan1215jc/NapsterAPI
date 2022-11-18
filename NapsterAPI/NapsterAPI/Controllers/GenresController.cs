using Microsoft.AspNetCore.Mvc;
using NapsterAPI.Models;
using Newtonsoft.Json;

namespace NapsterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {

        [HttpGet]
        public async Task<List<Generos>> Get()
        {
            List<Generos> lista = new List<Generos>();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri("https://api.napster.com/v1/");
            var response = await cliente.GetAsync("genres?apikey=YTkxZTRhNzAtODdlNy00ZjMzLTg0MWItOTc0NmZmNjU4Yzk4&lang=es-ES");

            if (response.IsSuccessStatusCode)
            {

                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Generos>>(json_respuesta);
                lista = resultado;

            }

            return lista;
        }


    }
}
