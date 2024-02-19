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
        public IActionResult CreateEmploees([FromBody] EmploeeModel emploeeModel)
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



        //        private readonly ApplicationContext _db;
        //private readonly UsersService _usersService;

        //public UsersController(ApplicationContext db)
        //{
        //    _db = db;
        //    _usersService = new UsersService(db);

        //}
        //
        //        [HttpPost]
        //        public IActionResult CreateUser([FromBody] UserModel userModel) // UserModel получаем из тела запроса
        //        {
        //            if (userModel != null)
        //            {
        //                // получим User из фронта UserModel
        //                bool result = _usersService.Create(userModel);
        //                return result ? Ok() : NotFound();
        //            }
        //            return BadRequest();
        //        }

        //        User newUser = new User(model.Surname, model.Name, model.Email,
        //model.Password, model.Phone, model.Status, model.Photo);
        //        _db.Users.Add(newUser);
        //                _db.SaveChanges();

    }
}
