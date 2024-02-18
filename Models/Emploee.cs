using System.ComponentModel.DataAnnotations.Schema;

namespace WebStaff.Models
{
    public class Emploee
    {
        public int Id { get; set; }
        public string SureName { get; set; }
        public string Name { get; set; }
        public string? ThirdName { get; set; }

        [Column(TypeName = "date")] // Чтобы в базе данных был тип только date без time
        public DateTime BirthDay { get; set; }

        [Column(TypeName = "date")] // Чтобы в базе данных был тип только date без time
        public DateTime EmploymentDate{ get; set; }

        public int Salary { get; set; }

        public Emploee() { }

        public Emploee(string sureName, string name, string thirdName,
            DateTime birfday, DateTime employmentDate, int salary)
        {
            
            SureName = sureName;
            Name = name;
            ThirdName = thirdName;
            BirthDay = birfday;
            EmploymentDate = employmentDate;
            Salary = salary;

        }

        //- “Создание/удаление/редактирование сотрудника”

    }
}
