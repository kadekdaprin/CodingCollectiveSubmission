using CodingCollectiveSubmission.Models;

namespace CodingCollectiveSubmission.Datasources
{
    public class EmployeeDataSource
    {
        public EmployeeDataSource()
        {
            Employees = new List<EmployeeModel>()
            {
                new EmployeeModel(){ Id = 1, Name = "Tony Stark", JobTitle = "CEO",  Salary = 200000000},
                new EmployeeModel(){ Id = 2, Name = "Thor", JobTitle = "Backend Developer",  Salary = 15000000},
                new EmployeeModel(){ Id = 3, Name = "Hawk Eye", JobTitle = "Front End Developer",  Salary = 13000000},
                new EmployeeModel(){ Id = 4, Name = "Black Widow", JobTitle = "System Analyst",  Salary = 16000000},
                new EmployeeModel(){ Id = 5, Name = "Hulk", JobTitle = "Security",  Salary = 10000000},
                new EmployeeModel(){ Id = 6, Name = "Captain America", JobTitle = "Technical Architect",  Salary = 25000000},
            };
        }

        public List<EmployeeModel> Employees { get; private set; }
    }
}
