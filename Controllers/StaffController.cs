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
        public async Task<IActionResult> CreateEmploeesAsync([FromBody] EmploeeModel emploeeModel)
        {
            if (emploeeModel != null)
            {
                Emploee newEmploee = new Emploee(emploeeModel.SurName, emploeeModel.Name, emploeeModel.ThirdName,
                    emploeeModel.BirthDay, emploeeModel.EmploymentDate, emploeeModel.Salary);
                _db.Emploees.Add(newEmploee);
                await _db.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }



        [HttpPatch("{id}")]
        public async Task<string> UpdateEmploeeAsync(int id, [FromBody] EmploeeModel emploeeModel)
        {
            if (emploeeModel != null)
            {
                Emploee emploeeForUpdate = _db.Emploees.FirstOrDefault(u => u.Id == id);
                if (emploeeForUpdate != null)
                {
                    try
                    {
                        emploeeForUpdate.SurName = emploeeModel.SurName;
                        emploeeForUpdate.Name = emploeeModel.Name;
                        emploeeForUpdate.ThirdName = emploeeModel.ThirdName;
                        emploeeForUpdate.BirthDay = emploeeModel.BirthDay;
                        emploeeForUpdate.EmploymentDate = emploeeModel.EmploymentDate;
                        emploeeForUpdate.Salary = emploeeModel.Salary;

                        _db.Emploees.Update(emploeeForUpdate);
                        await _db.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                    return $"Cотрудник под номером {id} обновлен";
                }

                return $"Cотрудник под номером {id} не найден";
            }
            return $"Что то пошло не так";
        }




        [HttpDelete("{id}")]
        public async Task<string> DeleteAsync(int id)
        {
            Emploee emploee = _db.Emploees.FirstOrDefault(u => u.Id == id);
            if (emploee != null)
            {
                try
                {
                    _db.Emploees.Remove(emploee);
                    await _db.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                    return ex.Message;
                }

                return $"Cотрудник под номером {id} удален";
            }
            return $"Нет сотрудника под номером {id}";
        }





    }
}
