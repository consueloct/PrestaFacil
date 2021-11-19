using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using FinancieraAcme.PrestaFacil.UI.Web.Models;

namespace FinancieraAcme.PrestaFacil.UI.Web.Controllers
{
    public class ConsultaProductoAjaxController : Controller
    {
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://financieraacmeapicw101.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            //Type os MIME that we want to receive (in this case Json)
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            List<Producto> productos = new List<Producto>();

            HttpResponseMessage response =  await client.GetAsync("api/producto");

            if(response.IsSuccessStatusCode)
            {
                productos = await response.Content.ReadAsAsync<List<Producto>>();
            }
            return View(productos);
        }
        public IActionResult Crear()
        {

            return View();
        }

        //[ValidateAntiForgeryToken]//add an hidden field, if petition is by a valid user
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody]  Producto producto)
        {
            //calling directly from Azure,needs to anable CORS in Azure
            //url: "https://financieraacmeapicw101.azurewebsites.net/api/producto",

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://financieraacmeapicw101.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            //Type os MIME that we want to receive (in this case Json)
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.PostAsJsonAsync("api/producto",producto);
            response.EnsureSuccessStatusCode();

            
            return Json(//creando un documento Json
                new
                {
                    exito = true,
                    mensaje = $"Producto Registrado con exito"
                });
        }
    }

}
