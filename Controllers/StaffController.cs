using WebStaff.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStaff.CommonModels;

namespace WebStaff.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        //тестовый запрос
        [HttpGet("test")]
        public IActionResult Test()
        {

            string t = $"";
            return Ok($"Привет! Сервер запущен {DateTime.Now.ToString("D")} в {DateTime.Now.ToString("t")}");
        }


        private readonly Context _db;

        public StaffController(Context db)
        {
            _db = db;
        }


        [HttpPost]
        public async Task<IActionResult> CreateEmploees([FromBody] EmploeeModel emploeeModel)
        {
            if (emploeeModel != null)
            {
                Emploee newEmploee = new Emploee(emploeeModel.SurName, emploeeModel.Name, emploeeModel.ThirdName,
                    emploeeModel.BirthDay, emploeeModel.EmploymentDate, emploeeModel.Salary);
                _db.Emploees.Add(newEmploee);
                _db.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }







        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            Emploee emploee = _db.Emploees.FirstOrDefault(u => u.Id == id);
            if (emploee != null)
            {
                try
                {
                    _db.Emploees.Remove(emploee);
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {

                   return ex.Message;
                }

                return $"Cотрудника под номером {id} удален";
            }
            return $"Нет сотрудника под номером {id}"; 
        }





    }
}
