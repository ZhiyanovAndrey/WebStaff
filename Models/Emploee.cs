namespace WebStaff.Models
{
    public class Emploee
    {
        public int Id { get; set; }
        public string SureName { get; set; }
        public string Name { get; set; }
        public string ThirdName { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime EmploymentDate{ get; set; }
        public int Salary { get; set; }

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
