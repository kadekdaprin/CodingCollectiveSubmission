using CodingCollectiveSubmission.Datasources;
using CodingCollectiveSubmission.Helpers;
using CodingCollectiveSubmission.Models;

namespace CodingCollectiveSubmission.Repositories
{
    public class EmployeeRepository
    {
        private readonly List<EmployeeModel> _employees;

        public EmployeeRepository(EmployeeDataSource employeeDataSource)
        {
            _employees = employeeDataSource.Employees;
        }

        public DataTableResponeModel<EmployeeModel> GetEmployees(string search, string orderBy, string orderByType, int start, int pageSize)
        {
            var query = _employees.AsQueryable();

            query = query.ConditionalWhere(() => !string.IsNullOrEmpty(search), employee =>
                employee.Name.Contains(search, StringComparison.OrdinalIgnoreCase)
                || employee.JobTitle.Contains(search, StringComparison.OrdinalIgnoreCase)
                || employee.Salary.ToString().Contains(search, StringComparison.OrdinalIgnoreCase)
            );

            query = query.OrderBy(employee => employee.Name);
            query = query.ConditionalOrderBy(orderByType, () => orderBy == nameof(EmployeeModel.Name), employee => employee.Name);
            query = query.ConditionalOrderBy(orderByType, () => orderBy == nameof(EmployeeModel.JobTitle), employee => employee.JobTitle);
            query = query.ConditionalOrderBy(orderByType, () => orderBy == nameof(EmployeeModel.Salary), employee => employee.Salary);

            var count = query.Count();
            var paged = query.Skip(start).Take(pageSize).ToList();

            var result = new DataTableResponeModel<EmployeeModel>(start, pageSize, _employees.Count, count, paged);

            return result;
        }
    }
}
