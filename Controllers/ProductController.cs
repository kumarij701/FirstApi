using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly dbContext db;
        public ProductController(dbContext _db)
        {
            db = _db;
        }

        [HttpGet]
        [Route("GetUserStory")]
        public ActionResult<List<UserStory>> GetUserStory()
        {
            return Ok(db.UserStories.ToList());
        }

        [HttpPost("AddProduct")]
        public ActionResult AddNewProduct([FromBody] UserStory p)
        {
            db.UserStories.Add(p);
            db.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public ActionResult<UserStory> GetById(int id)
        {
            UserStory p = db.UserStories.Find(id);
            return Ok(p);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult DeleteProduct(int id)
        {
            UserStory p = db.UserStories.Find(id);
            db.UserStories.Remove(p);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("update/{id}")]
        public ActionResult UpdateProduct(int id, [FromBody]UserStory p)
        {
            db.UserStories.Update(p);
            db.SaveChanges();
            return Ok();
        }

    }
}
