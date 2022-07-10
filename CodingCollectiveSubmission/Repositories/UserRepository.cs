using CodingCollectiveSubmission.Datasources;
using CodingCollectiveSubmission.Helpers;
using CodingCollectiveSubmission.Models;

namespace CodingCollectiveSubmission.Repositories
{
    public class UserRepository
    {
        private readonly List<UserModel> _users;

        public UserRepository(UserDataSource employeeDataSource)
        {
            _users = employeeDataSource.Users;
        }

        public UserModel? GetUser(LoginModel model)
        {
            return _users.FirstOrDefault(user => user.Email == model.Email && user.Password == model.Password);
        }
    }
}
