
using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using FirstAPI.Repo;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        //Not used DI(dependency Injection)
        CartRepo cr = new CartRepo();
        // GET: api/<CartController>
        [HttpGet]
        public IEnumerable<Cart> Get()
        {
            return cr.getCarts();
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public Cart Get(int id)
        {
            return cr.getCartItemById(id);
        }

        [HttpGet("Products")]
        public async Task<List<UserStory>> GetProducts()
        {

            string Baseurl = "https://localhost:7119/";   //44328
            List<UserStory> PrdInfo = new List<UserStory>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Product/GetUserStory");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var ProductResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    PrdInfo = JsonConvert.DeserializeObject<List<UserStory>>(ProductResponse);
                    return PrdInfo;
                }
                else
                {
                    return null;
                }

            }
        }
        // POST api/<CartController>
        [HttpPost]
        [Route("Add")]
        public void Post([FromBody] Cart c)
        {
            cr.AddItemtoCart(c);

        }

        // PUT api/<CartController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Cart c)
        {
            cr.CancelItem(id);
            cr.AddItemtoCart(c);
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cr.CancelItem(id);
        }
    }
}
