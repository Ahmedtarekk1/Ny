
using System.Text.Json;
using Laboration2.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace APIConsume.Controllers

{
    public class ReservationController : Controller

    {
        string _baseURL = "http://localhost:5155/api/Lan";
        public async Task<IActionResult> Index()
        {
            List<Lan>? ApiLista = new List<Lan>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_baseURL);
                    HttpResponseMessage response = await client.GetAsync("http://localhost:5155/api/Lan");

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        ApiLista = JsonSerializer.Deserialize<List<Lan>>(content,
                           new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    }
                    else
                        ViewBag.Message = "Tyvärr gick något fel: " + response.ReasonPhrase;
                }
            }
            catch (Exception ex)
            {

                ViewBag.Message = "Tyvärr gick något fel: " + ex.Message;
            }
            return View(ApiLista);
        }
    }
}
