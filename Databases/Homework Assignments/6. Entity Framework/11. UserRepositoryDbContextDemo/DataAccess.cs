using NorthwindModels;
using System.Linq;
using System.Transactions;

internal static class DataAccess
{
    private static UserRepositoryEntities userRepository;

    public static void Initialize(UserRepositoryEntities userRepositoryContext)
    {
        userRepository = userRepositoryContext;
    }

    public static void InsertNewUser(string groupName, string username, string password, string userFirstName, string userLastName)
    {
        using (TransactionScope scope = new TransactionScope())
        {
            Group group = userRepository.Groups.FirstOrDefault(g => g.GroupName == groupName);

            if (group == null)
            {
                // the group doesn't exist, create it
                group = new Group()
                {
                    GroupName = groupName
                };

                userRepository.Groups.Add(group);
                userRepository.SaveChanges();
            }

            User newUser = new User()
            {
                GroupId = group.GroupId,
                Username = username,
                Password = password,
                UserFirstName = userFirstName,
                UserLastName = userLastName
            };

            userRepository.Users.Add(newUser);

            userRepository.SaveChanges();

            scope.Complete();
        }
    }
}
