using System.ComponentModel.DataAnnotations.Schema;
using WebStaff.CommonModels;

namespace WebStaff.Models
{
    public class Emploee
    {
        public int Id { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public string? ThirdName { get; set; }

        [Column(TypeName = "date")] // Чтобы в базе данных был тип только date без time
        public DateTime BirthDay { get; set; }

        [Column(TypeName = "date")] // Чтобы в базе данных был тип только date без time
        public DateTime EmploymentDate { get; set; }

        public int Salary { get; set; }

        public Emploee() { }

        public Emploee(string sureName, string name, string thirdName,
            DateTime birfday, DateTime employmentDate, int salary)
        {

            SurName = sureName;
            Name = name;
            ThirdName = thirdName;
            BirthDay = birfday;
            EmploymentDate = employmentDate;
            Salary = salary;

        }


        // применим патерн DTO
        public EmploeeModel ToDto()
        {
            return new EmploeeModel()
            {
                Id = this.Id, 
                SurName = this.SurName,
                Name = this.Name,
                ThirdName = this.ThirdName,
                BirthDay = this.BirthDay,
                EmploymentDate = this.EmploymentDate,
                Salary = this.Salary

            };
        }

        //- “Создание/удаление/редактирование сотрудника”

    }
}
