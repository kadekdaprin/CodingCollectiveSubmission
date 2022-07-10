using CodingCollectiveSubmission.Datasources;

namespace CodingCollectiveSubmission.Repositories
{
    public class RepositoryWrapper
    {
        private readonly EmployeeDataSource _employeeDataSource;
        private readonly UserDataSource _userDataSource;

        public RepositoryWrapper(EmployeeDataSource employeeDataSource, UserDataSource userDataSource)
        {
            _employeeDataSource = employeeDataSource;
            _userDataSource = userDataSource;
        }

        private EmployeeRepository? employee;

        public EmployeeRepository Employee
        {
            get
            {
                employee ??= new EmployeeRepository(_employeeDataSource);
                return employee;
            }
        }

        private UserRepository? user;

        public UserRepository User
        {
            get
            {
                user ??= new UserRepository(_userDataSource);
                return user;
            }
        }
    }
}
