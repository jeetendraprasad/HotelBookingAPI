using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PmsApi.Models;
using PmsApi.Data;

namespace PmsApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApiContext _context;

        public UserController(ApiContext context)
        {
            _context = context;
        }

        // Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(UserInfo model)
        {
            if (model.Id == 0)
            {
                _context.Users.Add(model);
            } else
            {
                var record = _context.Users.Find(model.Id);

                if (record == null)
                    return new JsonResult(NotFound());

                record = model;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(model));
        }

        // Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Users.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        // Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Users.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            _context.Users.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        // Get all
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Users.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
