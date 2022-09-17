using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PmsApi.Models;
using PmsApi.Data;

namespace PmsApi.Controllers
{
    [Route("api/[controller]")]
    //[Route("api/[controller]/[action]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly ApiContext _context;

        public MedicineController(ApiContext context)
        {
            _context = context;
        }

        // Create/Edit
        [HttpPost]
        [Route("CreateEditMedicine")]
        public JsonResult CreateEdit(MedicineInfo medicine)
        {
            if (medicine.Id == 0)
            {
                _context.Medicines.Add(medicine);
            }
            else
            {
                var medicineInDb = _context.Medicines.Find(medicine.Id);

                if (medicineInDb == null)
                    return new JsonResult(NotFound());

                medicineInDb = medicine;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(medicine));
        }

        // Get
        [HttpGet]
        [Route("GetMedicineById")]
        public JsonResult Get(int id)
        {
            var result = _context.Medicines.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        // Delete
        [HttpDelete]
        [Route("DeleteMedicine")]
        public JsonResult Delete(int id)
        {
            var result = _context.Medicines.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            _context.Medicines.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        // Get all
        [HttpGet]
        [Route("GetAllMedicines")]
        public JsonResult GetAll()
        {
            var result = _context.Medicines.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
