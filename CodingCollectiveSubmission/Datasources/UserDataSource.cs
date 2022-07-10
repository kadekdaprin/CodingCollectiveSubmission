using CodingCollectiveSubmission.Models;

namespace CodingCollectiveSubmission.Datasources
{
    public class UserDataSource
    {
        public UserDataSource()
        {
            Users = new List<UserModel>()
            {
                new UserModel(){ Id = 1, Username = "Avengers", Email = "avengers@earth.com", Password = "Assemble616"},
            };
        }

        public List<UserModel> Users { get; private set; }
    }
}
