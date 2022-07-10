namespace CodingCollectiveSubmission.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public double Salary { get; set; }

    }

    public class EmployeeSearchModel
    {
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public double Salary { get; set; }
    }
}
